using Classes.Model;
using System.Collections.Generic;
using System;
using System.IO;
using Newtonsoft.Json;

namespace Classes.Repository
{
   public class DynamicEquipmentRepository
   {
        List<DynamicEquipment> dynamics = new List<DynamicEquipment>();
        List<DoneExports> exports = new List<DoneExports>();

        public DynamicEquipmentRepository()
        {
            readWarehouseJson();
            readExportsJson();
        }
        public void readWarehouseJson()
        {
            if (!File.Exists("warehouse.json"))
            {
                File.Create("warehouse.json").Close();
            }

            using (StreamReader r = new StreamReader("warehouse.json"))
            {
                string json = r.ReadToEnd();
                if (json != "")
                {
                    dynamics = JsonConvert.DeserializeObject<List<DynamicEquipment>>(json);
                }
            }
        }
        public void readExportsJson()
        {
            if (!File.Exists("exports.json"))
            {
                File.Create("exports.json").Close();
            }

            using (StreamReader r = new StreamReader("exports.json"))
            {
                string json = r.ReadToEnd();
                if (json != "")
                {
                    exports = JsonConvert.DeserializeObject<List<DoneExports>>(json);
                }
            }
        }
        public void writeInJson()
        {
            string json = JsonConvert.SerializeObject(dynamics, Formatting.Indented);
            File.WriteAllText("warehouse.json", json);
        }
        public void writeInExportsJson()
        {
            string json = JsonConvert.SerializeObject(exports, Formatting.Indented);
            File.WriteAllText("exports.json", json);
        }
        public string CreateDynamicEquipment(DynamicEquipment dynamicEquip)
      {
         string message = "NOT SUCCEEDED";
             dynamics.Add(dynamicEquip);
             writeInJson();
             message = "SUCCEEDED";
         return message;
      }
      
      public DynamicEquipment ReadDynamicEquipment(int id)
      {
         throw new NotImplementedException();
      }
      
      public string UpdateDynamicEquipment(DynamicEquipment dynamicEquip)
      {
            string message = "NOT SUCCEEDED";
            int index = dynamics.FindIndex(obj => obj.id == dynamicEquip.id);
            dynamics[index] = dynamicEquip;
            writeInJson();
            message = "SUCCEEDED";
            return message;
      }
      
      public string DeleteDynamicEquipment(int id)
      {
         string message="NOT SUCCEEDED";
            foreach(var equipment in dynamics.ToArray())
            {
                if(equipment.id == id)
                {
                    dynamics.Remove(equipment);
                    writeInJson();
                    message = "SUCCEEDED";
                }
            }
         return message;
      }
      
      public List<DynamicEquipment> ReadAllDynamicEquipment()
      {
         return dynamics;
      }
      
      public string Export(DoneExports export)
      {
            string message;
            int index = dynamics.FindIndex(obj => obj.name== export.name);
            dynamics[index].quantity -= export.quantity;
            writeInJson();
            message = "SUCCEEDED";
            exports.Add(export);
            writeInExportsJson();
            return message;

      }
      
      public List<DoneExports> ReadAllExports()
      {
          return exports;
      }

      public string path;
   
   }
}