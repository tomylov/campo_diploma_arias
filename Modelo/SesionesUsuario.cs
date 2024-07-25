using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class SesionUsuario
    {
        [Key]
        public int id_sesion { get; set; }
        public int id_usuario { get; set; }
        public string usuario { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Duracion { get; set; } // Duración en formato "hh:mm:ss"
    }
}
