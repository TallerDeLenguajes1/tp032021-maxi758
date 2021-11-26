using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using tp03_2021.Entities;
using tp03_2021.Interfaces;

namespace tp03_2021.Models
{
    public class RepoUsuario : IRepoUsuario
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
            using (SQLiteConnection connection = new SQLiteConnection(_conectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Usuarios(nombre, password) values(@nombre, @password)";
                command.Parameters.AddWithValue("@nombre", usuario.Username);
                command.Parameters.AddWithValue("@password", usuario.Password);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public Usuario Login(Usuario usuario)
        {
            Usuario userData = new Usuario();
            using (SQLiteConnection connection = new SQLiteConnection(_conectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT usuarioId, nombre, password FROM  Usuarios WHERE nombre=@nombre AND password=@password";
                command.Parameters.AddWithValue("@nombre", usuario.Username);
                command.Parameters.AddWithValue("@password", usuario.Password);
                SQLiteDataReader dataReader = command.ExecuteReader();

                if (!dataReader.HasRows) return null;

                dataReader.Read();

                userData.Username = dataReader["nombre"].ToString();
                userData.Password = dataReader["password"].ToString();
                userData.Id = Convert.ToInt32(dataReader["usuarioId"]);

                dataReader.Close();
                connection.Close();
            }
            return userData;
        }
    }
}
