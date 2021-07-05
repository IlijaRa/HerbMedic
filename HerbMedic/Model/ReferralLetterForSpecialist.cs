// File:    ReferralLetterForSpecialist.cs
// Author:  LifeBook A574
// Created: Monday, April 26, 2021 17:09:31
// Purpose: Definition of Class ReferralLetterForSpecialist

using System;

namespace Classes.Model
{
   public class ReferralLetterForSpecialist
   {
      public int id;
      public string reason;
      public bool isUsed;
      public string type;
      
      public Doctor doctor;
      public Patient patient;
   }
}