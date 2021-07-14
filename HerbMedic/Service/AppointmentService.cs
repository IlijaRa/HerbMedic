using Classes.Model;
using System.Collections.Generic;
using System;
using Classes.Repository;

namespace Classes.Service
{
   public class AppointmentService
   {
      AppointmentRepository appointmentRepository = new AppointmentRepository();
      
      public string CreateAppointment(Appointment appointment)
      {
            string message = "";
            if (CheckIfDateIsOK(appointment))
                message = appointmentRepository.CreateAppointment(appointment);
            else
                message = "NOT SUCCEEDED";
            return message;
      }

        public bool CheckIfDateIsOK(Appointment appoint)
        {
            bool isDateOK = true;           // flag da li je dobro unet datum

            DateTime dt1 = appoint.date; // u dt1 je datum kada je renoviranje
            DateTime dt2 = DateTime.Now;    // u dt2 je trenutni datum

            //provera da li je datum koje je unet vec prosao
            if (dt1.Date < dt2.Date)
            {
                isDateOK = false;
            }

            //provera da li je vreme kraja termina pre vremena pocetka termina
            else if (appoint.startTime > appoint.endTime)
            {
                isDateOK = false;
            }
            return isDateOK;
        }

        public Appointment ReadAppointment(int appointmentId)
      {
         throw new NotImplementedException();
      }
      
      public string UpdateAppointment(Appointment appointment)
      {
            string message = "";
            if (CheckIfDateIsOK(appointment))
                message = appointmentRepository.UpdateAppointment(appointment);
            else
                message = "NOT SUCCEEDED";
            return message;
      }

        public string DeleteAppointment(int appointmentId, string username)
        {
            return appointmentRepository.DeleteAppointment(appointmentId, username);
        }

        public void readAllAppointments()
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
   }
}