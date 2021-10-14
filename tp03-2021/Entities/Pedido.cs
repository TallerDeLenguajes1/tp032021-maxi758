using System;
using System.Collections.Generic;
using System.Text;

namespace tp03_2021.Entities
{
    public enum Estado { Recibido = 0, Realizandose, Entregado, Desconocido};
    public class Pedido
    {   
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public string Observaciones { get; set; }
        public Estado Estado { get; set; }

        public Pedido()
        {
            
        }

        public Pedido(int id, string observaciones, Estado estado, string nombre, string direccion, string telefono)
        {
            Id = id;
            Cliente = new Cliente(nombre, direccion, telefono);
            Observaciones = observaciones;
            this.Estado = estado;
        }

      
    }
}
