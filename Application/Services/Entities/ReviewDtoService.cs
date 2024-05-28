using Application.CustomExceptions;
using Application.Dtos.Reviews;
using Application.Errors;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.Reviews;
using Domain.Interfaces;

namespace Application.Services.Entities;

public class ReviewDtoService(IReviewRepository repository, IMapper mapper) : IReviewDtoService
{
    private readonly IReviewRepository _repository = repository;
    private readonly IMapper _mapper = mapper;
    private readonly string _message = "An unexpected error occurred while processing the request.";


    public async Task<IEnumerable<ReviewDto>> GetEntitiesAsync()
    {
        var reviewsDto = await _repository.GetEntitiesAsync();

        if (reviewsDto == null || !reviewsDto.Any()) return [];

        return _mapper.Map<IEnumerable<ReviewDto>>(reviewsDto);
    }

    public async Task<ReviewDto> GetByIdAsync(int? id)
    {
        ReviewIdNull(id);

        try
        {
            var review = await _repository.GetByIdAsync(id) ??
                throw new RequestException(new RequestError
                {
                    Message = $"Review with ID {id} not found.",
                    Severity = "Error",
                    StatusCode = System.Net.HttpStatusCode.NotFound
                });

            return _mapper.Map<ReviewDto>(review);
        }
        catch (Exception ex)
        {
            throw new ReviewException(_message, ex);
        }
    }

    public async Task AddAsync(ReviewDto entity)
    {
        ReviewNull(entity);

        try
        {
            var review = _mapper.Map<Review>(entity) ?? throw new RequestException(new RequestError
            {
                Message = "Error when adding review.",
                Severity = "Error",
                StatusCode = System.Net.HttpStatusCode.BadRequest
            });

            await _repository.CreateAsync(review);
        }
        catch (Exception ex)
        {
            throw new ReviewException(_message, ex);
        }
    }

    public async Task UpdateAsync(ReviewDto entity)
    {
        ReviewNull(entity);

        try
        {
            var review = _mapper.Map<Review>(entity) ?? throw new RequestException(new RequestError
            {
                Message = "Error when updating review.",
                Severity = "Error",
                StatusCode = System.Net.HttpStatusCode.BadRequest
            });

            await _repository.UpdateAsync(review);
        }
        catch (Exception ex)
        {
            throw new ReviewException(_message, ex);
        }
    }

    public async Task DeleteAsync(int? id)
    {
        ReviewIdNull(id);

        try
        {
            var review = await _repository.GetByIdAsync(id) ?? throw new RequestException(new RequestError
            {
                Message = "Error when removing review.",
                Severity = "Error",
                StatusCode = System.Net.HttpStatusCode.BadRequest
            });

            await _repository.DeleteAsync(review);
        }
        catch (Exception ex)
        {
            throw new ReviewException(_message, ex);
        }
    }

    private static void ReviewIdNull(int? id)
    {
        if (!id.HasValue)
            throw new ArgumentNullException(nameof(id), "Review ID cannot be null.");
    }

    private static void ReviewNull(ReviewDto reviewDto)
    {
        if (reviewDto == null)
            throw new ArgumentNullException(nameof(reviewDto), "Review cannot be null.");
    }
}