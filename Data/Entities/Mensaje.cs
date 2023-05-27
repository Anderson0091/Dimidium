using Dimidiun.Data.Request;
using Dimidiun.Data.Response;
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

        public static Mensaje Crear(MensajeRequest mensaje)
     => new Mensaje()
     {
         ContenidoMensaje = mensaje.ContenidoMensaje,
         FechaEnvio = mensaje.FechaEnvio,
     };
        public bool Modificar(MensajeRequest mensaje)
        {
            var cambio = false;
            if (ContenidoMensaje != mensaje.ContenidoMensaje)
            {
                ContenidoMensaje = mensaje.ContenidoMensaje;
                cambio = true;
            }
            if (FechaEnvio != mensaje.FechaEnvio)
            {
                FechaEnvio = mensaje.FechaEnvio;
                cambio = true;
            }
            return cambio;
        }

        public MensajeResponse ToResponse()
       => new MensajeResponse()
       {
           ContenidoMensaje = ContenidoMensaje,
           FechaEnvio =FechaEnvio,
       };

    }
}
