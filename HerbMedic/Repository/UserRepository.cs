using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Model;
using Newtonsoft.Json;

namespace Classes.Repository
{
    public class UserRepository
    {
        public List<User> users = new List<User>();
        public UserRepository(){
            readUsersJson();
        }

        public void readUsersJson()
        {
            // deserializuje renovation.json
            if (!File.Exists("users.json"))
            {
                File.Create("users.json").Close();
            }

            using (StreamReader r = new StreamReader("users.json"))
            {
                string json = r.ReadToEnd();
                if (json != "")
                {
                    users = JsonConvert.DeserializeObject<List<User>>(json);
                }
            }
        }
        public bool CheckUserCredentials(string username, string password)
        {
            bool isCredentialsOK = false;
            foreach(var user in users)
            {
                if (user.username == username && user.password == password)
                {
                    isCredentialsOK = true;
                }
            }
            return isCredentialsOK;
        }

        public User ReadUserByUsername(string username)
        {
            User transferUser = new User();
            foreach(var user in users)
            {
                if(user.username == username)
                {
                    transferUser = user;
                }
            }
            return transferUser;
        }
    }
}
