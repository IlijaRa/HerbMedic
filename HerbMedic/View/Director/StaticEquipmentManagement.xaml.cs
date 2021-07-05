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
using Classes.Controller;
using ToastNotifications;
using ToastNotifications.Position;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;

namespace HerbMedic.View
{
    public partial class StaticEquipmentManagement : Window
    {
        RoomController roomController = new RoomController();
        TransferEquipmentController transferController = new TransferEquipmentController();

        public StaticEquipmentManagement()
        {
            InitializeComponent();
            List<Room> rooms = roomController.ReadAllRooms();
            ObservableCollection<Room> observableRooms = new ObservableCollection<Room>();
            foreach (var room in rooms)
            {
                observableRooms.Add(room);
            }
            dg_rooms1.ItemsSource = observableRooms;
            dg_rooms2.ItemsSource = observableRooms;
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

        private void ButtonSeeEquipmentFromRoom(object sender, RoutedEventArgs e)
        {
            //kako ovde uraditi exception catch, probao sam obican try catch, ali ne hvata izuzetak
            Room room = (Room)dg_rooms1.SelectedItem;
            List<StaticEquipment> equipment = roomController.ReadRoomsEquipment(room.name);
            dg_rooms1.ItemsSource = equipment;
        }

        //private void ButtonSeeEquipmentToRoom(object sender, RoutedEventArgs e)
        //{
        //    //kako ovde uraditi exception catch, probao sam obican try catch, ali ne hvata izuzetak
        //    Room room = (Room)dg_rooms2.SelectedItem;
        //    List<StaticEquipment> equipment = roomController.ReadRoomsEquipment(room.name);
        //    dg_rooms2.ItemsSource = equipment;
        //}

        private void ButtonGoToRooms1(object sender, RoutedEventArgs e)
        {
                List<Room> rooms = roomController.ReadAllRooms();
                ObservableCollection<Room> observableRooms = new ObservableCollection<Room>();
                foreach (var room in rooms)
                {
                    observableRooms.Add(room);
                }
                dg_rooms1.ItemsSource = observableRooms;
        }

        //private void ButtonGoToRooms2(object sender, RoutedEventArgs e)
        //{
        //    List<Room> rooms = roomController.ReadAllRooms();
        //    ObservableCollection<Room> observableRooms = new ObservableCollection<Room>();
        //    foreach (var room in rooms)
        //    {
        //        observableRooms.Add(room);
        //    }
        //    dg_rooms2.ItemsSource = observableRooms;
        //}

        private void ButtonClaimTransfer(object sender, RoutedEventArgs e)
        {
            bool passed = false;
            string s1 = String.Empty;
            string s2 = String.Empty;
            string s3 = String.Empty;
            int s3int;
            DateTime dt;
            try
            {
                s1 = Textbox1.Text;
                dt = Convert.ToDateTime(s1);
                s1 = dt.ToString("HH:mm");
                passed = true;
                try
                {
                    s2 = Textbox2.Text;
                    dt = Convert.ToDateTime(s2);
                    s2 = dt.ToString("HH:mm");
                    passed = true;
                    try
                    {
                        s3 = Textbox3.Text;
                        s3int = Convert.ToInt32(s3);
                        passed = true;
                        if (dg_rooms1.SelectedCells.Count == 0 || dg_rooms2.SelectedCells.Count == 0)
                        {
                            notifier.ShowWarning("WARNING: You need to select item from a datagrid!");
                        }
                        else
                        {
                            StaticEquipment static1 = (StaticEquipment)dg_rooms1.SelectedItem;
                            Room toRoom = (Room)dg_rooms2.SelectedItem;
                            TransferEquipment transfer = new TransferEquipment(transferController.GenerateId(),
                                                                               static1.roomName,
                                                                               toRoom.name,
                                                                               static1.name,
                                                                               Convert.ToInt32(Textbox3.Text),
                                                                               Convert.ToDateTime(Datepicker1.Text),
                                                                               Convert.ToDateTime(Textbox1.Text),
                                                                               Convert.ToDateTime(Textbox2.Text));

                            string message = transferController.CreateTransfer(transfer);
                            if (message == "SUCCEEDED")
                                notifier.ShowSuccess("SUCCESS: Transfer is created!");
                            else
                                notifier.ShowError("ERROR: Transfer isn't created!");
                        }
                    }
                    catch
                    {
                        notifier.ShowWarning("WARNING: Entered bad format for quantity or you didn't select equipment from wanted room!");
                    }
                           
                }
                catch (Exception ex)
                {
                    notifier.ShowWarning("WARNING: Entered bad format for end time!");
                }
            }
            catch (Exception ex)
            {
                notifier.ShowWarning("WARNING: Entered bad format for start time!");
            }
        }
    }
}
