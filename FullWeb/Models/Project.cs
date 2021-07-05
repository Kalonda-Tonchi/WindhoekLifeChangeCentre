using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FullWeb.Models
{
    public class Project
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Project: ")]
        public string ProjectName { get; set; }
    }
}
