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
using Classes.Controller;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using ToastNotifications.Messages;
using System.Collections.ObjectModel;

namespace HerbMedic.View.Doctor
{
    public partial class Anamnesis : Window
    {
        AnamnesisController anamnesisController = new AnamnesisController();
        public Anamnesis()
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


        public void TransferInfo(string name, string surname, string username)
        {
            Textbox1.Text = name;
            Textbox2.Text = surname;
            Textbox_username.Text = username;
        }

        private void ButtonGoBack(object sender, RoutedEventArgs e)
        {
            MedicalRecord medical = new MedicalRecord();
            medical.Show();
            medical.TransferInfoForMedicalRecord(Textbox1.Text, Textbox2.Text, Textbox_username.Text);
            this.Hide();
        }

        private void ButtonCreate(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            string fullName = Textbox1.Text + " " + Textbox2.Text;
            if (Textbox4.Text != "" && Textbox5.Text != "" && Datepicker1.Text != "") 
            {
                Classes.Model.Anamnesis anamnesis = new Classes.Model.Anamnesis(random.Next(1000), 
                                                                                fullName,
                                                                                Textbox4.Text, 
                                                                                Textbox5.Text, 
                                                                                Convert.ToDateTime(Datepicker1.Text));
                string message = anamnesisController.CreateAnamnesis(anamnesis);
                if(message == "SUCCEEDED")
                {
                    notifier.ShowSuccess("SUCCESS: Anamnesis is succesfully added to a medical record");
                }
            }
            else
            {
                notifier.ShowWarning("WARNING: You need to fill all blanks!");
            }
        }

        private void ButtonUpdate(object sender, RoutedEventArgs e)
        {
            string fullName = Textbox1.Text + " " + Textbox2.Text;
            if (Textbox4.Text != "" && Textbox5.Text != "" && Datepicker1.Text != "")
            {
                Classes.Model.Anamnesis anamnesis = new Classes.Model.Anamnesis(Convert.ToInt32(Textbox3.Text),
                                                                                fullName,
                                                                                Textbox4.Text,
                                                                                Textbox5.Text,
                                                                                Convert.ToDateTime(Datepicker1.Text));
                string message = anamnesisController.UpdateAnamnesis(anamnesis);
                if (message == "SUCCEEDED")
                {
                    notifier.ShowSuccess("SUCCESS: Anamnesis is succesfully added to a medical record");
                }
            }
            else
            {
                notifier.ShowWarning("WARNING: You need to fill all blanks!");
            }
        }

        private void ButtonReadAll(object sender, RoutedEventArgs e)
        {
            string fullName = Textbox1.Text + " " + Textbox2.Text;
            List<Classes.Model.Anamnesis> anamneses = anamnesisController.ReadAnamnesisByNameSurname(fullName);
            ObservableCollection<Classes.Model.Anamnesis> observableAnamnesis = new ObservableCollection<Classes.Model.Anamnesis>();
            foreach (var a in anamneses)
            {
                observableAnamnesis.Add(a);
            }
            dg_anamnesis.ItemsSource = observableAnamnesis;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Textbox3.Clear();
            Textbox4.Clear();
            Textbox5.Clear();
        }
    }
}
