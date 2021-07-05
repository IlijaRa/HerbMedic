using Classes.Model;
using System.Collections.Generic;
using System;

namespace Classes.Repository
{
   public class RequestForNewsFileRepository : IRequestForNewsRepository
   {
      public RequestForNews Read(int id)
      {
         throw new NotImplementedException();
      }
      
      public void Update(int id, String name)
      {
         throw new NotImplementedException();
      }
      
      public Boolean Delete(int id)
      {
         throw new NotImplementedException();
      }
      
      public void Save(int id)
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
      
      public void WriteToJson()
      {
         throw new NotImplementedException();
      }
   
   }
}