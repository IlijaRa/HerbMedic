using Classes.Model;
using System.Collections.Generic;
using System;

namespace Classes.Service
{
   public class ReferralLetterForSpecialistService
   {
      public Classes.Controller.ReferralLetterForSpecialistController CreateReferralLetter(Classes.Controller.ReferralLetterForSpecialistController letter)
      {
         throw new NotImplementedException();
      }
      
      public Classes.Controller.ReferralLetterForSpecialistController ReadReferralLetter(int referralLetterId)
      {
         throw new NotImplementedException();
      }
      
      public Classes.Repository.ReferralLetterForSpecialistRepository referralLetterForSpecialistRepository;
      public IReferralFactory iReferralFactory;
   
   }
}