using AMS.EntityFramework;
using AnimalMonitoringSystem1.View;
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

namespace AnimalMonitoringSystem.View
{
    /// <summary>
    /// Interaction logic for AddHabitat.xaml
    /// </summary>
    public partial class AddHabitat : Page
    {
        public AddUpdateDeleteHabitatViewModel vm = new AddUpdateDeleteHabitatViewModel();
        public AddHabitat()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void Button_Click_GoBack(object sender, RoutedEventArgs e)
        {
            // Create new instance of AddAnimalInformation to navigate to page.

            App.AMS_Home.AMS_Frame.Navigate(new AddAnimalInformation());
        }       

        private async void Button_Click_AddToRecords(object sender, RoutedEventArgs e)
        {
            await vm.AddNewHabitatRecord();
        }

        private void Button_Click_UpdateDelete(object sender, RoutedEventArgs e)
        {
            App.AMS_Home.AMS_Frame.Navigate(new UpdateOrDeleteHabitat());
        }
    }
}
