using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Classes.Controller;
using Classes.Model;
using Newtonsoft.Json;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace HerbMedic.View
{
    public partial class MergeRooms : Window
    {
        RoomController roomController = new RoomController();
        RenovationController renovationController = new RenovationController();

        public MergeRooms()
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

        private void dg_rooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Textbox1.Text = "";
            foreach (Room stat in dg_rooms.SelectedItems)
            {
                string s = JsonConvert.SerializeObject(stat.name);
                string floor= JsonConvert.SerializeObject(stat.floor);
                Textbox1.Text += s + "\n";
                Textbox7.Text = floor;
            }
        }

        private void ButtonCreate(object sender, RoutedEventArgs e)
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
                    if (dg_rooms.SelectedCells.Count <2)
                    {
                        notifier.ShowWarning("WARNING: You need to select rooms for merge!");
                    }
                    else
                    {
                        if (Textbox1.Text == "" || Textbox2.Text == "" || Textbox3.Text == "" || Textbox4.Text == "" || Textbox6.Text == "" || Textbox7.Text == "" || Textbox8.Text == "" || Combobox1.Text== "")
                        {
                            notifier.ShowWarning("WARNING: You need too fill all empty places!");
                        }
                        else
                        {
                            List<string> rooms = roomController.FormatMergeRooms(Textbox1.Text);
                            bool areFloorsTheSame = roomController.CheckFloors(rooms);
                            if (areFloorsTheSame)
                            {
                                // formiranje objekta renoviranje da bi se smestio u json
                                Renovation renovation = new Renovation(renovationController.GenerateId(),
                                                                   "ADVANCED",
                                                                   "MERGE",
                                                                   Convert.ToDateTime(Datepicker1.Text),
                                                                   Convert.ToDateTime(Textbox2.Text),
                                                                   Convert.ToDateTime(Textbox3.Text),
                                                                   Textbox4.Text,
                                                                   Textbox6.Text,
                                                                   rooms);
                                string message = renovationController.CreateRenovation(renovation);

                                //formiranje objekta nove sobe da bi se smestio u pendingRoom json
                                List<string> mergingRooms = roomController.FormatMergeRooms(Textbox1.Text);
                                Room newRoomAtributes = new Room(roomController.GenerateId(), Textbox6.Text, Combobox1.Text, Convert.ToInt32(Textbox7.Text), Textbox8.Text, null);
                                Room BigRoom = roomController.MergeRooms(newRoomAtributes, mergingRooms);
                                string message1 = roomController.CreatePendingRoom(BigRoom);

                                if (message == "SUCCEEDED" && message1 == "SUCCEEDED")
                                {
                                    notifier.ShowSuccess("SUCCESS: Renovation is created!");
                                }
                                else
                                {
                                    notifier.ShowWarning("WARNING: Watch entered date correction and exemination terms in room that you want to renovate");
                                }
                            }
                            else
                            {
                                notifier.ShowError("ERROR: You need to select rooms on the same floor!");
                            }
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

        private void ButtonLoadRenovations(object sender, RoutedEventArgs e)
        {
            SeeRenovations see = new SeeRenovations();
            see.Show();
        }
    }
}