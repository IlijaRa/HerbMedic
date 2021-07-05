using System;
using System.Collections.Generic;
using Classes.Model;
namespace Classes.Service
{
   public class RequestForNewsService
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
      public int GenerateNextId()
      {
         throw new NotImplementedException();
      }
      
      public Classes.Repository.IRequestForNewsRepository iRequestForNewsRepository;
   
   }
}