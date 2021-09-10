using System;
using System.Collections.Generic;
using System.Text;

namespace tp03_2021.Entities
{
    public class Cadeteria
    {
        public List<Cadete> ListadoDeCadetes { get; set; }
        public string Nombre { get; set; }
        public Cadeteria()
        {

        }

        public Cadeteria(List<Cadete> listadoDeCadetes, string nombre)
        {
            ListadoDeCadetes = listadoDeCadetes;
            Nombre = nombre;
        }
    }
}
