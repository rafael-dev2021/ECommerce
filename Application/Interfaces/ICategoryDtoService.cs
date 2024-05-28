using Application.Dtos;

namespace Application.Interfaces;

public interface ICategoryDtoService : IGenericCrudServiceDto<CategoryDto>
{
    Task<List<CategoryWithProductCountDto>> GetCategoriesWithProductDtoCountAsync();
}
