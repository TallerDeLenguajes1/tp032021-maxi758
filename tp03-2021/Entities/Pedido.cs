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

        public Pedido(int id, Cliente cliente, string observaciones, Estado estado)
        {
            Id = id;
            Cliente = cliente;
            Observaciones = observaciones;
            this.Estado = estado;
        }

      
    }
}
