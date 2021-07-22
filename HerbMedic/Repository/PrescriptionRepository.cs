using Classes.Model;
using System.Collections.Generic;
using System;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace Classes.Repository
{
   public class PrescriptionRepository
   {
        List<MedicalRecord> medicalRecords = new List<MedicalRecord>();

        public PrescriptionRepository()
        {
            readMedicalRecordJson();
        }
        public void readMedicalRecordJson()
        {
            if (!File.Exists("medicalRecords.json"))
            {
                File.Create("medicalRecords.json").Close();
            }

            using (StreamReader r = new StreamReader("medicalRecords.json"))
            {
                string json = r.ReadToEnd();
                if (json != "")
                {
                    medicalRecords = JsonConvert.DeserializeObject<List<MedicalRecord>>(json);
                }
            }
        }

        public void writeInJson()
        {
            string json = JsonConvert.SerializeObject(medicalRecords, Formatting.Indented);
            File.WriteAllText("medicalRecords.json", json);
        }

        public string CreatePrescription(Prescription prescription)
        {
            string message = "NOT SUCCEEDED";
            foreach (var med in medicalRecords)
            {
                if (med.patient == prescription.patientName)
                {
                    med.prescriptions.Add(prescription);
                    writeInJson();
                    message = "SUCCEEDED";
                    break;
                }
            }

            return message;
        }

        public string UpdatePrescription(Prescription prescription)
        {
            string message = "NOT SUCCEEDED";
            foreach (var med in medicalRecords)
            {
                foreach (var p in med.prescriptions)
                {
                    if (p.id == prescription.id)
                    {
                        message = "SUCCEEDED";
                        p.patientName = prescription.patientName;
                        p.medicineName = prescription.medicineName;
                        p.quantity = prescription.quantity;
                        p.usageInstruction = prescription.usageInstruction;
                        writeInJson();
                        break;
                    }
                }
            }
            return message;
        }

        public List<Prescription> ReadPatientPrescriptions(string patientsFullname)
        {
            List<Prescription> prescriptions = new List<Prescription>();
            foreach (var med in medicalRecords)
            {
                if (med.patient == patientsFullname)
                {
                    prescriptions = med.prescriptions;
                    break;
                }
            }
            return prescriptions;
        }

        public Prescription GetPrescriptionById(int prescriptionId)
      {
         throw new NotImplementedException();
      }
      
      public List<Prescription> GetPrescriptionsByPatientJmbg(string patientJmbg)
      {
         throw new NotImplementedException();
      }
   
   }
}