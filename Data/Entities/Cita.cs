using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dimidiun.Data.Entities
{
    public class Cita
    {
        [Key]
        public int IdCita { get; set; }
        public int IdUsuario1 { get; set; }
        [ForeignKey("IdUsuario1")]
        public Usuario Usuario1 { get; set; }

        public int IdUsuario2 { get; set; }
        [ForeignKey("IdUsuario2")]
        public Usuario Usuario2 { get; set; }

        public DateTime FechaCita { get; set; }
        public string Ubicacion { get; set; }
    }
}
