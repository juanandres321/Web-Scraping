using Due_Diligence.DTOs;
using Due_Diligence.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Scraping.DTOs;

namespace Due_Diligence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService) {
            _personService = personService;
        }
        [HttpPost("LogIn")]
        public async Task<ActionResult<List<SupplierDTO>>> LogIn(PersonLoginDTO personLoginDTO)
        {
            var (response, statusCode) = await _personService.LogIn(personLoginDTO);
            return StatusCode((int)statusCode, response);
        }
    }
}
