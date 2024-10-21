using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RegistroTecnicos.Models;

namespace RegistroTecnicos.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> Options) 
        : base(Options){ }

    public DbSet<Tecnicos> Tecnicos { get; set; }
    public DbSet<TiposTecnicos> TiposTecnicos { get; set; }
    public DbSet<Clientes> Clientes { get; set; }
    public DbSet<Trabajos> Trabajos { get; set; }
    public DbSet<Prioridades> Prioridades { get; set; }
    public DbSet<Articulos> Articulos { get; set; }
    public DbSet<TrabajosDetalle> TrabajosDetalle { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Articulos>().HasData(
            new List<Articulos>()
            {
                new()
                {
                    ArticuloId = 1,
                    Descripcion = "Pasta Termica",
                    Costo = 200,
                    Precio = 500,
                    Existencia = 20
                },
                 new()
                {
                    ArticuloId = 2,
                    Descripcion = "USB",
                    Costo = 150,
                    Precio = 600,
                    Existencia = 40
                }
            }
            );
        base.OnModelCreating(modelBuilder);
    }
}
