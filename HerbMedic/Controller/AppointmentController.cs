using Classes.Model;
using System.Collections.Generic;
using System;
using Classes.Service;

namespace Classes.Controller
{
   public class AppointmentController
   {
      AppointmentService appointmentService = new AppointmentService();
      
      public string CreateAppointment(Appointment appointment)
      {
            return appointmentService.CreateAppointment(appointment);
      }
     

      public Appointment ReadAppointment(int appointmentId)
      {
         throw new NotImplementedException();
      }
      
      public string UpdateAppointment(Appointment appointment)
      {
         return appointmentService.UpdateAppointment(appointment);
      }
      
      public string DeleteAppointment(int appointmentId,string username)
      {
            return appointmentService.DeleteAppointment(appointmentId, username);
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