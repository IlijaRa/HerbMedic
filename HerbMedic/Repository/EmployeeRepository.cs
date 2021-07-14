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
        public EmployeeRepository()
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

      public Employee CreateEmployee(Employee employee)
      {
         throw new NotImplementedException();
      }
      
      public Employee ReadEmployee(int employeeId)
      {
         throw new NotImplementedException();
      }

        public List<Appointment> ReadAppointmentsByUsername(string username)
        {
            List<Appointment> appoints = new List<Appointment>();
            var employee = employees.Find(obj => obj.user.username == username);
            appoints = employee.appointments.FindAll(obj => obj.appointmentType == "Examination");
            return appoints;
        }

        public List<Appointment> ReadOperationsByUsername(string username)
        {
            List<Appointment> appoints = new List<Appointment>();
            var employee = employees.Find(obj => obj.user.username == username);
            appoints = employee.appointments.FindAll(obj => obj.appointmentType == "Operation");
            return appoints;
        }

        public User ReadEmployeeUserByUsername(string username)
        {
            User user = new User();
            foreach(var employee in employees)
            {
                if (employee.user.username == username)
                    user = employee.user;
            }

            return user;
        }

        public string ReadEmployeesRoomByUsername(string username)
        {
            string room = "";
            foreach(var employee in employees)
            {
                if (employee.user.username == username)
                    room = employee.room;
            }
            return room;
        }

        public Employee UpdateEmployee(Employee employee)
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
      
      public Boolean MarkOffDaysForDoctor(TimeSpan parameter1, string explanation, Boolean onOffDays)
      {
         throw new NotImplementedException();
      }
   
   }
}