using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using Classes.Controller;
using Classes.Model;
using System.Collections.Generic;

namespace HerbMedic.View
{
    public partial class SearchEquipment : Window
    {
        StaticEquipmentController staticController = new StaticEquipmentController();
        DynamicEquipmentController dynamicController = new DynamicEquipmentController();
        public SearchEquipment()
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

        private void ButtonGoBack(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void ButtonStaticEquip(object sender, RoutedEventArgs e)
        {
            List<StaticEquipment> staticEquipment = staticController.ReadAllStaticEquipment();
            dg_search.ItemsSource = staticEquipment;
            label_type.Content = "STATIC EQUIPMENT";
        }

        private void ButtonDynamicEquip(object sender, RoutedEventArgs e)
        {
            List<DynamicEquipment> dynamicEquipment = dynamicController.ReadAllDynamicEquipment();
            dg_search.ItemsSource = dynamicEquipment;
            label_type.Content = "DYNAMIC EQUIPMENT";
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(label_type.Content == "STATIC EQUIPMENT")
            {
                List<StaticEquipment> staticEquipment = staticController.SearchEquipmentByName(Textbox1.Text, dg_search);
                dg_search.ItemsSource = staticEquipment;
            }

            if (label_type.Content == "DYNAMIC EQUIPMENT")
            {
                List<DynamicEquipment> dynamicEquipment = dynamicController.SearchEquipmentByName(Textbox1.Text, dg_search);
                dg_search.ItemsSource = dynamicEquipment;
            }
        }
    }
}
