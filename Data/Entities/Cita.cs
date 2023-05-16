namespace Dimidiun.Data.Entities
{
    public class Cita
    {
        public int IdCita { get; set; }
        public int IdUsuario1 { get; set; }
        public int IdUsuario2 { get; set; }
        public DateTime FechaCita { get; set; }
        public string Ubicacion { get; set; }
    }
}
