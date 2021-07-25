using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Classes.Model;
using Classes.Controller;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using ToastNotifications.Messages;

namespace HerbMedic.View.Doctor
{
    public partial class ReferralLetterForSpecialistForm : Window
    {
        EmployeeController employeeController = new EmployeeController();
        ReferralLetterForSpecialistController referralLetterForSpecialistController = new ReferralLetterForSpecialistController();
        public ReferralLetterForSpecialistForm()
        {
            InitializeComponent();
            List<Employee> doctors = employeeController.ReadAllDoctors();
            List<string> doctorNames = new List<string>();
            foreach(var d in doctors)
            {
                doctorNames.Add(d.user.firstName + " " + d.user.lastName);
            }
            cb_doctorNames.ItemsSource = doctorNames;
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
            DutySchedule duty = new DutySchedule();
            duty.Show();
            duty.TransferAndDisplayOperations(Textbox_username.Text);
            this.Hide();
        }

        public void TransferInfoForMedicalRecord(string name, string surname, string username)
        {
            Textbox1.Text = name;
            Textbox2.Text = surname;
            Textbox_username.Text = username;
        }

        private void ButtonSendReferralLetter(object sender, RoutedEventArgs e)
        {
            if(Textbox1.Text != "" && Textbox2.Text != "" && cb_doctorNames.Text !="" && Textbox3.Text != "")
            {
                Random random = new Random();
                Employee employee = employeeController.FindEmployeeByUsername(Textbox_username.Text);
                string patientName = Textbox1.Text + " " + Textbox2.Text;
                string doctorName = employee.user.firstName + " " + employee.user.lastName;

                ReferralLetterForSpecialist referral = new ReferralLetterForSpecialist(random.Next(1000),
                                                                                       doctorName,
                                                                                       cb_doctorNames.Text,
                                                                                       patientName,
                                                                                       Textbox3.Text);
                string message = referralLetterForSpecialistController.CreateReferralLetter(referral);
                if(message == "SUCCEEDED")
                {
                    notifier.ShowSuccess("SUCCESS: Referral letter is sent to a doctor!");
                    cb_doctorNames.Text=" ";
                    Textbox3.Clear();
                }
                else
                {
                    notifier.ShowError("ERROR: Error occured while sending a referral letter");
                }
            }
        }
    }
}
