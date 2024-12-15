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
			return await _applicationDbContext.Users.ToListAsync();
		}

		public async Task<User> GetUserById(int Id)
		{
			User? user= await _applicationDbContext.Users.FirstOrDefaultAsync(x => x.Id == Id);
			return user!;
		}

        public async Task<bool> UpdateUser(User user)
        {
            _applicationDbContext.Users.Update(user);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
    }
}
