using Classes.Model;
using System.Collections.Generic;
using System;
using System.IO;
using Newtonsoft.Json;

namespace Classes.Repository
{
    public class MedicineRepository
    {
        List<Medicine> medicines = new List<Medicine>();

        public MedicineRepository()
        {
            readMedicineJson();
        }
      public void readMedicineJson()
      {
            if (!File.Exists("medicines.json"))
            {
                File.Create("medicines.json").Close();
            }

            using (StreamReader r = new StreamReader("medicines.json"))
            {
                string json = r.ReadToEnd();
                if (json != "")
                {
                    medicines = JsonConvert.DeserializeObject<List<Medicine>>(json);
                }
            }
        }
        public void writeInJson()
        {
            string json = JsonConvert.SerializeObject(medicines, Formatting.Indented);
            File.WriteAllText("medicines.json", json);
        }

      public string CreateMedicine(Medicine medicine)
      {
          string message;
            medicines.Add(medicine);
            writeInJson();
            message = "SUCCEEDED";
          return message;
      }
      
      public Medicine ReadMedicine(int medicineId)
      {
         throw new NotImplementedException();
      }
        public List<string> ReadMedicineIngredients(string medicineName)
        {
            List<string> ingredients = new List<string>();
            foreach(var medicine in medicines)
            {
                if (medicine.name == medicineName)
                {
                    foreach(var ingredient in medicine.ingredients.ToArray())
                    {
                        ingredients.Add(ingredient);
                    }
                }
            }
            return ingredients;
        }

        public List<string> ReadMedicineAlternatives(string medicineName)
        {
            List<string> alternatives = new List<string>();
            foreach (var medicine in medicines)
            {
                if (medicine.name == medicineName)
                {
                    foreach (var ingredient in medicine.ingredients.ToArray())
                    {
                        alternatives.Add(ingredient);
                    }
                }
            }
            return alternatives;
        }

      public string UpdateMedicine(Medicine medicine)
      {
            string message;
            int index = medicines.FindIndex(obj => obj.id == medicine.id);
            medicines[index] = medicine;
            writeInJson();
            message = "SUCCEEDED";
            return message;
        }
      
      public string DeleteMedicine(int medicineId)
      {
            string message = "NOT SUCCEEDED";
            foreach (var medicine in medicines.ToArray())
            {
                if (medicine.id == medicineId)
                {
                    medicines.Remove(medicine);
                    writeInJson();
                    message = "SUCCEEDED";
                }
            }
            return message;
        }
      
      public List<Medicine> ReadAllMedicines()
      {
         return medicines;
      }
      
      public void VerificateMedicine(int medicineId)
      {
         throw new NotImplementedException();
      }
      
      public void DeclineMedicine(int medicineId, string reason)
      {
         throw new NotImplementedException();
      }
      
      public string path;
   
   }
}