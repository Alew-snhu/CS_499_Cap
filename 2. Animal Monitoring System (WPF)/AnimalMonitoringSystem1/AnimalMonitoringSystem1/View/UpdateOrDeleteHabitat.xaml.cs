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
    /// Interaction logic for UpdateOrDeleteHabitat.xaml
    /// </summary>
    public partial class UpdateOrDeleteHabitat : Page
    {
        public AddUpdateDeleteHabitatViewModel vm { get; set;} = new AddUpdateDeleteHabitatViewModel();
        public UpdateOrDeleteHabitat()
        {
            InitializeComponent();
            vm.GetHabitatsFromDb();            
            DataContext = vm;            
        }

        private void Button_Click_GoBack(object sender, RoutedEventArgs e)
        {
            App.AMS_Home.AMS_Frame.Navigate(new AddHabitat());
        }
                        
        private void Button_Click_UpdateRecords(object sender, RoutedEventArgs e)
        {
            vm.UpdateHabitatRecord();
        }

        private void Button_Click_DeleteRecord(object sender, RoutedEventArgs e)
        {
            vm.DeleteHabitatRecord();
        }
       
    }
}
