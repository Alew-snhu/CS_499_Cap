using AnimalMonitoringSystem;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AMS.Tests.ViewModels
{
    public class AnimalViewModelTests
    {

        [Fact]
        public async void GetAnimalList_Test()
        {

            //Arrange
            AnimalFromTextFileViewModel avm = new AnimalFromTextFileViewModel();

            //Act
            await avm.GetAnimalList(avm.HardCodedTextFilePath);

            //Assert 
            Assert.NotNull(avm.AnimalsFromTextFile);
            Assert.Equal(4, avm.AnimalsFromTextFile.Count);
            Assert.Equal("Lion", avm.AnimalsFromTextFile[0]);
            Assert.Equal("Tiger", avm.AnimalsFromTextFile[1]);
            Assert.Equal("Bear", avm.AnimalsFromTextFile[2]);
            Assert.Equal("Giraffe", avm.AnimalsFromTextFile[3]);

        }

        [Fact]
        public async void GetAnimalInfoList_Test()
        {
            //Arrange
            AnimalFromTextFileViewModel avm = new AnimalFromTextFileViewModel();
            string entry1 = "Name: Leo\nAge: 5\n*****Health concerns: Cut on left front paw\nFeeding schedule: Twice daily\n";
            string entry2 = "Name: Maj\nAge: 15\nHealth concerns: None\nFeeding schedule: 3x daily\n";
            string entry3 = "Name: Baloo\nAge: 1\nHealth concerns: None\n*****Feeding schedule: None on record\n";
            string entry4 = "Name: Spots\nAge: 12\nHealth concerns: None\nFeeding schedule: Grazing\n";

            //Act
            await avm.GetAnimalInfo(avm.HardCodedTextFilePath);

            //Assert
            Assert.NotNull(avm.AnimalInfoFromTextFile);
            Assert.Equal(4, avm.AnimalInfoFromTextFile.Count);
            Assert.Equal(entry1, avm.AnimalInfoFromTextFile[0]);
            Assert.Equal(entry2, avm.AnimalInfoFromTextFile[1]);
            Assert.Equal(entry3, avm.AnimalInfoFromTextFile[2]);
            Assert.Equal(entry4, avm.AnimalInfoFromTextFile[3]);
        }

        [Fact]
        public async void ReturnAnimalKeysAndValues_Test()
        {
            //Arrange
            AnimalFromTextFileViewModel avm = new AnimalFromTextFileViewModel();

            string key1 = "Lion";
            string key2 = "Tiger";
            string key3 = "Bear";
            string key4 = "Giraffe";

            string value1 = "Name: Leo\nAge: 5\n*****Health concerns: Cut on left front paw\nFeeding schedule: Twice daily\n";
            string value2 = "Name: Maj\nAge: 15\nHealth concerns: None\nFeeding schedule: 3x daily\n";
            string value3 = "Name: Baloo\nAge: 1\nHealth concerns: None\n*****Feeding schedule: None on record\n";
            string value4 = "Name: Spots\nAge: 12\nHealth concerns: None\nFeeding schedule: Grazing\n";

            //Act
            await avm.GetAnimalInfo(avm.HardCodedTextFilePath);
            await avm .GetAnimalList(avm.HardCodedTextFilePath);
            await avm.ReturnAnimalKeysAndValues();

            //Assert
            Assert.NotNull(avm.AnimalKeysAndValues);
            Assert.Equal(4, avm.AnimalKeysAndValues.Count);

            Assert.True(avm.AnimalKeysAndValues.ContainsKey(key1));
            Assert.True(avm.AnimalKeysAndValues.ContainsKey(key2));
            Assert.True(avm.AnimalKeysAndValues.ContainsKey(key3));
            Assert.True(avm.AnimalKeysAndValues.ContainsKey(key4));

            Assert.True(avm.AnimalKeysAndValues.ContainsValue(value1));
            Assert.True(avm.AnimalKeysAndValues.ContainsValue(value2));
            Assert.True(avm.AnimalKeysAndValues.ContainsValue(value3));
            Assert.True(avm.AnimalKeysAndValues.ContainsValue(value4));            
        }
        
    }
}