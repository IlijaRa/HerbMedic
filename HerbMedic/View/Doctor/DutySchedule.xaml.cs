using Classes.Controller;
using Classes.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;
using HerbMedic.View.MessageBoxes;

namespace HerbMedic.View.Doctor
{
    public partial class DutySchedule : Window
    {
        EmployeeController employeeController = new EmployeeController();
        PatientController patientController = new PatientController();
        MedicalRecordController medicalRecordController = new MedicalRecordController();
        public DutySchedule()
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

        private void ButtonGoBack(object sender, RoutedEventArgs e)
        {
            User user = employeeController.ReadEmployeeUserByUsername(Textbox_username.Text);
            HomeDoctor home = new HomeDoctor();
            home.Show();
            home.TransferInfoAboutUser(user);
            home.CheckNotifications(Textbox_username.Text);
            this.Hide();
        }

        public void TransferAndDisplayOperations(string username)
        {
            Textbox_username.Text = username;
            List<Appointment> appointments = employeeController.ReadAllDutiesByUsername(Textbox_username.Text);
            ObservableCollection<Appointment> observableAppointments = new ObservableCollection<Appointment>();
            foreach (var appointment in appointments)
            {
                observableAppointments.Add(appointment);
            }
            dg_appointsOperations.ItemsSource = observableAppointments;
        }

        private void dg_appointsOperations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Appointment appointment = (Appointment)dg_appointsOperations.SelectedItem;
            Classes.Model.Patient patient = patientController.ReadPatientByNameSurname(appointment.patient);
            Textbox1.Text = patient.user.firstName;
            Textbox2.Text = patient.user.lastName;
            Textbox3.Text = patient.user.username;
            Textbox4.Text = patient.user.jmbg;
            Textbox5.Text = patient.user.phoneNumber;
            Textbox6.Text = patient.user.dateOfBirth.Date.ToString("d/MM/yyyy");
            Textbox7.Text = patient.bloodType;
            Textbox8.Text = patient.height.ToString();
            Textbox9.Text = patient.weight.ToString();
        }

        private void ButtonMedicalRecord(object sender, RoutedEventArgs e)
        {
            if(Textbox1.Text != "" && Textbox2.Text != "")
            {
                string fullName = Textbox1.Text + " " + Textbox2.Text;
                if (medicalRecordController.CheckIfPatientHasMedicalRecord(fullName) == true)
                {
                    MedicalRecord medical = new MedicalRecord();
                    medical.Show();
                    medical.TransferInfoForMedicalRecord(Textbox1.Text, Textbox2.Text, Textbox_username.Text);
                    this.Hide();
                }
                else
                {
                    MedicalRecordDoesntExists doesntExists = new MedicalRecordDoesntExists();
                    doesntExists.Show();
                    doesntExists.TransferInfo(Textbox1.Text + " " + Textbox2.Text, Textbox_username.Text);
                }
            }
            else
            {
                notifier.ShowWarning("WARNING: You need to select a patient!");
            }
        }

        private void ButtonReferralLetter(object sender, RoutedEventArgs e)
        {
            if (Textbox1.Text != "" && Textbox2.Text != "")
            {
                string fullName = Textbox1.Text + " " + Textbox2.Text;
                ReferralLetterForSpecialistForm referral = new ReferralLetterForSpecialistForm();
                referral.Show();
                referral.TransferInfoForMedicalRecord(Textbox1.Text, Textbox2.Text, Textbox_username.Text);
                this.Hide();
            }
            else
            {
                notifier.ShowWarning("WARNING: You need to select a patient!");
            }
        }
    }
}
