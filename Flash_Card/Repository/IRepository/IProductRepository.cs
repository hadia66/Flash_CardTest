using Flash_Card.Entity;

namespace Flash_Card.Repository.IRepository
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Task<List<Product>> GetAllAsync();
        Product Get(int id);
        List<Product> GetFirstOrDefault(int id);

        Task<int> CreateAsync(Product entity);
        int Update(int id, Product model);
        int Delete(int id);
    }
}
