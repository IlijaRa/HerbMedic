using Classes.Controller;
using Classes.Model;
using Newtonsoft.Json;
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
    public partial class OperationCRUD : Window
    {
        EmployeeController employeeController = new EmployeeController();
        PatientController patientController = new PatientController();
        AppointmentController appointmentController = new AppointmentController();
        StaticEquipmentController staticController = new StaticEquipmentController();
        RoomController roomController = new RoomController();

        public OperationCRUD()
        {
            InitializeComponent();
            List<Classes.Model.Patient> patients = patientController.ReadAllPatients();
            List<StaticEquipment> statics = staticController.ReadAllStaticEquipment();

            List<string> nameSurname = new List<string>();

            foreach (var patient in patients)
            {
                nameSurname.Add(patient.user.firstName + " " + patient.user.lastName);
            }
            Combobox1.ItemsSource = nameSurname;

            List<string> staticName = new List<string>();

            foreach (var stat in statics)
            {
                staticName.Add(stat.name);
            }
            Combobox3.ItemsSource = staticName;

            List<Room> rooms = roomController.ReadAllRooms();
            //ObservableCollection<Room> observableRooms = new ObservableCollection<Room>();
            List<string> roomy = new List<string>();
            foreach (var room in rooms)
            {
                roomy.Add(room.name);
            }
            Textbox4.ItemsSource = roomy;
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
        private void ButtonSearch(object sender, RoutedEventArgs e)
        {
            try
            {
                List<string> operationEquipment = appointmentController.FormatOperationEquipment(Textbox5.Text);
                List<Room> rooms = roomController.FindRoomsByEquipmentForOperation(operationEquipment);
                dg_rooms.ItemsSource = rooms;

                Textbox5.Text = "";
            }
            catch (Exception ex)
            {
                notifier.ShowError("ERROR: When you enter equipment for operation, it needs to be separated by comma");
            }
        }

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
                    if (Textbox2.Text == "" || Textbox3.Text == "" || Textbox4.Text == "" || Datepicker1.Text == "" || Combobox1.Text == "" || Combobox2.Text == "")
                    {
                        notifier.ShowWarning("WARNING: You need too fill all empty places!");
                    }
                    else
                    {
                        Appointment operation = new Appointment(random.Next(1000),
                                                                  false,
                                                                  Combobox1.Text,
                                                                  Textbox_username.Text,
                                                                  Convert.ToDateTime(Datepicker1.Text),
                                                                  Convert.ToDateTime(Textbox2.Text),
                                                                  Convert.ToDateTime(Textbox3.Text),
                                                                  Textbox4.Text,
                                                                  Combobox2.Text);
                        string message = appointmentController.CreateAppointment(operation);

                        if (message == "SUCCEEDED")
                            notifier.ShowSuccess("SUCCESS: Operation is successfully created!");
                        else
                            notifier.ShowError("ERROR: Operation isn't created! Check date inputs");

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
                Appointment operation = new Appointment(Convert.ToInt32(Textbox1.Text),
                                                          false,
                                                          Combobox1.Text,
                                                          Textbox_username.Text,
                                                          Convert.ToDateTime(Datepicker1.Text),
                                                          Convert.ToDateTime(Textbox2.Text),
                                                          Convert.ToDateTime(Textbox3.Text),
                                                          room,
                                                          Combobox2.Text);

                string message = appointmentController.UpdateAppointment(operation);

                if (message == "SUCCEEDED")
                {
                    notifier.ShowSuccess("SUCCESS: Operation is updated!");

                }
                else
                    notifier.ShowError("ERROR: Operation isn't updated! Check your inputs.");
            }
            catch
            {
                notifier.ShowWarning("WARNING: Blanks are poorly filled!");
            }
        }

        private void ButtonDelete(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dg_operations.SelectedCells.Count > 0)
                {
                    Appointment selectedOperation = (Appointment)dg_operations.SelectedItem;
                    string message = appointmentController.DeleteAppointment(selectedOperation.id, Textbox_username.Text);
                    if (message == "SUCCEEDED")
                    {
                        notifier.ShowSuccess("SUCCESS: Operation is deleted!");
                    }
                    else
                        notifier.ShowWarning("ERROR: Operation isn't deleted!");
                }
                else
                {
                    notifier.ShowWarning("WARNING: You didn't select an operation!");
                }
            }
            catch
            {
                notifier.ShowWarning("WARNING: Blanks are poorly filled!");
            }
        }

        private void ButtonReadAll(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Appointment> operations = employeeController.ReadOperationsByUsername(Textbox_username.Text);
                ObservableCollection<Appointment> observableAppointments = new ObservableCollection<Appointment>();
                foreach (var o in operations)
                {
                    observableAppointments.Add(o);
                }
                dg_operations.ItemsSource = observableAppointments;
            }
            catch (Exception exception)
            {
                notifier.ShowError(exception.Message);
            }
        }

        public void TransferAndDisplayOperations(string username)
        {
            Textbox_username.Text = username;
            List<Appointment> appointments = employeeController.ReadOperationsByUsername(Textbox_username.Text);
            ObservableCollection<Appointment> observableAppointments = new ObservableCollection<Appointment>();
            foreach (var appointment in appointments)
            {
                observableAppointments.Add(appointment);
            }
            dg_operations.ItemsSource = observableAppointments;
        }

        private void ButtonGoBack(object sender, RoutedEventArgs e)
        {
            User user = employeeController.ReadEmployeeUserByUsername(Textbox_username.Text);
            HomeDoctor home = new HomeDoctor();
            home.Show();
            home.TransferInfoAboutUser(user);
            this.Hide();
        }

        private void Combobox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Textbox5.Text += Combobox3.SelectedItem + ",";
        }
    }
}

