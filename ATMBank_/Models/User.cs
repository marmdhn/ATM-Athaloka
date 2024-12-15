namespace ATMBank_.Models;

public class User
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public int Role { get; set; }

    public Nasabah? Nasabah { get; set; }
    public Admin? Admin { get; set; }
}
