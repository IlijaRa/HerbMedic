using Classes.Model;
using System.Collections.Generic;
using System;
using Classes.Service;
namespace Classes.Controller
{
   public class PrescriptionController
   {
        PrescriptionService prescriptionService = new PrescriptionService();
      public string CreatePrescription(Prescription prescription)
      {
            return prescriptionService.CreatePrescription(prescription);
      }

        public string UpdatePrescription(Prescription prescription)
        {
            return prescriptionService.UpdatePrescription(prescription);
        }

        public List<Prescription> ReadPatientPrescriptions(string patientsFullname)
        {
            return prescriptionService.ReadPatientPrescriptions(patientsFullname);
        }

        public Prescription GetPrescriptionById(int prescriptionId)
      {
         throw new NotImplementedException();
      }
      
      public List<Prescription> GetPrescriptionsByPatientJmbg(string patientJmbg)
      {
         throw new NotImplementedException();
      }
   }
}