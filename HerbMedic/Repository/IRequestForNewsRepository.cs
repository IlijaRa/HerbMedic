using Classes.Model;
using System.Collections.Generic;
using System;

namespace Classes.Repository
{
   public interface IRequestForNewsRepository
   {
      RequestForNews Read(int id);
      
      void Update(int id, String name);
      
      Boolean Delete(int id);
      
      void Save(int id);
      
      int AcceptingRequestForNews(int id, StatusType newStatus, String explanation);
      
      List<RequestForNews> FilterByName(String name);
      
      List<RequestForNews> FilterByStatus(StatusType status);
      
      List<RequestForNews> SortByDateOfCreation();
      
      int GenerateNextId();
   
   }
}