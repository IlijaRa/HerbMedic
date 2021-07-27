using Classes.Model;
using System.Collections.Generic;
using System;
using System.IO;
using Newtonsoft.Json;

namespace Classes.Repository
{
   public class PatientRepository
   {
        public List<Patient> patients = new List<Patient>();

        public PatientRepository()
        {
            readPatientJson();
        }
        public void readPatientJson()
        {
            // deserializuje renovation.json
            if (!File.Exists("patients.json"))
            {
                File.Create("patients.json").Close();
            }

            using (StreamReader r = new StreamReader("patients.json"))
            {
                string json = r.ReadToEnd();
                if (json != "")
                {
                    patients = JsonConvert.DeserializeObject<List<Patient>>(json);
                }
            }
        }


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
            Patient patient = new Patient();
            string fullNameSurname = "";
            foreach(var p in patients)
            {
                fullNameSurname = p.user.firstName + " " + p.user.lastName;
                if (fullNameSurname.Equals(nameSurname))
                {
                    patient = p;
                    break;
                }         
            }
            return patient;
        }

        public Patient ReadPatientByUsername(string username)
        {
            Patient patient = new Patient();
            foreach (var p in patients)
            {
                if (p.user.username.Equals(username))
                {
                    patient = p;
                    break;
                }
            }
            return patient;
        }

        public List<Appointment> ReadExaminationsByUsername(string username)
        {
            List<Appointment> examinations = new List<Appointment>();
            foreach (var p in patients)
            {
                if (p.user.username.Equals(username))
                {
                    examinations = p.examinations;
                    break;
                }
            }
            return examinations;
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
            return patients;
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
      
      public string path;
   
   }
}