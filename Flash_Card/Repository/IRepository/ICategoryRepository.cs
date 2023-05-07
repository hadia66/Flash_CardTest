using Flash_Card.Entity;

namespace Flash_Card.Repository.IRepository
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Task<List<Category>> GetAllAsync();
        Category Get(int id);
        Category GetFirstOrDefault(int id);

        Task<int> CreateAsync(Category entity);
        int Update(int id, Category model);
        int Delete(int id);
    }
}
