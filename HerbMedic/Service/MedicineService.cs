using Classes.Model;
using System.Collections.Generic;
using System;
using Classes.Repository;
using System.Linq;

namespace Classes.Service
{
   public class MedicineService
   {
      MedicineRepository medicineRepository = new MedicineRepository();

      public string CreateMedicine(Medicine medicine)
      {
         return medicineRepository.CreateMedicine(medicine);
      }

        public void CreateIngredient(Ingredient ingredient)
        {
            medicineRepository.CreateIngredient(ingredient);
        }

        public void CreateAlternative(Alternative alternative)
        {
            medicineRepository.CreateAlternative(alternative);
        }

      public Medicine ReadMedicine(int medicineId)
      {
         throw new NotImplementedException();
      }
        public List<Ingredient> ReadMedicineIngredients(string medicineName)
        {
            return medicineRepository.ReadMedicineIngredients(medicineName);
        }

        public List<Alternative> ReadMedicineAlternatives(string medicineName)
        {
            return medicineRepository.ReadMedicineAlternatives(medicineName);
        }

        public string UpdateMedicine(Medicine medicine)
      {
         return medicineRepository.UpdateMedicine(medicine);
      }
      
      public string DeleteMedicine(int medicineId)
      {
         return medicineRepository.DeleteMedicine(medicineId);
      }
      
      public List<Medicine> ReadAllMedicines()
      {
         return medicineRepository.ReadAllMedicines();
      }
      
      public void VerificateMedicine(int medicineId)
      {
         throw new NotImplementedException();
      }
      
      public void DeclineMedicine(int medicineId, string reason)
      {
         throw new NotImplementedException();
      }
        public int GenerateId()
        {
            List<Medicine> medicines = medicineRepository.ReadAllMedicines();
            try
            {
                int maxId = medicines.Max(obj => obj.id);
                return maxId + 1;
            }
            catch
            {
                return 1;
            }
        }
        public List<string> FormatIngredients(string ingredientsToFormat)
        {
            List<string> ingredientList = new List<string>();
            string[] ingredients = ingredientsToFormat.Split(',');
            foreach (var i in ingredients)
            {
                ingredientList.Add(i);
            }
            return ingredientList;
        }
        public List<string> FormatAlternatives(string alternativesToFormat)
        {
            List<string> alternativeList = new List<string>();
            string[] alternatives = alternativesToFormat.Split(',');
            foreach (var a in alternatives)
            {
                alternativeList.Add(a);
            }
            return alternativeList;
        }
    }
}