using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using FullWeb.Models;

namespace FullWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<FullWeb.Models.Product> Product { get; set; }
        public DbSet<FullWeb.Models.Donation> Donation { get; set; }
        public DbSet<FullWeb.Models.Project> Project { get; set; }
        public DbSet<FullWeb.Models.Volunteer> Volunteer { get; set; }
    }
}
