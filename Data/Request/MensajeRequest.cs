using Dimidiun.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dimidiun.Data.Request
{
    public class MensajeRequest
    {
        public int IdMensaje { get; set; }
        public int IdRemitente { get; set; }
        public int IdDestinatario { get; set; }
        public string ContenidoMensaje { get; set; }
        public DateTime FechaEnvio { get; set; }
    }
}
