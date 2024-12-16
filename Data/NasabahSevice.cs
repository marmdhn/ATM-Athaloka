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

        public async Task<List<Customer>> GetAllNasabah()
        {
            return await _applicationDbContext.customers.ToListAsync();
        }

        public async Task<bool> AddNewNasabah(Customer customer)
        {
            await _applicationDbContext.customers.AddAsync(customer);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

		public async Task<Customer> GetNasabahByNoRek(int NoRek)
		{
			Customer? nasabah = await _applicationDbContext.customers.FirstOrDefaultAsync(x => x.account_number == NoRek);
			return nasabah!;
		}

		public async Task<Customer> GetNasabahByUserId(int UserId)
        {
            Customer? nasabah = await _applicationDbContext.customers.FirstOrDefaultAsync(x => x.user_id == UserId);
            return nasabah!;
        }
        
        public async Task<Customer> GetNasabahById(int Id)
        {
            Customer? nasabah = await _applicationDbContext.customers.FirstOrDefaultAsync(x => x.id == Id);
            return nasabah!;
        }

        public async Task<bool> UpdateNasabah(Customer customer)
        {
            _applicationDbContext.customers.Update(customer);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteNasabah(Customer customer)
        {
            _applicationDbContext.customers.Remove(customer);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }


    }
}
