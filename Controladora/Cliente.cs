﻿using System;
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

        private Cliente() { }

        public List<Modelo.Clientes> GetCliente(int dni)
        {
            var clientesConDni = from cliente in Modelo.Contexto.Obtener_instancia().Clientes
                                 where cliente.dni == dni
                                 select cliente;
            return clientesConDni.ToList();
        }

        public List<Modelo.Clientes> GetClienteID(int id_cliente)
        {
            var clientes = from cliente in Modelo.Contexto.Obtener_instancia().Clientes
                where cliente.id_cliente == id_cliente
                select cliente;
            return clientes.ToList();
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
