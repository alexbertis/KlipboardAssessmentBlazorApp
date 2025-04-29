namespace BlazorApp.Data
{
    public class TaxedGoodsItem : GoodsItem
    {
        public decimal TaxAmountApplied { get; set; }

        public decimal PriceAfterTax
        {
            get
            {
                return PriceBeforeTax + TaxAmountApplied;
            }
        }

    }
}
