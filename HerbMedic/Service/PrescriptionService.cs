using Classes.Model;
using System.Collections.Generic;
using System;

namespace Classes.Service
{
   public class PrescriptionService
   {
      public Classes.Model.Prescription AddPrescription(int id, string medicine, string usage, string quantity)
      {
         throw new NotImplementedException();
      }
      
      public Classes.Model.Prescription GetPrescriptionById(int prescriptionId)
      {
         throw new NotImplementedException();
      }
      
      public List<Prescription> GetPrescriptionsByPatientJmbg(string patientJmbg)
      {
         throw new NotImplementedException();
      }
      
      public Classes.Repository.PrescriptionRepository prescriptionRepository;
   
   }
}