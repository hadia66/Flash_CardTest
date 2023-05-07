using ServiceStack.DataAnnotations;

namespace Flash_Card.Entity
{
    public class Product
    {
        [PrimaryKey]
        [AutoIncrement]
        public int ProductId { get; set; }

        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime StartDate { get; set; }

        public string Duration { get; set; }
        public decimal Price { get; set; }

        //[ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public CustomField CustomField { get; set; }

    }
}
