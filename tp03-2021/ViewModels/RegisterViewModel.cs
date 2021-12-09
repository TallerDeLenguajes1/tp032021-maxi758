using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tp03_2021.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(8, MinimumLength = 8,
            ErrorMessage = "La contraseña debe contener 8 caracteres")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Compare(nameof(Password), ErrorMessage = "Contraseñas no coinciden")]
        public string VerifyPassword { get; set; }
    }
}
