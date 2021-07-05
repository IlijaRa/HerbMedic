// File:    InReviewState.cs
// Author:  LifeBook A574
// Created: Tuesday, June 8, 2021 16:20:17
// Purpose: Definition of Class InReviewState

using System;

namespace Classes.Model
{
   public abstract class InReviewState : PropositionState
   {
      public abstract void Approve();
      
      public abstract void Reject();
   
   }
}