using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp03_2021.Entities;

namespace tp03_2021.ViewModels
{
    public class CadeteViewModel
    {
        public int Id { get; set; }
        public int CadeteriaId { get; set; }
        public String Nombre { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public int CantidadPedidos { get; set; }
        public List<Cadeteria> Cadeterias { get; set; } = new List<Cadeteria>();

    }
}
