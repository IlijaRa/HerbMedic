// File:    News.cs
// Author:  LENOVO
// Created: Tuesday, April 27, 2021 12:56:54
// Purpose: Definition of Class News

using System;

namespace Classes.Model
{
   public class News
   {
      public int id;
      public string title;
      public string text;
      public DateTime date;
      
      public NewsBoard newsBoard;
   
   }
}