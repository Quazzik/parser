using System.ComponentModel.DataAnnotations;

namespace parser.Models.Entities
{
    public class Shop
    {
        [Key]
        public int ID { get; set; }
        public string Url { get; set; }
        public string ShopName { get; set; }
    }
}
