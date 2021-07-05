// File:    Survey.cs
// Author:  LifeBook A574
// Created: Monday, April 26, 2021 17:46:30
// Purpose: Definition of Class Survey

using System;

namespace Classes.Model
{
   public class Survey
   {
      public int id;
      public int review;
      public string description;
      
      public Doctor doctor;
      public Patient patient;
   
   }
}