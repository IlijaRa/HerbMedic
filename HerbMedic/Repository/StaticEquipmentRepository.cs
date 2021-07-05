using Classes.Model;
using System.Collections.Generic;
using System;
using System.IO;
using Newtonsoft.Json;

namespace Classes.Repository
{
   public class StaticEquipmentRepository
   {
        List<Room> rooms = new List<Room>();

        public StaticEquipmentRepository()
        {
            readRoomJson();
        }
        public void readRoomJson()
        {
            if (!File.Exists("rooms.json"))
            {
                File.Create("rooms.json").Close();
            }

            using (StreamReader r = new StreamReader("rooms.json"))
            {
                string json = r.ReadToEnd();
                if (json != "")
                {
                    rooms = JsonConvert.DeserializeObject<List<Room>>(json);
                }
            }
        }
        public void writeInJson()
        {
            string json = JsonConvert.SerializeObject(rooms, Formatting.Indented);
            File.WriteAllText("rooms.json", json);
        }
      public string CreateStaticEquipment(StaticEquipment staticEquip)
      {
         string message = "NOT SUCCEEDED";
         foreach(var room in rooms.ToArray())
         {
            if(room.name == staticEquip.roomName)
            {
                room.staticEquipment.Add(staticEquip);
                writeInJson();
                message = "SUCCEEDED";
            }
         }
         return message;
      }
      
      public StaticEquipment ReadStaticEquipment(int id)
      {
         throw new NotImplementedException();
      }
      
      public string UpdateStaticEquipment(StaticEquipment staticEquip)
      {
            string message = "NOT SUCCEEDED";
            int index = rooms.FindIndex(obj => obj.name == staticEquip.roomName);                       // nalazi sobu po nazivu
            int staticIndex = rooms[index].staticEquipment.FindIndex(obj => obj.id == staticEquip.id);  // u toj sobi nalazi opremu po indexu
            rooms[index].staticEquipment[staticIndex] = staticEquip;                                    // prebacuje sve promene u tu opremu
            writeInJson();
            message = "SUCCEEDED";
            return message;
        }
      
      public string DeleteStaticEquipment(string roomName, int staticId)
      {
         string message = "NOT SUCCEEDED";
         foreach(var room in rooms.ToArray())
         {
            if(room.name == roomName)
            {
               foreach(var stat in room.staticEquipment.ToArray())
               {
                  if(stat.id == staticId)
                  {
                     room.staticEquipment.Remove(stat);
                     writeInJson();
                     message = "SUCCEEDED";
                  }
               }
            }
         }
         return message;
      }
      
      public List<StaticEquipment> ReadAllStaticEquipment()
      {
         List<StaticEquipment> equipments= new List<StaticEquipment>();
         foreach(var room in rooms)
         {
            foreach(var equipment in room.staticEquipment)
            {
                equipments.Add(equipment);
            }
         }
         return equipments;
      }
      
      public void TransferStaticEquipment(int fromRoomId, int toRoomId, int staticEquipId, double quantity, DateTime enterDate, DateTime startTime, DateTime endTime)
      {
         throw new NotImplementedException();
      }
      
      public Boolean CheckQuantity(int staticEquipId, double quantity)
      {
         throw new NotImplementedException();
      }
      
      public string path;
   
   }
}