using Microsoft.EntityFrameworkCore;


namespace projetopim.Services
{
    public class InsumoService
    {
        private readonly ApplicationDbContext _context;

        public InsumoService(ApplicationDbContext context)
        {
            _context = context;
        }

    
        public async Task<List<CultivosEInsumos>> GetAllInsumos()
        {
            return await _context.CultivosEInsumos.ToListAsync();
        }

        public async Task<CultivosEInsumos> GetInsumoById(int id)
        {
            return await _context.CultivosEInsumos.FindAsync(id);
        }

   
        public async Task CreateInsumo(CultivosEInsumos cultivoInsumo)
        {
            _context.CultivosEInsumos.Add(cultivoInsumo);
            await _context.SaveChangesAsync();
        }

   
        public async Task UpdateInsumo(CultivosEInsumos cultivoInsumo)
        {
            _context.CultivosEInsumos.Update(cultivoInsumo);
            await _context.SaveChangesAsync();
        }

  
        public async Task DeleteInsumo(int id)
        {
            var cultivoInsumo = await GetInsumoById(id);
            if (cultivoInsumo != null)
            {
                _context.CultivosEInsumos.Remove(cultivoInsumo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
