namespace BlazorApp.Data
{
    public class GoodsItem
    {
        public ItemType Type { get; set; }

        public ImportStatus ImportStatus { get; set; }

        public decimal PriceBeforeTax { get; set; }

    }
}
