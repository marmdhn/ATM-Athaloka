using ATMBank_.Context;
using ATMBank_.Models;
using Microsoft.EntityFrameworkCore;

namespace ATMBank_.Data
{
    public class NasabahService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public NasabahService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<Nasabah>> GetAllNasabah()
        {
            return await _applicationDbContext.Nasabahs.ToListAsync();
        }

        public async Task<bool> AddNewNasabah(Nasabah nasabah)
        {
            await _applicationDbContext.Nasabahs.AddAsync(nasabah);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

		public async Task<Nasabah> GetNasabahByNoRek(int NoRek)
		{
			Nasabah? nasabah = await _applicationDbContext.Nasabahs.FirstOrDefaultAsync(x => x.NoRekening == NoRek);
			return nasabah!;
		}

		public async Task<Nasabah> GetNasabahByUserId(int UserId)
        {
            Nasabah? nasabah = await _applicationDbContext.Nasabahs.FirstOrDefaultAsync(x => x.UserId == UserId);
            return nasabah!;
        }
        
        public async Task<Nasabah> GetNasabahById(int Id)
        {
            Nasabah? nasabah = await _applicationDbContext.Nasabahs.FirstOrDefaultAsync(x => x.Id == Id);
            return nasabah!;
        }

        public async Task<bool> UpdateNasabah(Nasabah nasabah)
        {
            _applicationDbContext.Nasabahs.Update(nasabah);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteNasabah(Nasabah nasabah)
        {
            _applicationDbContext.Nasabahs.Remove(nasabah);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }


    }
}
