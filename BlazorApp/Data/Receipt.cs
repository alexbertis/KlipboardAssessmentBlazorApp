namespace BlazorApp.Data
{
    public class Receipt
    {
        public required List<TaxedGoodsItem> ItemsPurchased { get; set; }

        public decimal TotalPriceBeforeTax
        {
            get
            {
                return ItemsPurchased.Select(goodsItem => goodsItem.PriceBeforeTax).Sum();
            }
        }

        public decimal TotalTaxApplied
        {
            get
            {
                return ItemsPurchased.Select(goodsItem => goodsItem.TaxAmountApplied).Sum();
            }
        }

        public decimal TotalPriceAfterTax
        {
            get
            {
                return ItemsPurchased.Select(goodsItem => goodsItem.PriceAfterTax).Sum();
            }
        }
    }
}
