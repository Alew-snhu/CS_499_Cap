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
    /// Interaction logic for ViewAnimals.xaml
    /// </summary>
    public partial class ViewAnimals : Page
    {
        public ViewAnimals()
        {
            InitializeComponent();
        }

        private void Button_Click_Main_Menu(object sender, RoutedEventArgs e)
        {
            // Create a new instance of MainMenu for navigation.

            App.AMS_Home.AMS_Frame.Navigate(new MainMenu());
        }                       

        private void Button_Click_ViewFromTextFile(object sender, RoutedEventArgs e)
        {
            // Create a new instance of ViewAnimalsFromTextFiles for navigation. 

            App.AMS_Home.AMS_Frame.Navigate(new ViewAnimalsFromTextFile());                        
        }        

        private void Button_Click_ViewFromDatabase(object sender, RoutedEventArgs e)
        {
            // Creat a new instance of ViewAnimalsFromDatabase for navigation.

            App.AMS_Home.AMS_Frame.Navigate(new ViewAnimalsFromDatabase());
        }
    }
}
