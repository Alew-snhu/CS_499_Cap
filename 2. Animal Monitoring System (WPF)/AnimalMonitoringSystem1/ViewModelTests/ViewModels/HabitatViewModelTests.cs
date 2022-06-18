using AnimalMonitoringSystem;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AMS.Tests.ViewModels
{
    public class HabitatViewModelTests
    {
        [Fact]
        public async void GetHabitatList_Test()
        {
            //Arrange
            HabitatFromTextFileViewModel hvm = new HabitatFromTextFileViewModel();

            //Act
            await hvm.GetHabitatList(hvm.HardCodedTextFilePath);

            //Assert 
            Assert.NotNull(hvm.Habitats);
            Assert.Equal(3, hvm.Habitats.Count);
            Assert.Equal("Penguin", hvm.Habitats[0]);
            Assert.Equal("Bird", hvm.Habitats[1]);
            Assert.Equal("Aquarium", hvm.Habitats[2]);            
        }

        [Fact]
        public async void GetHabitatInfoList_Test()
        {
            //Arrange
            HabitatFromTextFileViewModel hvm = new HabitatFromTextFileViewModel();
            string entry1 = "Temperature: Freezing\n*****Food source: Fish in water running low\nCleanliness: Passed\n";
            string entry2 = "Temperature: Moderate\nFood source: Natural from environment\nCleanliness: Passed\n";
            string entry3 = "Temperature: Varies with output temperature\nFood source: Added daily\n*****Cleanliness: Needs cleaning from algae\n";


            //Act
            await hvm .GetHabitatInfo(hvm.HardCodedTextFilePath);

            //Assert
            Assert.NotNull(hvm.HabitatInfo);
            Assert.Equal(3, hvm.HabitatInfo.Count);
            Assert.Equal(entry1, hvm.HabitatInfo[0]);
            Assert.Equal(entry2, hvm.HabitatInfo[1]);
            Assert.Equal(entry3, hvm.HabitatInfo[2]);
        }

        [Fact]
        public async void ReturnHabitatKeysAndValues_Test()
        {
            //Arrange
            HabitatFromTextFileViewModel hvm = new HabitatFromTextFileViewModel();

            string key1 = "Penguin";
            string key2 = "Bird";
            string key3 = "Aquarium";            

            string value1 = "Temperature: Freezing\n*****Food source: Fish in water running low\nCleanliness: Passed\n";
            string value2 = "Temperature: Moderate\nFood source: Natural from environment\nCleanliness: Passed\n";
            string value3 = "Temperature: Varies with output temperature\nFood source: Added daily\n*****Cleanliness: Needs cleaning from algae\n";            

            //Act
            await hvm .GetHabitatInfo(hvm.HardCodedTextFilePath);
            await hvm .GetHabitatList(hvm.HardCodedTextFilePath);
            await hvm .ReturnHabitatKeysAndValues();

            //Assert
            Assert.NotNull(hvm.HabitatKeysAndValues);
            Assert.Equal(3, hvm.HabitatKeysAndValues.Count);

            Assert.True(hvm.HabitatKeysAndValues.ContainsKey(key1));
            Assert.True(hvm.HabitatKeysAndValues.ContainsKey(key2));
            Assert.True(hvm.HabitatKeysAndValues.ContainsKey(key3));
            
            Assert.True(hvm.HabitatKeysAndValues.ContainsValue(value1));
            Assert.True(hvm.HabitatKeysAndValues.ContainsValue(value2));
            Assert.True(hvm.HabitatKeysAndValues.ContainsValue(value3));
        }
    }
}
