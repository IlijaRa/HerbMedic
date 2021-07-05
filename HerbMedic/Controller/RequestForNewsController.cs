using Classes.Model;
using System.Collections.Generic;
using System;
using Classes.Service;
namespace Classes.Controller
{
   public class RequestForNewsController
   {
      public void UpdateRequestNews(int id, String name)
      {
         throw new NotImplementedException();
      }
      
      public Boolean DeleteRequestNews(int id)
      {
         throw new NotImplementedException();
      }
      
      public void SaveRequestNews(int id)
      {
         throw new NotImplementedException();
      }
      
      public int AcceptingRequestForNews(int id, StatusType newStatus, String explanation)
      {
         throw new NotImplementedException();
      }
      
      public List<RequestForNews> FilterByName(String name)
      {
         throw new NotImplementedException();
      }
      
      public List<RequestForNews> FilterByStatus(StatusType status)
      {
         throw new NotImplementedException();
      }
      
      public List<RequestForNews> SortByDateOfCreation()
      {
         throw new NotImplementedException();
      }
      
      public int GenerateNextId()
      {
         throw new NotImplementedException();
      }
      
      public Classes.Service.RequestForNewsService requestForNewsService;
   
   }
}