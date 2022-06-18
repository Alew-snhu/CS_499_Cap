using AnimalMonitoringSystem.View;
using AnimalMonitoringSystem1.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnimalMonitoringSystem1.View
{
    /// <summary>
    /// Interaction logic for CreateAnAccount.xaml
    /// </summary>
    public partial class CreateAnAccount : Page
    {
        public UserLoginViewModel vm = new UserLoginViewModel();
        public CreateAnAccount()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void Button_Click_GoBack(object sender, RoutedEventArgs e)
        {
            App.AMS_Home.AMS_Frame.Navigate(new UserLogin());
        }

        private async void Button_Click_CreateAccount(object sender, RoutedEventArgs e)
        {
            vm.Password = PBox.Password;
            await vm.AddCredentialsToDb();           
        }
    }
}
