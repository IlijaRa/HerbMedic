// File:    Warehouse.cs
// Author:  rakoc
// Created: Wednesday, April 7, 2021 20:56:24
// Purpose: Definition of Class Warehouse

using System;

namespace Classes.Model
{
   public class Warehouse
   {
      public int id;
      public String name;
      public Boolean isFull;
      
      public System.Collections.Generic.List<DynamicEquipment> dynamicEquipment;
      
      /// <summary>
      /// Property for collection of DynamicEquipment
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<DynamicEquipment> DynamicEquipment
      {
         get
         {
            if (dynamicEquipment == null)
               dynamicEquipment = new System.Collections.Generic.List<DynamicEquipment>();
            return dynamicEquipment;
         }
         set
         {
            RemoveAllDynamicEquipment();
            if (value != null)
            {
               foreach (DynamicEquipment oDynamicEquipment in value)
                  AddDynamicEquipment(oDynamicEquipment);
            }
         }
      }
      
      /// <summary>
      /// Add a new DynamicEquipment in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddDynamicEquipment(DynamicEquipment newDynamicEquipment)
      {
         if (newDynamicEquipment == null)
            return;
         if (this.dynamicEquipment == null)
            this.dynamicEquipment = new System.Collections.Generic.List<DynamicEquipment>();
         if (!this.dynamicEquipment.Contains(newDynamicEquipment))
            this.dynamicEquipment.Add(newDynamicEquipment);
      }
      
      /// <summary>
      /// Remove an existing DynamicEquipment from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveDynamicEquipment(DynamicEquipment oldDynamicEquipment)
      {
         if (oldDynamicEquipment == null)
            return;
         if (this.dynamicEquipment != null)
            if (this.dynamicEquipment.Contains(oldDynamicEquipment))
               this.dynamicEquipment.Remove(oldDynamicEquipment);
      }
      
      /// <summary>
      /// Remove all instances of DynamicEquipment from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllDynamicEquipment()
      {
         if (dynamicEquipment != null)
            dynamicEquipment.Clear();
      }
   
   }
}