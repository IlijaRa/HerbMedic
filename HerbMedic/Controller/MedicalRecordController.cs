using Classes.Model;
using System.Collections.Generic;
using System;
using Classes.Service;
namespace Classes.Controller
{
   public class MedicalRecordController
   {
        MedicalRecordService medicalRecordService = new MedicalRecordService();

      public bool CreateMedicalRecord(MedicalRecord medicalRecord)
      {
          return medicalRecordService.CreateMedicalRecord(medicalRecord);
      }

        public bool CheckIfPatientHasMedicalRecord(string nameSurname)
        {
            return medicalRecordService.CheckIfPatientHasMedicalRecord(nameSurname);
        }

        public MedicalRecord UpdateMedicalRecord(MedicalRecord medicalRecord)
      {
         throw new NotImplementedException();
      }
      
      public MedicalRecord GetMedicalRecordById(int id)
      {
         throw new NotImplementedException();
      }
      
      public void removeMR(int id)
      {
         throw new NotImplementedException();
      }
      
      public List<MedicalRecord> ReadAllMedicalRecords()
      {
            return medicalRecordService.ReadAllMedicalRecords();
      }
   }
}