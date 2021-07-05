using Classes.Model;
using System.Collections.Generic;
using System;

namespace Classes.Service
{
   public interface IReferralFactory
   {
      ReferralLetterForSpecialist CreateReferralLetter();
   
   }
}