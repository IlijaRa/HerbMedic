using Classes.Model;
using System.Collections.Generic;
using System;
using Classes.Repository;

namespace Classes.Service
{
   public class MedicalRecordService
   {
        MedicalRecordRepository medicalRecordRepository = new MedicalRecordRepository();

      public bool CreateMedicalRecord(MedicalRecord medicalRecord)
      {
           return medicalRecordRepository.CreateMedicalRecord(medicalRecord);
      }

        public bool CheckIfPatientHasMedicalRecord(string nameSurname)
        {
            bool isExist = false;
            List<MedicalRecord> medicalRecords = medicalRecordRepository.ReadAllMedicalRecords();
            foreach (var m in medicalRecords)
            {
                if (m.patient == nameSurname)
                    isExist = true;
            }
            return isExist;
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
            return medicalRecordRepository.ReadAllMedicalRecords();
      }
   }
}