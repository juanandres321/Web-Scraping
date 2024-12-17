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
        /// <summary>
        /// Constructor de la clase `PersonController`.
        /// Inicializa una nueva instancia del controlador con el servicio `IPersonService`.
        /// </summary>
        /// <param name="personService">Instancia del servicio `IPersonService` para realizar las operaciones relacionadas con las personas.</param>
        public PersonController(IPersonService personService) {
            _personService = personService;
        }

        /// <summary>
        /// GENERA JWT BEARER. Realiza el inicio de sesión de una persona.
        /// </summary>
        /// <param name="personLoginDTO">Objeto que contiene las credenciales de la persona para el inicio de sesión.</param>
        /// <returns>BRINDA EL TOKEN JWT BEARER.Retorna un bool si el inicio de sesión es exitoso, o una respuesta con el código de estado correspondiente en caso de error.</returns>
        /// 
        [HttpPost("LogIn")]
        public async Task<ActionResult<bool>> LogIn(PersonLoginDTO personLoginDTO)
        {
            var (response, statusCode) = await _personService.LogIn(personLoginDTO);
            return StatusCode((int)statusCode, response);
        }
    }
}
