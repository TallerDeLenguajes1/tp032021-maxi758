using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp03_2021.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Rol { get; set; }
        public Usuario()
        {
        }

        public Usuario(string nickname, string password, string email)
        {
            Username = nickname;
            Password = password;
            Email = email;
        }

    }
}
