using System.Collections.Generic;
using System;

namespace Classes.Model
{
    public class Medicine
    {
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string description { get; set; }
        public List<Ingredient> ingredients { get; set; }
        public List<Alternative> alternatives { get; set; }
        public string reason { get; set; }

        public Medicine(int id, string name, string status, string description, List<Ingredient> ingredients, List<Alternative> alternatives, string reason)
        {
            this.id = id;
            this.name = name;
            this.status = status;
            this.description = description;
            this.ingredients = ingredients;
            this.alternatives = alternatives;
            this.reason = reason;
        }

    }
}