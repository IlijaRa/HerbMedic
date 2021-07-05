/***********************************************************************
 * Module:  Doctor.cs
 * Author:  8470
 * Purpose: Definition of the Class Doctor
 ***********************************************************************/

using System;

namespace Classes.Model
{
   public class Doctor : Employee
   {
      public string specialization;
      public Boolean onOffDays = false;
      
      public System.Collections.ArrayList appointment;

      public System.Collections.Generic.List<HospitalTreatment> hospitalTreatment;

      public ReferralLetterForSpecialist[] referralLetterForSpecialist;
   
   }
}