namespace Dimidiun.Data.Response
{
    public class MensajeResponse
    {
        public int IdMensaje { get; set; }
        public int IdRemitente { get; set; }
        public int IdDestinatario { get; set; }
        public string ContenidoMensaje { get; set; }
        public DateTime FechaEnvio { get; set; }
    }
}
