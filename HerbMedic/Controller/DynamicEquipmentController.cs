using Classes.Model;
using System.Collections.Generic;
using System;
using Classes.Service;
using System.Windows.Controls;

namespace Classes.Controller
{
   public class DynamicEquipmentController
   {
      DynamicEquipmentService dynamicService = new DynamicEquipmentService();

      public string CreateDynamicEquipment(DynamicEquipment dynamicEquip)
      {
         return dynamicService.CreateDynamicEquipment(dynamicEquip);
      }
      
      public DynamicEquipment ReadDynamicEquipment(int id)
      {
         throw new NotImplementedException();
      }
      
      public string UpdateDynamicEquipment(DynamicEquipment dynamicEquip)
      {
         return dynamicService.UpdateDynamicEquipment(dynamicEquip);
      }
      
      public string DeleteDynamicEquipment(int id)
      {
         return dynamicService.DeleteDynamicEquipment(id);
      }
      
      public List<DynamicEquipment> ReadAllDynamicEquipment()
      {
         return dynamicService.ReadAllDynamicEquipment();
      }
      
      public string Export(DoneExports export)
      {
         return dynamicService.Export(export);
      }

        public List<DoneExports> ReadAllExports()
        {
            return dynamicService.ReadAllExports();
        }

        public int GenerateId()
        {
            return dynamicService.GenerateId();
        }

        public List<DynamicEquipment> SearchEquipmentByName(string name, DataGrid datagrid)
        {
            return dynamicService.SearchEquipmentByName(name, datagrid);
        }
    }
}