using parser.Models.Entities;

namespace ParserMVC.DataModels
{
    public class PageData
    {
        public List<TransferDataModel> RowData { get; set; }
        public List<Category> Categories { get; set; }
        public List<Shop> Shops { get; set; }
    }
}
