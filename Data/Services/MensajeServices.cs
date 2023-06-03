using Dimidiun.Data.Context;
using Dimidiun.Data.Entities;
using Dimidiun.Data.Request;
using Dimidiun.Data.Response;
using Microsoft.EntityFrameworkCore;

namespace Dimidiun.Data.Services
{
    public class MensajeServices : IMensajeServices
    {
        private readonly IMyDbContext dbContext;

        public MensajeServices(IMyDbContext dbContext)
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
            public List<MensajeResponse> Data { get; internal set; }
        }

        public async Task<Result> Crear(MensajeRequest request)
        {
            try
            {
                var mensaje = Mensaje.Crear(request);
                dbContext.Mensajes.Add(mensaje);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }

        public async Task<Result> Modificar(MensajeRequest request)
        {
            try
            {
                var mensaje = await dbContext.Mensajes
                    .FirstOrDefaultAsync(c => c.IdMensaje == request.IdMensaje);
                if (mensaje == null)
                    return new Result() { Message = "No se encontro el Mensaje", Success = false };

                if (mensaje.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }

        public async Task<Result> Eliminar(MensajeRequest request)
        {
            try
            {
                var mensaje = await dbContext.Mensajes
                    .FirstOrDefaultAsync(c => c.IdMensaje == request.IdMensaje);
                if (mensaje == null)
                    return new Result() { Message = "No se encontro el Mensaje", Success = false };

                dbContext.Mensajes.Remove(mensaje);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result<List<MensajeResponse>>> Consultar(string filtro)
        {
            try
            {
                var mensajes = await dbContext.Mensajes
                    .Include(c => c.Remitente)
                    .Where(c =>
                        (c + " "
                        + c.Remitente + " "
                        + c.Destinatario + " "
                        + c.ContenidoMensaje + " "
                        + c.FechaEnvio + " "
                        )
                        .ToLower()
                        .Contains(filtro.ToLower()
                        )
                    )
                    .Select(c => c.ToResponse())
                    .ToListAsync();
                return new Result<List<MensajeResponse>>()
                {
                    Message = "Ok",
                    Success = true,
                    Data = mensajes
                };
            }
            catch (Exception E)
            {
                return new Result<List<MensajeResponse>>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }
    }
}
