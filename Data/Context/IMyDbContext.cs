using Dimidiun.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dimidiun.Data.Context
{
    public interface IMyDbContext
    {
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Mensaje> Mensajes { get; set; }
        public DbSet<Perfil> Perfiles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}