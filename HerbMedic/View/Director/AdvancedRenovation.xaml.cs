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

namespace HerbMedic.View
{
    public partial class AdvancedRenovation : Window
    {
        public AdvancedRenovation()
        {
            InitializeComponent();
        }

        private void ButtonGoBack(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void ButtonMergeRooms(object sender, RoutedEventArgs e)
        {
            MergeRooms merge = new MergeRooms();
            merge.Show();
            this.Hide();
        }

        private void ButtonSplitRooms(object sender, RoutedEventArgs e)
        {
            SplitRooms split = new SplitRooms();
            split.Show();
            this.Hide();
        }
    }
}
