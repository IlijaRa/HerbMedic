using System;
using System.Collections.Generic;

namespace Classes.Model
{
   public class Prescription
   {
      public int id { get; set; }
      public string patientName { get; set; }
      public string medicineName { get; set; }
      public string quantity { get; set; }
      public string usageInstruction { get; set; }

        public Prescription(int id, string patientName, string medicineName, string quantity, string usageInstruction)
        {
            this.id = id;
            this.patientName = patientName;
            this.medicineName = medicineName;
            this.quantity = quantity;
            this.usageInstruction = usageInstruction;
        }
    }
}