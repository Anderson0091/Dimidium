using Dimidiun.Data.Request;
using Dimidiun.Data.Response;

namespace Dimidiun.Data.Services
{
    public interface IUsuarioServices
    {
        Task<UsuarioServices.Result<List<UsuarioResponse>>> Consultar(string filtro);
        Task<UsuarioServices.Result> Crear(UsuarioRequest request);
        Task<UsuarioServices.Result> Eliminar(UsuarioRequest request);
        Task<UsuarioServices.Result> Modificar(UsuarioRequest request);
    }
}