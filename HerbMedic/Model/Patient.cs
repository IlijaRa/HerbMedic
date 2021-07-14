using System;
using System.Collections.Generic;

namespace Classes.Model
{
   public class Patient
   {
        public int healthInsuranceNumber { get; set; }
        public double height { get; set; }
        public double weight { get; set; }
        public string bloodType { get; set; }
        public bool isBlocked { get; set; } = false;
        public int cancellationCounter { get; set; }
        public DateTime dateOfCancelation { get; set; }
        public List<MedicineAlert> medicineAlerts { get; set; }
        public List<ReferralLetterForSpecialist> referralLetterForSpecialists { get; set; }
        public List<Survey> surveys { get; set; }
        public List<HospitalTreatment> hospitalTreatments { get; set; }
        public User user { get; set; }
    }
}