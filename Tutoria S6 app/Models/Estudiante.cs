using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tutoria_S6_app.Models
{
    public class Estudiante
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }
        [MaxLength(30)]
        public string Usuario{ get; set; }
        [MaxLength(30)]
        public string Contrasenia { get; set; }
    }
}
