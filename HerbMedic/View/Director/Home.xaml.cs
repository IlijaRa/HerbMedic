using System.Windows;
using Classes.Model;
using Classes.Controller;
using System;

namespace HerbMedic.View
{
    public partial class Home : Window
    {
        StaticEquipmentController staticController = new StaticEquipmentController();
        RenovationController renovationController = new RenovationController();
        RoomController roomController = new RoomController();
        public Home()
        {
            InitializeComponent();
            roomController.SwitchMergeToRoomJson();
            roomController.SwitchSplitToRoomJson();
            staticController.ExecuteTransfer();
            renovationController.DeleteExpiredBasicRenovation();
        }

        private void ButtonRoomCRUD(object sender, RoutedEventArgs e)
        {
            RoomCRUD room = new RoomCRUD();
            room.Show();
            this.Hide();
        }

        private void ButtonMedicineCRUD(object sender, RoutedEventArgs e)
        {
            MedicineCRUD medicine = new MedicineCRUD();
            medicine.Show();
            this.Hide();
        }

        private void ButtonStaticEquipmentCRUD(object sender, RoutedEventArgs e)
        {
            StaticEquipmentCRUD staticEquipment = new StaticEquipmentCRUD();
            staticEquipment.Show();
            this.Hide();
        }

        private void ButtonDynamicEquipmentCRUD(object sender, RoutedEventArgs e)
        {
            DynamicEquipmentCRUD dynamicEquipment = new DynamicEquipmentCRUD();
            dynamicEquipment.Show();
            this.Hide();
        }

        private void ButtonSearchEquipment(object sender, RoutedEventArgs e)
        {
            SearchEquipment search = new SearchEquipment();
            search.Show();
            this.Hide();
        }

        private void ButtonEquipmentManagement(object sender, RoutedEventArgs e)
        {
            StaticEquipmentManagement management = new StaticEquipmentManagement();
            management.Show();
            this.Hide();
        }

        private void ButtonAdvancedRenovation(object sender, RoutedEventArgs e)
        {
            AdvancedRenovation advanced = new AdvancedRenovation();
            advanced.Show();
            this.Hide();
        }

        private void ButtonBasicRenovation(object sender, RoutedEventArgs e)
        {
            BasicRenovation basic = new BasicRenovation();
            basic.Show();
            this.Hide();
        }
        
        public void TransferInfo(User user)
        {
            Textbox1.Text = user.username;
            Textbox2.Text = user.password;
            Textbox3.Text = user.firstName;
            Textbox4.Text = user.lastName;
            Textbox5.Text = user.jmbg;
            Textbox6.Text = user.phoneNumber;
            Textbox7.Text = user.address;
            Textbox8.Text = user.email;
            Textbox9.Text = user.dateOfBirth.ToString("MM/dd/yyyy");
        }

        private void ButtonLogOut(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Hide();
        }

        private void ButtonMinimized(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
