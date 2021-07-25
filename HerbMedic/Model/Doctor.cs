using System;
using System.Collections;
using System.Collections.Generic;
namespace Classes.Model
{
   public class Doctor : Employee
   {
      public string specialization;

      public Boolean onOffDays = false;
      
      public ArrayList appointment;

      public List<HospitalTreatment> hospitalTreatment;

      public List<ReferralLetterForSpecialist> referralLetters;

   }
}