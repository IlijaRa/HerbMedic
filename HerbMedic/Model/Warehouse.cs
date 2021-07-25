using System;

namespace Classes.Model
{
   public class Warehouse
   {
      public int id;
      public String name;
      public Boolean isFull;
      
      public System.Collections.Generic.List<DynamicEquipment> dynamicEquipment;
   }
}