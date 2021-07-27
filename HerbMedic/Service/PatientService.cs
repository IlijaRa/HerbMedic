using Classes.Model;
using System.Collections.Generic;
using System;
using Classes.Repository;

namespace Classes.Service
{
   public class PatientService
   {
        PatientRepository patientRepository = new PatientRepository();
        MedicalRecordRepository medicalRecordRepository = new MedicalRecordRepository();
      public Patient CreatePatient(Patient patient)
      {
         throw new NotImplementedException();
      }
      
      public Patient ReadPatient(int patientId)
      {
         throw new NotImplementedException();
      }

        public Patient ReadPatientByNameSurname(string nameSurname)
        {
            return patientRepository.ReadPatientByNameSurname(nameSurname);
        }

        public Patient ReadPatientByUsername(string username)
        {
            return patientRepository.ReadPatientByUsername(username);
        }

        public List<Appointment> ReadExaminationsByUsername(string username)
        {
            return patientRepository.ReadExaminationsByUsername(username);
        }

        public bool isTimeOK(DateTime date, string time1, string time2)
        {
            bool itIsOK = false;
            DateTime firstTime = Convert.ToDateTime(time1);
            DateTime secondTime = Convert.ToDateTime(time2);
            if (firstTime.Hour < secondTime.Hour)
                itIsOK = true;
            if (DateTime.Now < date)
                itIsOK = true;
            return itIsOK;
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
            return patientRepository.ReadAllPatients();
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