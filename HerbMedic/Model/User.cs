using System;

namespace Classes.Model
{
   public class User
   {
      public int id;
      public string username;
      public string password;
      public string firstName;
      public string lastName;
      public string jmbg;
      public string phoneNumber;
      public string feedback;
      public string address;
      public string email;
      public DateTime dateOfBirth;
      public System.Collections.Generic.List<NotificationRefferal> notificationRefferal;

   }
}