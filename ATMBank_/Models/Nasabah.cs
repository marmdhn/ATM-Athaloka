using System.ComponentModel.DataAnnotations;
namespace ATMBank_.Models;

    public class Nasabah
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [StringLength(50)]
        public string? NamaNasabah { get; set; }

        public int NoRekening { get; set; }

        public int NoKartuAtm {  get; set; }

        public int PinAtm {  get; set; }

        [Required]
        public int Saldo { get; set; }

        public User? User { get; set; }
    }
