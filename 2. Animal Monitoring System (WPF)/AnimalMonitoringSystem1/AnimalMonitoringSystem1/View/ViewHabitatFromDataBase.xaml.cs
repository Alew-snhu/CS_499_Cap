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
    /// Interaction logic for ViewHabitatFromDataBase.xaml
    /// </summary>
    /// 
    public partial class ViewHabitatFromDataBase : Page
    {
        HabitatFromDbViewModel vm = new HabitatFromDbViewModel();
        public ViewHabitatFromDataBase()
        {
            InitializeComponent();
        }

        private void Button_Click_Go_Back(object sender, RoutedEventArgs e)
        {
            // Create a new instance of ViewHabitats for navigation. 

            App.AMS_Home.AMS_Frame.Navigate(new ViewHabitats());
        }

        private async void Button_Click_Search_Database(object sender, RoutedEventArgs e)
        {
            // Search the database for Habitats. The functions will get the Habitat Names and Info and put them into a Dictionary for the Combobox
            HabitatFromDbList.ItemsSource = await vm.GetHabitatsFromDbAsync();
            await vm.GetHabitatInfoFromDbAsync();
            await vm.ReturnDbHabitatKeysAndValues();
        }

        private void HabitatFromDbList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Bind the Dictionary values to the Combobox keys for display in the textbox
            var selectedItem = HabitatFromDbList.SelectedItem;
            vm.SelectedHabitat = selectedItem;
            HabitatInfoDisplayFromDb.Text = vm.DbHabitatKeysAndValues[vm.SelectedHabitat.ToString()];
        }
    }
}
