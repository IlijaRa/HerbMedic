using Classes.Model;
using System.Collections.Generic;
using System;
using Classes.Service;
namespace Classes.Controller
{
   public class RoomController
   {
      RoomService roomService = new RoomService();

      public string CreateRoom(Room room)
      {
         return roomService.CreateRoom(room);
      }

      public List<string> FormatMergeRooms(string TextboxWithRooms)
      {
          return roomService.FormatMergeRooms(TextboxWithRooms);
      }

        public string FormatStaticEquipment(string equipment)
        {
            return roomService.FormatStaticEquipment(equipment);
        }

        public List<Room> FindRoomsByEquipmentForOperation(List<string> equipmentForOperation)
        {
            return roomService.FindRoomsByEquipmentForOperation(equipmentForOperation);
        }

      public bool CheckFloors(List<string> roomNames)
      {
         return roomService.CheckFloors(roomNames);
      }

      public string CreatePendingRoom(Room room)
      {
         return roomService.CreatePendingRoom(room);
      }
      
      public void SwitchMergeToRoomJson()
      {
         roomService.SwitchMergeToRoomJson();
      }

        public void SwitchSplitToRoomJson()
        {
            roomService.SwitchSplitToRoomJson();
        }

      public Room ReadRoomById(int id)
      {
         throw new NotImplementedException();
      }
      
      public Room ReadRoomByName(string roomName)
      {
         throw new NotImplementedException();
      }

      public List<StaticEquipment> ReadRoomsEquipment(string roomName)
      {
         return roomService.ReadRoomsEquipment(roomName);
      }

      public List<Room> ReadAllRooms()
      {
         return roomService.ReadAllRooms();
      }

      public string UpdateRoom(Room room)
      {
         return roomService.UpdateRoom(room);
      }
      
      public string DeleteRoomById(int id)
      {
         return roomService.DeleteRoomById(id);
      }
      
      public void DeleteRoomByName(string roomName)
      {
         throw new NotImplementedException();
      }

        public Room MergeRooms(Room roomAtributes, List<string> RoomsForMerge)
        {
            return roomService.MergeRooms(roomAtributes, RoomsForMerge);
        }

      public void SplitRoom(Room roomForSplit, int numberOfSplits)
      {
         throw new NotImplementedException();
      }

      public int GenerateId()
      {
         return roomService.GenerateId();
      }
   }
}