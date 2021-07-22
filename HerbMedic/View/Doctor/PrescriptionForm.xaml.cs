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
using Classes.Controller;
using Classes.Model;
using ToastNotifications.Messages;
using System.Collections.ObjectModel;

namespace HerbMedic.View.Doctor
{
    public partial class PrescriptionForm : Window
    {
        PrescriptionController prescriptionController = new PrescriptionController();
        MedicineController medicineController = new MedicineController();

        public PrescriptionForm()
        {
            InitializeComponent();
            List<Medicine> medicines = medicineController.ReadAllMedicines();
            List<string> mediciny = new List<string>();
            foreach(var medicine in medicines)
            {
                mediciny.Add(medicine.name);
            }
            Combobox1.ItemsSource = mediciny;
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
                        var brush = SetRGBColor(45, 173, 246);
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
            if(Combobox1.Text != "" && Combobox2.Text != "" && Textbox5.Text != "")
            {
                Random random = new Random();
                
                string fullName=Textbox1.Text + " " + Textbox2.Text;

                Prescription prescription = new Prescription(random.Next(1000),
                                                            fullName,
                                                            Combobox1.Text,
                                                            Combobox2.Text,
                                                            Textbox5.Text);

                string message = prescriptionController.CreatePrescription(prescription);
                if (message == "SUCCEEDED")
                    notifier.ShowSuccess("SUCCEESS: Prescription successfully created!");
                else
                    notifier.ShowError("ERROR: Error occured while creating!");
            }
            else
            {
                notifier.ShowWarning("WARNING: You need to fill all blanks!");
            }
        }

        private void ButtonUpdate(object sender, RoutedEventArgs e)
        {
            if (Combobox1.Text != "" && Combobox2.Text != "" && Textbox5.Text != "")
            {
                Random random = new Random();

                string fullName = Textbox1.Text + " " + Textbox2.Text;

                Prescription prescription = new Prescription(Convert.ToInt32(Textbox3.Text),
                                                            fullName,
                                                            Combobox1.Text,
                                                            Combobox2.Text,
                                                            Textbox5.Text);

                string message = prescriptionController.UpdatePrescription(prescription);
                if (message == "SUCCEEDED")
                    notifier.ShowSuccess("SUCCEESS: Prescription successfully created!");
                else
                    notifier.ShowError("ERROR: Error occured while creating!");
            }
            else
            {
                notifier.ShowWarning("WARNING: You need to fill all blanks!");
            }
        }

        private void ButtonDelete(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonReadAll(object sender, RoutedEventArgs e)
        {
            string fullName = Textbox1.Text + " " + Textbox2.Text;
            List<Prescription> prescriptions = prescriptionController.ReadPatientPrescriptions(fullName);
            
            ObservableCollection<Prescription> observablePrescriptions = new ObservableCollection<Prescription>();
            foreach (var p in prescriptions)
            {
                observablePrescriptions.Add(p);
            }
            dg_prescriptions.ItemsSource = observablePrescriptions;
        }
    }
}
