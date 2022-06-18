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
    /// Interaction logic for AddAnimalInformation.xaml
    /// </summary>
    public partial class AddAnimalInformation : Page
    {
        public AddAnimalInformation()
        {
            InitializeComponent();
        }

        private void Button_Click_AddAnimal(object sender, RoutedEventArgs e)
        {
            //Create a new instance of AddAnimal to proceed to page.

            App.AMS_Home.AMS_Frame.Navigate(new AddAnimal());
        }

        private void Button_Click_AddHabitat(object sender, RoutedEventArgs e)
        {
            //Create a new instance of AddHabitat to proceed to page.

            App.AMS_Home.AMS_Frame.Navigate(new AddHabitat());
        }

        private void Button_Click_GoBack(object sender, RoutedEventArgs e)
        {
            //Create a new instance of MainMenu to go back to main menu.

            App.AMS_Home.AMS_Frame.Navigate(new MainMenu());
        }
    }
}
