using Web_Scraping.Models;

namespace Web_Scraping.Services
{
    public interface ICompaniesService
    {
        Task<(int, List<Company>)> RunScrapping();
    }
}
