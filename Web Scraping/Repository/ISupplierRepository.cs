using Web_Scraping.Models;

namespace Web_Scraping.Repository
{
    public interface ISupplierRepository
    {
        Task Add(Supplier entity);
        void Update(Supplier entity);
        void Delete(Supplier entity);
        Task<List<Supplier>?> GetAll();
        Task<Supplier?> GetByID(int ID);
        Task Save();
    }
}
