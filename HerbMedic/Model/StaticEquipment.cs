using System;

namespace Classes.Model
{
   public class StaticEquipment
   {
      public string roomName { get; set; }
      public int id { get; set; }
      public string name { get; set; }
      public int quantity { get; set; }

      public StaticEquipment(string roomName, int id, string name, int quantity)
      {
          this.roomName = roomName;
          this.id = id;
          this.name = name;
          this.quantity = quantity;
      }
   }
}