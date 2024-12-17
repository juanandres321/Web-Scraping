using Due_Diligence.DTOs;
using Due_Diligence.Models;
using System.Net;
using Web_Scraping.DTOs;
using Web_Scraping.Models;

namespace Due_Diligence.Services
{
    public interface IPersonService
    {
        Task<(Response<bool?>, HttpStatusCode)> LogIn(PersonLoginDTO personLoginDTO);
    }
}
