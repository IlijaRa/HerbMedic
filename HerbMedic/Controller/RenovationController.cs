using Classes.Model;
using System.Collections.Generic;
using System;
using Classes.Service;

namespace Classes.Controller
{
   public class RenovationController
   {
      RenovationService renovationService= new RenovationService();

      public string CreateRenovation(Renovation renovation)
      {
         return renovationService.CreateRenovation(renovation);
      }
      
      public void DeleteExpiredBasicRenovation()
      {
          renovationService.DeleteExpiredBasicRenovation();
      }
      
      public Renovation ReadRenovation(int renovationId)
      {
         throw new NotImplementedException();
      }
      
      public void UpdateRenovation(Renovation renovation)
      {
         throw new NotImplementedException();
      }
      
      public void DeleteRenovationById(int id)
      {
         renovationService.DeleteRenovationById(id);
      }
      
      public void DeleteLastRenovation()
      {
         renovationService.DeleteLastRenovation();
      }

      public List<Renovation> ReadAllRenovations()
      {
         return renovationService.ReadAllRenovations();
      }

        public bool CheckIfDateIsOK(Renovation renovation)
        {
           return renovationService.CheckIfDateIsOK(renovation);
        }
        public int GenerateId()
        {
            return renovationService.GenerateId();
        }
    }
}