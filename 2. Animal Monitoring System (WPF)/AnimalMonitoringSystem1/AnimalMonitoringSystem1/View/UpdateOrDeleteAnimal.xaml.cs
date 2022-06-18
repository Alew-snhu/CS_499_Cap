using AMS.EntityFramework;
using AnimalMonitoringSystem.View;
using AnimalMonitoringSystem1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace AnimalMonitoringSystem1.View
{
    /// <summary>
    /// Interaction logic for UpdateOrDeleteAnimal.xaml
    /// </summary>
    public partial class UpdateOrDeleteAnimal : Page
    {
        public AddUpdateDeleteAnimalViewModel vm { get; set; } = new AddUpdateDeleteAnimalViewModel();
       
        public UpdateOrDeleteAnimal()
        {
            InitializeComponent();
            vm.GetAnimalsFromDb();            
            DataContext = vm;
        }

        private void Button_Click_GoBack(object sender, RoutedEventArgs e)
        {
            App.AMS_Home.AMS_Frame.Navigate(new AddAnimal());
        }

        private void Button_Click_Delete_Record(object sender, RoutedEventArgs e)
        {
            vm.DeleteAnimalRecord();           
        }

        private void Button_Click_Update_Record(object sender, RoutedEventArgs e)
        {
            vm.UpdateAnimalRecord();            
        }
                
    }
}
