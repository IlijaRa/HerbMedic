using System;
using System.Collections.Generic;
namespace Classes.Model
{
   public class User
   {
      public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string jmbg { get; set; }
        public string phoneNumber { get; set; }
        public string feedback { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public DateTime dateOfBirth { get; set; }
        public List<NotificationRefferal> notificationRefferal { get; set; }

    }
}