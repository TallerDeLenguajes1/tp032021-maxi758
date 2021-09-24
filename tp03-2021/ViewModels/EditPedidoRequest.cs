using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp03_2021.Entities;

namespace tp03_2021.ViewModels
{
    public class EditPedidoRequest
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public string Observaciones { get; set; }
        public Estado Estado { get; set; }
        public List<Cadete> Cadetes { get; set; } = new List<Cadete>();
        public Cadete Cadete { get; set; }
        public EditPedidoRequest()
        {
            
        }

        public EditPedidoRequest(Cliente cliente, string observaciones, Estado estado, List<Cadete> cadetes)
        {
            Cliente = cliente;
            Observaciones = observaciones;
            Estado = estado;
            Cadetes = cadetes;
        }

        
    }
}
