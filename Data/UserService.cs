using ATMBank_.Context;
using ATMBank_.Models;
using Microsoft.EntityFrameworkCore;

namespace ATMBank_.Data
{
	public class UserService
	{
		private readonly ApplicationDbContext _applicationDbContext;
		public UserService(ApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		public async Task<List<User>> GetAllUser()
		{
			return await _applicationDbContext.users.ToListAsync();
		}

		public async Task<User> GetUserById(int id)
		{
			User? user= await _applicationDbContext.users.FirstOrDefaultAsync(x => x.id == id);
			return user!;
		}

        public async Task<bool> UpdateUser(User user)
        {
            _applicationDbContext.users.Update(user);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
    }
}
