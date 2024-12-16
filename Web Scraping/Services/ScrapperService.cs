using System.Net.Http;
using Web_Scraping.Models;
using System.Globalization;
using Microsoft.Playwright;

namespace Web_Scraping.Services
{
    public class ScrapperService : IScrapperService
    {
        public async Task<(int, List<Company>)> RunScrapping(string? searchcompany)
        {
            int hits = 0;
            List<Company> companies = new();

            string url = "https://projects.worldbank.org/en/projects-operations/procurement/debarred-firms";

            // Iniciar Playwright
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                ExecutablePath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe",
                Headless = true
            });
            var page = await browser.NewPageAsync();

            try
            {
                // Navegar a la página
                await page.GotoAsync(url);

                //Filtrar
                if(searchcompany!= null)
                {
                    await page.WaitForSelectorAsync("#category");
                    await page.FillAsync("#category", searchcompany);
                    await page.PressAsync("#category", "Enter");
                    await page.WaitForTimeoutAsync(2000);
                }

                // Esperar a que la tabla esté visible (asegura que la página cargue dinámicamente)
                await page.WaitForSelectorAsync("//div[@class='k-grid-content k-auto-scrollable']/table/tbody");

                // Seleccionar todas las filas de la tabla
                var rows = await page.QuerySelectorAllAsync("//div[@class='k-grid-content k-auto-scrollable']/table/tbody/tr");

                foreach (var row in rows)
                {
                    // Obtener todas las celdas (td) dentro de cada fila
                    var cells = await row.QuerySelectorAllAsync("td");

                    if (cells != null && cells.Count >= 7) // Asegurar que hay suficientes celdas
                    {
                        // Usar await antes de Trim()
                        var fromDateText = (await cells[4].InnerTextAsync()).Trim();
                        var toDateText = (await cells[5].InnerTextAsync()).Trim();

                        // Intentar parsear las fechas
                        DateTime? fromDate = DateTime.TryParseExact(fromDateText, "dd-MMM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedFromDate) ? parsedFromDate : null;
                        DateTime? toDate = DateTime.TryParseExact(toDateText, "dd-MMM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedToDate) ? parsedToDate : null;

                        // Crear y agregar la instancia de Company
                        var company = new Company
                        {
                            FirmName = (await cells[0].InnerTextAsync()).Trim(),
                            Address = (await cells[2].InnerTextAsync()).Trim(),
                            Country = (await cells[3].InnerTextAsync()).Trim(),
                            FromDate = fromDate,
                            ToDate = toDate,
                            Grounds = (await cells[6].InnerTextAsync()).Trim()
                        };

                        companies.Add(company);
                        hits++;
                        if (hits > 3)
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                await browser.CloseAsync();
            }

            return (hits, companies);
        }
    }
}
