using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using FullWeb.Models;


namespace FullWeb.Dtos
{
    public class ProjectDto
    {
        public int Id { get; set; }

        public string ProjectName { get; set; }
    }
}
