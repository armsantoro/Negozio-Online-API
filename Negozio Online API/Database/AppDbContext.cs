using Microsoft.EntityFrameworkCore;
using Negozio_Online_API.Models.Dipendente;
using Negozio_Online_API.Models.Reparto;

namespace Negozio_Online_API.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> IL NOME DEVE CORRISPONDERE A QUELLO DELLA TABELLA NEL DB <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        public DbSet<DipendenteModel> Dipendente { get; set; }
        public DbSet<RepartoModel> Reparto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Imposta l'azione di eliminazione a "CASCADE" se si desidera eliminare i dipendenti quando si elimina un reparto. // Configurazioni aggiuntive... }
            modelBuilder.Entity<DipendenteModel>().HasOne(d => d.Reparto).WithMany(r => r.Dipendente).HasForeignKey(d => d.RepartoID).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
