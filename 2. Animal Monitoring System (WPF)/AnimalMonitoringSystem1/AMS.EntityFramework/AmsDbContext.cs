using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.EntityFramework
{                                                   
    public class AmsDbContext : DbContext
    {
        private static bool created = false;
        public AmsDbContext()
        {                        
            if (!created)
            {
                created = true;
                //Database.EnsureDeleted();
                Database.EnsureCreated();
            }

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=AMS.db");
            optionsBuilder.UseLazyLoadingProxies();
        }
        public DbSet<Animal> Animal { get; set; }
        public DbSet<Habitat> Habitat { get; set; }
        public DbSet<UserCredentials> UserCredentials {get; set;}
    }
}
