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

namespace HerbMedic.View.Doctor
{
    public partial class HomeDoctor : Window
    {
        public HomeDoctor()
        {
            InitializeComponent();
            Textbox1.Text = "makezza";
        }

        private void ButtonAppointmentCRUD(object sender, RoutedEventArgs e)
        {
            AppointmentCRUD appointment = new AppointmentCRUD();
            appointment.Show();
            appointment.TransferAndDisplayAppointments(Textbox1.Text);
            this.Hide();
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

        private void ButtonOperationCRUD(object sender, RoutedEventArgs e)
        {
            OperationCRUD operation = new OperationCRUD();
            operation.Show();
            operation.TransferAndDisplayOperations(Textbox1.Text);
            this.Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DutySchedule duty = new DutySchedule();
            duty.Show();
            duty.TransferAndDisplayOperations(Textbox1.Text);
            this.Hide();
        }
    }
}
