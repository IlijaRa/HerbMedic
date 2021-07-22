using Newtonsoft.Json;
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

        public MedicalRecord(string patient, List<Anamnesis> anamnesis, List<Prescription> prescriptions, List<Allergen> allergens)
        {
            this.patient = patient;
            this.anamnesis = anamnesis;
            this.prescriptions = prescriptions;
            this.allergens = allergens;
        }
    }
}