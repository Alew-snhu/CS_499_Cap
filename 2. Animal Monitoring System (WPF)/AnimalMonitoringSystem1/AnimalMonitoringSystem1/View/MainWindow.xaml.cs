using AnimalMonitoringSystem1.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();            
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Setting the context for the navigation and creating a new instance of MainMenue to navigate to.

            App.AMS_Home = this;
            AMS_Frame.Navigate(new UserLogin());
        }
       
    }
}
