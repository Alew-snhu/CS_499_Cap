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
    /// Interaction logic for ViewHabitatFromTextFile.xaml
    /// </summary>
    public partial class ViewHabitatFromTextFile : Page
    {
        // instantiate HabitatViewModel to use class functions and properties
        public HabitatFromTextFileViewModel hvm { get; set; } = new HabitatFromTextFileViewModel();

        public ViewHabitatFromTextFile()
        {
            InitializeComponent(); 
            this.DataContext = hvm;
        }

        private void Button_Click_Go_Back(object sender, RoutedEventArgs e)
        {
            // Create new instance of ViewHabitats for navigation.

            App.AMS_Home.AMS_Frame.Navigate(new ViewHabitats());
        }

        private async void Button_Click_Open_File(object sender, RoutedEventArgs e)
        {            
            // Button click will call the GetHabitatTextFile function which will parse the file and return a dictionary.
            // the dictionary will provide the combobox with animal habitats.

            await hvm.GetHabitatTextFile();
            HabitatList.ItemsSource = hvm.HabitatKeysAndValues.Keys;
        }

        private void HabitatList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // When the user selects a habitat from the combobox, the value will appear in the TextBox next to the combo box.
           
            var selectedItem = HabitatList.SelectedItem;
            hvm.SelectedHabitat = selectedItem;            
            HabitatInfoDisplay.Text = hvm.HabitatKeysAndValues[hvm.SelectedHabitat.ToString()];

            // if the user selected habitat has any issues, a dialog box will appear to alert the zoo keeper.
            if (HabitatInfoDisplay.Text.Contains("*****"))
            {
                MessageBox.Show("This Habitat Requires Special Attention.", "Warning!!!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
