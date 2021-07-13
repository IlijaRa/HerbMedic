using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Classes.Model;
using Classes.Controller;
using System.Collections.ObjectModel;
using ToastNotifications;
using ToastNotifications.Position;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;

namespace HerbMedic.View
{
    public partial class BasicRenovation : Window
    {
        RenovationController renovationController = new RenovationController();
        RoomController roomController = new RoomController();

        public BasicRenovation()
        {
            InitializeComponent();
            List<Renovation> renovations = renovationController.ReadAllRenovations();
            ObservableCollection<Renovation> observableRenovations = new ObservableCollection<Renovation>();
            foreach (var renovation in renovations)
            {
                observableRenovations.Add(renovation);
            }
            dg_renovations.ItemsSource = observableRenovations;

            List<Room> rooms = roomController.ReadAllRooms();
            //ObservableCollection<Room> observableRooms = new ObservableCollection<Room>();
            List<string> roomy = new List<string>();
            foreach (var room in rooms)
            {
                roomy.Add(room.name);
            }
            Combobox1.ItemsSource = roomy;
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
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void ButtonLoadRenovations(object sender, RoutedEventArgs e)
        {
            List<Renovation> renovations = renovationController.ReadAllRenovations();
            ObservableCollection<Renovation> observableRenovations = new ObservableCollection<Renovation>();
            foreach (var renovation in renovations)
            {
                observableRenovations.Add(renovation);
            }
            dg_renovations.ItemsSource = observableRenovations;
        }

        private void ButtonCreateRenovation(object sender, RoutedEventArgs e)
        {
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
                    if (Combobox1.Text == "" || Textbox2.Text == "" || Textbox3.Text == "" || Textbox4.Text == "" || Datepicker1.SelectedDate == null)
                    {
                        notifier.ShowWarning("WARNING: You need to fill all empty places!");
                    }
                    else
                    {
                        string room = Combobox1.Text;
                        List<string> rooms = new List<string>() {Combobox1.Text};
                        Renovation renovation = new Renovation(renovationController.GenerateId(),
                                                               "BASIC",
                                                               "BASIC",
                                                               Convert.ToDateTime(Datepicker1.Text),
                                                               Convert.ToDateTime(Textbox2.Text),
                                                               Convert.ToDateTime(Textbox3.Text),
                                                               Textbox4.Text,
                                                               null,
                                                               rooms);

                        string message = renovationController.CreateRenovation(renovation);
                        if(message=="SUCCEEDED")
                        {
                            notifier.ShowSuccess("SUCCESS: Renovation is created!");
                        }
                        else
                        {
                            notifier.ShowWarning("WARNING: Watch entered date correction and exemination terms in room that you want to renovate");
                        }
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
    }
}
