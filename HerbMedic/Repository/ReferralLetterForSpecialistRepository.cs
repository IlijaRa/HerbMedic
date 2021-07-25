using Classes.Model;
using System.Collections.Generic;
using System;
using System.IO;
using Newtonsoft.Json;

namespace Classes.Repository
{
   public class ReferralLetterForSpecialistRepository
   {
        List<Employee> employees = new List<Employee>();

        public ReferralLetterForSpecialistRepository()
        {
            readEmployeeJson();
        }
        public void readEmployeeJson()
        {
            // deserializuje renovation.json
            if (!File.Exists("employees.json"))
            {
                File.Create("employees.json").Close();
            }

            using (StreamReader r = new StreamReader("employees.json"))
            {
                string json = r.ReadToEnd();
                if (json != "")
                {
                    employees = JsonConvert.DeserializeObject<List<Employee>>(json);
                }
            }
        }

        public void writeInJson()
        {
            string json = JsonConvert.SerializeObject(employees, Formatting.Indented);
            File.WriteAllText("employees.json", json);
        }

        public string CreateReferralLetter(ReferralLetterForSpecialist letter)
        {
            string message = "NOT SUCCEEDED";
            foreach(var e in employees.ToArray())
            {
                string employeeName = e.user.firstName + " " + e.user.lastName;
                if(employeeName == letter.doctorWhoReceives)
                {
                    e.referralLetters.Add(letter);
                    writeInJson();
                    message = "SUCCEEDED";
                }
            }
            return message;
        }

        public int CheckNumberOfReferrals(string username)
        {
            int counter=0;
            foreach(var e in employees)
            {
                if(e.user.username == username)
                {
                    foreach(var rl in e.referralLetters)
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }
        public List<ReferralLetterForSpecialist> ReadAllReferralLetters(string username)
        {
            List<ReferralLetterForSpecialist> letters = new List<ReferralLetterForSpecialist>();
            foreach(var e in employees)
            {
                if(e.user.username == username)
                {
                    foreach(var rl in e.referralLetters)
                    {
                        letters.Add(rl);
                    }
                }
            }
            return letters;
        }
    }
}