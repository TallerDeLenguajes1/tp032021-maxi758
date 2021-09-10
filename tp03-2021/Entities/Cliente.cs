using System;
using System.Collections.Generic;
using System.Text;

namespace tp03_2021.Entities
{
    
    public class Cliente
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
