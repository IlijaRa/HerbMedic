using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Model
{
    public class Ingredient
    {
        public string medicineName { get; set; }
        public int ingredientId { get; set; }
        public string ingredientName { get; set; }

        public Ingredient(string medicineName, int ingredientId, string ingredientName)
        {
            this.medicineName = medicineName;
            this.ingredientId = ingredientId;
            this.ingredientName = ingredientName;
        }
    }
}
