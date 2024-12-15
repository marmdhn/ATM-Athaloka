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
            return await _applicationDbContext.ATMs.ToListAsync();
        }

        public async Task<bool> AddNewATM(ATM atm)
        {
            await _applicationDbContext.ATMs.AddAsync(atm);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ATM> GetATMById(int id)
        {
            ATM? atm = await _applicationDbContext.ATMs.FirstOrDefaultAsync(x => x.Id == id);
            return atm!;
        }

        public async Task<bool> UpdateATM(ATM atm)
        {
            _applicationDbContext.ATMs.Update(atm);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
    }
}
