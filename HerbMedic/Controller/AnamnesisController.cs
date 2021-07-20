using Classes.Model;
using System;
using System.Collections.Generic;
using Classes.Service;
namespace Classes.Controller
{
   public class AnamnesisController
   {
        AnamnesisService anamnesisService = new AnamnesisService();

      public string CreateAnamnesis(Anamnesis anamnesis)
      {
            return anamnesisService.CreateAnamnesis(anamnesis);
      }
      
        public List<Anamnesis> ReadAnamnesisByNameSurname(string fullName)
        {
            return anamnesisService.ReadAnamnesisByNameSurname(fullName);
        }

      public string UpdateAnamnesis(Anamnesis anamnesis)
      {
            return anamnesisService.UpdateAnamnesis(anamnesis);
      }
      
      public List<Anamnesis> GetAnamnesisByPatientJmbg(string patientJmbg)
      {
         throw new NotImplementedException();
      }
   }
}