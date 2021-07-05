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
      
      public Medicine ReadMedicine(int medicineId)
      {
         throw new NotImplementedException();
      }
      public List<string> ReadMedicineIngredients(string medicineName)
      {
            return medicineService.ReadMedicineIngredients(medicineName);
      }
        public List<string> ReadMedicineAlternatives(string medicineName)
        {
            return medicineService.ReadMedicineAlternatives(medicineName);
        }

      public string UpdateMedicine(Medicine medicine)
      {
         return medicineService.UpdateMedicine(medicine);
      }
      
      public string DeleteMedicine(int medicineId)
      {
         return medicineService.DeleteMedicine(medicineId);
      }
      
      public List<Medicine> ReadAllMedicines()
      {
         return medicineService.ReadAllMedicines();
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