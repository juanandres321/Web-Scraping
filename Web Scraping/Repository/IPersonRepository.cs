using Due_Diligence.Models;
using Web_Scraping.Models;

namespace Due_Diligence.Repository
{
    public interface IPersonRepository
    {
        Task<bool?> LogIn(Person person);
    }
}
