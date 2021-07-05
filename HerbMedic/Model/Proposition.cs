// File:    Proposition.cs
// Author:  LifeBook A574
// Created: Tuesday, June 8, 2021 20:28:41
// Purpose: Definition of Class Proposition

using System;

namespace Classes.Model
{
   public class Proposition
   {
      public void SetActiveState(PropositionState state)
      {
         throw new NotImplementedException();
      }
      
      public int id;
      public int medicine;
      public PropositionState currentState;
      
      public PropositionState state;
   
   }
}