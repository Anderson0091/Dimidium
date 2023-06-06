﻿using Dimidiun.Data.Request;

namespace Dimidiun.Data.Response
{
    public class UsuarioResponse
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



        public UsuarioRequest ToRequest()
        {
            return new UsuarioRequest
            {
                IdUsuario = IdUsuario,
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
}