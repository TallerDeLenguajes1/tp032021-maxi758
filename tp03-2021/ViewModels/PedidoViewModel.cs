using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp03_2021.Entities;

namespace tp03_2021.ViewModels
{
    public class PedidoViewModel
    {
        public int Id { get; set; }
        public string Observaciones { get; set; }
        public Estado Estado { get; set; }
        public int CadeteId { get; set; }
        public int ClienteId { get; set; }
        public List<CadeteViewModel> Cadetes { get; set; } = new List<CadeteViewModel>();
        public List<Cliente> Clientes { get; set; } = new List<Cliente>();

        public PedidoViewModel()
        {
            
        }

        public PedidoViewModel(string observaciones, Estado estado, List<CadeteViewModel> cadetes, List<Cliente> clientes, int cadeteId, int clienteId)
        {
            Observaciones = observaciones;
            Estado = estado;
            Cadetes = cadetes;
            Clientes = clientes;
            CadeteId = cadeteId;
            ClienteId = clienteId;
        }


    }
}
