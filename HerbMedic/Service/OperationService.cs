using Classes.Model;
using System.Collections.Generic;
using System;

namespace Classes.Service
{
   public class OperationService : CreatingAppointmentBehavior
   {
      public void Create(Classes.Model.Appointment appointment)
      {
         throw new NotImplementedException();
      }
      
      public Classes.Repository.OperationsRepository operationsRepository;
   
   }
}