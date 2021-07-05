using Classes.Model;
using System.Collections.Generic;
using System;

namespace Classes.Service
{
   public class RegularAppointmentService : CreatingAppointmentBehavior
   {
      public void Create(Classes.Model.Appointment appointment)
      {
         throw new NotImplementedException();
      }
      
      public Classes.Repository.RegularAppointmentRepository regularAppointmentRepository;
   
   }
}