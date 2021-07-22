using Classes.Model;
using System.Collections.Generic;
using System;
using Classes.Repository;

namespace Classes.Service
{
   public class PrescriptionService
   {
        PrescriptionRepository prescriptionRepository = new PrescriptionRepository();
      public string CreatePrescription(Prescription prescription)
      {
            return prescriptionRepository.CreatePrescription(prescription);
      }

        public string UpdatePrescription(Prescription prescription)
        {
            return prescriptionRepository.UpdatePrescription(prescription);
        }

        public List<Prescription> ReadPatientPrescriptions(string patientsFullname)
        {
            return prescriptionRepository.ReadPatientPrescriptions(patientsFullname);
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