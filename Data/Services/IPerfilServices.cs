using Dimidiun.Data.Request;
using Dimidiun.Data.Response;

namespace Dimidiun.Data.Services
{
    public interface IPerfilServices
    {
        Task<PerfilServices.Result<List<PerfilResponse>>> Consultar(string filtro);
        Task<PerfilServices.Result> Crear(PerfilRequest request);
        Task<PerfilServices.Result> Eliminar(PerfilRequest request);
        Task<PerfilServices.Result> Modificar(PerfilRequest request);
    }
}