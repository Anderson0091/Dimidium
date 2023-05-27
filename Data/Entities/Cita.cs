using Dimidiun.Data.Request;
using Dimidiun.Data.Response;
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
        public Usuario? Usuario1 { get; set; }

        public int IdUsuario2 { get; set; }
        [ForeignKey("IdUsuario2")]
        public Usuario? Usuario2 { get; set; }

        public DateTime FechaCita { get; set; }
        public string? Ubicacion { get; set; }

        public static Cita Crear(CitaRequest cita)
       => new Cita()
       {
           FechaCita = cita.FechaCita,
           Ubicacion = cita.Ubicacion,
       };
        public bool Modificar(CitaRequest cita)
        {
            var cambio = false;
            if (FechaCita != cita.FechaCita)
            {
                FechaCita = cita.FechaCita;
                cambio = true;
            }
            if (Ubicacion != cita.Ubicacion)
            {
                Ubicacion = cita.Ubicacion;
                cambio = true;
            }
            return cambio;
        }

        public CitaResponse ToResponse()
       => new CitaResponse()
       {
           FechaCita = FechaCita,
           Ubicacion = Ubicacion,
       };
    }
}
