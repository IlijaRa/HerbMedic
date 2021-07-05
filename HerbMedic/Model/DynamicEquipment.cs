using System;

namespace Classes.Model
{
   public class DynamicEquipment
   {
      public int id { get; set; }
      public string name { get; set; }
        public int quantity { get; set; }

        public DynamicEquipment(int id, string name, int quantity)
       {
            this.id = id;
            this.name = name;
            this.quantity = quantity;
       }
   }
}