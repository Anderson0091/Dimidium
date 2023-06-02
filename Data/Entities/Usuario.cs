using Dimidiun.Data.Request;
using Dimidiun.Data.Response;
using System.ComponentModel.DataAnnotations;

namespace Dimidiun.Data.Entities
{
    public class Usuario
    {
        [Key]
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

        public static Usuario Crear(UsuarioRequest usuario)
        => new Usuario()
        {
            Nombre = usuario.Nombre,
            Apellido = usuario.Apellido,
            Edad = usuario.Edad,
            Telefono = usuario.Telefono,
            Email = usuario.Email,
            Contraseña = usuario.Contraseña,
            Genero = usuario.Genero,
            Ubicacion = usuario.Ubicacion,
            FotoPerfil = usuario.FotoPerfil,
            Intereses = usuario.Intereses,
        };
        public bool Modificar(UsuarioRequest usuario)
        {
            var cambio = false;
            if (Nombre != usuario.Nombre)
            {
                Nombre = usuario.Nombre;
                cambio = true;
            }
            if (Apellido != usuario.Apellido)
            {
                Apellido = usuario.Apellido;
                cambio = true;
            }
            if (Edad != usuario.Edad)
            {
                Edad = usuario.Edad;
                cambio = true;
            }
            if (Telefono != usuario.Telefono)
            {
                Telefono = usuario.Telefono;
                cambio = true;
            }
            if (Email != usuario.Email)
            {
                Email = usuario.Email;
                cambio = true;
            }
            if (Contraseña != usuario.Contraseña)
            {
                Contraseña = usuario.Contraseña;
                cambio = true;
            }
            if (Genero != usuario.Genero)
            {
                Genero = usuario.Genero;
                cambio = true;
            }
            if (Ubicacion != usuario.Ubicacion)
            {
                Ubicacion = usuario.Ubicacion;
                cambio = true;
            }
            if (FotoPerfil != usuario.FotoPerfil)
            {
                FotoPerfil = usuario.FotoPerfil;
                cambio = true;
            }
            if (Intereses != usuario.Intereses)
            {
                Intereses = usuario.Intereses;
                cambio = true;
            }
            return cambio;
        }

        public UsuarioResponse ToResponse()
        => new()
        {
            Nombre = Nombre,
            Apellido = Apellido,
            Edad = Edad,
            Telefono = Telefono,
            Email = Email,
            Contraseña = Contraseña,
            Genero = Genero,
            Ubicacion = Ubicacion,
            FotoPerfil = FotoPerfil,
            Intereses = Intereses
        };
    }
}
