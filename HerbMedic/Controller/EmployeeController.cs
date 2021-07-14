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
      
      public Employee ReadEmployee(int employeeId)
      {
         throw new NotImplementedException();
      }

        public List<Appointment> ReadAppointmentsByUsername(string username)
        {
            return employeeService.ReadAppointmentsByUsername(username);
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