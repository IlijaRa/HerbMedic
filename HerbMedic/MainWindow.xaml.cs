using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Classes.Controller;
using Classes.Model;
using HerbMedic.View;
using HerbMedic.View.Doctor;
using HerbMedic.View.Patient;
using HerbMedic.View.Secretary;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace HerbMedic
{
    public partial class MainWindow : Window
    {
        EmployeeController employeeController = new EmployeeController();
        UserController userController = new UserController();
        public MainWindow()
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
                        var brush = SetRGBColor(44, 153, 215);
                        TextBox text = e.Source as TextBox;
                        text.Background = brush;
                    }
                    private void OnLostFocusTextbox(object sender, RoutedEventArgs e)
                    {
                        TextBox text = e.Source as TextBox;
                        text.Background = Brushes.White;
                    }
                    private void OnGotFocusPasswordbox(object sender, RoutedEventArgs e)
                    {
                        var brush = SetRGBColor(32, 158, 103);
                        PasswordBox pwtext = e.Source as PasswordBox;
                        pwtext.Background = brush;
                    }
                    private void OnLostFocusPasswordbox(object sender, RoutedEventArgs e)
                    {
                        PasswordBox pwtext = e.Source as PasswordBox;
                        pwtext.Background = Brushes.White;
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
        private void ButtonLogIn(object sender, RoutedEventArgs e)
        {
            string password = Passwordbox1.Password.ToString();
            //Employee employee = employeeController.FindEmployeeByUsername(Textbox1.Text);
            //bool areCredentialsOK = employeeController.CheckEmployeeCredentials(Textbox1.Text, password);
            //if(employee == null)
            User user = userController.ReadUserByUsername(Textbox1.Text);
            bool isCredentialsOK = userController.CheckUserCredentials(Textbox1.Text, password);
            if (isCredentialsOK == false)
                notifier.ShowError("Entered user doesnt exists!");
            else
            {
                switch (user.positionInASystem)
                {
                    case "Director":
                        {
                            Home home = new Home();
                            home.Show();
                            home.TransferInfo(user);
                            this.Hide();
                        }
                        break;
                    case "Doctor":
                        {
                            HomeDoctor home = new HomeDoctor();
                            home.Show();
                            home.TransferInfoAboutUser(user);
                            this.Hide();
                        }
                        break;
                    case "Secretary":
                        {
                            HomeSecretary home = new HomeSecretary();
                            home.Show();
                            home.TransferInfoAboutUser(user);
                            this.Hide();
                        }
                        break;
                    case "Patient":
                        {
                            HomePatient home = new HomePatient();
                            home.Show();
                            home.TransferInfoAboutUser(user);
                            this.Hide();
                        }
                        break;
                }                
            }
        }
    }
}
