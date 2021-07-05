using Classes.Model;
using System.Collections.Generic;
using System;
using Classes.Service;
namespace Classes.Controller
{
   public class MedicineAlertController
   {
      public MedicineAlert ReadMedicineAlert(int medicineAlertId)
      {
         throw new NotImplementedException();
      }
      
      public List<MedicineAlert> ReadAllMedicineAlerts(int patientId)
      {
         throw new NotImplementedException();
      }
      
      public void deleteReminder(int medicineAlertId)
      {
         throw new NotImplementedException();
      }
      
      public bool CheckForMedicalAlert(Classes.Model.Patient patient)
      {
         throw new NotImplementedException();
      }
      
      public Classes.Service.MedicineAlertService medicineAlertService;
   
   }
}