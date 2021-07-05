using System;
using System.Collections.Generic;

namespace Classes.Model
{
   public class Renovation
   {
      public int id { get; set; }
      public string type { get; set; }
      public DateTime date { get; set; }
      public DateTime startTime { get; set; }
      public DateTime endTime { get; set; }
      public string description { get; set; }
      public string newRoom { get; set; }
      public List<string> rooms { get; set; }

        public Renovation(int id, string type, DateTime date, DateTime startTime, DateTime endTime, string description, string newRoom, List<string> rooms)
        {
            this.id = id;
            this.type = type;
            this.date = date;
            this.startTime = startTime;
            this.endTime = endTime;
            this.description = description;
            this.newRoom = newRoom;
            this.rooms = rooms;
        }
    }
}