using Dimidiun.Data.Entities;
using Microsoft.EntityFrameworkCore;
namespace Dimidiun.Data.Context
{
    public class MyDbContext : DbContext, IMyDbContext
    {
        private readonly IConfiguration confi;

        public MyDbContext(IConfiguration confi)
        {
            this.confi=confi;
        }

        public DbSet<Cita> Citas { get; set; }

        public DbSet<Mensaje> Mensajes { get; set; }

        public DbSet<Perfil> Perfiles { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(confi.GetConnectionString(name: "MSSQL"));
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
