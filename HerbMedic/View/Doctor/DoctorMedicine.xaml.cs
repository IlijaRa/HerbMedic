using Classes.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Classes.Controller;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using ToastNotifications.Messages;

namespace HerbMedic.View.Doctor
{
    public partial class DoctorMedicine : Window
    {
        MedicineController medicineController = new MedicineController();
        EmployeeController employeeController = new EmployeeController();
        public DoctorMedicine()
        {
            InitializeComponent();
            //List<Medicine> medicines = medicineController.ReadAllMedicines();
            //ObservableCollection<Medicine> observableMedicines = new ObservableCollection<Medicine>();
            //foreach (var medicine in medicines)
            //{
            //    observableMedicines.Add(medicine);
            //}
            //dg_medicines.ItemsSource = observableMedicines;
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
            User user = employeeController.ReadEmployeeUserByUsername(Textbox_username.Text);
            HomeDoctor home = new HomeDoctor();
            home.Show();
            home.TransferInfoAboutUser(user);
            home.CheckNotifications(Textbox_username.Text);
            this.Hide();
        }
        private void ButtonAcceptMedicine(object sender, RoutedEventArgs e)
        {
            if(dg_medicines.SelectedItems.Count < 1)
            {
                notifier.ShowWarning("WARNING: Firstly you need to select a medicine!");
            }
            else
            {
                Medicine medicine = (Medicine)dg_medicines.SelectedItem;
                string message = medicineController.VerificateMedicine(medicine);
                if (message == "SUCCEEDED")
                    notifier.ShowSuccess("SUCCESS: Medicine is validated");
                else
                    notifier.ShowError("ERROR: Error occured while validating");
            }
        }

        private void ButtonDeclineMedicine(object sender, RoutedEventArgs e)
        {
            if (dg_medicines.SelectedItems.Count < 1)
            {
                notifier.ShowWarning("WARNING: Firstly you need to select a medicine!");
            }
            else
            {
                Medicine medicine = (Medicine)dg_medicines.SelectedItem;
                MedicineDeclining medDeclining = new MedicineDeclining();
                medDeclining.Show();
                medDeclining.TransferInfo(medicine);
            }
        }

        private void ButtonUpdateMedicine(object sender, RoutedEventArgs e)
        {
            if (Textbox1.Text != "" && Textbox2.Text != "" && Textbox3.Text != "" && Textbox4.Text != "")
            {
                Medicine medicine = new Medicine(Convert.ToInt32(Textbox1.Text),
                                                Textbox2.Text,
                                                Textbox3.Text,
                                                Textbox4.Text,
                                                null,
                                                null,
                                                null);
                string message = medicineController.UpdateMedicine(medicine, "Doctor");
                if(message == "SUCCEEDED")
                {
                    notifier.ShowSuccess("SUCCESS: Medicine is updated!");
                }
                else
                {
                    notifier.ShowError("ERROR: Error occured while updating!");
                }
            }
            else
            {
                notifier.ShowWarning("WARNING: Blanks are poorly filled");
            }
        }

        private void ButtonReadAll(object sender, RoutedEventArgs e)
        {
            List<Medicine> medicines = medicineController.ReadAllMedicines();
            ObservableCollection<Medicine> observableMedicines = new ObservableCollection<Medicine>();
            foreach (var medicine in medicines)
            {
                observableMedicines.Add(medicine);
            }
            dg_medicines.ItemsSource = observableMedicines;
            
            //-----------------------------------------------------------------
            List<Medicine> medicines1 = medicineController.ReadAllMedicines();
            ObservableCollection<Medicine> observableMedicines1 = new ObservableCollection<Medicine>();
            foreach (var medicine in medicines1)
            {
                observableMedicines1.Add(medicine);
            }
            dg_medicines.ItemsSource = observableMedicines1;
        }

        private void dg_ingredients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dg_alternatives_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void TransferInfo(string username)
        {
            Textbox_username.Text = username;
        }

        private void dg_medicines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Medicine selectedMedicine = (Medicine)dg_medicines.SelectedItem;
            List<Ingredient> ingredients = medicineController.ReadMedicineIngredients(selectedMedicine.name);
            List<Alternative> alternatives = medicineController.ReadMedicineAlternatives(selectedMedicine.name);
            dg_ingredients.ItemsSource = ingredients;
            dg_alternatives.ItemsSource = alternatives;
            //Textbox5.Text = "";
            //Textbox6.Text = "";
        }
    }
}
