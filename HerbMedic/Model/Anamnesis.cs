using System;

namespace Classes.Model
{
   public class Anamnesis
   {
      public int id { get; set; }
      public string patientName { get; set; }
      public string title { get; set; }
      public string description { get; set; }
      public DateTime date { get; set; }

        public Anamnesis(int id, string patientName, string title, string description, DateTime date)
        {
            this.id = id;
            this.patientName = patientName;
            this.title = title;
            this.description = description;
            this.date = date;
        }
    }
}