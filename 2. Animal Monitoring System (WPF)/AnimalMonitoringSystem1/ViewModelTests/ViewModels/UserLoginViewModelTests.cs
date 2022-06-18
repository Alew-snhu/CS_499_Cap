using AMS.EntityFramework;
using AnimalMonitoringSystem.View;
using AnimalMonitoringSystem1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AMS.Tests
{
    public class UserLoginViewModelTests
    {
        [Fact]
        public async Task AddCredentialsToDb_Test()
        {
            //Arrange 
            UserLoginViewModel vm = new UserLoginViewModel();
            AmsDbContext context = new AmsDbContext();

            vm.UserName = "123";
            vm.Password = "ABC";
            string DbUserName = "";
            string DbPassword = "";
            

            //Act
            await vm.AddCredentialsToDb();
            var userInfo = context.UserCredentials.Where(un => un.UserName == vm.UserName && un.UserPassword == vm.Password);
            foreach (var info in userInfo)
            {
                DbUserName = info.UserName;
                DbPassword = info.UserPassword;
            }

            //Assert
            Assert.Equal(vm.UserName, DbUserName);
            Assert.Equal(vm.Password, DbPassword);      
        }

        [Fact]
        public  void GetUserCredentials_Test()
        {
            //Arrange 
            UserLoginViewModel vm = new UserLoginViewModel();
            AmsDbContext context = new AmsDbContext();

            vm.UserName = "123";
            vm.Password = "ABC";

            //Act
            vm.GetUserCredentials();

            //Assert
            Assert.NotNull(vm.UserName);
            Assert.NotNull(vm.Password);

        }
    }
}
