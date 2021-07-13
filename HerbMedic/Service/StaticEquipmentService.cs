using Classes.Model;
using System.Collections.Generic;
using System;
using Classes.Repository;
using System.Linq;
using System.Windows.Controls;

namespace Classes.Service
{
   public class StaticEquipmentService
   {
      StaticEquipmentRepository staticRepository = new StaticEquipmentRepository();
      TransferEquipmentRepository transferRepository = new TransferEquipmentRepository();
      RoomRepository roomRepository = new RoomRepository();
      public string CreateStaticEquipment(StaticEquipment staticEquip)
      {
         return staticRepository.CreateStaticEquipment(staticEquip);
      }
      
      public StaticEquipment ReadStaticEquipment(int id)
      {
         throw new NotImplementedException();
      }
      
      public string UpdateStaticEquipment(StaticEquipment staticEquip)
      {
         return staticRepository.UpdateStaticEquipment(staticEquip);
      }
      
      public string DeleteStaticEquipment(string roomName, int staticId)
      {
         return staticRepository.DeleteStaticEquipment(roomName, staticId);
      }
      
      public List<StaticEquipment> ReadAllStaticEquipment()
      {
         return staticRepository.ReadAllStaticEquipment();
      }

      public void ExecuteTransfer()
      {
         List<TransferEquipment> transfers = transferRepository.ReadAllTransfers();
         List<Room> rooms = roomRepository.ReadAllRooms();
            DateTime currentDateAndTime = DateTime.Now;
            DateTime currentDate = currentDateAndTime.Date;
            int currentHour = currentDateAndTime.Hour;
            int currentMinute = currentDateAndTime.Minute;

         foreach (var transfer in transfers.ToArray())
         {
            if(transfer.date < currentDate || (transfer.date == currentDate && transfer.startTime.Hour < currentHour && transfer.startTime.Minute < currentMinute))//ako je datum transfera opreme manji od trenutnog datuma ,ili ako je datum transfera jednak trenutnom datumu i pocetak transfera manji od trenutnog vremena
            {
                  foreach(var room in rooms.ToArray())
                  {
                     if(room.name == transfer.toRoom)
                     {
                         if(CheckIfEquipmentExistInRoom(transfer.equipment, room.name))// ako oprema vec postoji, samo ce povecati kolicinu
                         {
                             AddEquipment(transfer.toRoom, transfer.equipment, transfer.quantity);
                             SubtractEquipment(transfer.fromRoom, transfer.equipment, transfer.quantity);
                             transferRepository.DeleteTransfer(transfer.id);
                         }
                         else// ako ne postoji vec u prostoriji, kreira opremu
                         {
                             StaticEquipment stat = new StaticEquipment(room.name,GenerateId(),transfer.equipment,transfer.quantity);
                             room.staticEquipment.Add(stat);
                             roomRepository.writeInJson();
                             SubtractEquipment(transfer.fromRoom, transfer.equipment, transfer.quantity);
                             transferRepository.DeleteTransfer(transfer.id);
                             
                         }
                         
                     }
                  }
            }
         }
      }
        public void SubtractEquipment(string roomName, string equipmentName, int quantity)
        {
            List<Room> rooms = roomRepository.ReadAllRooms();
            foreach (var room in rooms.ToArray())
            {
                if (room.name == roomName)
                {
                    foreach (var equipment in room.staticEquipment.ToArray())
                    {
                        if (equipment.name == equipmentName)
                        {
                            equipment.quantity -= quantity;
                            roomRepository.writeInJson();
                        }
                    }
                }
            }
        }


        public void AddEquipment(string roomName, string equipmentName, int quantity)
      {
            List<Room> rooms = roomRepository.ReadAllRooms();
            foreach(var room in rooms.ToArray())
            {
                if(room.name == roomName)
                {
                    foreach(var equipment in room.staticEquipment.ToArray())
                    {
                        if(equipment.name == equipmentName)
                        {
                            equipment.quantity += quantity;
                            roomRepository.writeInJson();
                        }
                    }
                }
            }
      }
      public bool CheckIfEquipmentExistInRoom(string equipmentName, string roomName)
      {
            List<Room> rooms = roomRepository.ReadAllRooms();
            bool exist = false;
            foreach(var room in rooms.ToArray())
            {
                if(room.name == roomName)
                {
                    foreach(var equipment in room.staticEquipment.ToArray())
                    {
                        if (equipment.name == equipmentName)
                        {
                            exist = true;
                        }
                    }
                }
            }
            return exist;
      }
      public Boolean CheckDate(DateTime transferDate)
      {
         throw new NotImplementedException();
      }
      
      public Boolean CheckToTransfer(DateTime transferDate)
      {
         throw new NotImplementedException();
      }
      
      public Boolean CheckQuantity(int staticEquipId, double quantity)
      {
         throw new NotImplementedException();
      }
        public int GenerateId()
        {
            List<StaticEquipment> equipments = staticRepository.ReadAllStaticEquipment();
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

        public List<StaticEquipment> SearchEquipmentByName(string name, DataGrid datagrid)
        {
            List<StaticEquipment> staticEquipment = new List<StaticEquipment>(staticRepository.ReadAllStaticEquipment());
            List<StaticEquipment> searchedEquipment = new List<StaticEquipment>();
            if (name.Length > 1)
            {
                datagrid.ItemsSource = null;

                foreach (var stat in staticEquipment)
                {
                    if (stat.name.Contains(name))
                    {
                        searchedEquipment.Add(stat);
                    }     
                }
                return searchedEquipment;
            }
            else
                return staticEquipment;
        }
    }
}