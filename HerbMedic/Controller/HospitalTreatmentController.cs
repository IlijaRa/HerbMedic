using Classes.Model;
using System.Collections.Generic;
using System;
using Classes.Service;
namespace Classes.Controller
{
   public class HospitalTreatmentController
   {
      public HospitalTreatment CreateHospitalTreatment(HospitalTreatment hospitalTreatment)
      {
         throw new NotImplementedException();
      }
      
      public HospitalTreatment ReadHospitalTreatmentById(int hospitalTreatmentId)
      {
         throw new NotImplementedException();
      }
      
      public void ExtendHospitalTreatment(int hospitalTreatmentId, int numberOfDays)
      {
         throw new NotImplementedException();
      }
      
      public List<HospitalTreatment> GetHospitalTreatmentsByPatientJmbg(string patientJmbg)
      {
         throw new NotImplementedException();
      }
      
      public Classes.Service.HospitalTreatmentService hospitalTreatmentService;
   
   }
}