using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullWeb.Models;

namespace FullWeb.ViewModel
{
    public class DonationViewModel
    {
        public  Donation Donation { get; set; }

        public IEnumerable <Project>  Project { get; set; }

        public Product Product { get; set; }
    }
}
