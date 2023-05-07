using System.ComponentModel.DataAnnotations;

namespace Flash_Card.Model
{
    public class ProductModel
    {
        [RequiredAttribute]
        public int CategoryId { get; set; }

        [RequiredAttribute]
        public string ProductName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime StartDate { get; set; }

        public string? Duration { get; set; }
        public decimal Price { get; set; }
    }
    public class ProductDto
    {
        public int ProductId { get; set; }

        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime StartDate { get; set; }

        public string Duration { get; set; }
        public decimal Price { get; set; }
    }
    public class ProductUpdate 
    {



  
        public string? ProductName { get; set; }
 
        public string? Duration { get; set; }
        public decimal? Price { get; set; }


    }
}
