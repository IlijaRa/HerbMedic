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

namespace HerbMedic.View.Doctor
{
    public partial class MedicalRecord : Window
    {
        public MedicalRecord()
        {
            InitializeComponent();
        }

        private void ButtonGoBack(object sender, RoutedEventArgs e)
        {
            DutySchedule duty = new DutySchedule();
            duty.Show();
            duty.TransferAndDisplayOperations(Textbox_username.Text);
            this.Hide();
        }

        public void TransferInfoForMedicalRecord(string name, string surname, string username)
        {
            Textbox1.Text = name;
            Textbox2.Text = surname;
            Textbox_username.Text = username;
        }

        private void ButtonAnamnesis(object sender, RoutedEventArgs e)
        {
            Anamnesis anamesis = new Anamnesis();
            anamesis.Show();
            anamesis.TransferInfo(Textbox1.Text, Textbox2.Text, Textbox_username.Text);
            this.Hide();
        }

        private void ButtonPrescription(object sender, RoutedEventArgs e)
        {
            PrescriptionForm prescription = new PrescriptionForm();
            prescription.Show();
            prescription.TransferInfo(Textbox1.Text, Textbox2.Text, Textbox_username.Text);
            this.Hide();
        }

        private void ButtonAllergens(object sender, RoutedEventArgs e)
        {

        }
    }
}
