using Application.CustomExceptions;
using Application.Dtos;
using Application.Errors;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services.Entities;

public class CategoryDtoService(IMapper mapper, ICategoryRepository categoryRepository) : ICategoryDtoService
{
    private readonly IMapper _mapper = mapper;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private const string Message = "An unexpected error occurred while processing the request.";
    private const string Error = "Error";

    public async Task<IEnumerable<CategoryDto>> GetEntitiesAsync()
    {
        var categoriesDto = await _categoryRepository.GetEntitiesAsync();
        return !categoriesDto.Any() ? [] : _mapper.Map<IEnumerable<CategoryDto>>(categoriesDto);
    }

    public async Task<CategoryDto> GetByIdAsync(int? id)
    {
        CategoryIdNull(id);

        try
        {
            var getCategoryId = await _categoryRepository.GetByIdAsync(id) ??
                throw new RequestException(new RequestError
                {
                    Message = $"Category with ID {id} not found.",
                    Severity = Error,
                    Response = true,
                    StatusCode = System.Net.HttpStatusCode.NotFound
                });
            return _mapper.Map<CategoryDto>(getCategoryId);
        }
        catch (Exception ex)
        {
            throw new CategoryException(Message, ex);
        }
    }

    public async Task AddAsync(CategoryDto? entity)
    {
        CategoryNull(entity);

        try
        {
            var addCategoryDto = _mapper.Map<Category>(entity) ??
                throw new RequestException(new RequestError
                {
                    Message = "Error when adding category.",
                    Severity = Error,
                    Response = true,
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                });
            await _categoryRepository.CreateAsync(addCategoryDto);
        }
        catch (Exception ex)
        {
            throw new CategoryException(Message, ex);
        }
    }

    public async Task UpdateAsync(CategoryDto? entity)
    {
        CategoryNull(entity);

        try
        {
            var updateCategory = _mapper.Map<Category>(entity) ??
                throw new RequestException(new RequestError
                {
                    Message = $"Error when updating the category",
                    Severity = Error,
                    Response = true,
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                });
            await _categoryRepository.UpdateAsync(updateCategory);
        }
        catch (Exception ex)
        {
            throw new CategoryException(Message, ex);
        }
    }

    public async Task DeleteAsync(int? id)
    {
        CategoryIdNull(id);

        try
        {
            var deleteCategory = await _categoryRepository.GetByIdAsync(id) ??
                throw new RequestException(new RequestError
                {
                    Message = "Error when removing category.",
                    Severity = Error,
                    Response = true,
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                });
            await _categoryRepository.DeleteAsync(deleteCategory);
        }
        catch (Exception ex)
        {
            throw new CategoryException(Message, ex);
        }
    }

    public async Task<List<CategoryWithProductCountDto>> GetCategoriesWithProductDtoCountAsync()
    {
        var categoriesWithProductCount = await _categoryRepository.GetCategoriesWithProductCountAsync();

        return categoriesWithProductCount.Count == 0 ? [] : 
            _mapper.Map<List<CategoryWithProductCountDto>>(categoriesWithProductCount);
    }

    public static void CategoryIdNull(int? id)
    {
        if (!id.HasValue)
            throw new ArgumentNullException(nameof(id), "Category ID cannot be null.");
    }

    public static void CategoryNull(CategoryDto? categoryDto)
    {
        if (categoryDto == null)
            throw new ArgumentNullException($"Category {categoryDto} cannot be null.");
    }
}
