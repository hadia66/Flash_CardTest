using Flash_Card.Entity;
using Flash_Card.Model;
using Flash_Card.Repository.IRepository;

namespace Flash_Card.Service
{
    public class CategoryService:ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public CategoryService(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }
        public async Task<List<CategoryNameDto>> GetAllAsync()
        {

            var Categories = await _categoryRepository.GetAllAsync();
            if (Categories == null)
                throw new Exception("No items Found");

            var categories = new List<CategoryNameDto>();

            foreach (var category in Categories)
            {
                var cat = new CategoryNameDto()
                {
                    CategoryId = category.CategoryId,

                    CategoryName = category.CategoryName,

                    CategoryDescription = category.CategoryDescription,
                };

                categories.Add(cat);
            }


            return categories;


        }
        public async Task<List<CategoryDto>> GetAllCProducts()
        {

            var Categories = _categoryRepository.GetAll();
           
            if (Categories == null)
                throw new Exception("No items Found");

            var categories = new List<CategoryDto>();
          
            foreach (var category in Categories)
            {
                var Products=_productRepository.GetFirstOrDefault(category.CategoryId);
                var products = new List<ProductDto>();
                var cat = new CategoryDto()
                {
                    CategoryId = category.CategoryId,

                    CategoryName = category.CategoryName,

                    CategoryDescription = category.CategoryDescription,
                };
                foreach (var product in Products) 
                {
                    var pro = new ProductDto()
                    {
                        CategoryId = product.CategoryId,
                        CreationDate = product.CreationDate,
                        ProductName = product.ProductName,
                        Duration=product.Duration,
                        Price = product.Price,
                        ProductId = product.ProductId,
                        StartDate=product.StartDate,

                    };
                   products.Add(pro);
                 
                }

                cat.Products = products;
                categories.Add(cat);
            }
           



            return categories;


        }
        public async Task<CategoryDto> GetById(int id)
        {
            var item = _categoryRepository.Get(id);
            if (item == null)
                throw new Exception("No item Found");
            var cat = new CategoryDto()
            {
             CategoryId=item.CategoryId,
             CategoryDescription=item.CategoryDescription,
             CategoryName=item.CategoryName,
             
            };

            return cat;

        }

        public async Task CreateAsync(CategoryModel model)
        {

            var cat = new Category()
            {
                CategoryName = model.CategoryName,
                CategoryDescription = model.CategoryDescription,
            };

            var newId = await _categoryRepository.CreateAsync(cat);
            if (newId <= 0)
                throw new Exception("An Error Occured While Adding Category");


        }

        public async Task Update(int id, CategoryUpdate model)
        {
            var category = _categoryRepository.Get(id);
            if (category == null)
                throw new Exception("Not Found");

            category.CategoryDescription = model.CategoryDescription;
            category.CategoryName = model.CategoryName;


        }
        public async Task Delete(int id)
        {

            var Result = _categoryRepository.Delete(id);
            if (Result == -1) throw new Exception("Not Found");


        }
    }
}
