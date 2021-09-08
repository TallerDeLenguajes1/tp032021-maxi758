using System;
using System.Collections.Generic;
using System.Text;

namespace tpnro3_maxi758
{
    
    class Cliente
    {
        static int identificador = 0;
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public Cliente()
        {

        }

        public Cliente(String nombre, String direccion, String telefono)
        {
      
            identificador++;
            Id = identificador;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
        
        }

        
    }
}
