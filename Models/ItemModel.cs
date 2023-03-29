namespace SilvershotCore.Models
{
    public class ItemModel
    {
        public int ItemID { get; set; }
        public string? ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal? ItemPrice { get; set; }
        public string? ItemDetails { get; set; }
    }
}