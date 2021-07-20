using System;
using System.Collections.Generic;

namespace Classes.Model
{
   public class MedicalRecord
   {

      public string patient { get; set; }

      public List<Anamnesis> anamnesis { get; set; }

      public List<Prescription> prescriptions { get; set; }

      public List<Allergen> allergens { get; set; }

    }
}