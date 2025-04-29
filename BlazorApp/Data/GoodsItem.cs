using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Data
{
    public class GoodsItem
    {
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid item type.")]
        public ItemType Type { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select whether the item was imported or not.")]
        public ImportStatus ImportStatus { get; set; }

        public decimal PriceBeforeTax { get; set; }

    }
}
