using Classes.Model;
using System.Collections.Generic;
using System;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace Classes.Repository
{
   public class RoomRepository
   {
      List<Room> rooms = new List<Room>();
      List<Room> pendingRooms = new List<Room>();
      public RoomRepository()
      {
         readRoomJson();
         readPendingRoomJson();
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
      public void readPendingRoomJson()
      {
            if (!File.Exists("pendingRoom.json"))
            {
                File.Create("pendingRoom.json").Close();
            }

            using (StreamReader r = new StreamReader("pendingRoom.json"))
            {
                string json = r.ReadToEnd();
                if (json != "")
                {
                    pendingRooms = JsonConvert.DeserializeObject<List<Room>>(json);
                }
            }
      }
      public void writeInJson()
      {
          string json = JsonConvert.SerializeObject(rooms, Formatting.Indented);
          File.WriteAllText("rooms.json", json);
      }
        public void writePendingJson()
        {
            string json = JsonConvert.SerializeObject(pendingRooms, Formatting.Indented);
            File.WriteAllText("pendingRoom.json", json);
        }

        public string CreateRoom(Room room)
      {
          string message;
              rooms.Add(room);
              writeInJson();
              message = "SUCCEEDED";
          return message;
      }
      
      public string CreatePendingRoom(Room room)
      {
            string message;
            pendingRooms.Add(room);
            writePendingJson();
            return message = "SUCCEEDED";
        }
      
      public Room ReadRoomById(int id)
      {
         throw new NotImplementedException();
      }
      
      public Room ReadRoomByName(string roomName)
      {
            Room r = null;
            foreach (var room in rooms)
            {
                if (room.name == roomName)
                {
                    r = room;
                    break;
                }
            }
            return r;
        }
      public List<StaticEquipment> ReadRoomsEquipment(string roomName)
      {
         List<StaticEquipment> statEquip= new List<StaticEquipment>();
         foreach(var room in rooms)
         {
             if (room.name == roomName)
             {
                foreach(var stat in room.staticEquipment.ToArray())
                {
                    statEquip.Add(stat);
                }
             }
         }
         return statEquip;
      }
      public List<Room> ReadAllRooms()
      {
         return rooms;
      }

        public List<Room> ReadAllPendingRooms()
        {
            return pendingRooms;
        }

        public string UpdateRoom(Room room)
      {
         string message;
             int index = rooms.FindIndex(obj => obj.id == room.id);
             rooms[index] = room;
             writeInJson();
             message = "SUCCEEDED";
         return message;
      }
      
      public string DeleteRoomById(int id)
      {
         string message="NOT SUCCEEDED";
         foreach(var room in rooms.ToArray())
         {
            if (room.id == id)
            {
                rooms.Remove(room);
                writeInJson();
                message = "SUCCEEDED";
            }
         }
         return message;
      }
      
      public void DeleteRoomByName(string roomName)
      {
            int index = rooms.FindIndex(obj => obj.name == roomName);
            rooms.RemoveAt(index);
            writeInJson();
      }

        public void DeletePendingRoomByName(string roomName)
        {
            int index = pendingRooms.FindIndex(obj => obj.name == roomName);
            pendingRooms.RemoveAt(index);
            writePendingJson();
        }

      public void SplitRoom(Room roomForSplit, int numberOfSplits)
      {
         throw new NotImplementedException();
      }
   
   }
}