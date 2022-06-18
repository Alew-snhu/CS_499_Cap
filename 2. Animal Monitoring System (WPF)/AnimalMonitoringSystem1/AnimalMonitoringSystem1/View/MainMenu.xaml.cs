using AnimalMonitoringSystem1.View;
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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Button_Click_Open_ViewAnimals(object sender, RoutedEventArgs e)
        {
            //Create a new instance of ViewAnimals to navigate to.

            App.AMS_Home.AMS_Frame.Navigate(new ViewAnimals());            
        }

        private void Button_Click_Open_ViewHabitats(object sender, RoutedEventArgs e)
        {
            // Create a new instance of the ViewHabitats page to navigate to.

            App.AMS_Home.AMS_Frame.Navigate(new ViewHabitats());
        }

        private void Button_Click_AddInfo(object sender, RoutedEventArgs e)
        {
            //Create a new instance of AddAnimalInformation to navigate to.

            App.AMS_Home.AMS_Frame.Navigate(new AddAnimalInformation());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.AMS_Home.AMS_Frame.Navigate(new UserLogin());
        }
    }
}
