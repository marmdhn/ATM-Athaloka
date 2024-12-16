using ATMBank_.Context;
using ATMBank_.Models;
using Microsoft.EntityFrameworkCore;

namespace ATMBank_.Data
{
    public class ATMService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ATMService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<ATM>> GetAllATM()
        {
            return await _applicationDbContext.atms.ToListAsync();
        }

        public async Task<bool> AddNewATM(ATM atm)
        {
            await _applicationDbContext.atms.AddAsync(atm);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ATM> GetATMById(int id)
        {
            ATM? atm = await _applicationDbContext.atms.FirstOrDefaultAsync(x => x.id == id);
            return atm!;
        }

        public async Task<bool> UpdateATM(ATM atm)
        {
            _applicationDbContext.atms.Update(atm);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
    }
}
