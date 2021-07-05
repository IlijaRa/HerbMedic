using Classes.Model;
using System.Collections.Generic;
using System;

namespace Classes.Service
{
   public class PropositionService
   {
      public void CreateProposition(string state, Medicine medicine)
      {
         throw new NotImplementedException();
      }
      
      public void UpdateProposition(Proposition proposition)
      {
         throw new NotImplementedException();
      }
      
      public Proposition ReadPropositionById(int id)
      {
         throw new NotImplementedException();
      }
      
      public void DeletePropositionById(int id)
      {
         throw new NotImplementedException();
      }
      
      public List<Proposition> ReadAllPropositions()
      {
         throw new NotImplementedException();
      }
      
      public void Approve(Proposition proposition)
      {
         throw new NotImplementedException();
      }
      
      public void Reject(Proposition proposition)
      {
         throw new NotImplementedException();
      }
      
      public Classes.Repository.PropositionRepository propositionRepository;
   
   }
}