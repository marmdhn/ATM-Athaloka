using System.ComponentModel.DataAnnotations;

namespace ATMBank_.Models;

public class TempInfo
{
    public int JumlahPenarikan { get; set; }

    [Range(111,999)]
    public int NoRekening { get; set; }

    public int Nominal { get; set; }

    public int JumlahLembar { get; set; }

	public string? Username { get; set; }

	public string? Password { get; set; }
}