using System;
using Classes.Model;
using System.Collections.Generic;

namespace Classes.Service
{
   public class AllergenService
   {
      public Classes.Model.Allergen AddNewAllergen(string name, DateTime date)
      {
         throw new NotImplementedException();
      }
      
      public Classes.Model.Allergen UpdateAllergen(string name, DateTime date)
      {
         throw new NotImplementedException();
      }
      
      public List<Allergen> GetAllAlergens(int patientId)
      {
         throw new NotImplementedException();
      }
      
      public Classes.Repository.AllergenRepository allergenRepository;
   
   }
}