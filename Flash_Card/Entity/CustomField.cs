using ServiceStack.DataAnnotations;

namespace Flash_Card.Entity
{
    public class CustomField
    {
        [PrimaryKey]
        [AutoIncrement]
        public int CustomId { get; set; }
        public int ProductId { get; set; }
        public string Custom_Title { get; set; }
        public string Custom_Key { get; set; }
        public Product Product { get; set; }

    }
}
