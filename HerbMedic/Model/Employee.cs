using System;
using System.Collections.Generic;
namespace Classes.Model
{
   public class Employee
   {
        public int id { get; set; }
        public int salary { get; set; }
        public int WorkingHoursPerWeek { get; set; }
        public int AnnualVacation { get; set; }
        public string role { get; set; }
        public User user { get; set; }
        public Room room { get; set; }

        //public List<Proposition> proposition;

        //public List<MedicalRecord> medicalRecord;

        //public List<Appointment> appointments;

    }
}