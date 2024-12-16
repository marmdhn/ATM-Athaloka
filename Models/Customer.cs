using System.ComponentModel.DataAnnotations;
namespace ATMBank_.Models;

    public class Customer
    {
        public int id { get; set; }

        public int user_id { get; set; }

        [StringLength(50)]
        public string? customer_name { get; set; }

        public int account_number { get; set; }

        public int atm_card_number {  get; set; }

        public int atm_pin {  get; set; }

        [Required]
        public int balance { get; set; }

        public User? user { get; set; }
    }
