using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stock.Models;

namespace Stock.Data
{
    public class StockContext : DbContext
    {
        public StockContext(DbContextOptions<StockContext> options)
            : base(options) { }

        public DbSet<Stock.Models.Produccion> Produccion { get; set; } = default!;
        public DbSet<Stock.Models.Trabajo> Trabajo { get; set; } = default!;
        public DbSet<Stock.Models.EquiposFinalizados> EquiposFinalizados { get; set; } = default!;
        public DbSet<Stock.Models.EntregasSmt> EntregasSmt { get; set; } = default!;
        public DbSet<Stock.Models.Observacion> Observacion { get; set; } = default!;

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder
        //         .Entity<Trabajo>()
        //         .HasMany(p => p.Entregas)
        //         .WithOne(p => p.OrdenTrabajo)
        //         .HasForeignKey(p=>p.OrdenTrabajoId);

        //     base.OnModelCreating(modelBuilder);
        // }
    }
}
