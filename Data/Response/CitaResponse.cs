using Dimidiun.Data.Entities;

namespace Dimidiun.Data.Response
{
    public class CitaResponse
    {
        public int IdCita { get; set; }
        public int IdUsuario1 { get; set; }
        public int IdUsuario2 { get; set; }
        public DateTime FechaCita { get; set; }
        public string Ubicacion { get; set; }
    }
}
