using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoAPI.Models.Users
{
    public class LoginViewModelOutput
    {
        public string Token { get; set; }

        public UserViewModelOutput User { get; set; }
    }
}
