using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mo3askerpro2.Models
{
    public class Applicationdbcontext :IdentityDbContext<ApplicationUser>
    {
        public Applicationdbcontext(DbContextOptions<Applicationdbcontext> options):base(options)
        {
             
        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<student>students { get; set; }
    }
}
