using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using FullWeb.Models;

namespace FullWeb.Dtos
{
    public class DonationDto
    {
        public int Id { get; set; }

        public string DonorName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string CardNumber { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string CVC { get; set; }

        public decimal DonationAmount { get; set; }

        public int ProductId { get; set; }

        public int ProjectId { get; set; }

    }
}
