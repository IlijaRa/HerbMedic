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
using ToastNotifications.Position;

namespace HerbMedic.View
{
    public partial class SplitRooms : Window
    {
        RoomController roomController = new RoomController();
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
            InfoAboutSplitRooms info = new InfoAboutSplitRooms();
            info.Show();
            Room room = (Room)dg_rooms.SelectedItem;
            info.transferData(Textbox1.Text, Textbox2.Text, room.floor);
            this.Hide();
            
        }
    }
}
