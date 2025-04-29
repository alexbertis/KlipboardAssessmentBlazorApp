namespace BlazorApp.Data
{
    public class TaxedGoodsItem : GoodsItem
    {
        public decimal TaxRateApplied { get; set; }

        public decimal TaxAmountApplied { 
            get
            {
                decimal d = Math.Round(TaxRateApplied * PriceBeforeTax, 2, MidpointRounding.AwayFromZero);
                decimal remainderToClosest = d % 0.05M;
                return (remainderToClosest < 0.03M) ? (d - remainderToClosest) : (d + 0.05M - remainderToClosest);
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
