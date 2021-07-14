using Classes.Model;
using System.Collections.Generic;
using System;
using System.IO;
using Newtonsoft.Json;

namespace Classes.Repository
{
   public class AppointmentRepository
   {
      List<Employee> employees = new List<Employee>();
        public AppointmentRepository()
        {
            readEmployeeJson();
        }
        public void readEmployeeJson()
        {
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
        public void writeInJson()
        {
            string json = JsonConvert.SerializeObject(employees, Formatting.Indented);
            File.WriteAllText("employees.json", json);
        }
      public string CreateAppointment(Appointment appointment)
      {
         string message = "NOT SUCCEEDED";
         foreach(var employee in employees)
            {
                if(employee.user.username == appointment.employeeUsername)
                {
                    employee.appointments.Add(appointment);
                    writeInJson();
                    message = "SUCCEEDED";
                }
            }
            return message;
      }

        public Appointment ReadAppointment(int appointmentId)
      {
         throw new NotImplementedException();
      }
      
      public string UpdateAppointment(Appointment appointment)
      {
            string message = "";
            var employee = employees.Find(obj => obj.user.username == appointment.employeeUsername);
            int appo = employee.appointments.FindIndex(obj => obj.id == appointment.id);
            employee.appointments[appo] = appointment;
            writeInJson();
            message = "SUCCEEDED";
            
            return message;
      }

        public string DeleteAppointment(int appointmentId, string username)
        {
            string message = "";
            var employee = employees.Find(obj => obj.user.username == username);
            int appIndex = employee.appointments.FindIndex(obj => obj.id == appointmentId);
            employee.appointments.RemoveAt(appIndex);
            writeInJson();
            message = "SUCCEEDED";
            return message;
        }

        public void readAllAppointments()// trenutno je void
      {
      }
      
      public Appointment CreateEmergency(Patient patient, string specialization)
      {
         throw new NotImplementedException();
      }
      
      public List<Appointment> ReadDoctorAppointments(int doctorId)
      {
         throw new NotImplementedException();
      }
      
      public List<Appointment> ReadPatientAppointments(int patientId)
      {
         throw new NotImplementedException();
      }
      
      public bool CheckForInvalidInput(Appointment appointment)
      {
         throw new NotImplementedException();
      }
      
      public string path;
   
   }
}