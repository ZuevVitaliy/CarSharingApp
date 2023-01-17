using CarSharingApp.Models.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApp.Models.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(){}

        public DbSet<Rent> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Rent> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connectionString = ConfigurationManager.ConnectionStrings["mssql"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
