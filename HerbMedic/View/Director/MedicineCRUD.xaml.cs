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
using Newtonsoft.Json;

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
        private void ButtonCreate(object sender, RoutedEventArgs e)
        {
            try
            {
                if(Textbox2.Text != "" && Textbox3.Text != "" && Textbox4.Text != "" && Textbox5.Text != "" && Textbox6.Text != "")
                {
                    Random random = new Random();
                    // formatiranje i kreiranje liste sastojaka za lek
                    List<string> ingredients = medicineController.FormatIngredients(Textbox5.Text);
                    List<Ingredient> realIngred = new List<Ingredient>();

                    // formatiranje i kreiranje liste alternativa za lek
                    List<string> alternatives = medicineController.FormatIngredients(Textbox6.Text);
                    List<Alternative> realAlter = new List<Alternative>();


                    Medicine medicine = new Medicine(medicineController.GenerateId(),
                                                         Textbox2.Text,
                                                         "WAITING",
                                                         Textbox4.Text,
                                                         realIngred,
                                                         realAlter,
                                                         null);
                    string message = medicineController.CreateMedicine(medicine);
                    if (message == "SUCCEEDED")
                    {
                        foreach (var ingredient in ingredients)
                        {
                            var ingr = new Ingredient(Textbox2.Text, medicineController.GenerateId() + random.Next(1000), ingredient);
                            medicineController.CreateIngredient(ingr);
                        }

                        foreach (var alternative in alternatives)
                        {
                            var alter = new Alternative(Textbox2.Text, medicineController.GenerateId() + random.Next(1000), alternative);
                            medicineController.CreateAlternative(alter);
                        }

                        notifier.ShowSuccess("SUCCESS: Medicine is created!");
                    }
                }
                else
                {
                    notifier.ShowWarning("WARNING: Blanks are poorly filled");
                }   
            }
            catch
            {
                notifier.ShowWarning("WARNING: Something went wrong!");
            }
        }

        private void ButtonUpdate(object sender, RoutedEventArgs e)
        {
            if (Textbox2.Text != "" && Textbox3.Text != "" && Textbox4.Text != "" && Textbox5.Text != "" && Textbox6.Text != "")
            {
                Random random = new Random();

                // formatiranje i kreiranje liste sastojaka za lek
                List<string> ingredients = medicineController.FormatIngredients(Textbox5.Text);
                List<Ingredient> realIngred = new List<Ingredient>();

                // formatiranje i kreiranje liste alternativa za lek
                List<string> alternatives = medicineController.FormatIngredients(Textbox6.Text);
                List<Alternative> realAlter = new List<Alternative>();

                    Medicine medicine = new Medicine(Convert.ToInt32(Textbox1.Text),
                                                    Textbox2.Text,
                                                    "WAITING",
                                                    Textbox4.Text,
                                                    realIngred,
                                                    realAlter,
                                                    null);
                    string message = medicineController.UpdateMedicine(medicine, "Director");

                if (message == "SUCCEEDED")
                {
                    foreach (var ingredient in ingredients)
                    {
                        var ingr = new Ingredient(Textbox2.Text, medicineController.GenerateId() + random.Next(1000), ingredient);
                        medicineController.CreateIngredient(ingr);
                    }

                    foreach (var alternative in alternatives)
                    {
                        var alter = new Alternative(Textbox2.Text, medicineController.GenerateId() + random.Next(1000), alternative);
                        medicineController.CreateAlternative(alter);
                    }

                    notifier.ShowSuccess("SUCCESS: Medicine is updated!");
                }
                else
                    notifier.ShowError("ERROR: Medicine isn't updated!");
            }
            else
            {
                notifier.ShowWarning("WARNING: Blanks are poorly filled");
            }
        }

        private void ButtonDelete(object sender, RoutedEventArgs e)
        {
            if(dg_medicines.SelectedCells.Count > 0)
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
            else
            {
                notifier.ShowWarning("WARNING: Firstly you need to select medicine!");
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
        }

        private void dg_ingredients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Textbox5.Text = "";
            var charsToRemove = new string[] { "@", ",", ".", ";", "'", "\\", "\"" }; // sluzi da bi se uklonile " " kada se selektuje iz dg_ingredients ili dg_alternatives, jer se iz nekog razloga pojavljuju
            string helper = "";
            foreach (Ingredient ingred in dg_ingredients.SelectedItems)
            {
                string s = JsonConvert.SerializeObject(ingred.ingredientName);
                foreach (var c in charsToRemove)
                    helper = s.Replace(c, string.Empty);
                Textbox5.Text += helper + ",";
            }
        }

        private void dg_alternatives_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Textbox6.Text = "";
            var charsToRemove = new string[] { "@", ",", ".", ";", "'", "\\", "\"" }; // sluzi da bi se uklonile " " kada se selektuje iz dg_ingredients ili dg_alternatives, jer se iz nekog razloga pojavljuju
            string helper = "";
            foreach (Alternative alter in dg_alternatives.SelectedItems)
            {
                string s = JsonConvert.SerializeObject(alter.alternativeName);
                foreach (var c in charsToRemove)
                    helper = s.Replace(c, string.Empty);
                Textbox6.Text += helper + ",";
            }
        }

        private void dg_medicines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Medicine selectedMedicine = (Medicine)dg_medicines.SelectedItem;
            List<Ingredient> ingredients = medicineController.ReadMedicineIngredients(selectedMedicine.name);
            List<Alternative> alternatives = medicineController.ReadMedicineAlternatives(selectedMedicine.name);
            dg_ingredients.ItemsSource = ingredients;
            dg_alternatives.ItemsSource = alternatives;
            Textbox5.Text = "";
            Textbox6.Text = "";
        }
    }
}
