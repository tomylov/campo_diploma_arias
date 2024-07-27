using Modelo;
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
                      join cl in Modelo.Contexto.Obtener_instancia().Clientes on cc.id_cliente equals cl.id_cliente
                      where cl.dni == dni
                      select new
                      {
                          Dni = cl.dni,
                          Name = cl.nombre,
                          Telefono = cl.telefono,
                          Email = cl.email,
                          Razon = cl.ra,
                          Saldo =cc.saldo,
                          Id_cc= cc.id_cc
                      };
            return vta.ToList();
        }

        public List<Modelo.Cuentas_Corrientes> Getcc(int id_cliente)
        {
            var vta = from cc in Modelo.Contexto.Obtener_instancia().Cuentas_Corrientes
                      where cc.id_cliente == id_cliente
                      select cc;
            return vta.ToList();
        }
        //Listo los movimientos de una cuenta corriente
        public System.Collections.IList listarMovimientos(int cc)
        {
            Contexto contexto = Modelo.Contexto.Obtener_instancia();
            var query = from m in contexto.Movimientos
                            join tm in contexto.tipo_movimientos on m.tipo equals tm.id_tipo_mov
                            where m.id_cc == cc
                            select new
                            {
                                m.id_mov,
                                m.fecha,
                                m.monto,
                                tipo=tm.descripcion
                            };

            return query.OrderByDescending(m => m.fecha).ToList();            
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
