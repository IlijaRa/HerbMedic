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
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using ToastNotifications.Messages;

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

        /*----------------------------WPF PART--------------------------------*/

                    /* Here is the implementation of toast notifications */
                    Notifier notifier = new Notifier(cfg =>
                    {
                        cfg.PositionProvider = new WindowPositionProvider(
                            parentWindow: Application.Current.MainWindow,
                            corner: Corner.BottomCenter,
                            offsetX: 10,
                            offsetY: 10);

                        cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                            notificationLifetime: TimeSpan.FromSeconds(2),
                            maximumNotificationCount: MaximumNotificationCount.FromCount(5));

                        cfg.Dispatcher = Application.Current.Dispatcher;
                    });
                    /*-------------implementation ends here------------ */

                    private void OnGotFocusTextbox(object sender, RoutedEventArgs e)
                    {
                        var brush = SetRGBColor(32, 158, 103);
                        TextBox text = e.Source as TextBox;
                        text.Background = brush;
                    }
                    private void OnLostFocusTextbox(object sender, RoutedEventArgs e)
                    {
                        TextBox text = e.Source as TextBox;
                        text.Background = Brushes.White;
                    }
                    public Brush SetRGBColor(int red, int green, int blue)
                    {
                        int R = red;
                        int G = green;
                        int B = blue;
                        var brush = new SolidColorBrush(Color.FromArgb(255, (byte)R, (byte)G, (byte)B));
                        return brush;
                    }
        /*----------------------------FUNCTIONALITY PART--------------------------------*/

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
            if(dg_medicines.SelectedItems.Count < 1)
            {
                notifier.ShowWarning("WARNING: Firstly you need to select a medicine!");
            }
            else
            {
                Medicine medicine = (Medicine)dg_medicines.SelectedItem;
                string message = medicineController.VerificateMedicine(medicine);
                if (message == "SUCCEEDED")
                    notifier.ShowSuccess("SUCCESS: Medicine is validated");
                else
                    notifier.ShowError("ERROR: Error occured while validating");
            }
        }

        private void ButtonDeclineMedicine(object sender, RoutedEventArgs e)
        {
            if (dg_medicines.SelectedItems.Count < 1)
            {
                notifier.ShowWarning("WARNING: Firstly you need to select a medicine!");
            }
            else
            {
                Medicine medicine = (Medicine)dg_medicines.SelectedItem;
                MedicineDeclining medDeclining = new MedicineDeclining();
                medDeclining.Show();
                medDeclining.TransferInfo(medicine);
            }
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
