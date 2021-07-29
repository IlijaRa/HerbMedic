using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ToastNotifications.Messages;

namespace HerbMedic.View.Doctor
{
    public partial class Allergens : Window
    {
        AllergenController allergenController = new AllergenController();
        public Allergens()
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

        private void AddAllergen(object sender, RoutedEventArgs e)
        {
            if(Textbox3.Text != "")
            {
                Allergen allergen = new Allergen(Textbox3.Text);

                string message = allergenController.CreateAllergen(Textbox1.Text + " " + Textbox2.Text, allergen);
                if (message == "SUCCEEDED")
                {
                    notifier.ShowSuccess("SUCCESS: Allergen is added");
                    string fullName = Textbox1.Text + " " + Textbox2.Text;
                    List<Allergen> allergens = allergenController.ReadAllergenByNameSurname(fullName);
                    ObservableCollection<Allergen> observableAllergens = new ObservableCollection<Allergen>();
                    foreach (var a in allergens)
                    {
                        observableAllergens.Add(a);
                    }
                    dg_allergens.ItemsSource = observableAllergens;
                }
                else
                {
                    notifier.ShowError("ERROR: Error occured while adding!");
                }
            }
            else
            {
                notifier.ShowWarning("WARNING: You need to enter name for new allergen!");
            }
        }

        private void DeleteAllergen(object sender, RoutedEventArgs e)
        {
            if (dg_allergens.SelectedItems.Count < 1)
            {
                notifier.ShowWarning("WARNING: You need to select an allergen!"); 
            }
            else
            {
                Allergen allergen = (Allergen)dg_allergens.SelectedItem;
                string message = allergenController.DeleteAllergen(Textbox1.Text + " " + Textbox2.Text, allergen);
                if (message == "SUCCEEDED")
                {
                    notifier.ShowSuccess("SUCCESS: Allergen is deleted");
                    string fullName = Textbox1.Text + " " + Textbox2.Text;
                    List<Allergen> allergens = allergenController.ReadAllergenByNameSurname(fullName);
                    ObservableCollection<Allergen> observableAllergens = new ObservableCollection<Allergen>();
                    foreach (var a in allergens)
                    {
                        observableAllergens.Add(a);
                    }
                    dg_allergens.ItemsSource = observableAllergens;
                }
                else
                {
                    notifier.ShowError("ERROR: Error occured while adding!");
                }
            }
        }

        private void ReadAllAllergens(object sender, RoutedEventArgs e)
        {
            string fullName = Textbox1.Text + " " + Textbox2.Text;
            List<Allergen> allergens = allergenController.ReadAllergenByNameSurname(fullName);
            ObservableCollection<Allergen> observableAllergens = new ObservableCollection<Allergen>();
            foreach (var a in allergens)
            {
                observableAllergens.Add(a);
            }
            dg_allergens.ItemsSource = observableAllergens;
        }
    }
}
