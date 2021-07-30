using Classes.Model;
using System.Collections.Generic;
using System;
using Classes.Service;
namespace Classes.Controller
{
   public class EmployeeController
   {
      EmployeeService employeeService = new EmployeeService();
      public List<Doctor> GetDoctorBySpecialization(string specialization)
      {
         throw new NotImplementedException();
      }
      
      public Employee FindEmployeeByUsername(string username)
      {
            return employeeService.FindEmployeeByUsername(username);
      }

      public Employee CreateEmployee(Employee employee)
      {
         throw new NotImplementedException();
      }
      
        public bool CheckIfDoctorIsAvailable(Appointment appointment)
        {
            return employeeService.CheckIfDoctorIsAvailable(appointment);
        }

      public Employee ReadEmployee(int employeeId)
      {
         throw new NotImplementedException();
      }

        public List<Appointment> ReadAppointmentsByUsername(string username)
        {
            return employeeService.ReadAppointmentsByUsername(username);
        }

        public List<Appointment> ReadTermsOfDoctorByNameSurname(string doctorsNameSurname)
        {
            return employeeService.ReadTermsOfDoctorByNameSurname(doctorsNameSurname);
        }

        public Employee ReadSecretary()
        {
            return employeeService.ReadSecretary();
        }

        public List<Appointment> ReadOperationsByUsername(string username)
        {
            return employeeService.ReadOperationsByUsername(username);
        }

        public List<Appointment> ReadAllDutiesByUsername(string username)
        {
            return employeeService.ReadAllDutiesByUsername(username);
        }

        public User ReadEmployeeUserByUsername(string username)
        {
            return employeeService.ReadEmployeeUserByUsername(username);
        }

        public Employee ReadEmployeeByNameSurname(string nameSurname)
        {
            return employeeService.ReadEmployeeByNameSurname(nameSurname);
        }

        public string ReadEmployeesRoomByUsername(string username)
        {
            return employeeService.ReadEmployeesRoomByUsername(username);
        }

        public List<Employee> ReadAllDoctors()
        {
            return employeeService.ReadAllDoctors();
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