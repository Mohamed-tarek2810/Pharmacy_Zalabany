using Microsoft.EntityFrameworkCore;
using Pharmacy_Zalabany.Models;

namespace Pharmacy_Zalabany.Data
{
        public class ApplicationDbContext : DbContext
        {
            public DbSet<Products> Products { get; set; }
        public DbSet<Categorys> Categorys { get; set; }
            public DbSet<Notes> Notes { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                base.OnConfiguring(optionsBuilder);

                optionsBuilder.UseSqlServer("Data Source=LAPTOP-F7MI2PIT\\MSSQLSERVERMO;Initial Catalog=Zlabanypharmacy_2;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;");
            }
        }
    }

