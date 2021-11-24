using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp03_2021.Entities
{
    public class Cadeteria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Cadete> ListaCadetes { get; set; }
        public List<Pedido> Pedidos { get; set; }
        public Cadeteria()
        {
        }

        public Cadeteria(string nombre, List<Cadete> listaCadetes)
        {
            Nombre = nombre;
            ListaCadetes = listaCadetes;
        }
    }
}
