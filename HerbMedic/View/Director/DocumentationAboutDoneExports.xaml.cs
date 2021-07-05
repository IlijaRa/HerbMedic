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
using Classes.Model;
using Classes.Controller;
using System.Collections.ObjectModel;

namespace HerbMedic.View
{
    public partial class DocumentationAboutDoneExports : Window
    {
        DynamicEquipmentController dynamicController = new DynamicEquipmentController();
        public DocumentationAboutDoneExports()
        {
            InitializeComponent();
            List<DoneExports> exports = dynamicController.ReadAllExports();
            ObservableCollection<DoneExports> observableExports = new ObservableCollection<DoneExports>();
            foreach (var export in exports)
            {
                observableExports.Add(export);
            }
            dg_exports.ItemsSource = observableExports;
        }

        private void ButtonGoBack(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
