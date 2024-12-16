using AutoMapper;
using System;
using System.Net;
using Web_Scraping.DTOs;
using Web_Scraping.Models;
using Web_Scraping.Repository;

namespace Web_Scraping.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        public SupplierService(ISupplierRepository supplierRepository,IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<(Response<SupplierDTO?>, HttpStatusCode)> AddSupplier(SupplierInsertDTO supplierInsertDTO)
        {
            try
            {
                Supplier supplier = _mapper.Map<Supplier>(supplierInsertDTO);
                await _supplierRepository.Add(supplier);
                await _supplierRepository.Save();
                SupplierDTO supplierDTO = _mapper.Map<SupplierDTO>(supplier);
                return (Response<SupplierDTO?>.CreateResponse(true, "OK", supplierDTO), HttpStatusCode.OK);

            }
            catch (Exception ex)
            {
                return (Response<SupplierDTO?>.Failure(ex.ToString()), HttpStatusCode.InternalServerError);
            }

        }

        public async Task<(Response<SupplierDTO?>, HttpStatusCode)> DeleteSupplier(int ID)
        {
            try
            {
                Supplier? supplier = await _supplierRepository.GetByID(ID);
                if (supplier != null)
                {
                    SupplierDTO supplierDTO = _mapper.Map<SupplierDTO>(supplier);
                    _supplierRepository.Delete(supplier);
                    await _supplierRepository.Save();
                    return (Response<SupplierDTO?>.CreateResponse(true, "Ok", supplierDTO), HttpStatusCode.OK);
                }
                return (Response<SupplierDTO?>.Failure("Proveedor invalido"), HttpStatusCode.BadRequest);

            }
            catch (Exception ex)
            {
                return (Response<SupplierDTO?>.Failure(ex.ToString()), HttpStatusCode.InternalServerError);
            }
        }

        public async Task<(Response<List<SupplierDTO>>, HttpStatusCode)> GetAllSupplier()
        {
            try
            {
                List<Supplier>? supplierlist = await _supplierRepository.GetAll();
                if (supplierlist != null)
                {
                    var peopleList = supplierlist.Select(person => _mapper.Map<SupplierDTO>(person)).ToList();
                    return (Response<List<SupplierDTO>>.CreateResponse(true, "OK", peopleList), HttpStatusCode.OK);
                }
                return (Response<List<SupplierDTO>>.CreateResponse(true, "OK", null), HttpStatusCode.OK);

            }
            catch (Exception ex)
            {
                return (Response<List<SupplierDTO>>.Failure(ex.ToString()), HttpStatusCode.InternalServerError);
            }
        }

        public async Task<(Response<SupplierDTO?>, HttpStatusCode)> GetSupplier(int id)
        {
            try
            {
                Supplier? supplier = await _supplierRepository.GetByID(id);
                if (supplier != null)
                {
                    SupplierDTO supplierDTO = _mapper.Map<SupplierDTO>(supplier);
                    return (Response<SupplierDTO?>.CreateResponse(true, "Ok", supplierDTO), HttpStatusCode.OK);
                }
                return (Response<SupplierDTO?>.Failure("Proveedor invalido"), HttpStatusCode.BadRequest);

            }
            catch (Exception ex)
            {
                return (Response<SupplierDTO?>.Failure(ex.ToString()), HttpStatusCode.InternalServerError);
            }
        }

        public async Task<(Response<SupplierDTO?>, HttpStatusCode)> UpdateSupplier(SupplierUpdateDTO supplierUpdateDTO)
        {
            try
            {
                Supplier supplier = _mapper.Map<Supplier>(supplierUpdateDTO);
                _supplierRepository.Update(supplier);
                await _supplierRepository.Save();
                SupplierDTO supplierDTO = _mapper.Map<SupplierDTO>(supplier);
                return (Response<SupplierDTO?>.CreateResponse(true, "OK", supplierDTO), HttpStatusCode.OK);

            }
            catch (Exception ex)
            {
                return (Response<SupplierDTO?>.Failure(ex.ToString()), HttpStatusCode.InternalServerError);
            }
        }
    }
}
