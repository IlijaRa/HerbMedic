// File:    AprovedState.cs
// Author:  LifeBook A574
// Created: Tuesday, June 8, 2021 16:20:16
// Purpose: Definition of Class AprovedState

using System;

namespace Classes.Model
{
   public abstract class AprovedState : PropositionState
   {
      public abstract void Approve();
      
      public abstract void Reject();
   
   }
}