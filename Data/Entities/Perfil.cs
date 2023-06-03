using Dimidiun.Data.Request;
using Dimidiun.Data.Response;
using System.ComponentModel.DataAnnotations;

namespace Dimidiun.Data.Entities
{
    public class Perfil
    {
        [Key]
        public int IdPerfil { get; set; }

        public int IdUsuario { get; set; }
        // [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        public string Descripcion { get; set; }
        public string Gustos { get; set; }

        public static Perfil Crear(PerfilRequest perfil)
      => new Perfil()
      {
          Descripcion = perfil.Descripcion,
          Gustos = perfil.Gustos,
      };
        public bool Modificar(PerfilRequest perfil)
        {
            var cambio = false;
            if (Descripcion != perfil.Descripcion)
            {
                Descripcion = perfil.Descripcion;
                cambio = true;
            }
            if (Gustos != perfil.Gustos)
            {
                Gustos = perfil.Gustos;
                cambio = true;
            }
            return cambio;
        }

        public PerfilResponse ToResponse()
       => new PerfilResponse()
       {
           Descripcion = Descripcion,
           Gustos = Gustos,
       };
    }
}
