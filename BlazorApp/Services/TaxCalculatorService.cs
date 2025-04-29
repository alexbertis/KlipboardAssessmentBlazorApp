using BlazorApp.Data;

namespace BlazorApp.Services
{
    public class TaxCalculatorService(IConfigurationService configurationService)
    {

        private static readonly ItemType[] ExemptGoods = { ItemType.Book, ItemType.ChocolateBar, ItemType.ChocolateBox, ItemType.Paracetamol };

        public decimal CalculateTaxAmount(GoodsItem item)
        {
            ArgumentNullException.ThrowIfNull(item);
            if (item.ImportStatus == ImportStatus.Unknown)
            {
                throw new ArgumentException("The import status of the provided item is not known");
            }

            decimal amount = 0;
            // If the item is not exempt, apply the basic tax to it
            if (!ExemptGoods.Contains(item.Type))
            {
                amount += ApplyTaxRate(item, configurationService.GetBasicTaxRate());
            }

            // If the item is imported, apply the import tax to it (on top of the basic tax)
            if (item.ImportStatus == ImportStatus.Imported)
            {
                amount += ApplyTaxRate(item, configurationService.GetImportedTaxRate());
            }

            return amount;
        }

        public decimal ApplyTaxRate(GoodsItem item, decimal taxRate)
        {
            decimal d = taxRate * item.PriceBeforeTax;
            decimal remainderToClosest = d % 0.05M;
            return Math.Round(
                (remainderToClosest < 0.025M) ? (d - remainderToClosest) : (d + 0.05M - remainderToClosest), 
                2, 
                MidpointRounding.AwayFromZero);
        }

        public TaxedGoodsItem ConvertToTaxedItem(GoodsItem item)
        {
            var taxedItem = new TaxedGoodsItem()
            {
                Type = item.Type,
                ImportStatus = item.ImportStatus,
                PriceBeforeTax = item.PriceBeforeTax
            };
            taxedItem.TaxAmountApplied = CalculateTaxAmount(item);

            return taxedItem;
        }
    }
}
