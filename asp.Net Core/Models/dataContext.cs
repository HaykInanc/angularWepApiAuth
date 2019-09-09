using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class dataContext : DbContext
    {
        public dataContext(DbContextOptions<dataContext> options):base(options) {


        }

    public DbSet<PostInfo> PostInfo { get; set; }
    public DbSet<ApplicationUser> ApplicationUser { get; set; }
        

    }
}
