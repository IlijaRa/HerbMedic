using Classes.Model;
using System.Collections.Generic;
using System;
using System.IO;
using Newtonsoft.Json;

namespace Classes.Repository
{
   public class EmployeeRepository
   {
        public List<Employee> employees = new List<Employee>();
        EmployeeRepository()
        {
            readEmployeeJson();
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
        public List<Doctor> GetDoctorBySpecialization(string specialization)
      {
         throw new NotImplementedException();
      }

        public Employee FindEmployeeByUsername(string username)
        {
            Employee employee = new Employee();
            int index = employees.FindIndex(obj => obj.user.username == username);
            employee = employees[index];
            return employee;
        }

        public Classes.Model.Employee CreateEmployee(Classes.Model.Employee employee)
      {
         throw new NotImplementedException();
      }
      
      public Classes.Model.Employee ReadEmployee(int employeeId)
      {
         throw new NotImplementedException();
      }
      
      public Classes.Model.Employee UpdateEmployee(Classes.Model.Employee employee)
      {
         throw new NotImplementedException();
      }
      
      public void DeleteEmployeeById(int employeeId)
      {
         throw new NotImplementedException();
      }
      
      public List<Employee> ReadAllEmployees()
      {
         throw new NotImplementedException();
      }
      
      public Boolean MarkOffDaysForDoctor(System.TimeSpan parameter1, string explanation, Boolean onOffDays)
      {
         throw new NotImplementedException();
      }
   
   }
}