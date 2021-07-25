using Classes.Model;
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
using Classes.Controller;
using System.Collections.ObjectModel;

namespace HerbMedic.View.Doctor
{
    public partial class ReceiveReferralLetters : Window
    {
        EmployeeController employeeController = new EmployeeController();
        ReferralLetterForSpecialistController referralLetterController = new ReferralLetterForSpecialistController();
        public ReceiveReferralLetters()
        {
            InitializeComponent();
            
        }

        public void TransferInfo(string username)
        {
            Textbox_username.Text = username;
        }

        private void ButtonGoBack(object sender, RoutedEventArgs e)
        {
            User user = employeeController.ReadEmployeeUserByUsername(Textbox_username.Text);
            HomeDoctor home = new HomeDoctor();
            home.Show();
            home.TransferInfoAboutUser(user);
            this.Hide();
        }

        public void TransferAndDisplayReferrals(string username)
        {
            Textbox_username.Text = username;
            List<ReferralLetterForSpecialist> letters = referralLetterController.ReadAllReferralLetters(Textbox_username.Text);
            ObservableCollection<ReferralLetterForSpecialist> observableLetters = new ObservableCollection<ReferralLetterForSpecialist>();
            foreach (var letter in observableLetters)
            {
                observableLetters.Add(letter);
            }
            dg_referrals.ItemsSource = observableLetters;
        }
    }
}
