using Classes.Model;
using System.Collections.Generic;
using System;
using System.IO;
using Newtonsoft.Json;

namespace Classes.Repository
{
   public class AllergenRepository
   {
        List<MedicalRecord> medicalRecords = new List<MedicalRecord>();

        public AllergenRepository()
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

        public string CreateAllergen(string patientName, Allergen allergenName)
        {
            string message = "NOT SUCCEEDED";
            foreach (var med in medicalRecords)
            {
                if (med.patient == patientName)
                {
                    med.allergens.Add(allergenName);
                    writeInJson();
                    message = "SUCCEEDED";
                    break;
                }
            }

            return message;

        }

        public string DeleteAllergen(string patientName, Allergen allergen)
        {
            string message = "NOT SUCCEEDED";
            foreach (var med in medicalRecords)
            {
                if (med.patient == patientName)
                {
                    foreach(var a in med.allergens)
                    {
                        if(a.name == allergen.name)
                        {
                            med.allergens.Remove(allergen);
                            writeInJson();
                            message = "SUCCEEDED";
                            break;
                        }
                    }
                }
            }

            return message;

        }

        public List<Allergen> ReadAllergenByNameSurname(string fullName)
        {
            List<Allergen> allergens = new List<Allergen>();
            foreach (var med in medicalRecords)
            {
                if (med.patient == fullName)
                {
                    allergens = med.allergens;
                    break;
                }
            }
            return allergens;
        }

        public Allergen UpdateAllergen(string name, DateTime date)
      {
         throw new NotImplementedException();
      }
      
      public List<Allergen> GetAllAlergens(int patientId)
      {
         throw new NotImplementedException();
      }
   
   }
}