using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiNetCoreReact.Models
{
    [Table("usuarios") ]
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }
        public string Apellido_paterno { get; set; }
        public string Apellido_materno { get; set; }
        public string Correo { get; set; }
        public string Username { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
       
    }
}

