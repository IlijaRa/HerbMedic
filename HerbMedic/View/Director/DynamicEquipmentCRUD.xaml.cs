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
using ToastNotifications.Position;
using Classes.Model;
using Classes.Controller;
using System.Collections.ObjectModel;
using ToastNotifications.Messages;

namespace HerbMedic.View
{
    public partial class DynamicEquipmentCRUD : Window
    {
        DynamicEquipmentController dynamicController= new DynamicEquipmentController();

        public DynamicEquipmentCRUD()
        {
            InitializeComponent();
            List<DynamicEquipment> equipments = dynamicController.ReadAllDynamicEquipment();
            ObservableCollection<DynamicEquipment> observableEquipments = new ObservableCollection<DynamicEquipment>();
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
                DynamicEquipment equipment = new DynamicEquipment(dynamicController.GenerateId(),
                                                                  Textbox2.Text,
                                                                  Convert.ToInt32(Textbox3.Text));

                string message = dynamicController.CreateDynamicEquipment(equipment);
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
                DynamicEquipment equipment = new DynamicEquipment(Convert.ToInt32(Textbox1.Text),
                                                                  Textbox2.Text,
                                                                  Convert.ToInt32(Textbox3.Text));

                string message = dynamicController.UpdateDynamicEquipment(equipment);
                if (message == "SUCCEEDED")
                {
                    notifier.ShowSuccess("SUCCESS: Medicine is updated!");
                }
                else
                    notifier.ShowError("ERROR: Medicine isn't updated!");
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
                DynamicEquipment equipment = (DynamicEquipment)dg_equipments.SelectedItem;
                string message = dynamicController.DeleteDynamicEquipment(equipment.id);
                if (message == "SUCCEEDED")
                    notifier.ShowSuccess("SUCCESS: Equipment is deleted!");
                else
                    notifier.ShowError("ERROR: Equipment isn't deleted!");
            }
            catch
            {
                notifier.ShowWarning("WARNINIG: Something went wrong, try again!");
            }
        }

        private void ButtonReadAll(object sender, RoutedEventArgs e)
        {
            List<DynamicEquipment> equipments = dynamicController.ReadAllDynamicEquipment();
            ObservableCollection<DynamicEquipment> observableEquipments = new ObservableCollection<DynamicEquipment>();
            foreach (var equipment in equipments)
            {
                observableEquipments.Add(equipment);
            }
            dg_equipments.ItemsSource = observableEquipments;
        }

        private void ButtonExportEquipment(object sender, RoutedEventArgs e)
        {
            if (Textbox1.Text == "" || Textbox2.Text == " ")
                notifier.ShowWarning("WARNING: Firstly, you need to select the equipment!");
            else
            {
                ExportDynamicEquipment export = new ExportDynamicEquipment();
                export.transfer(Textbox1.Text, Textbox2.Text);
                export.Show();
            }  
        }

        private void ButtonDocumentationAboutExports(object sender, RoutedEventArgs e)
        {
            DocumentationAboutDoneExports documentation = new DocumentationAboutDoneExports();
            documentation.Show();
        }
    }
}
