using Classes.Model;
using System.Collections.Generic;
using System;
using Classes.Repository;

namespace Classes.Service
{
   public class ReferralLetterForSpecialistService
   {
        ReferralLetterForSpecialistRepository referralLetterForSpecialistRepository = new ReferralLetterForSpecialistRepository();
        public string CreateReferralLetter(ReferralLetterForSpecialist letter)
        {
            return referralLetterForSpecialistRepository.CreateReferralLetter(letter);
        }

        public int CheckNumberOfReferrals(string username)
        {
            return referralLetterForSpecialistRepository.CheckNumberOfReferrals(username);
        }

        public List<ReferralLetterForSpecialist> ReadAllReferralLetters(string username)
        {
            return referralLetterForSpecialistRepository.ReadAllReferralLetters(username);
        }
        public string DeleteReferralLetter(ReferralLetterForSpecialist letter)
        {
            return referralLetterForSpecialistRepository.DeleteReferralLetter(letter);
        }
    }
}