using System;
using System.Collections.Generic;
using System.Data.SQLite;
using tp03_2021.Entities;
using tp03_2021.Interfaces;
using tp03_2021.ViewModels;

namespace tp03_2021.Models
{
    public class RepoPedido : IRepoPedido
    {
        private readonly string _conectionString;
        private readonly SQLiteConnection _conexion;

        public RepoPedido(string conectionString)
        {
            _conectionString = conectionString;
            //_conexion = new SQLiteConnection(conectionString);
        }
        public List<PedidoGetViewModel> getAll()
        {
            try
            {
                List<PedidoGetViewModel> listaDePedidos = new List<PedidoGetViewModel>();
                using (SQLiteConnection connection = new SQLiteConnection(_conectionString))
                {
                    connection.Open();
                    string SQLiteQuery = "SELECT * FROM Pedidos P inner join Clientes C on P.clienteId=C.clienteId where P.activo=1";
                    SQLiteCommand command = new SQLiteCommand(SQLiteQuery, connection);
                    SQLiteDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        /*Cliente cliente = new();
                        cliente.Nombre = dataReader["Clientes.clienteNombre"].ToString();*/

                        PedidoGetViewModel pedidoVM = new PedidoGetViewModel()
                        {
                            Id = Convert.ToInt32(dataReader["pedidoID"]),
                            Observaciones = dataReader["pedidoObs"].ToString(),
                            Cliente = new Cliente { Nombre = dataReader["clienteNombre"].ToString(), Id = Convert.ToInt32(dataReader["clienteId"])},
                            EstadoPedido = (Estado)Convert.ToInt32(dataReader["pedidoEstado"]),
                            
                            //Cliente = cliente
                        };
                        pedidoVM.CantidadPedidos = CantidadPedidoPorCliente(pedidoVM.Cliente.Id);
                        listaDePedidos.Add(pedidoVM);
                    }
                    dataReader.Close();
                    connection.Close();
                }

                return listaDePedidos;
            }
            catch (Exception)
            {

                
                throw;
            }
            
        }
        public Pedido getPedidoById(int id)
        {
            Pedido pedido = new Pedido();
            using (SQLiteConnection connection = new SQLiteConnection(_conectionString))
            {
                connection.Open();
                string SQLiteQuery = "SELECT * FROM Pedidos where pedidoID = @id";
                SQLiteCommand command = new SQLiteCommand(SQLiteQuery, connection);
                command.Parameters.AddWithValue("@id", id);
                SQLiteDataReader dataReader = command.ExecuteReader();
                dataReader.Read();
                pedido.Id = Convert.ToInt32(dataReader["pedidoID"]);
                pedido.Observaciones = dataReader["pedidoObs"].ToString();
                pedido.Cadete = new Cadete {Id = Convert.ToInt32(dataReader["cadeteId"]) };
                pedido.Cliente = new Cliente { Id = Convert.ToInt32(dataReader["clienteId"]) };

                dataReader.Close();
                connection.Close();
            }

            return pedido;
        }
        public void CreatePedido(PedidoPostViewModel pedidoVM)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_conectionString))
            {
                connection.Open();
                string SQLiteQuery = "INSERT INTO Pedidos(pedidoObs, cadeteId, clienteId, pedidoEstado, activo) values(@observ, @cadeteId, @clienteId, @estado, @activo); ";
                SQLiteCommand command = new SQLiteCommand(SQLiteQuery, connection);
                command.Parameters.AddWithValue("@observ", pedidoVM.Observaciones);
                command.Parameters.AddWithValue("@estado", Convert.ToInt32(pedidoVM.Estado));
                command.Parameters.AddWithValue("@cadeteId", pedidoVM.CadeteId);
                command.Parameters.AddWithValue("@clienteId", pedidoVM.ClienteId);
                command.Parameters.AddWithValue("@activo", 1);
                command.ExecuteNonQuery();
                connection.Close();
            }

        }
        public void UpdatePedido(PedidoPostViewModel pedidoVM)
        {
            using SQLiteConnection connection = new SQLiteConnection(_conectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "UPDATE Pedidos SET pedidoObs = @observ, cadeteID = @cadeteId, " +
                "clienteID = @clienteId , pedidoEstado = @estado WHERE pedidoID = @pedidoId";
            command.Parameters.AddWithValue("@pedidoId", pedidoVM.Id);
            command.Parameters.AddWithValue("@observ", pedidoVM.Observaciones);
            command.Parameters.AddWithValue("@estado", pedidoVM.Estado.ToString());
            command.Parameters.AddWithValue("@clienteId", pedidoVM.CadeteId);
            command.Parameters.AddWithValue("@cadeteId", pedidoVM.ClienteId);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void DeletePedido(int id)
        {
            using SQLiteConnection connection = new SQLiteConnection(_conectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "UPDATE Pedidos SET Activo = 0 WHERE pedidoID = @id";
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public int CantidadPedidoPorCliente(int id)
        {
            int cantidad = 0;
            using (SQLiteConnection connection = new SQLiteConnection(_conectionString))
            {
                connection.Open();
                string SQLiteQuery = "SELECT Count(P.pedidoId) FROM Pedidos P inner join Clientes C on P.clienteId = C.clienteId where P.clienteId = @id";
                SQLiteCommand command = new SQLiteCommand(SQLiteQuery, connection);
                command.Parameters.AddWithValue("@id", id);
                SQLiteDataReader dataReader = command.ExecuteReader();
                dataReader.Read();
                cantidad = dataReader.GetInt32(0);

                dataReader.Close();
                connection.Close();
            }

            return cantidad;
        }
    }
}

