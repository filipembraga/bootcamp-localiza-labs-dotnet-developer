using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursoAPI.Models.Users
{
    public class LoginViewModelInput
    {
        [Required(ErrorMessage = "O Login é obrigatório")]
        public string Login { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Password { get; set; }
    }
}
