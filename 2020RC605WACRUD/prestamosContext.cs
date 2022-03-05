using Microsoft.EntityFrameworkCore;
using _2020RC605WACRUD.Models;
namespace _2020RC605WACRUD

{
    public class prestamosContext : DbContext
    {
        public prestamosContext(DbContextOptions<prestamosContext> options) : base(options)
        {

        }

        public DbSet<equipos> equipos { get; set; }
        public DbSet<marca> marcas { get; set; }
        public DbSet<estados_equipo> estados_equipo { get; set; }
        public DbSet<tipo_equipo> tipo_equipo { get; set; }
    }
}
