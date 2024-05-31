using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class Cuenta_Corriente_Cliente
    {
        private static Cuenta_Corriente_Cliente cc;

        public static Cuenta_Corriente_Cliente Obtener_instancia()
        {
            if (cc == null)
            {
                cc = new Cuenta_Corriente_Cliente();
            }
            return cc;
        }

        public System.Collections.IList GetCuentaCorriente(int dni)
        {
            var vta = from cc in Modelo.Contexto.Obtener_instancia().Cuentas_Corrientes
                      join cl in Modelo.Contexto.Obtener_instancia().Clientes on cc.dni equals cl.dni
                      where cc.dni == dni
                      select new
                      {
                          Dni = cc.dni,
                          Name = cl.nombre,
                          Telefono = cl.telefono,
                          Email = cl.email,
                          Razon = cl.ra,
                          Saldo =cc.saldo,
                          Id_cc= cc.id_cc
                      };
            return vta.ToList();
        }

        public List<Modelo.Cuentas_Corrientes> Getcc(int dni)
        {
            var vta = from cc in Modelo.Contexto.Obtener_instancia().Cuentas_Corrientes
                      where cc.dni == dni
                      select cc;
            return vta.ToList();
        }
        //Listo los movimientos de una cuenta corriente
        public System.Collections.IList listarMovimientos(int cc)
        {
            var mov = from mo in Modelo.Contexto.Obtener_instancia().Movimientos
                      join co in Modelo.Contexto.Obtener_instancia().Comprobantes on mo.id_comp equals co.id_comp
                      where mo.id_cc == cc
                      select new
                      {
                          mo.id_mov,
                          mo.tipo,
                          tipoComp = "Venta",
                          co.numero
                      };
            return mov.ToList();
        }

        public void agregarCC(Modelo.Cuentas_Corrientes cc)
        {
            Modelo.Contexto.Obtener_instancia().Cuentas_Corrientes.Add(cc);
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }

        public void modificarCuentaCorriente(Modelo.Cuentas_Corrientes cc)
        {
            Modelo.Contexto.Obtener_instancia().Entry(cc).State = System.Data.Entity.EntityState.Modified;
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }
    }
}
