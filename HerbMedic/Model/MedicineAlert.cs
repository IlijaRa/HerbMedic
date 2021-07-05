// File:    MedicineAlert.cs
// Author:  HP-Miha
// Created: Sunday, April 18, 2021 19:59:14
// Purpose: Definition of Class MedicineAlert

using System;

namespace Classes.Model
{
   public class MedicineAlert
   {
      public int id;
      public string name;
      public string description;
      public DateTime alarmTime;
      
      public Prescription prescription;
      public Patient patient;
   }
}