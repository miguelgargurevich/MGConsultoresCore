using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGConsultores.Models
{
    public class ComentarioModel
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Mensaje { get; set; }
        public Nullable<int> Puntaje { get; set; }
        public Nullable<int> CodUsuario { get; set; }
    }
}