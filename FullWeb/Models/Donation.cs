using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FullWeb.Models;

namespace FullWeb.Models
{
    public class Donation
    {
        [Required]
        
        public int Id { get; set; }

        [Required]
        [Display(Name = "Cardholder Name: ")]
        public string DonorName { get; set; }

        [Required]
        [Display(Name = "E-mail: ")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Residential Address: ")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Card Number: ")]
        public string CardNumber { get; set; }

        [Required]
        [Display(Name = "Card Expiration Month/Year: ")]
        public DateTime ExpirationDate { get; set; }


        [Required]
        [Display(Name = "CVC (3 digit number): ")]
        public string CVC { get; set; }

        [Required]
        [Display(Name = "Amount You Wish To Donate : ")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DonationAmount { get; set; }

        //public bool MultipleDonation {get; set;}

        [Display(Name = "What goods do you wish to donate: ")]

        public Product Product { get; set; }
        public int ProductId { get; set; }


        public Project Project { get; set; }
        public int ProjectId { get; set; }



    }
}
