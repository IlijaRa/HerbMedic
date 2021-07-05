// File:    MedicalRecord.cs
// Author:  LENOVO
// Created: Friday, April 9, 2021 20:54:52
// Purpose: Definition of Class MedicalRecord

using System;

namespace Classes.Model
{
   public class MedicalRecord
   {
      public System.Collections.Generic.List<Prescription> prescription;
      
      /// <summary>
      /// Property for collection of Prescription
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Prescription> Prescription
      {
         get
         {
            if (prescription == null)
               prescription = new System.Collections.Generic.List<Prescription>();
            return prescription;
         }
         set
         {
            RemoveAllPrescription();
            if (value != null)
            {
               foreach (Prescription oPrescription in value)
                  AddPrescription(oPrescription);
            }
         }
      }
      
      /// <summary>
      /// Add a new Prescription in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddPrescription(Prescription newPrescription)
      {
         if (newPrescription == null)
            return;
         if (this.prescription == null)
            this.prescription = new System.Collections.Generic.List<Prescription>();
         if (!this.prescription.Contains(newPrescription))
         {
            this.prescription.Add(newPrescription);
            newPrescription.MedicalRecord = this;
         }
      }
      
      /// <summary>
      /// Remove an existing Prescription from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemovePrescription(Prescription oldPrescription)
      {
         if (oldPrescription == null)
            return;
         if (this.prescription != null)
            if (this.prescription.Contains(oldPrescription))
            {
               this.prescription.Remove(oldPrescription);
               oldPrescription.MedicalRecord = null;
            }
      }
      
      /// <summary>
      /// Remove all instances of Prescription from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllPrescription()
      {
         if (prescription != null)
         {
            System.Collections.ArrayList tmpPrescription = new System.Collections.ArrayList();
            foreach (Prescription oldPrescription in prescription)
               tmpPrescription.Add(oldPrescription);
            prescription.Clear();
            foreach (Prescription oldPrescription in tmpPrescription)
               oldPrescription.MedicalRecord = null;
            tmpPrescription.Clear();
         }
      }
      public System.Collections.Generic.List<Allergen> allergen;
      
      /// <summary>
      /// Property for collection of Allergen
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Allergen> Allergen
      {
         get
         {
            if (allergen == null)
               allergen = new System.Collections.Generic.List<Allergen>();
            return allergen;
         }
         set
         {
            RemoveAllAllergen();
            if (value != null)
            {
               foreach (Allergen oAllergen in value)
                  AddAllergen(oAllergen);
            }
         }
      }
      
      /// <summary>
      /// Add a new Allergen in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddAllergen(Allergen newAllergen)
      {
         if (newAllergen == null)
            return;
         if (this.allergen == null)
            this.allergen = new System.Collections.Generic.List<Allergen>();
         if (!this.allergen.Contains(newAllergen))
            this.allergen.Add(newAllergen);
      }
      
      /// <summary>
      /// Remove an existing Allergen from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveAllergen(Allergen oldAllergen)
      {
         if (oldAllergen == null)
            return;
         if (this.allergen != null)
            if (this.allergen.Contains(oldAllergen))
               this.allergen.Remove(oldAllergen);
      }
      
      /// <summary>
      /// Remove all instances of Allergen from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllAllergen()
      {
         if (allergen != null)
            allergen.Clear();
      }
      public Patient patient;
      public Anamnesis[] anamnesis;
   
   }
}