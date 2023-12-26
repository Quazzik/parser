using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parser.Models.Entities
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public uint Price { get; set; }
        public int CategoryID { get; set; }
        [ForeignKey (nameof(CategoryID))]
        public Category Category { get; set; }
        public int ShopID { get; set; }
        [ForeignKey (nameof(ShopID))]
        public Shop Shop { get; set; }
        public string Url { get; set; }
    }
}
