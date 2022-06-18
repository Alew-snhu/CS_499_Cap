using AnimalMonitoringSystem1.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AMS.Tests.ViewModels
{
    public class HabitatFromDbViewModelTests
    {
        [Fact]
        public async Task GetHabitatFromDbAsync_Test()
        {
            //Arrange
            HabitatFromDbViewModel vm = new HabitatFromDbViewModel();

            string entry1 = "Penguin";
            string entry2 = "Bird";
            string entry3 = "Aquarium";

            //Act
            await vm.GetHabitatsFromDbAsync();

            //Assert
            Assert.NotNull(vm.HabitatsFromDb);
            Assert.Equal(entry1, vm.HabitatsFromDb[0]);
            Assert.Equal(entry2, vm.HabitatsFromDb[1]);
            Assert.Equal(entry3, vm.HabitatsFromDb[2]);
        }

        [Fact]
        public async Task GetHabitatInfoFromDbAsync_Test()
        {
            //Arrange
            HabitatFromDbViewModel vm = new HabitatFromDbViewModel();

            string entry1 = " Habitat ID: 1 \n Habitat Type: Penguin \n Temperature: Freezing \n Food Source: Fish in water running low \n Cleanliness: Passed";
            string entry2 = " Habitat ID: 2 \n Habitat Type: Bird \n Temperature: Moderate \n Food Source: Natural from environment \n Cleanliness: Passed";
            string entry3 = " Habitat ID: 3 \n Habitat Type: Aquarium \n Temperature: Varies with output temperature \n Food Source: Added daily \n Cleanliness: Needs cleaning from algae";

            //Act
            await vm.GetHabitatInfoFromDbAsync();

            //Assert
            Assert.NotNull(vm.HabitatInfoFromDb);
            Assert.Equal(entry1, vm.HabitatInfoFromDb[0]);
            Assert.Equal(entry2, vm.HabitatInfoFromDb[1]);
            Assert.Equal(entry3, vm.HabitatInfoFromDb[2]);
        }

        [Fact]
        public async Task ReturnDbHabitatKeysAndValues_Test()
        {
            //Arrange
            HabitatFromDbViewModel vm = new HabitatFromDbViewModel();

            string key1 = "Penguin";
            string key2 = "Bird";
            string key3 = "Aquarium";           

            string value1 = " Habitat ID: 1 \n Habitat Type: Penguin \n Temperature: Freezing \n Food Source: Fish in water running low \n Cleanliness: Passed";
            string value2 = " Habitat ID: 2 \n Habitat Type: Bird \n Temperature: Moderate \n Food Source: Natural from environment \n Cleanliness: Passed";
            string value3 = " Habitat ID: 3 \n Habitat Type: Aquarium \n Temperature: Varies with output temperature \n Food Source: Added daily \n Cleanliness: Needs cleaning from algae";


            //Act
            await vm.GetHabitatsFromDbAsync();
            await vm.GetHabitatInfoFromDbAsync();
            await vm.ReturnDbHabitatKeysAndValues();

            //Assert
            Assert.NotNull(vm.DbHabitatKeysAndValues);


            Assert.True(vm.DbHabitatKeysAndValues.ContainsKey(key1));
            Assert.True(vm.DbHabitatKeysAndValues.ContainsKey(key2));
            Assert.True(vm.DbHabitatKeysAndValues.ContainsKey(key3));
                           
            Assert.True(vm.DbHabitatKeysAndValues.ContainsValue(value1));
            Assert.True(vm.DbHabitatKeysAndValues.ContainsValue(value2));
            Assert.True(vm.DbHabitatKeysAndValues.ContainsValue(value3));
        }


    }
}
