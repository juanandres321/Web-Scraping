using System.Net;
using Web_Scraping.DTOs;
using Web_Scraping.Models;

namespace Web_Scraping.Services
{
    public interface ISupplierService
    {
        Task<(Response<SupplierDTO?>, HttpStatusCode)> AddSupplier(SupplierInsertDTO supplierInsertDTO );
        Task<(Response<List<SupplierDTO>>, HttpStatusCode)> GetAllSupplier();

        Task<(Response<SupplierDTO?>, HttpStatusCode)> GetSupplier(int id);
        Task<(Response<SupplierDTO?>, HttpStatusCode)> DeleteSupplier(int ID);
        Task<(Response<SupplierDTO?>, HttpStatusCode)> UpdateSupplier(SupplierUpdateDTO supplierUpdateDTO);
    }
}
