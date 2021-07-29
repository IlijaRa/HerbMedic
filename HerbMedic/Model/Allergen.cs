using System;

namespace Classes.Model
{
   public class Allergen
   {
      public string name { get; set; }

        public Allergen(string name)
        {
            this.name = name;
        }
    }
}