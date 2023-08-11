using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationAndAuthorization
{
    internal class UserModel
    {
        public string Username { get; }
        public string Email { get; }

        public UserModel(string username, string email)
            {
                Username = username;
                Email = email;
            }
    }
}
