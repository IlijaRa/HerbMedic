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

        public bool CheckIfDoctorIsAvailable(Appointment appointment)
        {
            bool isAvailable = true;
            string start = appointment.startTime.ToString("HH:mm");
            string end = appointment.endTime.ToString("HH:mm");
            string enteredDate = appointment.date.ToString("M/dd/yyyy");

            List<Employee> doctors = employeeRepository.ReadAllDoctors();
            foreach (var d in doctors)
            {
                if (d.user.username == appointment.employeeUsername)
                {
                    foreach (var a in d.appointments)
                    {
                        string appDate = a.date.ToString("M/dd/yyyy");
                        if (appDate.Equals(enteredDate))
                        {
                            string appStart = a.startTime.ToString("HH:mm");
                            if (appStart.Equals(start))
                            {
                                isAvailable = false;
                            }   
                        }
                    }
                }
            }
            return isAvailable;
        }

        public Employee ReadEmployee(int employeeId)
      {
         throw new NotImplementedException();
      }

        public List<Appointment> ReadAppointmentsByUsername(string username)
        {
            return employeeRepository.ReadAppointmentsByUsername(username);
        }

        public List<Appointment> ReadTermsOfDoctorByNameSurname(string doctorsNameSurname)
        {
            return employeeRepository.ReadTermsOfDoctorByNameSurname(doctorsNameSurname);
        }

        public Employee ReadSecretary()
        {
            return employeeRepository.ReadSecretary();
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

        public Employee ReadEmployeeByNameSurname(string nameSurname)
        {
            return employeeRepository.ReadEmployeeByNameSurname(nameSurname);
        }

        public string ReadEmployeesRoomByUsername(string username)
        {
            return employeeRepository.ReadEmployeesRoomByUsername(username);
        }

        public List<Employee> ReadAllDoctors()
        {
            return employeeRepository.ReadAllDoctors();
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