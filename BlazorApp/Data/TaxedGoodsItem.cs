namespace BlazorApp.Data
{
    public class TaxedGoodsItem : GoodsItem
    {
        public decimal TaxRateApplied { get; set; }

        public decimal TaxAmountApplied { 
            get
            {
                return Math.Round(TaxRateApplied * PriceBeforeTax, 2, MidpointRounding.AwayFromZero);
            }
        }

        public decimal PriceAfterTax
        {
            get
            {
                return PriceBeforeTax + TaxAmountApplied;
            }
        }

    }
}
