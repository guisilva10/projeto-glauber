using Microsoft.EntityFrameworkCore;


namespace projetopim.Services
{
    public class VendasService
    {
        private readonly ApplicationDbContext _context;

        public VendasService(ApplicationDbContext context)
        {
            _context = context;
        }

     
        public async Task<List<Vendas>> GetAllVendas()
        {
            return await _context.Vendas.ToListAsync();
        }

     
        public async Task<Vendas> GetVendasById(int id)
        {
            return await _context.Vendas.FindAsync(id);
        }

  
        public async Task CreateVendas(Vendas vendaInsumo)
        {
            _context.Vendas.Add(vendaInsumo);
            await _context.SaveChangesAsync();
        }

   
        public async Task UpdateVendas(Vendas vendaInsumo)
        {
            _context.Vendas.Update(vendaInsumo);
            await _context.SaveChangesAsync();
        }

    
        public async Task DeleteVendas(int id)
        {
            var vendaInsumo = await GetVendasById(id);
            if (vendaInsumo != null)
            {
                _context.Vendas.Remove(vendaInsumo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
