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

namespace HerbMedic.View
{
    public partial class SplitRooms : Window
    {
        RoomController roomController = new RoomController();
        RenovationController renovationController = new RenovationController();
        public SplitRooms()
        {
            InitializeComponent();
            List<Room> rooms = roomController.ReadAllRooms();
            ObservableCollection<Room> observableRooms = new ObservableCollection<Room>();
            foreach (var room in rooms)
            {
                observableRooms.Add(room);
            }
            dg_rooms.ItemsSource = observableRooms;
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

        private void ButtonScheduleRenovation(object sender, RoutedEventArgs e)
        {
            bool passed = false;
            string s1 = String.Empty;
            string s2 = String.Empty;
            DateTime dt;
            try
            {
                s1 = Textbox3.Text;
                dt = Convert.ToDateTime(s1);
                s1 = dt.ToString("HH:mm");
                passed = true;
                try
                {
                    s2 = Textbox4.Text;
                    dt = Convert.ToDateTime(s2);
                    s2 = dt.ToString("HH:mm");
                    passed = true;
                    try
                    {
                        if (dg_rooms.SelectedCells.Count < 1)
                        {
                            notifier.ShowWarning("WARNING: You need to select room to split!");
                        }
                        else
                        {
                            if (Textbox1.Text == "" || Textbox2.Text == "" || Textbox3.Text == "" || Textbox4.Text == "" || Textbox5.Text == "" || Datepicker1.Text == "")
                            {
                                notifier.ShowWarning("WARNING: You need too fill all empty places!");
                            }
                            else
                            {
                                if (Convert.ToInt32(Textbox2.Text)>1 || Convert.ToInt32(Textbox2.Text)<=3)
                                {
                                    List<string> rooms = new List<string>();
                                    Renovation renovation = new Renovation(renovationController.GenerateId(),
                                                                           "ADVANCED",
                                                                           "SPLIT",
                                                                           Convert.ToDateTime(Datepicker1.Text),
                                                                           Convert.ToDateTime(Textbox3.Text),
                                                                           Convert.ToDateTime(Textbox4.Text),
                                                                           Textbox5.Text,
                                                                           Textbox1.Text,
                                                                           rooms);

                                    string message = renovationController.CreateRenovation(renovation);

                                    if (message == "SUCCEEDED")
                                    {
                                        InfoAboutSplitRooms info = new InfoAboutSplitRooms();
                                        info.Show();
                                        Room room = (Room)dg_rooms.SelectedItem;
                                        info.transferData(Textbox1.Text, Textbox2.Text, room.floor);
                                        this.Hide();
                                    }
                                }                                
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        notifier.ShowError("ERROR: Creation didn't go well. Check your inputs!");
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
