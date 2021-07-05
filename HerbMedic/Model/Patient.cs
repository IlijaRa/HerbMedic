using System;

namespace Classes.Model
{
   public class Patient
   {
      public double weight;
      public double beight;
      public string bloodType;
      public int healthInsuranceNumber;
      public bool isBlocked = false;
      public int cancellationCounter;
      public DateTime dateOfCancelation;
      public System.Collections.Generic.List<MedicineAlert> medicineAlert;
      public User user;
      public System.Collections.Generic.List<ReferralLetterForSpecialist> referralLetterForSpecialist;
      public System.Collections.Generic.List<Survey> survey;
      public HospitalTreatment[] hospitalTreatment;
   
   }
}