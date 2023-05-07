using Flash_Card.Entity;
using Flash_Card.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Flash_Card.Repository
{
    public class ProductRepository: IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<Product> GetAll()
        {

            return _db.Products.ToList();

        }
        public async Task<List<Product>> GetAllAsync()
        {

            return await _db.Products.ToListAsync();

        }
        public Product Get(int id)
        {
            return _db.Products.Find(id);

        }

        //public Product GetFirstOrDefault(int id)
        //{
        //    return _db.Products.FirstOrDefault(x => x.ProductId == id);

        //}
        public List<Product> GetFirstOrDefault(int id)
        {
            return _db.Products.Where(x => x.CategoryId == id).ToList();

        }

        public async Task<int> CreateAsync(Product entity)
        {
            _db.Products.Add(entity);
            return await _db.SaveChangesAsync();

        }
        public int Update(int id, Product model)
        {

            var dbEntity = Get(id);
            if (dbEntity == null) { return -1; }
            dbEntity.ProductName = model.ProductName;
            dbEntity.Duration = model.Duration;
            dbEntity.Price = model.Price;
            return _db.SaveChanges();
        }
        public int Delete(int id)
        {
            var dbEntity = Get(id);
            if (dbEntity == null) { return -1; }
            _db.Products.Remove(dbEntity);
            return _db.SaveChanges();

        }

    }

   
}
