using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class Movimiento
    {
        private static Movimiento movimiento;

        public static Movimiento Obtener_instancia()
        {
            if (movimiento == null)
            {
                movimiento = new Movimiento();
            }
            return movimiento;
        }
        private Movimiento() { }

        public void agregarMovimiento(Modelo.Movimientos movimiento)
        {
            Modelo.Contexto.Obtener_instancia().Movimientos.Add(movimiento);
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }

        public void modificarMovimiento(Modelo.Movimientos movimiento)
        {
            Modelo.Contexto.Obtener_instancia().Entry(movimiento).State = System.Data.Entity.EntityState.Modified;
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }

        public void eliminarMovimiento(Modelo.Movimientos movimiento)
        {
            Modelo.Contexto.Obtener_instancia().Entry(movimiento).State = System.Data.Entity.EntityState.Modified;
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }
    }
}
