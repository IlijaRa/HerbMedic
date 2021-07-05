using Classes.Model;
using System.Collections.Generic;
using System;

namespace Classes.Repository
{
   public class GuestAccountRepository
   {
      public List<Patient> GetAllGuests()
      {
         throw new NotImplementedException();
      }
      
      public void SaveGuest(Patient patient)
      {
         throw new NotImplementedException();
      }
      
      public Patient UpdateGuest(Patient patient)
      {
         throw new NotImplementedException();
      }
      
      public void removePAcc(Patient patient)
      {
         throw new NotImplementedException();
      }
      
      public Classes.Model.Patient CreateGuest(int patientId, string name, string surname, string jmbg)
      {
         throw new NotImplementedException();
      }
      
      public Classes.Model.Patient GetGuestByJMBG(int jmbg)
      {
         throw new NotImplementedException();
      }
      
      public Classes.Model.Patient GetGuestById(int id)
      {
         throw new NotImplementedException();
      }
      
      public string path;
   
   }
}