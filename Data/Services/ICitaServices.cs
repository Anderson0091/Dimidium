using Dimidiun.Data.Request;
using Dimidiun.Data.Response;

namespace Dimidiun.Data.Services
{
    public interface ICitaServices
    {
        Task<CitaServices.Result<List<CitaResponse>>> Consultar(string filtro);
        Task<CitaServices.Result> Crear(CitaRequest request);
        Task<CitaServices.Result> Eliminar(CitaRequest request);
        Task<CitaServices.Result> Modificar(CitaRequest request);
    }
}