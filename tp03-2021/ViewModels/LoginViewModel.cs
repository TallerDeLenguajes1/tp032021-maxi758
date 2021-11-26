using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tp03_2021.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(8, MinimumLength = 8,
            ErrorMessage = "La contraseña debe contener 8 caracteres")]
        public string Password { get; set; }

    }
}
