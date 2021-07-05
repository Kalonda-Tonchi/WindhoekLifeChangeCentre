using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullWeb.Models
{
    public class Blog
    {
        public int Id { get; set; }

        public string BlogEntry { get; set; }

        public DateTime DatePosted { get; set; }
    }
}
