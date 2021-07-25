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

namespace HerbMedic.View.Patient
{
    /// <summary>
    /// Interaction logic for HomePatient.xaml
    /// </summary>
    public partial class HomePatient : Window
    {
        public HomePatient()
        {
            InitializeComponent();
        }

        private void ButtonRoomCRUD(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonMedicineCRUD(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonStaticEquipmentCRUD(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDynamicEquipmentCRUD(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSearchEquipment(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonEquipmentManagement(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAdvancedRenovation(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonBasicRenovation(object sender, RoutedEventArgs e)
        {

        }
        public void TransferInfoAboutUser(User user)
        {
            Textbox1.Text = user.username;
            Textbox2.Text = user.password;
            Textbox3.Text = user.firstName;
            Textbox4.Text = user.lastName;
            Textbox5.Text = user.jmbg;
            Textbox6.Text = user.phoneNumber;
            Textbox7.Text = user.address;
            Textbox8.Text = user.email;
            Textbox9.Text = user.dateOfBirth.Date.ToString("d/MM/yyyy");
        }
    }
}
