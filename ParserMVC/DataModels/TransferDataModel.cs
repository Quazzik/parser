using parser.Models.Entities;

namespace ParserMVC.DataModels
{
    public class TransferDataModel
    {
        public Product RowProduct { get; set; }
        public string ShopName { get; set; }
        public string CategoryName { get; set; }
    }
}
