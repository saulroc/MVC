using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.BaseDeDatos
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set;  }
        public string ConnectionString => "Server=Localhost;Database=Vidly;Trusted_Connection=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(ConnectionString);

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Cliente>()
        //                .Property(c => c.Nombre)
        //                .IsRequired()
        //                .HasMaxLength(255);
        //}
    }
}
