using ServiceStack.DataAnnotations;

namespace Flash_Card.Entity
{
    public class Category
    {
        [PrimaryKey]
        [AutoIncrement]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public List<Product> Products { get; set; }
    }
}
