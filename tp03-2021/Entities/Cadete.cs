using System;
using System.Collections.Generic;
using System.Text;

namespace tp03_2021.Entities
{
    public class Cadete
    {
        public int Id { get; set; }      
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public List<Pedido> ListadoPedidos { get; set; } = new List<Pedido>();
        public Cadete()
        {

        }

        public Cadete(int id, string nombre, string direccion, string telefono, List<Pedido> listadoPedidos)
        {
            Id = id;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            ListadoPedidos = listadoPedidos;
        }
    }
}
