using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using tp03_2021.Entities;

namespace tp03_2021.Models
{
    public class RepoUsuario
    {
        private readonly string _conectionString;
        private readonly SQLiteConnection _conexion;

        public RepoUsuario(string conectionString)
        {
            _conectionString = conectionString;
            //_conexion = new SQLiteConnection(conectionString);
        }

        public void Register(Usuario usuario)
        {
            using(SQLiteConnection connection = new SQLiteConnection(_conectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Usuarios(nombre, password) values(@nombre, @password)";
                command.Parameters.AddWithValue("@nombre", usuario.Nickname);
                command.Parameters.AddWithValue("@password", usuario.Password);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Login(Usuario usuario)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_conectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT usuarioId, nombre, password FROM  Usuarios WHERE nombre=@nombre AND password=@password";
                command.Parameters.AddWithValue("@nombre", usuario.Nickname);
                command.Parameters.AddWithValue("@password", usuario.Password);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
