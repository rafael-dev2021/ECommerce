using Application.Dtos;

namespace Application.Interfaces;

public interface ICategoryDtoService : IGenericCRUDServiceDTO<CategoryDto>
{
    Task<List<CategoryWithProductCountDto>> GetCategoriesWithProductDtoCountAsync();
}
