using Classes.Model;
using System.Collections.Generic;
using System;
using Classes.Repository;

namespace Classes.Service
{
   public class AnamnesisService
   {
        AnamnesisRepository anamnesisRepository = new AnamnesisRepository();

      public string CreateAnamnesis(Anamnesis anamnesis)
      {
            return anamnesisRepository.CreateAnamnesis(anamnesis);
      }

        public List<Anamnesis> ReadAnamnesisByNameSurname(string fullName)
        {
            return anamnesisRepository.ReadAnamnesisByNameSurname(fullName);
        }

      public string UpdateAnamnesis(Anamnesis anamnesis)
      {
            return anamnesisRepository.UpdateAnamnesis(anamnesis);
      }
      
      public List<Anamnesis> GetAnamnesisByPatientJmbg(string patientJmbg)
      {
         throw new NotImplementedException();
      }
   }
}