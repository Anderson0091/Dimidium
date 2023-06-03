using Dimidiun.Data.Context;
using Dimidiun.Data.Entities;
using Dimidiun.Data.Request;
using Dimidiun.Data.Response;
using Microsoft.EntityFrameworkCore;

namespace Dimidiun.Data.Services
{
    public class CitaServices : ICitaServices
    {
        private readonly IMyDbContext dbContext;

        public CitaServices(IMyDbContext dbContext)
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
            public List<CitaResponse> Data { get; internal set; }
        }

        public async Task<Result> Crear(CitaRequest request)
        {
            try
            {
                var cita = Cita.Crear(request);
                dbContext.Citas.Add(cita);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }

        public async Task<Result> Modificar(CitaRequest request)
        {
            try
            {
                var cita = await dbContext.Citas
                    .FirstOrDefaultAsync(c => c.IdCita == request.IdCita);
                if (cita == null)
                    return new Result() { Message = "No se encontro el Cita", Success = false };

                if (cita.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }

        public async Task<Result> Eliminar(CitaRequest request)
        {
            try
            {
                var cita = await dbContext.Citas
                    .FirstOrDefaultAsync(c => c.IdCita == request.IdCita);
                if (cita == null)
                    return new Result() { Message = "No se encontro Cita", Success = false };

                dbContext.Citas.Remove(cita);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result<List<CitaResponse>>> Consultar(string filtro)
        {
            try
            {
                var citas = await dbContext.Citas
                    .Include(c => c.Usuario1)
                    .Where(c =>
                        (c + " "
                        + c.Usuario1 + " "
                        + c.Usuario2 + " "
                        + c.FechaCita + " "
                        + c.Ubicacion + " "
                        )
                        .ToLower()
                        .Contains(filtro.ToLower()
                        )
                    )
                    .Select(c => c.ToResponse())
                    .ToListAsync();
                return new Result<List<CitaResponse>>()
                {
                    Message = "Ok",
                    Success = true,
                    Data = citas
                };
            }
            catch (Exception E)
            {
                return new Result<List<CitaResponse>>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }
    }
}
