using Classes.Controller;
using Classes.Model;
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

namespace HerbMedic.View
{
    public partial class SeeRenovations : Window
    {
        RenovationController renovationController = new RenovationController();

        public SeeRenovations()
        {
            InitializeComponent();
            List<Renovation> renovations = renovationController.ReadAllRenovations();
            ObservableCollection<Renovation> observableRenovations = new ObservableCollection<Renovation>();
            foreach (var renovation in renovations)
            {
                observableRenovations.Add(renovation);
            }
            dg_renovations.ItemsSource = observableRenovations;
        }

        private void ButtonGoBack(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
