using ATMBank_.Context;
using ATMBank_.Models;
using Microsoft.EntityFrameworkCore;

namespace ATMBank_.Data
{
    public class CasetteService
    {
		private readonly ApplicationDbContext _applicationDbContext;
        public CasetteService(ApplicationDbContext applicationDbContext) 
        {
            _applicationDbContext = applicationDbContext;            
        }

        public async Task<List<Casette>> GetAllCasette()
        {
            return await _applicationDbContext.casettes.ToListAsync();
        }

        public async Task<bool> AddNewCasette(Casette casette)
        {
            await _applicationDbContext.casettes.AddAsync(casette);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Casette> GetCasetteById(int id)
        {
            Casette? casette = await _applicationDbContext.casettes.FirstOrDefaultAsync(x => x.id == id);
            return casette!;
        }

        public async Task<List<Casette>> GetCasettesByATMId(int idAtm)
        {
            List<Casette> casettes = await _applicationDbContext.casettes
                .Where(x => x.AtmId == idAtm)
                .ToListAsync();

            return casettes;
        }

        public async Task<bool> UpdateCasette(Casette casette)
        {
            _applicationDbContext.casettes.Update(casette);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
    }
}
