using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp03_2021.Entities;

namespace tp03_2021.ViewModels
{
    public class EditPedidoResponse
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public string Observaciones { get; set; }
        public Estado Estado { get; set; }
        public Cadete Cadete { get; set; } 

        public EditPedidoResponse()
        {
        }

        public EditPedidoResponse(int id, Cliente cliente, string observaciones, Estado estado, Cadete cadete)
        {
            Id = id;
            Cliente = cliente;
            Observaciones = observaciones;
            Estado = estado;
            Cadete = cadete;
        }

        

    }
}
