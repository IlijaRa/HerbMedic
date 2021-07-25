using Classes.Model;
using System.Collections.Generic;
using System;
using Classes.Service;
namespace Classes.Controller
{
   public class ReferralLetterForSpecialistController
   {
      ReferralLetterForSpecialistService referralLetterForSpecialistService = new ReferralLetterForSpecialistService();
      public string CreateReferralLetter(ReferralLetterForSpecialist letter)
      {
         return referralLetterForSpecialistService.CreateReferralLetter(letter);
      }

        public int CheckNumberOfReferrals(string username)
        {
            return referralLetterForSpecialistService.CheckNumberOfReferrals(username);
        }

      public List<ReferralLetterForSpecialist> ReadAllReferralLetters(string username)
      {
            return referralLetterForSpecialistService.ReadAllReferralLetters(username);
      }
   }
}