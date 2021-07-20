using Classes.Model;
using System.Collections.Generic;
using System;
using Classes.Repository;

namespace Classes.Service
{
   public class EmployeeService
   {
        EmployeeRepository employeeRepository = new EmployeeRepository();
      public List<Doctor> GetDoctorBySpecialization(string specialization)
      {
         throw new NotImplementedException();
      }

        public Employee FindEmployeeByUsername(string username)
        {
            return employeeRepository.FindEmployeeByUsername(username);
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
            return employeeRepository.ReadAppointmentsByUsername(username);
        }

        public List<Appointment> ReadOperationsByUsername(string username)
        {
            return employeeRepository.ReadOperationsByUsername(username);
        }

        public List<Appointment> ReadAllDutiesByUsername(string username)
        {
            return employeeRepository.ReadAllDutiesByUsername(username);
        }

        public User ReadEmployeeUserByUsername(string username)
        {
            return employeeRepository.ReadEmployeeUserByUsername(username);
        }

        public string ReadEmployeesRoomByUsername(string username)
        {
            return employeeRepository.ReadEmployeesRoomByUsername(username);
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