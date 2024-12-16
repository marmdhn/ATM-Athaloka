using System.ComponentModel.DataAnnotations;
namespace ATMBank_.Models;

public class Admin
{
	public int id { get; set; }

	public int user_id { get; set; }

	[StringLength(50)]
	public string? admin_name { get; set; }

	public string? admin_username { get; set; }

	[StringLength(8)]
	public string? admin_password { get; set; }
		
	public User? user { get; set; }
}
