using Dimidiun.Data.Context;
using Dimidiun.Data.Entities;
using Dimidiun.Data.Request;
using Dimidiun.Data.Response;
using Microsoft.EntityFrameworkCore;

namespace Dimidiun.Data.Services
{
    public class PerfilServices : IPerfilServices
    {
        private readonly IMyDbContext dbContext;

        public PerfilServices(IMyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public class Result
        {
            public bool Success { get; set; }
            public string? Message { get; set; }
        }
        public class Result<T>
        {
            public bool Success { get; set; }
            public string? Message { get; set; }

            public T? data { get; set; }
            public List<PerfilResponse> Data { get; internal set; }
        }

        public async Task<Result> Crear(PerfilRequest request)
        {
            try
            {
                var perfil = Perfil.Crear(request);
                dbContext.Perfiles.Add(perfil);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }

        public async Task<Result> Modificar(PerfilRequest request)
        {
            try
            {
                var perfil = await dbContext.Perfiles
                    .FirstOrDefaultAsync(c => c.IdPerfil == request.IdPerfil);
                if (perfil == null)
                    return new Result() { Message = "No se encontro el Perfil", Success = false };

                if (perfil.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }

        public async Task<Result> Eliminar(PerfilRequest request)
        {
            try
            {
                var perfil = await dbContext.Perfiles
                    .FirstOrDefaultAsync(c => c.IdPerfil == request.IdPerfil);
                if (perfil == null)
                    return new Result() { Message = "No se encontro el Perfil", Success = false };

                dbContext.Perfiles.Remove(perfil);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result<List<PerfilResponse>>> Consultar(string filtro)
        {
            try
            {
                var perfiles = await dbContext.Perfiles
                    .Include(c => c.Usuario)
                    .Where(c =>
                        (c + " "
                        + c.Usuario + " "
                        + c.Descripcion + " "
                        + c.Gustos + " "
                        )
                        .ToLower()
                        .Contains(filtro.ToLower()
                        )
                    )
                    .Select(c => c.ToResponse())
                    .ToListAsync();
                return new Result<List<PerfilResponse>>()
                {
                    Message = "Ok",
                    Success = true,
                    Data = perfiles
                };
            }
            catch (Exception E)
            {
                return new Result<List<PerfilResponse>>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }
    }
}
