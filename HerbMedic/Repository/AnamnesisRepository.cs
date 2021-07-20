using Classes.Model;
using System.Collections.Generic;
using System;
using System.IO;
using Newtonsoft.Json;

namespace Classes.Repository
{
   public class AnamnesisRepository
   {
        List<MedicalRecord> medicalRecords = new List<MedicalRecord>();

        public AnamnesisRepository()
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

      public string CreateAnamnesis(Anamnesis anamnesis)
      {
            string message = "NOT SUCCEEDED";
            foreach(var med in medicalRecords)
            {
                if (med.patient == anamnesis.patientName)
                {
                    med.anamnesis.Add(anamnesis);
                    writeInJson();
                    message = "SUCCEEDED";
                    break;
                }
            }

            return message;
      }

        public List<Anamnesis> ReadAnamnesisByNameSurname(string fullName)
        {
            List<Anamnesis> anamnesis = new List<Anamnesis>();
            foreach (var med in medicalRecords)
            {
                if (med.patient == fullName)
                {
                    anamnesis = med.anamnesis;
                    break;
                }
            }
            return anamnesis;
        }

      public string UpdateAnamnesis(Anamnesis anamnesis)
      {
            string message = "NOT SUCCEEDED";
            foreach(var med in medicalRecords)
            {
                foreach(var a in med.anamnesis)
                {
                    if (a.id == anamnesis.id)
                    {
                        message = "SUCCEEDED";
                        a.title = anamnesis.title;
                        a.description = anamnesis.description;
                        a.date = anamnesis.date;
                        writeInJson();
                        break;
                    }
                }
            }
            return message;
      }
      
      public List<Anamnesis> GetAnamnesisByPatientJmbg(string patientJmbg)
      {
         throw new NotImplementedException();
      }
   
   }
}