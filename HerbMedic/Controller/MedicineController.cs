using Classes.Model;
using System.Collections.Generic;
using System;
using Classes.Service;
namespace Classes.Controller
{
   public class MedicineController
   {
      MedicineService medicineService = new MedicineService();

      public string CreateMedicine(Medicine medicine)
      {
         return medicineService.CreateMedicine(medicine);
      }
      
      public void CreateIngredient(Ingredient ingredient)
        {
            medicineService.CreateIngredient(ingredient);
        }

        public void CreateAlternative(Alternative alternative)
        {
            medicineService.CreateAlternative(alternative);
        }
        public Medicine ReadMedicine(int medicineId)
      {
         throw new NotImplementedException();
      }
        public List<Ingredient> ReadMedicineIngredients(string medicineName)
        {
            return medicineService.ReadMedicineIngredients(medicineName);
        }
        public List<Alternative> ReadMedicineAlternatives(string medicineName)
        {
            return medicineService.ReadMedicineAlternatives(medicineName);
        }

        public string UpdateMedicine(Medicine medicine, string role)
      {
         return medicineService.UpdateMedicine(medicine, role);
      }
      
      public string DeleteMedicine(int medicineId)
      {
         return medicineService.DeleteMedicine(medicineId);
      }
      
      public List<Medicine> ReadAllMedicines()
      {
         return medicineService.ReadAllMedicines();
      }
      
      public string VerificateMedicine(Medicine medicine)
      {
            return medicineService.VerificateMedicine(medicine);
      }
      
      public string DeclineMedicine(Medicine medicine)
      {
            return medicineService.DeclineMedicine(medicine);
      }
      
      public int GenerateId()
      {
         return medicineService.GenerateId();
      }
        public List<string> FormatIngredients(string ingredientsToFormat)
        {
            return medicineService.FormatIngredients(ingredientsToFormat);
        }
        public List<string> FormatAlternatives(string alternativesToFormat)
        {
            return medicineService.FormatIngredients(alternativesToFormat);
        }
    }
}