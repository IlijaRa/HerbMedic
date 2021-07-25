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

namespace HerbMedic.View.Secretary
{
    /// <summary>
    /// Interaction logic for HomeSecretary.xaml
    /// </summary>
    public partial class HomeSecretary : Window
    {
        public HomeSecretary()
        {
            InitializeComponent();
        }

        private void ButtonAppointmentCRUD(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
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

        private void ButtonLogOut(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Hide();
        }
    }
}
