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
        public ScrapperController(IScrapperService scrapperService)
        {
            _scrapperService = scrapperService;
        }
        [HttpGet]
        public async Task<ActionResult<Company>> Get([FromHeader] string? company)
        {
            try
            {
                var result = await _scrapperService.RunScrapping(company);
                return Ok(result.Item2);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
