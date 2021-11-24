using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp03_2021.Entities;

namespace tp03_2021.ViewModels
{
    public class PedidoPostViewModel
    {
        public int Id { get; set; }
        public string Observaciones { get; set; }
        public Estado Estado { get; set; }
        public int CadeteId { get; set; }
        public int ClienteId { get; set; }

        public PedidoPostViewModel()
        {
        }

        public PedidoPostViewModel(int id, int clienteId, string observaciones, Estado estado, int cadeteId)
        {
            Id = id;
            ClienteId = clienteId;
            Observaciones = observaciones;
            Estado = estado;
            CadeteId = cadeteId;
        }

        

    }
}
