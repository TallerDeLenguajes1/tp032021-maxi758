using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp03_2021.Entities
{
    public class Cliente : Persona
    {
        public Cliente()
        {
        }

        public Cliente(string nombre, string direccion, string telefono) : base(nombre, direccion, telefono)
        {
        }
    }
}
