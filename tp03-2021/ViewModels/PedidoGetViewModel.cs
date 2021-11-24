using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp03_2021.Entities;

namespace tp03_2021.ViewModels
{
    public class PedidoGetViewModel
    {
        public int Id { get; set; }
        public string Observaciones { get; set; }
        public Cliente Cliente { get; set; }
        public Cadete Cadete { get; set; }
        public Estado EstadoPedido { get; set; }
        public int CantidadPedidos { get; set; }
    }
}
