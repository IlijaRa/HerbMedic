using Classes.Model;
using System.Collections.Generic;
using System;
using Classes.Service;
using Classes.Model;
using System.Windows.Controls;

namespace Classes.Controller
{
   public class StaticEquipmentController
   {
      StaticEquipmentService staticService = new StaticEquipmentService();
      public string CreateStaticEquipment(StaticEquipment staticEquip)
      {
         return staticService.CreateStaticEquipment(staticEquip);
      }
      
      public StaticEquipment ReadStaticEquipment(int id)
      {
         throw new NotImplementedException();
      }
      
      public string UpdateStaticEquipment(StaticEquipment staticEquip)
      {
         return staticService.UpdateStaticEquipment(staticEquip);
      }
      
      public string DeleteStaticEquipment(string roomName, int staticId)
      {
         return staticService.DeleteStaticEquipment(roomName, staticId);
      }
      
      public List<StaticEquipment> ReadAllStaticEquipment()
      {
         return staticService.ReadAllStaticEquipment();
      }

        public void ExecuteTransfer()
        {
            staticService.ExecuteTransfer();
        }

        public int GenerateId()
        {
            return staticService.GenerateId();
        }

        public List<StaticEquipment> SearchEquipmentByName(string name, DataGrid datagrid)
        {
            return staticService.SearchEquipmentByName(name, datagrid);
        }
    }
}