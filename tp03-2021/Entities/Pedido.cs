using System;
using System.Collections.Generic;
using System.Text;

namespace tpnro3_maxi758
{
    public enum Estado { Recibido = 0, Realizandose, Entregado, Desconocido};
    class Pedido
    {   
        public int Id { get; set; }
        Cliente Cliente { get; set; }
        String Observaciones { get; set; }
        Estado Estado { get; set; }

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
