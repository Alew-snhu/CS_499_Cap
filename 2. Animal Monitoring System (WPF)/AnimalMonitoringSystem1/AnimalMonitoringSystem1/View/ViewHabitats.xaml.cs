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
    /// Interaction logic for ViewHabitats.xaml
    /// </summary>
    public partial class ViewHabitats : Page
    {
        public ViewHabitats()
        {
            InitializeComponent();
        }

        private void Button_Click_ViewFromTextFile(object sender, RoutedEventArgs e)
        {
            // Create new instance of ViewHabitatFromTextFile for navigation.
            
            App.AMS_Home.AMS_Frame.Navigate(new ViewHabitatFromTextFile());
        }

        private void Button_Click_ViewFromDatabase(object sender, RoutedEventArgs e)
        {
            //Create new instance of ViewHabitatFromDataBase for navigation. 

            App.AMS_Home.AMS_Frame.Navigate(new ViewHabitatFromDataBase());
        }

        private void Button_Click_Main_Menu(object sender, RoutedEventArgs e)
        {
            //Create new instance of MainMenu for navigation. 

            App.AMS_Home.AMS_Frame.Navigate(new MainMenu());
        }
    }
}
