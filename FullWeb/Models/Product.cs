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
        public string ClothingType { get; set; }

        public string ClothingColor { get; set; }

        public char ClothingSize { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ClothingPrice { get; set; }

        public string Fabric { get; set; }

        public Project Project { get; set; }


    }
}
