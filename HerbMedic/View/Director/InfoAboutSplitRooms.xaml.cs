using Classes.Controller;
using Classes.Model;
using HerbMedic.View.MessageBoxes;
using Newtonsoft.Json;
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
    public partial class InfoAboutSplitRooms : Window
    {
        RoomController roomController = new RoomController();
        RenovationController renovationController = new RenovationController();
        StaticEquipmentController staticController = new StaticEquipmentController();

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
            if (Textbox3.Text == "" || Combobox1.Text == "" || Textbox5.Text == "" || Textbox6.Text == "" || Textbox7.Text == "")
            {
                notifier.ShowWarning("WARNING: You need to fill all empty places!");
            }
            else
            {
                Random random = new Random();
                List<StaticEquipment> staticEquip = new List<StaticEquipment>();
                string[] equip = Textbox6.Text.Split('\n');
                string[] quantity = Textbox7.Text.Split('\n');

                for (int i = 0; i < equip.Count() - 1; i++)
                {
                    string cleanEquip = roomController.FormatStaticEquipment(equip[i]);
                    StaticEquipment s = new StaticEquipment(Textbox3.Text,
                                                staticController.GenerateId() + random.Next(1000),
                                                cleanEquip,
                                                Convert.ToInt32(quantity[i].ToString()));
                    staticEquip.Add(s);
                }
                Room room = new Room(roomController.GenerateId() + random.Next(1000),
                                     Textbox3.Text,
                                     Combobox1.Text,
                                     Convert.ToInt32(Textbox4.Text),
                                     Textbox5.Text,
                                     staticEquip);

                string message = roomController.CreatePendingRoom(room);

                if (message == "SUCCEEDED")
                {
                    renovationController.AddRoomToRenovation(renovationController.GenerateId() - 1, Textbox3.Text);

                    int roomCount = Convert.ToInt32(Textbox2.Text);
                    roomCount -= 1;
                    Textbox2.Text = roomCount.ToString();
                    if (roomCount == 0)
                    {
                        MessageBox.Show("You can go back now");
                    }

                    Textbox3.Text = "";
                    Textbox5.Text = "";
                    Textbox6.Text = "";
                    Textbox7.Text = "";
                    Combobox1.Text = "";
                }
            } 
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

        private void dg_equipment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Textbox6.Text = "";
            Textbox7.Text = "";
            foreach (StaticEquipment stat in dg_equipment.SelectedItems)
            {
                string name = JsonConvert.SerializeObject(stat.name);
                string quantity = JsonConvert.SerializeObject(stat.quantity);
                Textbox6.Text += name     + "\n";
                Textbox7.Text += quantity + "\n";
            }
        }

        private void ButtonGoBack(object sender, RoutedEventArgs e)
        {
            if(Textbox2.Text != "0")
            {
                CommandAboutFillingRoomInfo command = new CommandAboutFillingRoomInfo();
                command.Show();
            }
            else{
                Home home = new Home();
                home.Show();
                this.Hide();
            }
        }
    }
}
