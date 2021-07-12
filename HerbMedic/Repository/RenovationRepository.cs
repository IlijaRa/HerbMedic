using Classes.Model;
using System.Collections.Generic;
using System;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace Classes.Repository
{
   public class RenovationRepository
   {
      List<Renovation> renovations = new List<Renovation>();

      public RenovationRepository()
      {
          readRenovationJson();         
      }

      public void readRenovationJson()
      {
            if (!File.Exists("renovations.json"))
            {
                File.Create("renovations.json").Close();
            }

            using (StreamReader r = new StreamReader("renovations.json"))
            {
                string json = r.ReadToEnd();
                if(json!= "")
                {
                    renovations = JsonConvert.DeserializeObject<List<Renovation>>(json);
                }
            }

        }
      
      public void writeInJson()
      {
         string json = JsonConvert.SerializeObject(renovations, Formatting.Indented);
         File.WriteAllText("renovations.json", json);
      }

      public string CreateRenovation(Renovation renovation)
      {
         string message;
         renovations.Add(renovation);
         writeInJson();
         message = "SUCCEEDED";
         return message;
      }
      
      public Renovation ReadRenovation(int renovationId)
      {
         throw new NotImplementedException();
      }
      
      public void AddRoomToRenovation(int id, string roomName)
      {
            int index = renovations.FindIndex(obj => obj.id == id);
            renovations[index].rooms.Add(roomName); // u renoviranje dodaje nazive soba koje popunjava kasnije u formi
            writeInJson();
      }
      
      public void DeleteRenovationById(int id)
      {
          int index = renovations.FindIndex(obj => obj.id == id);
          renovations.RemoveAt(index);
          writeInJson();
      }

        public void DeleteLastRenovation()
        {

        }

      public List<Renovation> ReadAllRenovations()
      {
         return renovations;
      }
   
   }
}