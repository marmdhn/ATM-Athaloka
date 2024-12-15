using System.ComponentModel.DataAnnotations;
namespace ATMBank_.Models;

public class Admin
{
	public int Id { get; set; }

	public int UserId { get; set; }

	[StringLength(50)]
	public string? NamaAdmin { get; set; }

	public string? UsernameAdmin { get; set; }

	[StringLength(8)]
	public string? PasswordAdmin { get; set; }
		
	public User? User { get; set; }
}
