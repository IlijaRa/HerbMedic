// File:    Prescription.cs
// Author:  HP-Miha
// Created: Thursday, April 8, 2021 19:20:33
// Purpose: Definition of Class Prescription

using System;

namespace Classes.Model
{
   public class Prescription
   {
      public int id;
      public string usage;
      public int quantity;
      
      public System.Collections.Generic.List<Medicine> medicine;
      
      /// <summary>
      /// Property for collection of Medicine
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Medicine> Medicine
      {
         get
         {
            if (medicine == null)
               medicine = new System.Collections.Generic.List<Medicine>();
            return medicine;
         }
         set
         {
            RemoveAllMedicine();
            if (value != null)
            {
               foreach (Medicine oMedicine in value)
                  AddMedicine(oMedicine);
            }
         }
      }
      
      /// <summary>
      /// Add a new Medicine in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddMedicine(Medicine newMedicine)
      {
         if (newMedicine == null)
            return;
         if (this.medicine == null)
            this.medicine = new System.Collections.Generic.List<Medicine>();
         if (!this.medicine.Contains(newMedicine))
            this.medicine.Add(newMedicine);
      }
      
      /// <summary>
      /// Remove an existing Medicine from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveMedicine(Medicine oldMedicine)
      {
         if (oldMedicine == null)
            return;
         if (this.medicine != null)
            if (this.medicine.Contains(oldMedicine))
               this.medicine.Remove(oldMedicine);
      }
      
      /// <summary>
      /// Remove all instances of Medicine from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllMedicine()
      {
         if (medicine != null)
            medicine.Clear();
      }
      public MedicalRecord medicalRecord;
      
      /// <summary>
      /// Property for MedicalRecord
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public MedicalRecord MedicalRecord
      {
         get
         {
            return medicalRecord;
         }
         set
         {
            if (this.medicalRecord == null || !this.medicalRecord.Equals(value))
            {
               if (this.medicalRecord != null)
               {
                  MedicalRecord oldMedicalRecord = this.medicalRecord;
                  this.medicalRecord = null;
                  oldMedicalRecord.RemovePrescription(this);
               }
               if (value != null)
               {
                  this.medicalRecord = value;
                  this.medicalRecord.AddPrescription(this);
               }
            }
         }
      }
   
   }
}