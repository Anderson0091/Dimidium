using Dimidiun.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dimidiun.Data.Request
{
    public class PerfilRequest
    {
        public int IdPerfil { get; set; }
        public int IdUsuario { get; set; }
        public string Descripcion { get; set; }
        public string Gustos { get; set; }
    }
}
