using Web_Scraping.Models;

namespace Web_Scraping.Services
{
    public interface IScrapperService
    {
        Task<(int, List<Company>)> RunScrapping(string? company);
    }
}
