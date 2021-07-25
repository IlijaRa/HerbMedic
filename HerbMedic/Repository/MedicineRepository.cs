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

        public void CreateIngredient(Ingredient ingredient)
        {
            int index = medicines.FindIndex(obj => obj.name == ingredient.medicineName);
            medicines[index].ingredients.Add(ingredient);
            writeInJson();
        }

        public void CreateAlternative(Alternative alternative)
        {
            int index = medicines.FindIndex(obj => obj.name == alternative.medicineName);
            medicines[index].alternatives.Add(alternative);
            writeInJson();
        }

      public Medicine ReadMedicine(int medicineId)
      {
         throw new NotImplementedException();
      }
        public List<Ingredient> ReadMedicineIngredients(string medicineName)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            foreach(var medicine in medicines)
            {
                if(medicine.name == medicineName)
                {
                    foreach(var ingred in medicine.ingredients)
                    {
                        ingredients.Add(ingred);
                    }
                }
            }
            //int index = medicines.FindIndex(obj => obj.name == medicineName);
            //ingredients = medicines[index].ingredients;
            return ingredients;
        }

        public List<Alternative> ReadMedicineAlternatives(string medicineName)
        {
            List<Alternative> alternatives = new List<Alternative>();
            foreach (var medicine in medicines)
            {
                if (medicine.name == medicineName)
                {
                    foreach (var alter in medicine.alternatives)
                    {
                        alternatives.Add(alter);
                    }
                }
            }
            //int index = medicines.FindIndex(obj => obj.name == medicineName);
            //alternatives = medicines[index].alternatives;
            return alternatives;
        }

      public string UpdateMedicine(Medicine medicine, string role)
      {
            string message= "NOT SUCCEEDED";
            if (role == "Director")
            {
                int index = medicines.FindIndex(obj => obj.id == medicine.id);
                medicines[index] = medicine;
                writeInJson();
                message = "SUCCEEDED";
            }
            else if(role == "Doctor")
            {
                int index = medicines.FindIndex(obj => obj.id == medicine.id);
                medicines[index].name = medicine.name;
                medicines[index].description = medicine.description;
                writeInJson();
                message = "SUCCEEDED";
            }
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

        public string VerificateMedicine(Medicine medicine)
        {
            string message;
            int index = medicines.FindIndex(obj => obj.id == medicine.id);
            medicines[index].status= "VALIDATED";
            medicines[index].reason = null;
            writeInJson();
            message = "SUCCEEDED";
            return message;
        }

        public string DeclineMedicine(Medicine medicine)
        {
            string message;
            int index = medicines.FindIndex(obj => obj.id == medicine.id);
            medicines[index].status = "DECLINED";
            medicines[index].reason = medicine.reason;
            writeInJson();
            message = "SUCCEEDED";
            return message;
        }

        public string path;
   }
}