using System;

namespace Classes.Model
{
   public class Employee
   {
      public int salary;
      public System.TimeSpan workingHours;
      public System.TimeSpan annualVacation;
      public EmployeeType role;
      public string explenation;
      
      public User user;
      public Room room;
      public Warehouse warehouse;
      public System.Collections.Generic.List<Proposition> proposition;
      
     
      public System.Collections.Generic.List<MedicalRecord> medicalRecord;

      public System.Collections.Generic.List<Appointment> appointment;
   
   }
}