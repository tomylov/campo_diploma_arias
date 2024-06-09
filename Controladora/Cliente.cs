using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class Cliente
    {
        private static Cliente cliente;

        public static Cliente Obtener_instancia()
        {
            if (cliente == null)
            {
                cliente = new Cliente();
            }
            return cliente;
        }
        public List<Modelo.Clientes> GetCliente(int dniBuscado)
        {
            var clientesConDni = from cliente in Modelo.Contexto.Obtener_instancia().Clientes
                                 where cliente.dni == dniBuscado
                                 select cliente;
            return clientesConDni.ToList();
        }

        public System.Collections.IList getClientes()
        {
            var clientesConDni = from cliente in Modelo.Contexto.Obtener_instancia().Clientes
                                 select cliente;
            return clientesConDni.ToList();
        }

        public void agregarCliente(Modelo.Clientes cliente)
        {
            Modelo.Contexto.Obtener_instancia().Clientes.Add(cliente);
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }

        public void modificarCliente(Modelo.Clientes cliente)
        {
            Modelo.Contexto.Obtener_instancia().Entry(cliente).State = System.Data.Entity.EntityState.Modified;
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }

        public void eliminarCliente(Modelo.Clientes cliente)
        {
            cliente.estado = false;
            Modelo.Contexto.Obtener_instancia().Entry(cliente).State = System.Data.Entity.EntityState.Modified;
            Modelo.Contexto.Obtener_instancia().SaveChanges();
        }

    }
}
