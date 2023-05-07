using Flash_Card.Model;

namespace Flash_Card.Service
{
    public interface ICategoryService
    {
        Task<List<CategoryNameDto>> GetAllAsync();
        Task<List<CategoryDto>> GetAllCProducts();
        Task<CategoryDto> GetById(int id);
        Task CreateAsync(CategoryModel model);
        Task Update(int id, CategoryUpdate model);
        Task Delete(int id);
    }
}
