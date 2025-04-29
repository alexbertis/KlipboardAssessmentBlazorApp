namespace BlazorApp.Services
{
    public class ConfigurationService(IConfiguration configuration) : IConfigurationService
    {
        public decimal GetBasicTaxRate() => configuration.GetValue<decimal>("SalesTax:Basic");
        public decimal GetImportedTaxRate() => configuration.GetValue<decimal>("SalesTax:Imported");
    }
}
