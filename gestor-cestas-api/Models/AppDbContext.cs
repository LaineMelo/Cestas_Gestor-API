using Microsoft.EntityFrameworkCore;

namespace gestor_cestas_api.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        // Define DbSet para cada entidade do modelo
        public DbSet<Beneficiario> Beneficiarios { get; set; }
        public DbSet<Voluntario> Voluntarios { get; set; }
        public DbSet<RegistroCesta> RegistroCestas { get; set; }
        public DbSet<ListaNecessidade> ListaNecessidades { get; set; }
        public DbSet<Dependente> Dependentes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura as chaves estrangeiras
            base.OnModelCreating(modelBuilder);

        }
    }
}
