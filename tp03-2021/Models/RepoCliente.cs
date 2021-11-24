using System;
using System.Collections.Generic;
using System.Data.SQLite;
using tp03_2021.Entities;
using tp03_2021.Interfaces;

namespace tp03_2021.Models
{
    public class RepoCliente : IRepoCliente
    {
        private readonly string _conectionString;
        private readonly SQLiteConnection _conexion;

        public RepoCliente(string conectionString)
        {
            _conectionString = conectionString;
            //_conexion = new SQLiteConnection(conectionString);
        }
        public List<Cliente> getAll()
        {
            List<Cliente> listaDeClientes = new List<Cliente>();
            using (SQLiteConnection connection = new SQLiteConnection(_conectionString))
            {
                connection.Open();
                string SQLiteQuery = "SELECT * FROM Clientes where activo=1";
                SQLiteCommand command = new SQLiteCommand(SQLiteQuery, connection);
                SQLiteDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Cliente cliente = new Cliente()
                    {
                        Id = Convert.ToInt32(dataReader["clienteID"]),
                        Nombre = dataReader["clienteNombre"].ToString(),
                        Direccion = dataReader["clienteDireccion"].ToString(),
                        Telefono = dataReader["clienteTelefono"].ToString()
                    };
                    listaDeClientes.Add(cliente);
                }
                dataReader.Close();
                connection.Close();
            }

            return listaDeClientes;
        }
        public Cliente getClienteById(int id)
        {
            Cliente cliente = new Cliente();
            using (SQLiteConnection connection = new SQLiteConnection(_conectionString))
            {
                connection.Open();
                string SQLiteQuery = "SELECT * FROM Clientes where clienteID = @id";
                SQLiteCommand command = new SQLiteCommand(SQLiteQuery, connection);
                command.Parameters.AddWithValue("@id", id);
                SQLiteDataReader dataReader = command.ExecuteReader();
                dataReader.Read();
                cliente.Id = Convert.ToInt32(dataReader["clienteID"]);
                cliente.Nombre = dataReader["clienteNombre"].ToString();
                cliente.Direccion = dataReader["clienteDireccion"].ToString();
                cliente.Telefono = dataReader["clienteTelefono"].ToString();

                dataReader.Close();
                connection.Close();
            }

            return cliente;
        }
        public void CreateCliente(Cliente cliente)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_conectionString))
            {
                connection.Open();
                string SQLiteQuery = "INSERT INTO Clientes(clienteNombre, clienteDireccion, clienteTelefono, activo) values(@nombre, @direccion, @telefono, @activo); ";
                SQLiteCommand command = new SQLiteCommand(SQLiteQuery, connection);
                command.Parameters.AddWithValue("@nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@direccion", cliente.Direccion);
                command.Parameters.AddWithValue("@telefono", cliente.Telefono);
                command.Parameters.AddWithValue("@activo", 1);
                command.ExecuteNonQuery();
                connection.Close();
            }

        }
        public void UpdateCliente(Cliente cliente)
        {
            using SQLiteConnection connection = new SQLiteConnection(_conectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "UPDATE Clientes SET clienteNombre = @nombre, clienteDireccion = @direccion, " +
                "clienteTelefono = @telefono  WHERE clienteID = @id";
            command.Parameters.AddWithValue("@id", cliente.Id);
            command.Parameters.AddWithValue("@nombre", cliente.Nombre);
            command.Parameters.AddWithValue("@direccion", cliente.Direccion);
            command.Parameters.AddWithValue("@telefono", cliente.Telefono);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteCliente(int id)
        {
            using SQLiteConnection connection = new SQLiteConnection(_conectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "UPDATE Clientes SET Activo = 0 WHERE clienteID = @id";
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}

