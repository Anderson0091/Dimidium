using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dimidiun.Data.Entities
{
    public class Mensaje
    {
        [Key]
        public int IdMensaje { get; set; }
        public int IdRemitente { get; set; }
        [ForeignKey("IdRemitente")]
        public Usuario Remitente { get; set; }

        public int IdDestinatario { get; set; }
        [ForeignKey("IdDestinatario")]
        public Usuario Destinatario { get; set; }

        public string ContenidoMensaje { get; set; }
        public DateTime FechaEnvio { get; set; }

    }
}
