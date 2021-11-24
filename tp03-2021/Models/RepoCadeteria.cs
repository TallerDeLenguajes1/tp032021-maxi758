using System;
using System.Collections.Generic;
using System.Data.SQLite;
using tp03_2021.Entities;
using tp03_2021.Interfaces;

namespace tp03_2021.Models
{
    public class RepoCadeteria : IRepoCadeteria
    {
        private readonly string _conectionString;
        private readonly SQLiteConnection _conexion;

        public RepoCadeteria(string conectionString)
        {
            _conectionString = conectionString;
            //_conexion = new SQLiteConnection(conectionString);
        }
        public List<Cadeteria> getAll()
        {
            List<Cadeteria> listaDeCadeterias = new List<Cadeteria>();
            using (SQLiteConnection connection = new SQLiteConnection(_conectionString))
            {
                connection.Open();
                string SQLiteQuery = "SELECT * FROM Cadeteria where activo=1";
                SQLiteCommand command = new SQLiteCommand(SQLiteQuery, connection);
                SQLiteDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Cadeteria cadeteria = new Cadeteria()
                    {
                        Id = Convert.ToInt32(dataReader["cadeteriaID"]),
                        Nombre = dataReader["cadeteriaNombre"].ToString(),

                    };
                    listaDeCadeterias.Add(cadeteria);
                }
                dataReader.Close();
                connection.Close();
            }

            return listaDeCadeterias;
        }
        public Cadeteria getCadeteriaById(int id)
        {
            Cadeteria cadeteria = new Cadeteria();
            using (SQLiteConnection connection = new SQLiteConnection(_conectionString))
            {
                connection.Open();
                string SQLiteQuery = "SELECT * FROM Cadeteria where cadeteriaID = @id";
                SQLiteCommand command = new SQLiteCommand(SQLiteQuery, connection);
                command.Parameters.AddWithValue("@id", id);
                SQLiteDataReader dataReader = command.ExecuteReader();
                dataReader.Read();
                cadeteria.Id = Convert.ToInt32(dataReader["pedidoID"]);
                cadeteria.Nombre = dataReader["cadeteriaNombre"].ToString();

                dataReader.Close();
                connection.Close();
            }

            return cadeteria;
        }
        public void CreateCadeteria(Cadeteria cadeteria)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_conectionString))
            {
                connection.Open();
                string SQLiteQuery = "INSERT INTO Cadeteria(cadeteriaNombre, activo) values(@nombre, @activo); ";
                SQLiteCommand command = new SQLiteCommand(SQLiteQuery, connection);
                command.Parameters.AddWithValue("@nombre", cadeteria.Nombre);
                command.Parameters.AddWithValue("@activo", 1);
                command.ExecuteNonQuery();
                connection.Close();
            }

        }
        public void UpdateCadeteria(Cadeteria cadeteria)
        {
            using SQLiteConnection connection = new SQLiteConnection(_conectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "UPDATE Cadeteria SET cadeteriaNombre = @nombre" +
                                  " WHERE cadeteriaID = @Id";
            command.Parameters.AddWithValue("@pId", cadeteria.Id);
            command.Parameters.AddWithValue("@nombre", cadeteria.Nombre);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteCadeteria(int id)
        {
            using SQLiteConnection connection = new SQLiteConnection(_conectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "UPDATE Cadeteria SET Activo = 0 WHERE cadeteriaID = @id";
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
