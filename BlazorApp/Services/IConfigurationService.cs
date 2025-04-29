namespace BlazorApp.Services
{
    public interface IConfigurationService
    {
        decimal GetBasicTaxRate();
        decimal GetImportedTaxRate();
    }
}