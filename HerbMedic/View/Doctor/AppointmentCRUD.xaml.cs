using Classes.Controller;
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
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;

namespace HerbMedic.View.Doctor
{
    public partial class AppointmentCRUD : Window
    {
        EmployeeController employeeController = new EmployeeController();
        PatientController patientController = new PatientController();
        public AppointmentCRUD()
        {
            InitializeComponent();
            List<Classes.Model.Patient> patients = patientController.ReadAllPatients();
            List<string> nameSurname = new List<string>();

            foreach(var patient in patients)
            {
                nameSurname.Add(patient.user.firstName + " " +patient.user.lastName);
            }

            Combobox1.ItemsSource = nameSurname;
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
                        var brush = SetRGBColor(45, 173, 246);
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
        private void ButtonCreate(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonUpdate(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDelete(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonReadAll(object sender, RoutedEventArgs e)
        {

        }

        public void TransferAndDisplayAppointments(string username)
        {
            Textbox_username.Text = username;
            List<Appointment> appointments = employeeController.ReadAppointmentsByUsername(Textbox_username.Text);
            ObservableCollection<Appointment> observableAppointments = new ObservableCollection<Appointment>();
            foreach (var appointment in appointments)
            {
                observableAppointments.Add(appointment);
            }
            dg_appointments.ItemsSource = observableAppointments;
        }

        private void ButtonGoBack(object sender, RoutedEventArgs e)
        {

        }
    }
}
