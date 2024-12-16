using System.ComponentModel.DataAnnotations;
namespace ATMBank_.Models;

    public class Casette
    {
        public int id { get; set; }

        public int AtmId { get; set; }

        public int nominal { get; set; }

        [Range(1, 1000)]
        public int quantity { get; set; }
    }
