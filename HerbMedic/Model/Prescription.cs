using System;
using System.Collections.Generic;

namespace Classes.Model
{
   public class Prescription
   {
      public int id;
      public string usage;
      public int quantity;
      public List<Medicine> medicine;
      public MedicalRecord medicalRecord;
   
   }
}