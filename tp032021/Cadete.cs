using System;
using System.Collections.Generic;
using System.Text;

namespace tpnro3_maxi758
{
    class Cadete
    {
        static int identificador = 0;

        

        public int Id { get; set; };       
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public List<Pedido> ListadoPedidos { get; set; }
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
