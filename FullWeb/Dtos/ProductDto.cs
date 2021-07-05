using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using FullWeb.Models;


namespace FullWeb.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ClothingType { get; set; }

        public string ClothingColor { get; set; }

        public char ClothingSize { get; set; }

        public decimal ClothingPrice { get; set; }

        public string Fabric { get; set; }
    }
}
