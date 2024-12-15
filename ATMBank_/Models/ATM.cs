namespace ATMBank_.Models;

public class ATM
{
    public int Id { get; set; }
    
    public string? NamaATM { get; set; }

    public List<Casette>? Casettes { get; set; }
}