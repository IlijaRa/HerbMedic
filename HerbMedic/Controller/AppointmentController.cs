using Classes.Model;
using System.Collections.Generic;
using System;
using Classes.Service;

namespace Classes.Controller
{
   public class AppointmentController
   {
      AppointmentService appointmentService = new AppointmentService();
      
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
         return appointmentService.readAllAppointments();
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