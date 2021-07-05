// File:    RejectedState.cs
// Author:  LifeBook A574
// Created: Tuesday, June 8, 2021 16:20:17
// Purpose: Definition of Class RejectedState

using System;

namespace Classes.Model
{
   public abstract class RejectedState : PropositionState
   {
      public abstract void Approve();
      
      public abstract void Reject();
   
   }
}