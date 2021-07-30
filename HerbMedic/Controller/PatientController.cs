using Classes.Model;
using System.Collections.Generic;
using System;
using Classes.Service;

namespace Classes.Controller
{
   public class PatientController
   {
        PatientService patientService = new PatientService();

      public Patient CreatePatient(Patient patient)
      {
         throw new NotImplementedException();
      }

        public string CreateExamination(Appointment appointment)
        {
            return patientService.CreateExamination(appointment);
        }


        public Patient ReadPatient(int patientId)
      {
         throw new NotImplementedException();
      }

        public Patient ReadPatientByNameSurname(string nameSurname)
        {
            return patientService.ReadPatientByNameSurname(nameSurname);
        }

        public Patient ReadPatientByUsername(string username)
        {
            return patientService.ReadPatientByUsername(username);
        }

        public List<Appointment> ReadExaminationsByUsername(string username)
        {
            return patientService.ReadExaminationsByUsername(username);
        }

        public bool isTimeOK(DateTime date, string time1, string time2)
        {
            return patientService.isTimeOK(date, time1, time2);
        }

      public Patient UpdatePatient(Patient patient)
      {
         throw new NotImplementedException();
      }
      
      public void DeletePatient(int patientId)
      {
         throw new NotImplementedException();
      }
      
      public List<Patient> ReadAllPatients()
      {
            return patientService.ReadAllPatients();
      }
      
      public void deleteAll()
      {
         throw new NotImplementedException();
      }
      
      public Boolean IsJmbgValid(string jmbg)
      {
         throw new NotImplementedException();
      }
      
      public Boolean IsJmbgUnique(string jmbg)
      {
         throw new NotImplementedException();
      }
      
      public Patient GetPatientByJMBG(int jmbg)
      {
         throw new NotImplementedException();
      }
      
      public int IncreaseCancellationCounter(int patientId)
      {
         throw new NotImplementedException();
      }
      
      public int GetNumberOfCancellations(int patientId)
      {
         throw new NotImplementedException();
      }
      
      public bool GetPatientStatus(int patientId)
      {
         throw new NotImplementedException();
      }
   }
}