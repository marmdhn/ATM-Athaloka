using System.ComponentModel.DataAnnotations;
namespace ATMBank_.Models;

    public class Casette
    {
        public int Id { get; set; }

        public int ATMId { get; set; }

        public int Nominal { get; set; }

        [Range(1, 1000)]
        public int Jumlah { get; set; }
    }
