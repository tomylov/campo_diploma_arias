using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Estado
{
    public static class EstadoFactory
    {
        public static Estado CrearEstado(int? idEstado)
        {
            switch (idEstado)
            {
                case 1:
                    return new Pendiente();
                case 2:
                    return new Aceptado();
                case 3:
                    return new Cuenta_corriente();
                case 4:
                    return new Pagado();
                case 5:
                    return new Pagado_cuenta_corriente();
                default:
                    throw new ArgumentException("ID de estado no válido");
            }
        }
    }
}
