using Classes.Model;
using System.Collections.Generic;
using System;

namespace Classes.Service
{
   public class EmergencyAppointmentService : CreatingAppointmentBehavior
   {
      public void Create(Classes.Model.Appointment appointment)
      {
         throw new NotImplementedException();
      }
      
      public Classes.Repository.EmergencyAppointmentRepository emergencyAppointmentRepository;
   
   }
}