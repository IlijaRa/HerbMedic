using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Classes.Model;
using Classes.Controller;

namespace HerbMedic.View.MessageBoxes
{
    public partial class MedicalRecordDoesntExists : Window
    {
        MedicalRecordController medicalRecordController = new MedicalRecordController();
        public MedicalRecordDoesntExists()
        {
            InitializeComponent();
        }

        public void TransferInfo(string fullName, string doctorUsername)
        {
            Textbox1.Text = fullName;
            Textbox2.Text = doctorUsername;
        }

        private void ButtonNO(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void ButtonYES(object sender, RoutedEventArgs e)
        {
            List<Anamnesis> anamnesis = new List<Anamnesis>();
            List<Prescription> prescriptions = new List<Prescription>();
            List<Allergen> allergens = new List<Allergen>();

            MedicalRecord medicalRecord = new MedicalRecord(Textbox1.Text,
                                                            anamnesis,
                                                            prescriptions,
                                                            allergens);

            bool isCreated = medicalRecordController.CreateMedicalRecord(medicalRecord);
            if (isCreated)
            {
                string[] nameSurname = Textbox1.Text.Split(' ');
                HerbMedic.View.Doctor.MedicalRecord medical = new HerbMedic.View.Doctor.MedicalRecord();
                medical.Show();
                medical.TransferInfoForMedicalRecord(nameSurname[0],nameSurname[1], Textbox2.Text);
                this.Hide();
            }
            this.Hide();
        }
    }
}
