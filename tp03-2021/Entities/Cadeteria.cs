using System;
using System.Collections.Generic;
using System.Text;

namespace tp03_2021.Entities
{
    public class Cadeteria
    {
        public List<Cadete> ListadoDeCadetes { get; set; }
        public List<Pedido> ListadoDePedidos { get; set; }
        public Cadeteria()
        {
            ListadoDeCadetes = new List<Cadete>();
            ListadoDePedidos = new List<Pedido>();
        }

        public Cadeteria(List<Cadete> listadoDeCadetes, List<Pedido> listadoDePedidos)
        {
            ListadoDeCadetes = listadoDeCadetes;
            ListadoDePedidos = listadoDePedidos;
        }
    }
}
