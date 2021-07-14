using Classes.Model;
using System.Collections.Generic;
using System;
using Classes.Repository;
using System.Linq;
using Classes.Controller;

namespace Classes.Service
{
   public class RenovationService
   {
      RenovationRepository renovationRepository = new RenovationRepository();
      AppointmentController appointmentController = new AppointmentController();
        public string CreateRenovation(Renovation renovation)
        {
            string message = "NOT SUCCEEDED";
            if (renovation.type == "BASIC")
            {
                if (CheckIfDateIsOK(renovation))
                    if (CheckIfTermIsAvailable(renovation))
                        message = renovationRepository.CreateRenovation(renovation);
            }
            else
            {
                if (CheckIfDateIsOK(renovation))
                    message = renovationRepository.CreateRenovation(renovation);
            }
         return message;
      }
        public bool CheckIfDateIsOK(Renovation renovation)
        {
            bool isDateOK = true;           // flag da li je dobro unet datum

            DateTime dt1 = renovation.date; // u dt1 je datum kada je renoviranje
            DateTime dt2 = DateTime.Now;    // u dt2 je trenutni datum

            //provera da li je datum koje je unet vec prosao
            if (dt1.Date < dt2.Date)
            {
                isDateOK = false;
            }

            //provera da li je vreme kraja termina pre vremena pocetka termina
            else if (renovation.startTime > renovation.endTime)
            {
                isDateOK = false;
            }

            //provera da li je startno vreme renoviranja u proslosti za trenutni dan
            //jer se moze desiti da upravik unese renoviranje za trenutni dan, ali vreme koje je vec proslo
            //tako da se i to ne prihvata (npr sada je 21:45, a on unosi renoviranje od 14:00 do 15:00)
            //else if (renovation.startTime < dt2)
            //{
            //    isDateOK = false;
            //}

            return isDateOK;
        }

        // mora se pogledati ova funkcija
        public bool CheckIfTermIsAvailable(Renovation renovation)
        {
            bool isAvailable = true;
            //string start = renovation.startTime.ToString("HH:mm");
            //string end = renovation.endTime.ToString("HH:mm");
            //string enterdate = renovation.date.ToString("M/dd/yyyy");
            //List<Appointment> appointments = appointmentController.readAllAppointments();
            //bool isAvailable = true;            // flag da li je slobodan termin

            //// proverava da li je ovaj termin vec zauzet u appointmentima
            //foreach (var apps in appointments)
            //{

            //        if (apps.roomName == renovation.rooms[0] && apps.date.Date == renovation.date.Date)
            //        {
            //            string appstart = apps.startTime.ToString("HH:mm"); // stavlja se u isti format kao i start da bi moglo da se uporedi sa njim
            //            if (appstart.Equals(start))
            //            {
            //                isAvailable = false;
            //            }
            //        }
            //}
            return isAvailable;
        }
      public void DeleteExpiredBasicRenovation()
      {
         List<Renovation> renovations = renovationRepository.ReadAllRenovations();
            DateTime currentDateAndTime = DateTime.Now;
            DateTime currentDate = currentDateAndTime.Date;
            int currentHour = currentDateAndTime.Hour;
            int currentMinute = currentDateAndTime.Minute;

            foreach (var renovation in renovations.ToArray())
            {
                if ((renovation.date.Date < currentDate && renovation.type == "BASIC" && renovation.subtype == "BASIC") ||
                    (renovation.date.Date == currentDate && renovation.startTime.Hour <= currentHour && renovation.startTime.Minute <= currentMinute && renovation.type == "BASIC" && renovation.subtype == "BASIC"))
                {
                    renovationRepository.DeleteRenovationById(renovation.id);
                } 
            }
      }

      public Renovation ReadRenovation(int renovationId)
      {
         throw new NotImplementedException();
      }
      
      public void AddRoomToRenovation(int id, string roomName)
      {
         renovationRepository.AddRoomToRenovation(id, roomName);
      }
      
      public void DeleteRenovationById(int id)
      {
         renovationRepository.DeleteRenovationById(id);
      }

        public void DeleteLastRenovation()
        {
            renovationRepository.DeleteLastRenovation();
        }

        public List<Renovation> ReadAllRenovations()
      {
         return renovationRepository.ReadAllRenovations();
      }

        public int GenerateId()
        {
            List<Renovation> renovations = renovationRepository.ReadAllRenovations();
            try
            {
                int maxId = renovations.Max(obj => obj.id);
                return maxId + 1;
            }
            catch
            {
                return 1;
            }
        }
    }
}