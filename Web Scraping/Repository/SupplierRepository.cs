using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using Web_Scraping.Models;

namespace Web_Scraping.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly Context _context;
        private SupplierRepository(Context context)
        {
            _context = context;
        }
        public async Task Add(Supplier entity)
       => await _context.Suppliers.AddAsync(entity);

        public void Delete(Supplier entity)
        => _context.Suppliers.Remove(entity);

        public async Task<List<Supplier>?> GetAll()
        => await _context.Suppliers.ToListAsync();

        public async Task Save()
        => await _context.SaveChangesAsync();


        public void Update(Supplier entity)
        {
            _context.Suppliers.Attach(entity);
            _context.Suppliers.Entry(entity).State = EntityState.Modified;
        }
        public async Task<Supplier?> GetByID(int ID)
        => await _context.Suppliers.Where(I => I.IdSupplier == ID).FirstOrDefaultAsync();
    }
}
