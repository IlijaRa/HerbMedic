using Classes.Model;
using System.Collections.Generic;
using System;
using Classes.Repository;
using System.Linq;
using Classes.Controller;

namespace Classes.Service
{
   public class RoomService
   {
      RoomRepository roomRepository = new RoomRepository();
      RenovationController renovationController = new RenovationController();

        public string CreateRoom(Room room)
      {
         return roomRepository.CreateRoom(room);
      }

        public List<string> FormatMergeRooms(string TextboxWithRooms)
        {
            List<string> listRooms = new List<string>();
            string[] rooms = TextboxWithRooms.Split('\n');
            var charsToRemove = new string[] { "@", ",", ".", ";", "'", "\\", "\"" };
            string helper = "";
            for(int i=0; i<rooms.Count()-1; i++)
            {
                //kada se selektuju zeljene sobe u datagridu, iz nekog razloga se u json ovo upise \"33-LG\" umesto samo naziv sobe, tako da ovde svi znaci viska otklanjaju
                foreach (var c in charsToRemove)
                    helper = rooms[i].Replace(c, string.Empty);

                listRooms.Add(helper);
            }
            return listRooms;
        }

      public string CreatePendingRoom(Room room)
      {
          return roomRepository.CreatePendingRoom(room);
      }

      public void SwitchToRoomJson()
      {
            List<Renovation> renovations = renovationController.ReadAllRenovations();
            List<Room> pendingRooms = roomRepository.ReadAllPendingRooms();
            DateTime currentDate = DateTime.Now;

            foreach (var renovation in renovations.ToList())
            {
                // ukoliko je datum renoviranja istekao
                if (renovation.date < currentDate || (renovation.date == currentDate && renovation.startTime < currentDate) && renovation.type == "ADVANCED")
                {
                    // prolazi se kroz sve pendingRooms koje sluze za skladistenje u json dok ne dodje pravi datum za formiranje prostorije
                    foreach(var pendingRoom in pendingRooms.ToList())
                    {
                        // ako je naziv pending sobe isti kao i naziv newRoom u renoviranju radi sledece
                        if(pendingRoom.name == renovation.newRoom)
                        {
                            //brisanje svih manjih soba iz rooms.json koje su spojene u vecu sobu i kreiranje te velike sobe
                            string message = roomRepository.CreateRoom(pendingRoom);
                            foreach (var roomName in renovation.rooms.ToList())
                            {
                                roomRepository.DeleteRoomByName(roomName);
                            }
                            roomRepository.DeletePendingRoomByName(pendingRoom.name);
                            renovationController.DeleteRenovationById(renovation.id);
                        }
                    }
                }
            }
            
        }

        public bool CheckFloors(List<string> roomNames)
      {
         bool floorsAreTheSame = true;
         List<int> floors = new List<int>();
         List<Room> rooms = roomRepository.ReadAllRooms();
         // prolazi se kroz sve nazile selektovanih soba, nalazi se njihov sprat i ubacuje u listu floors
         foreach(var name in roomNames)
         {
            int roomIndex = rooms.FindIndex(obj => obj.name == name);
            floors.Add(rooms[roomIndex].floor);
         }
         // provera da li svi elementi u listi imaju istu vrednost
         if (floors.Any(o => o != floors[0]))
            floorsAreTheSame = false;
         return floorsAreTheSame;
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
         return roomRepository.ReadRoomsEquipment(roomName);
      }
        public List<Room> ReadAllRooms()
      {
         return roomRepository.ReadAllRooms();
      }
      
      public string UpdateRoom(Room room)
      {
         return roomRepository.UpdateRoom(room);
      }
      
      public string DeleteRoomById(int id)
      {
         return roomRepository.DeleteRoomById(id);
      }
      
      public void DeleteRoomByName(string roomName)
      {
         throw new NotImplementedException();
      }

        public Room MergeRooms(Room roomAtributes, List<string> RoomsForMerge)
        {
            Random random = new Random();
            Room BigRoom = roomAtributes;
            Room r = new Room();
            foreach (var room in RoomsForMerge.ToList())
            {
                r = roomRepository.ReadRoomByName(room);
                foreach (var stat in r.staticEquipment.ToList())
                {
                    stat.id += random.Next(1000); //ovo sam cisto stavio da se ne bi desilo da se podese isti id-evi
                    stat.roomName = BigRoom.name; //da se ne bi desilo da ostane ime od prostorije gde je stajala oprema
                    BigRoom.staticEquipment.Add(stat);
                }
            }
            return BigRoom;
        }

        public void SplitRoom(Room roomForSplit, int numberOfSplits)
      {
         throw new NotImplementedException();
      }

      public int GenerateId()
      {
         List<Room> rooms = roomRepository.ReadAllRooms();
         try
         {
             int maxId = rooms.Max(obj => obj.id);
             return maxId + 1;
         }
         catch
         {
             return 1;
         }
      }
    }
}