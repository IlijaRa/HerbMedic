// File:    CreatingAppontmentBehavior.cs
// Author:  Korisnik
// Created: Tuesday, June 8, 2021 22:35:22
// Purpose: Definition of Interface CreatingAppontmentBehavior

using System;

namespace Classes.Model
{
   public interface CreatingAppontmentBehavior
   {
      Appointment Create(Appointment appointment);
   
   }
}