using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using FullWeb.Models;


namespace FullWeb.Dtos
{
    public class VolunteerDto
    {

        public int Id { get; set; }


        public string FirstName { get; set; }

        public string Surname { get; set; }

        public static IEnumerable<string> Country { get; set; } //as a list

        public int ProjectId { get; set; }
    }
}
