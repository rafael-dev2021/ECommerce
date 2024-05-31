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
    private const string Message = "An unexpected error occurred while processing the request.";
    private const string Error = "Error";

    public async Task<IEnumerable<ReviewDto>> GetEntitiesAsync()
    {
        var reviewsDto = await repository.GetEntitiesAsync();

        return !reviewsDto.Any() ? [] : mapper.Map<IEnumerable<ReviewDto>>(reviewsDto);
    }

    public async Task<ReviewDto> GetByIdAsync(int? id)
    {
        ReviewIdNull(id);

        try
        {
            var review = await repository.GetByIdAsync(id) ??
                throw new RequestException(new RequestError
                {
                    Message = $"Review with ID {id} not found.",
                    Severity = Error,
                    StatusCode = System.Net.HttpStatusCode.NotFound
                });

            return mapper.Map<ReviewDto>(review);
        }
        catch (Exception ex)
        {
            throw new ReviewException(Message, ex);
        }
    }

    public async Task AddAsync(ReviewDto entity)
    {
        ReviewNull(entity);

        try
        {
            var review = mapper.Map<Review>(entity) ?? throw new RequestException(new RequestError
            {
                Message = "Error when adding review.",
                Severity = Error,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            });

            await repository.CreateAsync(review);
        }
        catch (Exception ex)
        {
            throw new ReviewException(Message, ex);
        }
    }

    public async Task UpdateAsync(ReviewDto entity)
    {
        ReviewNull(entity);

        try
        {
            var review = mapper.Map<Review>(entity) ?? throw new RequestException(new RequestError
            {
                Message = "Error when updating review.",
                Severity = Error,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            });

            await repository.UpdateAsync(review);
        }
        catch (Exception ex)
        {
            throw new ReviewException(Message, ex);
        }
    }

    public async Task DeleteAsync(int? id)
    {
        ReviewIdNull(id);

        try
        {
            var review = await repository.GetByIdAsync(id) ?? throw new RequestException(new RequestError
            {
                Message = "Error when removing review.",
                Severity = Error,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            });

            await repository.DeleteAsync(review);
        }
        catch (Exception ex)
        {
            throw new ReviewException(Message, ex);
        }
    }

    public static void ReviewIdNull(int? id)
    {
        if (!id.HasValue)
            throw new ArgumentNullException(nameof(id), "Review ID cannot be null.");
    }

    public static void ReviewNull(ReviewDto? reviewDto)
    {
        if (reviewDto == null)
            throw new ArgumentNullException(nameof(reviewDto), "Review cannot be null.");
    }
}