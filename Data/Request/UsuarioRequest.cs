namespace Dimidiun.Data.Request
{
    public class UsuarioRequest
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public string Genero { get; set; }
        public string Ubicacion { get; set; }
        public string FotoPerfil { get; set; }
        public string Intereses { get; set; }
    }
}
