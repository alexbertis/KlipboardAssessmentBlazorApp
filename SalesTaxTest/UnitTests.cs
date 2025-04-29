using BlazorApp.Data;
using BlazorApp.Services;
using Moq;

namespace SalesTaxTest
{
    public class UnitTests
    {
        [Fact]
        public void Test_IfGoodIsImported_ApplyImportRate()
        {
            Mock<IConfigurationService> configService = SetupConfig();
            var taxCalculator = new TaxCalculatorService(configService.Object);
            
            var item = new GoodsItem() { Type = ItemType.Book, ImportStatus = ImportStatus.Imported };
            Assert.Equal(taxCalculator.CalculateTaxRate(item), configService.Object.GetImportedTaxRate());
        }

        private static Mock<IConfigurationService> SetupConfig()
        {
            var configService = new Mock<IConfigurationService>();
            configService.Setup(svc => svc.GetImportedTaxRate()).Returns(0.05M);
            configService.Setup(svc => svc.GetBasicTaxRate()).Returns(0.1M);
            return configService;
        }
    }
}