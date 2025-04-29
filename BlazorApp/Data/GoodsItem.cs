namespace BlazorApp.Data
{
    public class GoodsItem
    {

        public required string Name { get; set; }

        public ImportStatus ImportStatus { get; set; }

        public decimal PriceBeforeTax { get; set; }

    }
}
