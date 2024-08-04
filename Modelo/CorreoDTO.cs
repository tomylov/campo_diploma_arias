using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class CorreoDTO
    {
        public string EmailFrom { get; set; }
        public string Clave { get; set; }
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
    }
}
