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
        }

        private void ButtonAppointmentCRUD(object sender, RoutedEventArgs e)
        {
            AppointmentCRUD appointment = new AppointmentCRUD();
            appointment.Show();
            appointment.TransferAndDisplayAppointments(Textbox1.Text);
            this.Hide();
        }
    }
}
