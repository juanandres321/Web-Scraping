using Web_Scraping.Models;

namespace Due_Diligence.Models
{
    public class Seeder
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<Context>();
                if (!context.People.Any())
                {
                    context.People.AddRange(
                    new Person { Password = "123", UserName = "Admin" });
                    context.SaveChanges();
                }
                if (!context.Suppliers.Any())
                {
                    context.Suppliers.AddRange(
                    new Supplier
                    {
                        CompanyName = "TechSolutions Ltda.",
                        TradeName = "TechSolutions",
                        TaxIdentification = 12345678,
                        TelephoneNumber = 987654321,
                        EMail = "contact@techsolutions.com",
                        WebPage = "www.techsolutions.com",
                        Adress = "Calle Principal 123",
                        Country = "Perú",
                        AnnualTurnover = 500000,
                        LastEdition = DateTime.Now
                    },
                    new Supplier
                    {
                        CompanyName = "Global Supplies SA",
                        TradeName = "Global Supplies",
                        TaxIdentification = 87654321,
                        TelephoneNumber = 123456789,
                        EMail = "info@globalsupplies.com",
                        WebPage = "www.globalsupplies.com",
                        Adress = "Avenida de la Industria 456",
                        Country = "México",
                        AnnualTurnover = 1000000,
                        LastEdition = DateTime.Now.AddYears(-1)
                    },
                    new Supplier
                    {
                        CompanyName = "Innovatech Inc.",
                        TradeName = "Innovatech",
                        TaxIdentification = 19283746,
                        TelephoneNumber = 654321987,
                        EMail = "support@innovatech.com",
                        WebPage = "www.innovatech.com",
                        Adress = "Pasaje del Sol 789",
                        Country = "Colombia",
                        AnnualTurnover = 750000,
                        LastEdition = DateTime.Now.AddMonths(-6)
                    },
                    new Supplier
                    {
                        CompanyName = "EcoTech Group",
                        TradeName = "EcoTech",
                        TaxIdentification = 25896314,
                        TelephoneNumber = 321654987,
                        EMail = "sales@ecotech.com",
                        WebPage = "www.ecotech.com",
                        Adress = "Ruta Verde 321",
                        Country = "Argentina",
                        AnnualTurnover = 200000,
                        LastEdition = DateTime.Now.AddDays(-10)
                    },
                    new Supplier
                    {
                        CompanyName = "Prime Resources Ltd.",
                        TradeName = "Prime Resources",
                        TaxIdentification = 14725836,
                        TelephoneNumber = 963258741,
                        EMail = "info@primeresources.com",
                        WebPage = "www.primeresources.com",
                        Adress = "Jardín del Norte 654",
                        Country = "Chile",
                        AnnualTurnover = 1200000,
                        LastEdition = DateTime.Now.AddMonths(-3)
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
