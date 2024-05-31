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
    private const string Message = "An unexpected error occurred while processing the request.";
    private const string Error = "Error";

    public async Task<IEnumerable<CategoryDto>> GetEntitiesAsync()
    {
        var categoriesDto = await categoryRepository.GetEntitiesAsync();
        return !categoriesDto.Any() ? [] : mapper.Map<IEnumerable<CategoryDto>>(categoriesDto);
    }

    public async Task<CategoryDto> GetByIdAsync(int? id)
    {
        CategoryIdNull(id);

        try
        {
            var getCategoryId = await categoryRepository.GetByIdAsync(id) ??
                throw new RequestException(new RequestError
                {
                    Message = $"Category with ID {id} not found.",
                    Severity = Error,
                    Response = true,
                    StatusCode = System.Net.HttpStatusCode.NotFound
                });
            return mapper.Map<CategoryDto>(getCategoryId);
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
            var addCategoryDto = mapper.Map<Category>(entity) ??
                throw new RequestException(new RequestError
                {
                    Message = "Error when adding category.",
                    Severity = Error,
                    Response = true,
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                });
            await categoryRepository.CreateAsync(addCategoryDto);
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
            var updateCategory = mapper.Map<Category>(entity) ??
                throw new RequestException(new RequestError
                {
                    Message = $"Error when updating the category",
                    Severity = Error,
                    Response = true,
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                });
            await categoryRepository.UpdateAsync(updateCategory);
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
            var deleteCategory = await categoryRepository.GetByIdAsync(id) ??
                throw new RequestException(new RequestError
                {
                    Message = "Error when removing category.",
                    Severity = Error,
                    Response = true,
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                });
            await categoryRepository.DeleteAsync(deleteCategory);
        }
        catch (Exception ex)
        {
            throw new CategoryException(Message, ex);
        }
    }

    public async Task<List<CategoryWithProductCountDto>> GetCategoriesWithProductDtoCountAsync()
    {
        var categoriesWithProductCount = await categoryRepository.GetCategoriesWithProductCountAsync();

        return categoriesWithProductCount.Count == 0 ? [] : 
            mapper.Map<List<CategoryWithProductCountDto>>(categoriesWithProductCount);
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
