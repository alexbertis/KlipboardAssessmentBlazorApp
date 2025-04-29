using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Data
{
    public enum ItemType
    {
        [Display(Name = "Please select an item")]
        Unknown,
        [Display(Name = "Book")]
        Book,
        [Display(Name = "Music CD")]
        MusicCD,
        [Display(Name = "Chocolate Bar")]
        ChocolateBar,
        [Display(Name = "Chocolate Box")]
        ChocolateBox,
        [Display(Name = "Bottle of Perfume")]
        BottleOfPerfume,
        [Display(Name = "Paracetamol")]
        Paracetamol,
    }
}