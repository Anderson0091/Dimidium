using Dimidiun.Data.Context;
using Dimidiun.Data.Entities;
using Dimidiun.Data.Request;
using Dimidiun.Data.Response;
using Microsoft.EntityFrameworkCore;
namespace Dimidiun.Data.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IMyDbContext dbContext;

        public UsuarioServices(IMyDbContext dbContext)
        {
            this.dbContext=dbContext;
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
            public List<UsuarioResponse> Data { get; internal set; }
        }

        public async Task<Result> Crear(UsuarioRequest request)
        {
            try
            {
                var usuario = Usuario.Crear(request);
                dbContext.Usuarios.Add(usuario);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }

        public async Task<Result> Modificar(UsuarioRequest request)
        {
            try
            {
                var usuario = await dbContext.Usuarios
                    .FirstOrDefaultAsync(c => c.IdUsuario == request.IdUsuario);
                if (usuario == null)
                    return new Result() { Message = "No se encontro el Usuario", Success = false };

                if (usuario.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }

        public async Task<Result> Eliminar(UsuarioRequest request)
        {
            try
            {
                var usuario = await dbContext.Usuarios
                    .FirstOrDefaultAsync(c => c.IdUsuario == request.IdUsuario);
                if (usuario == null)
                    return new Result() { Message = "No se encontro el contacto", Success = false };

                dbContext.Usuarios.Remove(usuario);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result<List<UsuarioResponse>>> Consultar(string filtro)
        {
            try
            {
                var usuarios = await dbContext.Usuarios
                    .Where(c =>
                        (c.Nombre + " "
                        + c.Apellido + " "
                        + c.Edad
                        +c.Ubicacion + " "
                        + c.Telefono + " "
                        + c.Email + "  "
                        + c.Genero + "  "
                        + c.Intereses + " "
                        + c.FotoPerfil
                        )
                        .ToLower()
                        .Contains(filtro.ToLower()
                        )
                    )
                    .Select(c => c.ToResponse())
                    .ToListAsync();
                return new Result<List<UsuarioResponse>>()
                {
                    Message = "Ok",
                    Success = true,
                    Data = usuarios
                };
            }
            catch (Exception E)
            {
                return new Result<List<UsuarioResponse>>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }


    }
}
