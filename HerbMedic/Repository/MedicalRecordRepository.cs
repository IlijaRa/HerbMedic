using Classes.Model;
using System.Collections.Generic;
using System;
using System.IO;
using Newtonsoft.Json;

namespace Classes.Repository
{
   public class MedicalRecordRepository
   {
        List<MedicalRecord> medicalRecords = new List<MedicalRecord>();

        public MedicalRecordRepository()
        {
            readMedicalRecordJson();
        }
        public void readMedicalRecordJson()
        {
            if (!File.Exists("medicalRecords.json"))
            {
                File.Create("medicalRecords.json").Close();
            }

            using (StreamReader r = new StreamReader("medicalRecords.json"))
            {
                string json = r.ReadToEnd();
                if (json != "")
                {
                    medicalRecords = JsonConvert.DeserializeObject<List<MedicalRecord>>(json);
                }
            }
        }

        public void writeInJson()
        {
            string json = JsonConvert.SerializeObject(medicalRecords, Formatting.Indented);
            File.WriteAllText("medicalRecords.json", json);
        }

      public bool CreateMedicalRecord(MedicalRecord medicalRecord)
      {
            bool isCreated = false;
            medicalRecords.Add(medicalRecord);
            writeInJson();
            isCreated = true;
            return isCreated;
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
            return medicalRecords;
      }
      
      public string path;
   
   }
}