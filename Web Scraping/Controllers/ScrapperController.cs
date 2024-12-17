using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Scraping.Models;
using Web_Scraping.Services;

namespace Web_Scraping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScrapperController : ControllerBase
    {
        private readonly IScrapperService _scrapperService;
        /// <summary>
        /// Constructor de la clase `ScrapperController`.
        /// Inicializa una nueva instancia del controlador con el servicio `IScrapperService`.
        /// </summary>
        /// <param name="scrapperService">Instancia del servicio `IScrapperService` para realizar las operaciones de Webscrapping.</param>
        public ScrapperController(IScrapperService scrapperService)
        {
            _scrapperService = scrapperService;
        }
        /// <summary>
        /// REQUIERE AUTENTICACIÓN JWT BEARER. Realiza el proceso de scraping de datos.
        /// </summary>
        /// <param name="company">Nombre de la compañía para realizar el scraping de datos.</param>
        /// <returns>>REQUIERE AUTENTICACIÓN JWT BEARER.Retorna un `ActionResult-Company-` con los resultados del scraping si la operación es exitosa, o un `BadRequest` con el mensaje de error correspondiente en caso de fallo.Devuelve máximo 10 hits por el tiempo de espera</returns>
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<CompanyContainer>> Get([FromHeader] string? company)
        {
            try
            {
                var result = await _scrapperService.RunScrapping(company);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
