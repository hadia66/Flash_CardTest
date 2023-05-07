using Flash_Card.Entity;
using System.ComponentModel.DataAnnotations;

namespace Flash_Card.Model
{
    public class CategoryModel
    {
        [RequiredAttribute]
        public string CategoryName { get; set; }
        [RequiredAttribute]
        public string CategoryDescription { get; set; }
    }
    public class CategoryUpdate
    {

        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
    }
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public List<ProductDto> Products { get; set; }
    }
    public class CategoryNameDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

    }

}
