using System;
using Classes.Model;
using System.Collections.Generic;
using Classes.Repository;

namespace Classes.Service
{
   public class AllergenService
   {
        AllergenRepository allergenRepository = new AllergenRepository();

        public string CreateAllergen(string patientName, Allergen allergenName)
        {
            return allergenRepository.CreateAllergen(patientName, allergenName);
        }

        public string DeleteAllergen(string patientName, Allergen allergenName)
        {
            return allergenRepository.DeleteAllergen(patientName, allergenName);
        }

        public List<Allergen> ReadAllergenByNameSurname(string fullName)
        {
            return allergenRepository.ReadAllergenByNameSurname(fullName);
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