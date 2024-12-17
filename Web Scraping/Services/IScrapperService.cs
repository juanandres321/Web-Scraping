using Web_Scraping.Models;

namespace Web_Scraping.Services
{
    public interface IScrapperService
    {
        Task<CompanyContainer> RunScrapping(string? company);
    }
}
