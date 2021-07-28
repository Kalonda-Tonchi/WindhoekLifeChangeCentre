using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FullWeb.Models
{
    public class Goods
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public GoodsByCategory GoodsByCategory { get; set; }

        [Display(Name = "What type of product do you wish to donate?")]
        public int GoodsByCategoryId { get; set; }

        [Required]
        [Display(Name = "Product Name: ")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name="Quantity you wish to donate: ")]
        public int AmountOfGoodsDonating { get; set; }

        [Display(Name="Select the project you wish to donate to: ")]
        public Project Project { get; set; }

    }
}
