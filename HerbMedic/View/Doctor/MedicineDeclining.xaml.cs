using Classes.Model;
using System;
using System.Collections.Generic;
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
using Classes.Controller;

namespace HerbMedic.View.Doctor
{
    public partial class MedicineDeclining : Window
    {
        MedicineController medicineController = new MedicineController();
        public MedicineDeclining()
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
            this.Hide();
        }

        public void TransferInfo(Medicine medicine)
        {
            Textbox1.Text = medicine.id.ToString();
            Textbox2.Text = medicine.name;
            Textbox3.Text = medicine.status;
            Textbox4.Text = medicine.description;
        }

        private void ButtonDeclineMedicine(object sender, RoutedEventArgs e)
        {
            if (Textbox5.Text == "")
                notifier.ShowWarning("WARNING: You need to enter reason!");
            else
            {
                Medicine medicine = new Medicine(Convert.ToInt32(Textbox1.Text),
                                                 Textbox2.Text,
                                                 Textbox3.Text,
                                                 Textbox4.Text,
                                                 null,
                                                 null,
                                                 Textbox5.Text);

                string message = medicineController.DeclineMedicine(medicine);
                if(message == "SUCCEEDED")
                {
                    notifier.ShowSuccess("SUCCESS: Medicine is declined!");
                    this.Hide();
                }
                else
                    notifier.ShowError("ERROR: Error occured while declining!");
            }
        }
    }
}
