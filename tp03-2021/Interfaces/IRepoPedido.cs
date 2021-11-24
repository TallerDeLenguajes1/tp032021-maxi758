using System.Collections.Generic;
using tp03_2021.Entities;
using tp03_2021.ViewModels;

namespace tp03_2021.Interfaces
{
    public interface IRepoPedido
    {
        void CreatePedido(PedidoPostViewModel pedidoVM);
        void DeletePedido(int id);
        List<PedidoGetViewModel> getAll();
        Pedido getPedidoById(int id);
        void UpdatePedido(PedidoPostViewModel pedidoVM);
        public int CantidadPedidoPorCliente(int id);
    }
}