using Flash_Card.Model;

namespace Flash_Card.Service
{
    public interface IProductservice
    {
        Task<List<ProductDto>> GetAllAsync();
        Task<ProductDto> GetById(int id);
        Task CreateAsync(ProductModel model);
        Task Update(int id, ProductUpdate model);
        Task Delete(int id);
    }
}
