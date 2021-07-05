using System.Collections.Generic;
using System;

namespace Classes.Model
{
    public class Medicine
    {
        public Medicine(int id, string name, string status, string description, List<string> ingredients, List<string> alternatives, string reason)
        {
            this.id = id;
            this.name = name;
            this.status = status;
            this.description = description;
            this.ingredients = ingredients;
            this.alternatives = alternatives;
            this.reason = reason;
        }

        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string description { get; set; }
        public List<string> ingredients { get; set; }
        public List<string> alternatives { get; set; }
        public string reason { get; set; }
    }
}