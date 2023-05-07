using Flash_Card.Entity;
using Flash_Card.Model;
using Flash_Card.Repository.IRepository;

namespace Flash_Card.Service
{
    public class ProductService:IProductservice
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;


        }
        public async Task<List<ProductDto>> GetAllAsync()
        {

            var products = await _productRepository.GetAllAsync();
            if (products == null)
                throw new Exception("No item Found");

            var listProducts = new List<ProductDto>();

            foreach (var item in products)
            {
                var pro = new ProductDto()
                {
                    CategoryId = item.CategoryId,

                    ProductId = item.ProductId,

                    CreationDate = item.CreationDate,
                    StartDate = item.StartDate, 
                    Price = item.Price,
                    Duration = item.Duration,
                     ProductName = item.ProductName,
                };

                listProducts.Add(pro);
            }

            return listProducts;


        }
        public async Task<ProductDto> GetById(int id) 
        {
            var item =  _productRepository.Get(id);
            if (item == null)
                throw new Exception("No item Found");
            var pro=new ProductDto() 
            {
              CategoryId=item.CategoryId,
              ProductName=item.ProductName,
              CreationDate=item.CreationDate,
              Duration = item.Duration,
              Price = item.Price,
              ProductId = item.ProductId,
              StartDate=item.StartDate, 
               
            
            
            };

            return pro;

        }

        public async Task CreateAsync(ProductModel model)
        {

            var pro = new Product()
            {
                CategoryId=model.CategoryId,    
                ProductName = model.ProductName,
                Duration =model.Duration,
                StartDate = model.StartDate,
                Price=model.Price,
                CreationDate=model.CreationDate,
                
            };

            var newId = await _productRepository.CreateAsync(pro);
            if (newId <= 0)
                throw new Exception("An Error Occured While Adding Category");


        }

        public async Task Update(int id, ProductUpdate model)
        {
            var product = _productRepository.Get(id);
            if (product == null)
                throw new Exception("Not Found");

            product.Duration = model.Duration;
            product.Price =(decimal) model.Price;
            product.ProductName = model.ProductName;

        }
        public async Task Delete(int id)
        {

            var Result = _productRepository.Delete(id);
            if (Result == -1) throw new Exception("Not Found");


        }
    }
}
