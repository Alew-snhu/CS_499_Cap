using AMS.EntityFramework;
using AnimalMonitoringSystem.View;
using AnimalMonitoringSystem1.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AnimalMonitoringSystem1.ViewModel
{
    public class UserLoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _userName;
        private string _password;

        public string UserName
        {
            get { return _userName; }
            set
            {
                if (value != _userName)
                {
                    _userName = value;                    
                    OnPropertyChanged();
                }
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (value != _password)
                {
                    _password = value;                    
                    OnPropertyChanged();
                }
            }
        }
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //function called when user creates an account
        //adds credentials to the database
        public async Task AddCredentialsToDb()
        {
            
            AmsDbContext context = new AmsDbContext();            
            var userName = context.UserCredentials.Where(un => un.UserName == UserName).FirstOrDefault();
            
            
            if (string.IsNullOrEmpty(UserName) || (string.IsNullOrEmpty(Password)))
            {
                MessageBox.Show("You must enter a User name and Password", "Missing Field!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (userName != null)
            {
                MessageBox.Show("The User name entered is already taken. Please Select a different one", "User Name Taken!", MessageBoxButton.OK, MessageBoxImage.Error);                
            }
            else
            {
                                
                var credentials = new UserCredentials
                {
                    UserName = UserName,
                    UserPassword = Password
                };
                context.UserCredentials.Add(credentials);
                await context.SaveChangesAsync();
                var messageBox = MessageBox.Show("Your account has been created!.", "New Account Added", MessageBoxButton.OK, MessageBoxImage.Information);
                if (messageBox == MessageBoxResult.OK)
                {
                    App.AMS_Home.AMS_Frame.Navigate(new UserLogin());
                }
            }
        }

        //function called when user tries to log in
        //checks entered credentials against values stored in database
        public void GetUserCredentials()
        {
            AmsDbContext context = new AmsDbContext();

            var userName = context.UserCredentials.Where(un => un.UserName == UserName).FirstOrDefault();
            var password = context.UserCredentials.Where(pw => pw.UserPassword == Password).FirstOrDefault();

            if(userName == null || password == null)
            {
                MessageBox.Show("The User Name or Password entered is incorrect", "Wrong User Name Or Password!", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                App.AMS_Home.AMS_Frame.Navigate(new MainMenu());
            }
        }
    }
}
