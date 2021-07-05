using Classes.Model;
using System.Collections.Generic;
using System;
using Classes.Repository;
using System.Linq;
using System.Windows.Controls;

namespace Classes.Service
{
   public class DynamicEquipmentService
   {
      DynamicEquipmentRepository dynamicRepository = new DynamicEquipmentRepository();

      public string CreateDynamicEquipment(DynamicEquipment dynamicEquip)
      {
         return dynamicRepository.CreateDynamicEquipment(dynamicEquip);
      }
      
      public DynamicEquipment ReadDynamicEquipment(int id)
      {
         throw new NotImplementedException();
      }
      
      public string UpdateDynamicEquipment(DynamicEquipment dynamicEquip)
      {
         return dynamicRepository.UpdateDynamicEquipment(dynamicEquip);
      }
      
      public string DeleteDynamicEquipment(int id)
      {
         return dynamicRepository.DeleteDynamicEquipment(id);
      }
      
      public List<DynamicEquipment> ReadAllDynamicEquipment()
      {
         return dynamicRepository.ReadAllDynamicEquipment();
      }
      
      public string Export(DoneExports export)
      {
         return dynamicRepository.Export(export);
      }
        public List<DoneExports> ReadAllExports()
        {
            return dynamicRepository.ReadAllExports();
        }

        public int GenerateId()
        {
            List<DynamicEquipment> equipments = dynamicRepository.ReadAllDynamicEquipment();
            try
            {
                int maxId = equipments.Max(obj => obj.id);
                return maxId + 1;
            }
            catch
            {
                return 1;
            }
        }

        public List<DynamicEquipment> SearchEquipmentByName(string name, DataGrid datagrid)
        {
            List<DynamicEquipment> dynamicEquipment = new List<DynamicEquipment>(dynamicRepository.ReadAllDynamicEquipment());
            List<DynamicEquipment> searchedEquipment = new List<DynamicEquipment>();
            if (name.Length > 1)
            {
                datagrid.ItemsSource = null;

                foreach (var dynama in dynamicEquipment)
                {
                    if (dynama.name.Contains(name))
                    {
                        searchedEquipment.Add(dynama);
                    }
                }
                return searchedEquipment;
            }
            else
                return dynamicEquipment;
        }
    }
}