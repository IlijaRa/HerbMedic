using Classes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Model
{
    public class TransferEquipment
    {
        public int id { get; set; }
        public string fromRoom { get; set; }
        public string toRoom { get; set; }
        public string equipment { get; set; }
        public int quantity { get; set; }
        public DateTime date { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }

        public TransferEquipment(int id, string fromRoom, string toRoom, string equipment, int quantity, DateTime date, DateTime startTime, DateTime endTime)
        {
            this.id = id;
            this.fromRoom = fromRoom;
            this.toRoom = toRoom;
            this.equipment = equipment;
            this.quantity = quantity;
            this.date = date;
            this.startTime = startTime;
            this.endTime = endTime;
        }

    }
}
