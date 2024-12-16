namespace ATMBank_.Models;

public class ATM
{
    public int id { get; set; }
    
    public string? atm_name { get; set; }

    public List<Casette>? casettes { get; set; }
}