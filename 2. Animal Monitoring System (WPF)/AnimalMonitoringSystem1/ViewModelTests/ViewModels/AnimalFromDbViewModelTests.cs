using System;
using System.Collections.Generic;
using System.Text;
using AMS.EntityFramework;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using AnimalMonitoringSystem1.ViewModel;

namespace AMS.Tests
{
    public class AnimalFromDbViewModelTests
    {
        [Fact]
        public async Task GetAnimalTypesFromDb_TestAsync()
        {
            //Arrange
            AnimalFromDbViewModel vm = new AnimalFromDbViewModel();
            string entry1 = "Lion";
            string entry2 = "Tiger";         
            string entry3 = "Bear";
            string entry4 = "Giraffe";


            //Act
            await vm.GetAnimalsFromDbAsync();

            //Assert
            Assert.NotNull(vm.AnimalsFromDb);
            Assert.Equal(entry1, vm.AnimalsFromDb[0]);
            Assert.Equal(entry2, vm.AnimalsFromDb[1]);
            Assert.Equal(entry3, vm.AnimalsFromDb[2]);
            Assert.Equal(entry4, vm.AnimalsFromDb[3]);
        }

        [Fact]
        public async Task GetAnimalInfoFromDb_Test()
        {
            //Arrange
            AnimalFromDbViewModel vm = new AnimalFromDbViewModel();
            string entry1 = " Animal ID: 1 \n Animal Name: Leo \n Animal Age: 5 \n Health concerns: Cut on left front paw \n Feeding Schedule: Twice Daily";
            string entry2 = " Animal ID: 2 \n Animal Name: Maj \n Animal Age: 15 \n Health concerns: None \n Feeding Schedule: 3x daily";
            string entry3 = " Animal ID: 3 \n Animal Name: Baloo \n Animal Age: 1 \n Health concerns: None \n Feeding Schedule: None on record";
            string entry4 = " Animal ID: 4 \n Animal Name: Spots \n Animal Age: 12 \n Health concerns: None \n Feeding Schedule: Grazing";

            //Act
            await vm.GetAnimalInfoFromDbAsync();

            //Assert
            Assert.NotNull(vm.AnimalInfoFromDb);
            Assert.Equal(entry1, vm.AnimalInfoFromDb[0]);
            Assert.Equal(entry2, vm.AnimalInfoFromDb[1]);
            Assert.Equal(entry3, vm.AnimalInfoFromDb[2]);
            Assert.Equal(entry4, vm.AnimalInfoFromDb[3]);
        }

        [Fact]
        public async Task ReturnDbAnimalKeysAndValues_Test()
        {
            //Arrange
            AnimalFromDbViewModel vm = new AnimalFromDbViewModel();

            string key1 = "Lion";
            string key2 = "Tiger";
            string key3 = "Bear";
            string key4 = "Giraffe";

            string value1 = " Animal ID: 1 \n Animal Name: Leo \n Animal Age: 5 \n Health concerns: Cut on left front paw \n Feeding Schedule: Twice Daily";
            string value2 = " Animal ID: 2 \n Animal Name: Maj \n Animal Age: 15 \n Health concerns: None \n Feeding Schedule: 3x daily";
            string value3 = " Animal ID: 3 \n Animal Name: Baloo \n Animal Age: 1 \n Health concerns: None \n Feeding Schedule: None on record";
            string value4 = " Animal ID: 4 \n Animal Name: Spots \n Animal Age: 12 \n Health concerns: None \n Feeding Schedule: Grazing";


            //Act
            await vm.GetAnimalsFromDbAsync();
            await vm.GetAnimalInfoFromDbAsync();
            await vm.ReturnDbAnimalKeysAndValues();

            //Assert
            Assert.NotNull(vm.DbAnimalKeysAndValues);
            

            Assert.True(vm.DbAnimalKeysAndValues.ContainsKey(key1));
            Assert.True(vm.DbAnimalKeysAndValues.ContainsKey(key2));
            Assert.True(vm.DbAnimalKeysAndValues.ContainsKey(key3));
            Assert.True(vm.DbAnimalKeysAndValues.ContainsKey(key4));
                           
            Assert.True(vm.DbAnimalKeysAndValues.ContainsValue(value1));
            Assert.True(vm.DbAnimalKeysAndValues.ContainsValue(value2));
            Assert.True(vm.DbAnimalKeysAndValues.ContainsValue(value3));
            Assert.True(vm.DbAnimalKeysAndValues.ContainsValue(value4));

        }


    }
}
