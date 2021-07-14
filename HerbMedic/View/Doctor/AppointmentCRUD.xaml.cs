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
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace HerbMedic.View.Doctor
{
    public partial class AppointmentCRUD : Window
    {
        EmployeeController employeeController = new EmployeeController();
        PatientController patientController = new PatientController();
        AppointmentController appointmentController = new AppointmentController();

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
            Random random = new Random();
            bool passed = false;
            string s1 = String.Empty;
            string s2 = String.Empty;
            DateTime dt;
            try
            {
                s1 = Textbox2.Text;
                dt = Convert.ToDateTime(s1);
                s1 = dt.ToString("HH:mm");
                passed = true;
                try
                {
                    s2 = Textbox3.Text;
                    dt = Convert.ToDateTime(s2);
                    s2 = dt.ToString("HH:mm");
                    passed = true;
                    if (Textbox2.Text == "" || Textbox3.Text == "" || Datepicker1.Text == "" || Combobox1.Text == "" || Combobox2.Text == "")
                    {
                        notifier.ShowWarning("WARNING: You need too fill all empty places!");
                    }
                    else{
                        string room= employeeController.ReadEmployeesRoomByUsername(Textbox_username.Text);

                        Appointment appointment = new Appointment(random.Next(1000),
                                                                  false,
                                                                  Combobox1.Text,
                                                                  Textbox_username.Text,
                                                                  Convert.ToDateTime(Datepicker1.Text),
                                                                  Convert.ToDateTime(Textbox2.Text),
                                                                  Convert.ToDateTime(Textbox3.Text),
                                                                  room,
                                                                  Combobox2.Text);
                        string message = appointmentController.CreateAppointment(appointment);

                        if (message == "SUCCEEDED")
                            notifier.ShowSuccess("SUCCESS: Appointment is successfully created!");
                        else
                            notifier.ShowError("ERROR: Appointment isn't created! Check date inputs");

                    }
                }

                catch (Exception ex)
                {
                    notifier.ShowWarning("WARNING: End time format is bad!");
                }
            }
            catch (Exception ex)
            {
                notifier.ShowWarning("WARNING: Start time format is bad!");
            }
        }

        private void ButtonUpdate(object sender, RoutedEventArgs e)
        {
            try
            {
                string room = employeeController.ReadEmployeesRoomByUsername(Textbox_username.Text);
                Appointment appointment = new Appointment(Convert.ToInt32(Textbox1.Text),
                                                          false,
                                                          Combobox1.Text,
                                                          Textbox_username.Text,
                                                          Convert.ToDateTime(Datepicker1.Text),
                                                          Convert.ToDateTime(Textbox2.Text),
                                                          Convert.ToDateTime(Textbox3.Text),
                                                          room,
                                                          Combobox2.Text);
                
                string message = appointmentController.UpdateAppointment(appointment);

                if (message == "SUCCEEDED")
                {
                    notifier.ShowSuccess("SUCCESS: Appointment is updated!");
                }
                else
                    notifier.ShowError("ERROR: Appointment isn't updated! Check your inputs.");
            }
            catch
            {
                notifier.ShowWarning("WARNING: Something went wrong!");
            }
        }

        private void ButtonDelete(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dg_appointments.SelectedCells.Count > 0)
                {
                    Appointment selectedAppointment = (Appointment)dg_appointments.SelectedItem;
                    string message = appointmentController.DeleteAppointment(selectedAppointment.id, Textbox_username.Text);
                    if (message == "SUCCEEDED")
                    {
                        notifier.ShowSuccess("SUCCESS: Appointment is deleted!");
                    }
                    else
                        notifier.ShowWarning("ERROR: Appointment isn't deleted!");
                }
                else
                {
                    notifier.ShowWarning("WARNING: You didn't select an appointment!");
                }
            }
            catch
            {
                notifier.ShowWarning("WARNING: Blanks are poorly filled!");
            }
        }

        private void ButtonReadAll(object sender, RoutedEventArgs e)
        {
            List<Appointment> appointments = employeeController.ReadAppointmentsByUsername(Textbox_username.Text);
            ObservableCollection<Appointment> observableAppointments = new ObservableCollection<Appointment>();
            foreach (var appointment in appointments)
            {
                observableAppointments.Add(appointment);
            }
            dg_appointments.ItemsSource = observableAppointments;
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
            User user= employeeController.ReadEmployeeUserByUsername(Textbox_username.Text);
            HomeDoctor home = new HomeDoctor();
            home.Show();
            home.TransferInfoAboutUser(user);
            this.Hide();
        }
    }
}
