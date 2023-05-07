using Flash_Card.Entity;
using Flash_Card.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Flash_Card.Repository
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<Category> GetAll()
        {

            return _db.Categories.Include(x=>x.Products).ToList();

        }
        public async Task<List<Category>> GetAllAsync()
        {

            return await _db.Categories.ToListAsync();

        }
        public Category Get(int id)
        {
            return _db.Categories.Find(id);

        }

        public Category GetFirstOrDefault(int id)
        {
            return _db.Categories.FirstOrDefault(x => x.CategoryId == id);

        }
       
        public async Task<int> CreateAsync(Category entity)
        {
            _db.Categories.Add(entity);
            return await _db.SaveChangesAsync();

        }
        public int Update(int id, Category model)
        {

            var dbEntity = Get(id);
            if (dbEntity == null) { return -1; }
            dbEntity.CategoryName = model.CategoryName;
            dbEntity.CategoryDescription = model.CategoryDescription;
            return _db.SaveChanges();
        }
        public int Delete(int id)
        {
            var dbEntity = Get(id);
            if (dbEntity == null) { return -1; }
            _db.Categories.Remove(dbEntity);
            return _db.SaveChanges();

        }
    }
}
