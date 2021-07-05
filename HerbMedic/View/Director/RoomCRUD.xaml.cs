using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using Classes.Controller;
using Classes.Model;
using ToastNotifications.Messages;
using System.Collections.ObjectModel;

namespace HerbMedic.View
{
    public partial class RoomCRUD : Window
    {
        RoomController roomController = new RoomController();
        public RoomCRUD()
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
        private void ButtonReadStaticEquipment(object sender, RoutedEventArgs e)
        {
            try
            {
                Room selectedRoom = (Room)dg_rooms.SelectedItem;
                List<StaticEquipment> staticEquip = roomController.ReadRoomsEquipment(selectedRoom.name);
                dg_equipment.ItemsSource = staticEquip;
            }
            catch
            {
                notifier.ShowWarning("Firstly you need to select a room!");
            }
        }

        private void ButtonCreate(object sender, RoutedEventArgs e)
        {
            try
            {
                Room room = new Room(roomController.GenerateId(),
                                     Textbox2.Text,
                                     Combobox1.Text,
                                     Convert.ToInt32(Textbox4.Text),
                                     Textbox5.Text,
                                     null);
                string message = roomController.CreateRoom(room);

                if (message == "SUCCEEDED")
                {
                    notifier.ShowSuccess("SUCCESS: Room is created!");
                }
                else
                    notifier.ShowError("ERROR: Room isn't created!");
            }
            catch
            {
                notifier.ShowWarning("WARNING: Blanks are poorly filled!");
            }
        }

        private void ButtonReadAll(object sender, RoutedEventArgs e)
        {
            List<Room> rooms = roomController.ReadAllRooms();
            ObservableCollection<Room> observableRooms = new ObservableCollection<Room>();
            foreach (var room in rooms)
            {
                observableRooms.Add(room);
            }
            dg_rooms.ItemsSource = observableRooms;
        }

        private void ButtonDelete(object sender, RoutedEventArgs e)
        {
            Room selectedRoom = (Room)dg_rooms.SelectedItem;
            string message = roomController.DeleteRoomById(selectedRoom.id);
            if (dg_rooms.SelectedItem == null)
                notifier.ShowWarning("You need to select room!");
            if (message == "SUCCEEDED")
            {
                notifier.ShowSuccess("SUCCESS: Room is deleted!");
            }
            else
                notifier.ShowWarning("ERROR: Room isn't deleted!");

        }

        private void ButtonUpdate(object sender, RoutedEventArgs e)
        {
            List<StaticEquipment> staticEquipment = roomController.ReadRoomsEquipment(Textbox2.Text);
            Room room = new Room(Convert.ToInt32(Textbox1.Text),
                                 Textbox2.Text,
                                 Combobox1.Text,
                                 Convert.ToInt32(Textbox4.Text),
                                 Textbox5.Text,
                                 staticEquipment);
            string message = roomController.UpdateRoom(room);

            if (message == "SUCCEEDED")
            {
                notifier.ShowSuccess("SUCCESS: Room is updated!");
            }
            else
                notifier.ShowError("ERROR: Room isn't updated!");
        }

        private void ButtonGoBack(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}
