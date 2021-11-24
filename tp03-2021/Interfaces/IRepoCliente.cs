using System.Collections.Generic;
using tp03_2021.Entities;

namespace tp03_2021.Interfaces
{
    public interface IRepoCliente
    {
        void CreateCliente(Cliente cliente);
        void DeleteCliente(int id);
        List<Cliente> getAll();
        Cliente getClienteById(int id);
        void UpdateCliente(Cliente cliente);
    }
}