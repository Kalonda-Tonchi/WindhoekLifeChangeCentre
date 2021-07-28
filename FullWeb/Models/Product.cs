using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullWeb.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name ="Product Type: ")]
        public string ClothingType { get; set; }

        [Display(Name = "Quantity")]
        public string ClothingColor { get; set; }

        [Display(Name = "")] 
        public char ClothingSize { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "")]
        public decimal ClothingPrice { get; set; }

        [Display(Name = "")]
        public string Fabric { get; set; }

        public Project Project { get; set; }


    }
}
