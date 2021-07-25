using Classes.Model;
using System;
using System.Collections.Generic;
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
using System.Collections.ObjectModel;
using ToastNotifications;
using ToastNotifications.Position;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;

namespace HerbMedic.View.Doctor
{
    public partial class ReceiveReferralLetters : Window
    {
        EmployeeController employeeController = new EmployeeController();
        ReferralLetterForSpecialistController referralLetterController = new ReferralLetterForSpecialistController();
        public ReceiveReferralLetters()
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

        public void TransferInfo(string username)
        {
            Textbox_username.Text = username;
        }

        private void ButtonGoBack(object sender, RoutedEventArgs e)
        {
            User user = employeeController.ReadEmployeeUserByUsername(Textbox_username.Text);
            HomeDoctor home = new HomeDoctor();
            home.Show();
            home.TransferInfoAboutUser(user);
            this.Hide();
        }

        public void TransferAndDisplayReferrals(string username)
        {
            Textbox_username.Text = username;
            List<ReferralLetterForSpecialist> letters = referralLetterController.ReadAllReferralLetters(Textbox_username.Text);
            ObservableCollection<ReferralLetterForSpecialist> observableLetters = new ObservableCollection<ReferralLetterForSpecialist>();
            foreach (var letter in letters)
            {
                observableLetters.Add(letter);
            }
            dg_referrals.ItemsSource = observableLetters;
        }

        private void ButtonHasBeenRead(object sender, RoutedEventArgs e)
        {
            if(dg_referrals.SelectedItems.Count < 1)
            {
                notifier.ShowWarning("WARNING: You need to select a letter!");
            }
            else
            {
                ReferralLetterForSpecialist selectedLetter = (ReferralLetterForSpecialist)dg_referrals.SelectedItem;
                string message= referralLetterController.DeleteReferralLetter(selectedLetter);
                if (message == "SUCCEEDED")
                {
                    notifier.ShowSuccess("SUCCESS: Referral is reviewed!");
                    List<ReferralLetterForSpecialist> letters = referralLetterController.ReadAllReferralLetters(Textbox_username.Text);
                    ObservableCollection<ReferralLetterForSpecialist> observableLetters = new ObservableCollection<ReferralLetterForSpecialist>();
                    foreach (var letter in letters)
                    {
                        observableLetters.Add(letter);
                    }
                    dg_referrals.ItemsSource = observableLetters;
                }
                else
                    notifier.ShowError("ERROR: Error occured while deleting referral!");
            }
        }
    }
}
