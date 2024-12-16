using ATMBank_.Context;
using ATMBank_.Models;
using Microsoft.EntityFrameworkCore;

namespace ATMBank_.Data
{
	public class AdminService
	{
		private readonly ApplicationDbContext _applicationDbContext;
		public AdminService(ApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		public async Task<List<Admin>> GetAllAdmin()
		{
			return await _applicationDbContext.admins.ToListAsync();
		}

		public async Task<Admin> GetAdminByUserId(int UserId)
		{
			Admin? admin = await _applicationDbContext.admins.FirstOrDefaultAsync(x => x.user_id == UserId);
			return admin!;
		}

        public async Task<bool> UpdateAdmin(Admin admin)
        {
            _applicationDbContext.admins.Update(admin);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
    }
}
