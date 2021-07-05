using System;

namespace Classes.Model
{
   public class Secretary : Employee
   {
      public System.Collections.Generic.List<RequestForNews> requestForNews;

      public System.Collections.Generic.List<MedicalRecord> medicalRecord;
      
      public System.Collections.Generic.List<Appointment> appointment;
   }
}