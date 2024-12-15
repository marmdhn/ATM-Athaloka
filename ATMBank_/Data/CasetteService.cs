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
            return await _applicationDbContext.Casettes.ToListAsync();
        }

        public async Task<bool> AddNewCasette(Casette casette)
        {
            await _applicationDbContext.Casettes.AddAsync(casette);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Casette> GetCasetteById(int id)
        {
            Casette? casette = await _applicationDbContext.Casettes.FirstOrDefaultAsync(x => x.Id == id);
            return casette!;
        }

        public async Task<List<Casette>> GetCasettesByATMId(int idAtm)
        {
            List<Casette> casettes = await _applicationDbContext.Casettes
                .Where(x => x.ATMId == idAtm)
                .ToListAsync();

            return casettes;
        }

        public async Task<bool> UpdateCasette(Casette casette)
        {
            _applicationDbContext.Casettes.Update(casette);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
    }
}
