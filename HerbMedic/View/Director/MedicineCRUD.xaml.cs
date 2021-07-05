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
    public partial class MedicineCRUD : Window
    {
        MedicineController medicineController = new MedicineController();
        public MedicineCRUD()
        {
            InitializeComponent();
            List<Medicine> medicines = medicineController.ReadAllMedicines();
            ObservableCollection<Medicine> observableMedicines = new ObservableCollection<Medicine>();
            foreach (var medicine in medicines)
            {
                observableMedicines.Add(medicine);
            }
            dg_medicines.ItemsSource = observableMedicines;
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
        private void ButtonMoreAboutMedicine(object sender, RoutedEventArgs e)
        {
            try
            {
                Medicine selectedMedicine = (Medicine)dg_medicines.SelectedItem;
                List<string> ingredients = medicineController.ReadMedicineIngredients(selectedMedicine.name);
                List<string> alternatives = medicineController.ReadMedicineAlternatives(selectedMedicine.name);
                dg_ingredients.ItemsSource = ingredients;
                dg_alternatives.ItemsSource = alternatives;
            }
            catch
            {
                notifier.ShowWarning("Firstly you need to select the medicine!");
            }
            
        }

        private void ButtonCreate(object sender, RoutedEventArgs e)
        {
            List<string> ingredients = medicineController.FormatIngredients(Textbox5.Text);
            List<string> alternatives = medicineController.FormatIngredients(Textbox6.Text);
            Medicine medicine = new Medicine(medicineController.GenerateId(),
                                                 Textbox2.Text,
                                                 "WAITING",
                                                 Textbox4.Text,
                                                 ingredients,
                                                 alternatives,
                                                 null);
                    string message = medicineController.CreateMedicine(medicine);
                    if (message == "SUCCEEDED")
                    {
                        notifier.ShowSuccess("SUCCESS: Medicine is created!");
                    }
                    else
                        notifier.ShowError("ERROR: Medicine isn't created!");

        }

        private void ButtonUpdate(object sender, RoutedEventArgs e)
        {
            List<string> ingredients = medicineController.ReadMedicineIngredients(Textbox2.Text);
            List<string> alternatives = medicineController.ReadMedicineAlternatives(Textbox2.Text);
            Medicine medicine = new Medicine(Convert.ToInt32(Textbox1.Text),
                                 Textbox2.Text,
                                 "WAITING",
                                 Textbox4.Text,
                                 ingredients,
                                 alternatives,
                                 null);
            string message = medicineController.UpdateMedicine(medicine);

            if (message == "SUCCEEDED")
            {
                notifier.ShowSuccess("SUCCESS: Medicine is updated!");
            }
            else
                notifier.ShowError("ERROR: Medicine isn't updated!");
        }

        private void ButtonDelete(object sender, RoutedEventArgs e)
        {
            Medicine selectedMedicine = (Medicine)dg_medicines.SelectedItem;
            string message = medicineController.DeleteMedicine(selectedMedicine.id);
            
            if (dg_medicines.SelectedItem == null)
                notifier.ShowWarning("You need to select a medicine!");
            
            if (message == "SUCCEEDED")
                notifier.ShowSuccess("SUCCESS: Medicine is deleted!");
            else
                notifier.ShowWarning("ERROR: Medicine isn't deleted!");
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
        }
    }
}
