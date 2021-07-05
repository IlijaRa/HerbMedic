using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Classes.Controller;
using ToastNotifications;
using ToastNotifications.Position;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using Classes.Model;

namespace HerbMedic.View
{
    public partial class ExportDynamicEquipment : Window
    {
        DynamicEquipmentController dynamicController = new DynamicEquipmentController(); 

        public ExportDynamicEquipment()
        {
            InitializeComponent();
        }

        private void ButtonGoBack(object sender, RoutedEventArgs e)
        {
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
        private void ButtonExport(object sender, RoutedEventArgs e)
        {
            DoneExports export = new DoneExports(Textbox2.Text,
                                                Convert.ToInt32(Textbox3.Text));
            string message = dynamicController.Export(export);
            if (message == "SUCCEEDED")
                notifier.ShowSuccess("SUCCESS: Equipment is exported!");
            else
                notifier.ShowError("ERROR: Equipment isn't exported!");
        }

        public void transfer(string a, string b)
        {
            Textbox1.Text = a;
            Textbox2.Text = b;
        }
    }
}
