using Classes.Model;
using System.Collections.Generic;
using System;
using System.IO;
using Newtonsoft.Json;

namespace Classes.Repository
{
   public class AppointmentRepository
   {
      List<Appointment> appointments = new List<Appointment>();
        public AppointmentRepository()
        {
            readAppointmentJson();
        }
        public void readAppointmentJson()
        {
            if (!File.Exists("appointments.json"))
            {
                File.Create("appointments.json").Close();
            }

            using (StreamReader r = new StreamReader("appointments.json"))
            {
                string json = r.ReadToEnd();
                if (json != "")
                {
                    appointments = JsonConvert.DeserializeObject<List<Appointment>>(json);
                }
            }
        }
        public void writeInJson()
        {
            string json = JsonConvert.SerializeObject(appointments, Formatting.Indented);
            File.WriteAllText("appointments.json", json);
        }
      public Appointment CreateAppointment(Appointment appointment, int patientId)
      {
         throw new NotImplementedException();
      }

        public Appointment ReadAppointment(int appointmentId)
      {
         throw new NotImplementedException();
      }
      
      public Appointment UpdateAppointment(Appointment appointment)
      {
         throw new NotImplementedException();
      }
      
      public void DeleteAppointment(int appointmentId)
      {
         throw new NotImplementedException();
      }
      
      public List<Appointment> readAllAppointments()
      {
         return appointments;
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