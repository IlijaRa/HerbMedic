using Classes.Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using Classes.Controller;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ToastNotifications.Messages;

namespace HerbMedic.View.Patient
{
    public partial class ExaminationCRUD : Window
    {
        EmployeeController employeeController = new EmployeeController();
        PatientController patientController = new PatientController();
        AppointmentController appointmentController = new AppointmentController();

        public ExaminationCRUD()
        {
            InitializeComponent();
            List<Employee> doctors = employeeController.ReadAllDoctors();
            List<string> nameSurname = new List<string>();

            foreach (var doctor in doctors)
            {
                nameSurname.Add(doctor.user.firstName + " " + doctor.user.lastName);
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
                        var brush = SetRGBColor(255, 195, 0);
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
            Classes.Model.Patient patient = patientController.ReadPatientByUsername(Textbox_username.Text);
            HomePatient home = new HomePatient();
            home.Show();
            home.TransferInfoAboutUser(patient.user);
            //home.CheckNotifications(Textbox_username.Text);
            this.Hide();
        }

        private void ButtonCreate(object sender, RoutedEventArgs e)
        {

            if (Textbox2.Text != "" && Textbox3.Text != "" && Combobox1.Text != "" && Datepicker1.Text != "")
            {
                bool IsTimeOK = patientController.isTimeOK(Convert.ToDateTime(Datepicker1.Text), Textbox2.Text, Textbox3.Text);
                if (IsTimeOK)
                {
                    Random random = new Random();
                    Classes.Model.Patient patient = patientController.ReadPatientByUsername(Textbox_username.Text);
                    Employee doctor = employeeController.ReadEmployeeByNameSurname(Combobox1.Text);
                    
                    Appointment appointment = new Appointment(random.Next(1000),
                                                              false,
                                                              patient.user.firstName + " " + patient.user.lastName,
                                                              doctor.user.username,
                                                              Convert.ToDateTime(Datepicker1.Text),
                                                              Convert.ToDateTime(Textbox2.Text),
                                                              Convert.ToDateTime(Textbox3.Text),
                                                              doctor.room,
                                                              "Examination");

                    bool isDoctorAvailable = employeeController.CheckIfDoctorIsAvailable(appointment);
                    if (isDoctorAvailable)
                    {
                        string message = appointmentController.CreateAppointment(appointment);
                        string message1 = patientController.CreateExamination(appointment);
                        if(message == "SUCCEEDED" && message1 == "SUCCEEDED")
                            notifier.ShowSuccess("SUCCESS: Appointment is created!");
                        else
                            notifier.ShowError("ERROR: Error occured while creating, check your date&time inputs!");
                    }
                    else
                    {
                        notifier.ShowError("ERROR: Doctor is not available at that term!");
                    }
                }
                else
                {
                    notifier.ShowError("WARNING: Date or time are not good!");
                }
            }
            else
            {
                notifier.ShowWarning("WARNING: You need to fill all fields!");
            }
        }

        private void ButtonUpdate(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonDelete(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonReadAll(object sender, RoutedEventArgs e)
        {
            List<Appointment> examinations = patientController.ReadExaminationsByUsername(Textbox_username.Text);
            ObservableCollection<Appointment> observableExaminations = new ObservableCollection<Appointment>();
            foreach (var ex in examinations)
            {
                observableExaminations.Add(ex);
            }
            dg_examinations.ItemsSource = observableExaminations;
        }

        public void TransferAndDisplayExaminations(string username)
        {
            Textbox_username.Text = username;
            List<Appointment> examinations = patientController.ReadExaminationsByUsername(Textbox_username.Text);
            ObservableCollection<Appointment> observableExaminations = new ObservableCollection<Appointment>();
            foreach (var ex in examinations)
            {
                observableExaminations.Add(ex);
            }
            dg_examinations.ItemsSource = observableExaminations;
        }

        private void Combobox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string doctor = (string)Combobox1.SelectedItem;
            SelectedDoctorTerms terms = new SelectedDoctorTerms();
            terms.Show();
            terms.TransferAndDisplayTerms(doctor);
        }
    }
}
