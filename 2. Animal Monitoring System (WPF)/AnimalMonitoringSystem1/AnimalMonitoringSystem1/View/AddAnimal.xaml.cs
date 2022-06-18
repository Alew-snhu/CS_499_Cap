using AMS.EntityFramework;
using AnimalMonitoringSystem;
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
    /// Interaction logic for AddAnimal.xaml
    /// </summary>
    public partial class AddAnimal : Page
    {        
        public AddUpdateDeleteAnimalViewModel vm { get; set; } = new AddUpdateDeleteAnimalViewModel();
        public AddAnimal()
        {
            InitializeComponent();
            
            this.DataContext = vm;
        }

        private void Button_Click_GoBack(object sender, RoutedEventArgs e)
        {
            //Create a new instance of AddAnimalInformation to navigate back.

            App.AMS_Home.AMS_Frame.Navigate(new AddAnimalInformation());
        }

        private async void Button_Click_AddToRecords(object sender, RoutedEventArgs e)
        {            
            await vm.AddNewAnimalRecord();                                           
        }
        

        private void Button_Click_UpdateDelete(object sender, RoutedEventArgs e)
        {
            App.AMS_Home.AMS_Frame.Navigate(new UpdateOrDeleteAnimal());
        }
    }
}
