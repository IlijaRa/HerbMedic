using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Model;
using Classes.Repository;

namespace Classes.Service
{
    public class UserService
    {
        UserRepository userRepository = new UserRepository();
        public bool CheckUserCredentials(string username, string password)
        {
            return userRepository.CheckUserCredentials(username, password);
        }

        public User ReadUserByUsername(string username)
        {
            return userRepository.ReadUserByUsername(username);
        }
    }
}
