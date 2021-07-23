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

namespace HerbMedic.View.Doctor
{
    public partial class DoctorMedicine : Window
    {
        MedicineController medicineController = new MedicineController();
        EmployeeController employeeController = new EmployeeController();
        public DoctorMedicine()
        {
            InitializeComponent();
        }

        private void ButtonGoBack(object sender, RoutedEventArgs e)
        {
            User user = employeeController.ReadEmployeeUserByUsername(Textbox_username.Text);
            HomeDoctor home = new HomeDoctor();
            home.Show();
            home.TransferInfoAboutUser(user);
            this.Hide();
        }
        private void ButtonAcceptMedicine(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDeclineMedicine(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonUpdateMedicine(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonReadAll(object sender, RoutedEventArgs e)
        {
            List<Medicine> medicines = medicineController.ReadAllMedicines();
            ObservableCollection<Medicine> observableMedicines = new ObservableCollection<Medicine>();
            foreach (var medicine in medicines)
            {
                observableMedicines.Add(medicine);
            }
            dg_medicines.ItemsSource = observableMedicines;
        }

        private void dg_ingredients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dg_alternatives_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void TransferInfo(string username)
        {
            Textbox_username.Text = username;
        }
    }
}
