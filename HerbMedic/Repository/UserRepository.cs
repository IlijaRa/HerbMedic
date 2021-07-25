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
        public List<Employee> employees = new List<Employee>();
        public List<Patient> patients = new List<Patient>();
        public UserRepository()
        {
            readEmployeeJson();
            readPatientJson();
        }
        public void readEmployeeJson()
        {
            // deserializuje renovation.json
            if (!File.Exists("employees.json"))
            {
                File.Create("employees.json").Close();
            }

            using (StreamReader r = new StreamReader("employees.json"))
            {
                string json = r.ReadToEnd();
                if (json != "")
                {
                    employees = JsonConvert.DeserializeObject<List<Employee>>(json);
                }
            }
        }

        public void readPatientJson()
        {
            // deserializuje renovation.json
            if (!File.Exists("patients.json"))
            {
                File.Create("patients.json").Close();
            }

            using (StreamReader r = new StreamReader("patients.json"))
            {
                string json = r.ReadToEnd();
                if (json != "")
                {
                    patients = JsonConvert.DeserializeObject<List<Patient>>(json);
                }
            }
        }

        public bool CheckUserCredentials(string username, string password)
        {
            bool isCredentialsOK = false;
            foreach(var e in employees)
            {
                if (e.user.username == username && e.user.password == password)
                {
                    isCredentialsOK = true;
                }
            }

            if (!isCredentialsOK)
            {
                foreach (var p in patients)
                {
                    if (p.user.username == username && p.user.password == password)
                    {
                        isCredentialsOK = true;
                    }
                }
            }
            return isCredentialsOK;
        }

        public User ReadUserByUsername(string username)
        {
            User transferUser = new User();
            bool flag = false; // to see if transferUser found in employees, if not check in patients
            foreach(var e in employees)
            {
                if(e.user.username == username)
                {
                    transferUser= e.user;
                    flag = true;
                }
            }
            if (!flag)
            {
                foreach (var p in patients)
                {
                    if (p.user.username == username)
                    {
                        transferUser = p.user;
                        flag = true;
                    }
                }
            }
            return transferUser;
        }
    }
}
