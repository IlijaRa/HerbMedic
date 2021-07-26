using Classes.Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using Classes.Controller;

namespace HerbMedic.View.Doctor
{
    public partial class HomeDoctor : Window
    {
        ReferralLetterForSpecialistController referralLetterForSpecialistController = new ReferralLetterForSpecialistController();
        public HomeDoctor()
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

        private void ButtonAppointmentCRUD(object sender, RoutedEventArgs e)
        {
            AppointmentCRUD appointment = new AppointmentCRUD();
            appointment.Show();
            appointment.TransferAndDisplayAppointments(Textbox1.Text);
            this.Hide();
        }

        public void TransferInfoAboutUser(User user)
        {
            Textbox1.Text = user.username;
            Textbox2.Text = user.password;
            Textbox3.Text = user.firstName;
            Textbox4.Text = user.lastName;
            Textbox5.Text = user.jmbg;
            Textbox6.Text = user.phoneNumber;
            Textbox7.Text = user.address;
            Textbox8.Text = user.email;
            Textbox9.Text = user.dateOfBirth.Date.ToString("d/MM/yyyy");
        }

        private void ButtonOperationCRUD(object sender, RoutedEventArgs e)
        {
            OperationCRUD operation = new OperationCRUD();
            operation.Show();
            operation.TransferAndDisplayOperations(Textbox1.Text);
            this.Hide();
        }

        private void ButtonDutySchedule(object sender, RoutedEventArgs e)
        {
            DutySchedule duty = new DutySchedule();
            duty.Show();
            duty.TransferAndDisplayOperations(Textbox1.Text);
            this.Hide();
        }

        private void ButtonMedicineCRUD(object sender, RoutedEventArgs e)
        {
            DoctorMedicine medicine = new DoctorMedicine();
            medicine.Show();
            medicine.TransferInfo(Textbox1.Text);
            this.Hide();
        }

        private void ButtonReadNotifications(object sender, RoutedEventArgs e)
        {
            ReceiveReferralLetters receivedReferrals = new ReceiveReferralLetters();
            receivedReferrals.Show();
            receivedReferrals.TransferAndDisplayReferrals(Textbox1.Text);
            this.Hide();
        }

        private void ButtonLogOut(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Hide();
        }

        private void ButtonMinimized(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        public void CheckNotifications(string username)
        {
            int numberOfReferrals = referralLetterForSpecialistController.CheckNumberOfReferrals(username);
            if (numberOfReferrals > 0)
            {
                btn_notifications.Background = SetRGBColor(244, 119, 117);
            }
        }
    }
}
