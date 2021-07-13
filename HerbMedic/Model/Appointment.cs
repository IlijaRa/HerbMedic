using System;

namespace Classes.Model
{
   public class Appointment
   {
      public int id { get; set; }
        public bool isEmergency { get; set; } = false;
        public string patient { get; set; }
        //public Secretary secretary { get; set; }
        public string doctor { get; set; }
        //public Employee employee { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public DateTime date { get; set; }
        public string roomName { get; set; }
        public string appointmentType { get; set; }
    }
}