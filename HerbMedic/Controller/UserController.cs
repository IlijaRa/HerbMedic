using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Model;
using Classes.Service;

namespace Classes.Controller
{
    public class UserController
    {
        UserService userService = new UserService();
        public bool CheckUserCredentials(string username, string password)
        {
            return userService.CheckUserCredentials(username, password);
        }

        public User ReadUserByUsername(string username)
        {
            return userService.ReadUserByUsername(username);
        }
    }
}
