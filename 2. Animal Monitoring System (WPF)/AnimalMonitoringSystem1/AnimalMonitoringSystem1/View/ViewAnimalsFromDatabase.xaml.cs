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
    /// Interaction logic for ViewAnimalsFromDatabase.xaml
    /// </summary>
    public partial class ViewAnimalsFromDatabase : Page
    {
        //Instantiate a new instance of AnimalViewModel to call function for call to database
        
        AnimalFromDbViewModel vm { get; set;} = new AnimalFromDbViewModel();

        public ViewAnimalsFromDatabase()
        {
            InitializeComponent();
        }

        private async void Button_Click_Search_Database(object sender, RoutedEventArgs e)
        {
            // This will fill the combobox with Animal Types found in the Database
            // Part of Enhancement 3. Not functional yet.

            AnimalFromDatabaseList.ItemsSource = await vm.GetAnimalsFromDbAsync();
            await vm.GetAnimalInfoFromDbAsync();
            await vm.ReturnDbAnimalKeysAndValues();
        }

        private void Button_Click_Go_Back(object sender, RoutedEventArgs e)
        {
            //Create a new instance of ViewAnimals to go back a page.

            App.AMS_Home.AMS_Frame.Navigate(new ViewAnimals());
        }

        private void AnimalFromDatabaseList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = AnimalFromDatabaseList.SelectedItem;
            vm.SelectedAnimal = selectedItem;
            AnimalInfoDisplayFromDb.Text = vm.DbAnimalKeysAndValues[vm.SelectedAnimal.ToString()];
        }
    }
}
