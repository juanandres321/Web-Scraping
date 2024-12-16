using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Scraping.DTOs;
using Web_Scraping.Services;

namespace Web_Scraping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<SupplierDTO>>> GetAll()
        {
            var (response, statusCode) = await _supplierService.GetAllSupplier();
            return StatusCode((int)statusCode, response);
        }

        [HttpPost("AddSupplier")]
        public async Task<ActionResult<List<SupplierDTO>>> AddSupplier(SupplierInsertDTO supplierInsertDTO)
        {
            var (response, statusCode) = await _supplierService.AddSupplier(supplierInsertDTO);
            return StatusCode((int)statusCode, response);
        }

        [HttpGet("GetSupplier")]
        public async Task<ActionResult<List<SupplierDTO>>> GetSupplier(int ID)
        {
            var (response, statusCode) = await _supplierService.GetSupplier(ID);
            return StatusCode((int)statusCode, response);
        }
        [HttpDelete("DeleteSupplier")]
        public async Task<ActionResult<List<SupplierDTO>>> DeleteSupplier(int ID)
        {
            var (response, statusCode) = await _supplierService.DeleteSupplier(ID);
            return StatusCode((int)statusCode, response);
        }

        [HttpPut("UpdateSupplier")]
        public async Task<ActionResult<List<SupplierDTO>>> UpdateSupplier(SupplierUpdateDTO supplierUpdateDTO)
        {
            var (response, statusCode) = await _supplierService.UpdateSupplier(supplierUpdateDTO);
            return StatusCode((int)statusCode, response);
        }
    }
}
