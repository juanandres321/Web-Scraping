using Due_Diligence.Models;
using Microsoft.EntityFrameworkCore;
using Web_Scraping.Models;

namespace Due_Diligence.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly Context _context;
        public PersonRepository(Context context)
        {
            _context = context;
        }
        public async Task<bool?> LogIn(Person person)
        {
            Person? per = await _context.People.Where(I => (I.UserName == person.UserName && I.Password == person.Password)).FirstOrDefaultAsync();
            if (per == null)
                return false;
            return true;
        }
    }
}
