using Microsoft.AspNetCore.Authorization;
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
        /// <summary>
        /// Obtiene todos los proveedores de la base de datos.
        /// </summary>
        /// <returns>Lista de proveedores.</returns>
        
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<SupplierDTO>>> GetAll()
        {
            var (response, statusCode) = await _supplierService.GetAllSupplier();
            return StatusCode((int)statusCode, response);
        }

        /// <summary>
        /// REQUIERE AUTENTICACIÓN JWT BEARER.Agrega un nuevo proveedor.
        /// </summary>
        /// <param name="supplierInsertDTO">Objeto que contiene la información del nuevo proveedor.</param>
        /// <returns>>REQUIERE AUTENTICACIÓN JWT BEARER.Retorna un SupplierDTO del proveedor añadido, o un `BadRequest` con el mensaje de error correspondiente en caso de fallo.</returns>
        [Authorize]
        [HttpPost("AddSupplier")]
        public async Task<ActionResult<List<SupplierDTO>>> AddSupplier(SupplierInsertDTO supplierInsertDTO)
        {
            var (response, statusCode) = await _supplierService.AddSupplier(supplierInsertDTO);
            return StatusCode((int)statusCode, response);
        }

        /// <summary>
        /// REQUIERE AUTENTICACIÓN JWT BEARER.Obtiene un proveedor por su ID.
        /// </summary>
        /// <param name="ID">ID del proveedor a obtener.</param>
        /// <returns>>REQUIERE AUTENTICACIÓN JWT BEARER.Retorna un Supplier DTO con los detalles del proveedor encontrado si la operación es exitosa, o un `NotFound` si el proveedor no se encuentra.</returns>
        [Authorize]
        [HttpGet("GetSupplier")]
        public async Task<ActionResult<List<SupplierDTO>>> GetSupplier(int ID)
        {
            var (response, statusCode) = await _supplierService.GetSupplier(ID);
            return StatusCode((int)statusCode, response);
        }


        /// <summary>
        /// REQUIERE AUTENTICACIÓN JWT BEARER. Elimina un proveedor por su ID.
        /// </summary>
        /// <param name="ID">ID del proveedor a eliminar.</param>
        /// <returns>>REQUIERE AUTENTICACIÓN JWT BEARER.Retorna un SUPPLIER DTO con la información del proveedor eliminado, o un `NotFound` si el proveedor no se encuentra.</returns>
        [Authorize]
        [HttpDelete("DeleteSupplier")]
        public async Task<ActionResult<List<SupplierDTO>>> DeleteSupplier(int ID)
        {
            var (response, statusCode) = await _supplierService.DeleteSupplier(ID);
            return StatusCode((int)statusCode, response);
        }

        /// <summary>
        /// REQUIERE AUTENTICACIÓN JWT BEARER. Actualiza un proveedor.
        /// </summary>
        /// <param name="supplierUpdateDTO">Objeto que contiene la información actualizada del proveedor.</param>
        /// <returns>REQUIERE AUTENTICACIÓN JWT BEARER.Retorna un SUPPLIERDTO con la información actualizada del proveedor, o un `BadRequest` con el mensaje de error correspondiente en caso de fallo.</returns>
        [Authorize]
        [HttpPut("UpdateSupplier")]
        public async Task<ActionResult<List<SupplierDTO>>> UpdateSupplier(SupplierUpdateDTO supplierUpdateDTO)
        {
            var (response, statusCode) = await _supplierService.UpdateSupplier(supplierUpdateDTO);
            return StatusCode((int)statusCode, response);
        }
    }
}
