using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dimidiun.Data.Entities
{
    public class Perfil
    {
        [Key]
        public int IdPerfil { get; set; }
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
        public string Descripcion { get; set; }
        public string Gustos { get; set; }
    }
}
