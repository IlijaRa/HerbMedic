using Classes.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace HerbMedic.View.Patient
{
    public partial class SelectedDoctorTerms : Window
    {
        EmployeeController employeeController = new EmployeeController();
        public SelectedDoctorTerms()
        {
            InitializeComponent();
        }

        private void ButtonOK(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
        public void TransferAndDisplayTerms(string doctor)
        {
            List<Appointment> appointments = employeeController.ReadTermsOfDoctorByNameSurname(doctor);
            ObservableCollection<Appointment> observableAppointments = new ObservableCollection<Appointment>();
            foreach (var appointment in appointments)
            {
                observableAppointments.Add(appointment);
            }
            dg_terms.ItemsSource = observableAppointments;
        }
    }
}
