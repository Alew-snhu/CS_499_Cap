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
    /// Interaction logic for ViewAnimalsFromTextFile.xaml
    /// </summary>
    public partial class ViewAnimalsFromTextFile : Page
    {
        //instantiate AnimalViewModel to use functions and properties 
        AnimalFromTextFileViewModel avm { get; set; } = new AnimalFromTextFileViewModel();

        public ViewAnimalsFromTextFile()
        {
            InitializeComponent();
            this.DataContext = avm;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // When the user makes a selection from the combo box this code will
           // execute and update the text box to display the information related to the animal.

            var selectedItem = AnimalsList.SelectedItem;
            avm.SelectedAnimal = selectedItem;
            AnimalInfoDisplay.Text = avm.AnimalKeysAndValues[avm.SelectedAnimal.ToString()];

            //if the selected animal has any warnings in the file, a dialog box will be raised to inform the zookeeper
            if (AnimalInfoDisplay.Text.Contains("*****"))
            {
              MessageBox.Show("This Animal Requires Special Attention.", "Warning!!!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button_Click_Go_Back(object sender, RoutedEventArgs e)
        {
            // Create a new instance of ViewAnimals for navigation.

            App.AMS_Home.AMS_Frame.Navigate(new ViewAnimals());
        }

        private async void Button_Click_Open_File(object sender, RoutedEventArgs e)
        {
            // when the button is clicked, the text file selected will be read and parsed by
            // functions in the AnimalViewModel class to provide the intended outcome.

            await avm.GetAnimalTextFileAsync();
            AnimalsList.ItemsSource = avm.AnimalKeysAndValues.Keys;
        }

      
    }
}
