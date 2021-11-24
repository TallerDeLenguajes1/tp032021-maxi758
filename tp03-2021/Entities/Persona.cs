using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp03_2021.Entities
{
    public class Persona
    {
        int id;
        String nombre;
        String direccion;
        String telefono;
        bool activo;

        public Persona()
        {

        }

        public Persona(string nombre, string direccion, string telefono)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.Activo = true;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public bool Activo { get => activo; set => activo = value; }
    }
}
