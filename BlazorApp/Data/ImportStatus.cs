using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Data
{
    public enum ImportStatus
    {
        [Display(Name = "Please select whether the item was imported or not")]
        Unknown,
        [Display(Name = "Not Imported")]
        NotImported,
        [Display(Name = "Imported")]
        Imported
    }
}
