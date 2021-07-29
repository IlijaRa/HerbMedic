using Classes.Model;
using System;
using System.Collections.Generic;
using Classes.Service;
namespace Classes.Controller
{
   public class AllergenController
   {
        AllergenService allergenService = new AllergenService();

        public string CreateAllergen(string patientName, Allergen allergenName)
        {
            return allergenService.CreateAllergen(patientName, allergenName);
        }

        public string DeleteAllergen(string patientName, Allergen allergenName)
        {
            return allergenService.DeleteAllergen(patientName, allergenName);
        }

        public List<Allergen> ReadAllergenByNameSurname(string fullName)
        {
            return allergenService.ReadAllergenByNameSurname(fullName);
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