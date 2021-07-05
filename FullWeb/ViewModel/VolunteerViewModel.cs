using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullWeb.Models;

namespace FullWeb.ViewModel
{
    public class VolunteerViewModel
    {
        public Volunteer Volunteer  { get; set; }

        public IEnumerable <Project> Project { get; set; }
    }
}
