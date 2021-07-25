using System;

namespace Classes.Model
{
   public class Survey
   {
      public int id { get; set; }
      public int review { get; set; }
        public string description { get; set; }
        public Doctor doctor { get; set; }
        public Patient patient { get; set; }
    }
}