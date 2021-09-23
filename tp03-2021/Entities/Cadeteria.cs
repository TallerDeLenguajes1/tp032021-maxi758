using System;
using System.Collections.Generic;
using System.Text;

namespace tp03_2021.Entities
{
    public class Cadeteria
    {
        public List<Cadete> Cadetes { get; set; }
        public List<Pedido> Pedidos { get; set; }
        public Cadeteria()
        {
            Cadetes = new List<Cadete>();
            Pedidos = new List<Pedido>();
        }

        public Cadeteria(List<Cadete> listadoDeCadetes, List<Pedido> listadoDePedidos)
        {
            Cadetes = listadoDeCadetes;
            Pedidos = listadoDePedidos;
        }
    }
}
