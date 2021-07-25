using System;

namespace Classes.Model
{
   public class ReferralLetterForSpecialist
   {
        public int id { get; set; }
        public string doctorWhoSends { get; set; }
        public string doctorWhoReceives { get; set; }
        public string patientName { get; set; }
        public string reason { get; set; }

        public ReferralLetterForSpecialist()
        {

        }

        public ReferralLetterForSpecialist(int id, string doctorWhoSends, string doctorWhoReceives, string patientName, string reason)
        {
            this.id = id;
            this.doctorWhoSends = doctorWhoSends;
            this.doctorWhoReceives = doctorWhoReceives;
            this.patientName = patientName;
            this.reason = reason;
        }
   }
}