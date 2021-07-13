using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using Classes.Model;
using Classes.Controller;
using System.Collections.ObjectModel;
using ToastNotifications.Messages;

namespace HerbMedic.View
{
    public partial class StaticEquipmentCRUD : Window
    {

        StaticEquipmentController staticController = new StaticEquipmentController();

        public StaticEquipmentCRUD()
        {
            InitializeComponent();
            List<StaticEquipment> equipments = staticController.ReadAllStaticEquipment();
            ObservableCollection<StaticEquipment> observableEquipments = new ObservableCollection<StaticEquipment>();
            foreach (var equipment in equipments)
            {
                observableEquipments.Add(equipment);
            }
            dg_equipments.ItemsSource = observableEquipments;
        }

        private void ButtonGoBack(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
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

        private void ButtonCreate(object sender, RoutedEventArgs e)
        {
            try
            {
                StaticEquipment equipment = new StaticEquipment(Textbox1.Text,
                                                             staticController.GenerateId(),
                                                             Textbox3.Text,
                                                             Convert.ToInt32(Textbox4.Text));
                string message = staticController.CreateStaticEquipment(equipment);
                if (message == "SUCCEEDED")
                {
                    notifier.ShowSuccess("SUCCESS: Equipment is created!");
                }
                else
                    notifier.ShowError("ERROR: Equipment isn't created!");
            }
            catch
            {
                notifier.ShowWarning("WARNING: Blanks are poorly filled!");
            }
        }

        private void ButtonUpdate(object sender, RoutedEventArgs e)
        {
            try
            {
                StaticEquipment equipment = new StaticEquipment(Textbox1.Text,
                                                            Convert.ToInt32(Textbox2.Text),
                                                            Textbox3.Text,
                                                            Convert.ToInt32(Textbox4.Text));

                string message = staticController.UpdateStaticEquipment(equipment);
                if (message == "SUCCEEDED")
                {
                    notifier.ShowSuccess("SUCCESS: Equipment is updated!");
                }
                else
                    notifier.ShowError("ERROR: Equipment isn't updated!");
            }
            catch
            {
                notifier.ShowWarning("WARNING: Blanks are poorly filled!");
            }
        }

        private void ButtonDelete(object sender, RoutedEventArgs e)
        {
            try
            {
                if(dg_equipments.SelectedCells.Count > 0)
                {
                    StaticEquipment selectedStaticEquipment = (StaticEquipment)dg_equipments.SelectedItem;
                    string message = staticController.DeleteStaticEquipment(selectedStaticEquipment.roomName, selectedStaticEquipment.id);

                    if (message == "SUCCEEDED")
                        notifier.ShowSuccess("SUCCESS: Equipment is deleted!");
                    else
                        notifier.ShowError("ERROR: Equipment isn't deleted!");
                }
                else
                {
                    notifier.ShowWarning("WARNING: Firstly you need to select equipment!");
                }
            }
            catch
            {
                notifier.ShowWarning("WARNINIG: Something went wrong, try again!");
            }
        }

        private void ButtonReadAll(object sender, RoutedEventArgs e)
        {
            List<StaticEquipment> equipments = staticController.ReadAllStaticEquipment();
            ObservableCollection<StaticEquipment> observableEquipments = new ObservableCollection<StaticEquipment>();
            foreach (var equipment in equipments)
            {
                observableEquipments.Add(equipment);
            }
            dg_equipments.ItemsSource = observableEquipments;
        }
    }
}
