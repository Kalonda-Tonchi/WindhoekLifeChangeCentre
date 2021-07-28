using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FullWeb.Models
{
    public class GoodsByCategory
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Enter the product category: ")]
        public string CategoryName { get; set; }

        public List <Goods> Goods { get; set; }

    }
}
