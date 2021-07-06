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
    public partial class InfoAboutSplitRooms : Window
    {
        RoomController roomController = new RoomController();

        public InfoAboutSplitRooms()
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

        public void transferData(string selectedRoom, string splitedInto, int floor)
        {
            Textbox1.Text = selectedRoom;
            Textbox2.Text = splitedInto;
            Textbox4.Text = floor.ToString();
        }

        private void ButtonCreate(object sender, RoutedEventArgs e)
        {
            Room room = new Room(roomController.GenerateId(), 
                                 Textbox3.Text, 
                                 Combobox1.Text, 
                                 Convert.ToInt32(Textbox4.Text),
                                 Textbox5.Text,
                                 null);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<StaticEquipment> staticEquipmets = roomController.ReadRoomsEquipment(Textbox1.Text);
            ObservableCollection<StaticEquipment> observableEquipment = new ObservableCollection<StaticEquipment>();
            foreach (var statics in staticEquipmets)
            {
                observableEquipment.Add(statics);
            }
            dg_equipment.ItemsSource = observableEquipment;
        }
    }
}
