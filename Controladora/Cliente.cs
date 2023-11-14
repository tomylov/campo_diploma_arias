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
        public System.Collections.IList getClientes(int dniBuscado)
        {
            var clientesConDni = from cliente in Modelo.Contexto.Obtener_instancia().Clientes
                                 where cliente.dni == dniBuscado
                                 select cliente;
            return clientesConDni.ToList();
        }



    }
}
