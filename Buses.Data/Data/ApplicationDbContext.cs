using Buses.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel.Resolution;

namespace Buses.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Poner aquí todos los modelos que se vayan creando
        public DbSet<Ruta> Ruta { get; set; }
        public DbSet<Bus> Bus { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
    }
}
