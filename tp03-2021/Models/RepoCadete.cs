using System;
using System.Collections.Generic;
using System.Data.SQLite;
using tp03_2021.Entities;
using tp03_2021.ViewModels;
using tp03_2021.Interfaces;

namespace tp03_2021.Models
{
    public class RepoCadete : IRepoCadete
    {
        private readonly string _conectionString;
        private readonly SQLiteConnection _conexion;

        public RepoCadete(string conectionString)
        {
            _conectionString = conectionString;
            //_conexion = new SQLiteConnection(conectionString);
        }
        public List<CadeteViewModel> getAll()
        {
            List<CadeteViewModel> listaDeCadetes = new List<CadeteViewModel>();
            using (SQLiteConnection connection = new SQLiteConnection(_conectionString))
            {
                connection.Open();
                string SQLiteQuery = "SELECT * FROM cadetes where activo=1";
                SQLiteCommand command = new SQLiteCommand(SQLiteQuery, connection);
                SQLiteDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    CadeteViewModel cadete = new CadeteViewModel()
                    {
                        Id = Convert.ToInt32(dataReader["cadeteID"]),
                        Nombre = dataReader["cadeteNombre"].ToString(),
                        Direccion = dataReader["cadeteDireccion"].ToString(),
                        Telefono = dataReader["cadeteTelefono"].ToString()
                    };
                    cadete.CantidadPedidos = CantidadPedidoPorCadete(cadete.Id);
                    listaDeCadetes.Add(cadete);
                }
                dataReader.Close();
                connection.Close();
            }

            return listaDeCadetes;
        }
        public Cadete getCadeteById(int id)
        {
            Cadete cadete = new Cadete();
            using (SQLiteConnection connection = new SQLiteConnection(_conectionString))
            {
                connection.Open();
                string SQLiteQuery = "SELECT * FROM Cadetes where cadeteID = @id";
                SQLiteCommand command = new SQLiteCommand(SQLiteQuery, connection);
                command.Parameters.AddWithValue("@id", id);
                SQLiteDataReader dataReader = command.ExecuteReader();
                dataReader.Read();
                cadete.Id = Convert.ToInt32(dataReader["cadeteID"]);
                cadete.Nombre = dataReader["cadeteNombre"].ToString();
                cadete.Direccion = dataReader["cadeteDireccion"].ToString();
                cadete.Telefono = dataReader["cadeteTelefono"].ToString();
                cadete.CadeteriaId = Convert.ToInt32(dataReader["cadeteriaId"]);

                dataReader.Close();
                connection.Close();
            }

            return cadete;
        }
        public void CreateCadete(CadeteViewModel cadete)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_conectionString))
            {
                connection.Open();
                string SQLiteQuery = "INSERT INTO Cadetes(cadeteNombre, cadeteDireccion, cadeteTelefono, cadeteriaId, activo) values(@nombre, @direccion, @telefono, @cadeteriaId, @activo); ";
                SQLiteCommand command = new SQLiteCommand(SQLiteQuery, connection);
                command.Parameters.AddWithValue("@nombre", cadete.Nombre);
                command.Parameters.AddWithValue("@cadeteriaId", cadete.CadeteriaId);
                command.Parameters.AddWithValue("@direccion", cadete.Direccion);
                command.Parameters.AddWithValue("@telefono", cadete.Telefono);
                command.Parameters.AddWithValue("@activo", 1);
                command.ExecuteNonQuery();
                connection.Close();
            }

        }
        public void UpdateCadete(CadeteViewModel cadete)
        {
            using SQLiteConnection connection = new SQLiteConnection(_conectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "UPDATE Cadetes SET cadeteNombre = @nombre, cadeteDireccion = @direccion, " +
                "cadeteTelefono = @telefono, cadeteriaId = @cadeteriaId WHERE cadeteID = @id";
            command.Parameters.AddWithValue("@id", cadete.Id);
            command.Parameters.AddWithValue("@cadeteriaId", cadete.CadeteriaId);
            command.Parameters.AddWithValue("@nombre", cadete.Nombre);
            command.Parameters.AddWithValue("@direccion", cadete.Direccion);
            command.Parameters.AddWithValue("@telefono", cadete.Telefono);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteCadete(int id)
        {
            using SQLiteConnection connection = new SQLiteConnection(_conectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "UPDATE Cadetes SET Activo = 0 WHERE cadeteID = @id";
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public int CantidadPedidoPorCadete(int id)
        {
            int cantidad = 0;
            using (SQLiteConnection connection = new SQLiteConnection(_conectionString))
            {
                connection.Open();
                string SQLiteQuery = "SELECT Count(P.pedidoId) FROM Pedidos P inner join Cadetes C on P.cadeteId = C.cadeteId where C.cadeteId = @id";
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