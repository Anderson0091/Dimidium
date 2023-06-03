using Dimidiun.Data.Request;
using Dimidiun.Data.Response;

namespace Dimidiun.Data.Services
{
    public interface IMensajeServices
    {
        Task<MensajeServices.Result<List<MensajeResponse>>> Consultar(string filtro);
        Task<MensajeServices.Result> Crear(MensajeRequest request);
        Task<MensajeServices.Result> Eliminar(MensajeRequest request);
        Task<MensajeServices.Result> Modificar(MensajeRequest request);
    }
}