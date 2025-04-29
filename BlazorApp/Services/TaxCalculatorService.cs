using BlazorApp.Data;

namespace BlazorApp.Services
{
    public class TaxCalculatorService(IConfigurationService configurationService)
    {

        private static readonly ItemType[] ExemptGoods = { ItemType.Book, ItemType.ChocolateBar, ItemType.ChocolateBox, ItemType.Paracetamol };

        public decimal CalculateTaxRate(GoodsItem item)
        {
            ArgumentNullException.ThrowIfNull(item);
            if (item.ImportStatus == ImportStatus.Unknown)
            {
                throw new ArgumentException("The import status of the provided item is not known");
            }

            decimal rate = 0;
            // If the item is not exempt, apply the basic tax to it
            if (!ExemptGoods.Contains(item.Type))
            {
                rate += configurationService.GetBasicTaxRate();
            }

            // If the item is imported, apply the import tax to it (on top of the basic tax)
            if (item.ImportStatus == ImportStatus.Imported)
            {
                rate += configurationService.GetImportedTaxRate();
            }

            return rate;
        }

        public TaxedGoodsItem ConvertToTaxedItem(GoodsItem item)
        {
            var taxedItem = new TaxedGoodsItem()
            {
                Type = item.Type,
                ImportStatus = item.ImportStatus,
                PriceBeforeTax = item.PriceBeforeTax
            };
            taxedItem.TaxRateApplied = CalculateTaxRate(item);

            return taxedItem;
        }
    }
}
