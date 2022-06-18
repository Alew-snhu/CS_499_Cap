using AMS.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalMonitoringSystem1.ViewModel
{
    
    public class AnimalFromDbViewModel
    {
        public object SelectedAnimal { get; set; }
        public List<string> AnimalsFromDb { get; set; } = new List<string>();
        public List<string> AnimalInfoFromDb { get; set; } = new List<string>();
        public Dictionary<string, string> DbAnimalKeysAndValues { get; set; } = new Dictionary<string, string>();

        
        
        public async Task<List<string>> GetAnimalsFromDbAsync()
        {
            // Instantiate the DB context to access it
            AmsDbContext context = new AmsDbContext();            
            var animal = context.Animal;
             // loop through each property in the Animal DB set to find data assigned to the animal type
            foreach (var info in animal)
            {
                //add the animal type found to the list
                AnimalsFromDb.Add(info.AnimalType.ToString());
            }
            return await Task.FromResult(AnimalsFromDb);
        }

        public async Task<List<string>> GetAnimalInfoFromDbAsync()
        {
            // Instantiate the DB context to access it
            using (var context = new AmsDbContext())
            {
                var animal = context.Animal;

                // loop through each property in the DB set and pull out necessary info
                foreach (var info in animal)
                {
                    //Concatinate data into a single string to add it as a single entry to the list

                    var animalInfo = $" Animal ID: {info.AnimalID} \n " +
                        $"Animal Name: {info.AnimalName} \n Animal Age: {info.AnimalAge} \n " +
                        $"Health concerns: {info.HealthConcerns} \n Feeding Schedule: {info.FeedingSchedule}";

                    //Add to list
                    AnimalInfoFromDb.Add(animalInfo);
                }
            }
            //return list
            return await Task.FromResult(AnimalInfoFromDb);
        }

        public async Task<Dictionary<string, string>> ReturnDbAnimalKeysAndValues()
        {
            // Zip will take the two lists and create a dictionary from them. Animal types will be the key, Animal info will be the values. 
            // This is used for the combobox and text box on the XAML page. When the User selects an animal type, the value will appear in the text box. 
            DbAnimalKeysAndValues = AnimalsFromDb.Zip(AnimalInfoFromDb, (k, v) => new { k, v })
              .ToDictionary(x => x.k, x => x.v);

            return await Task.FromResult(DbAnimalKeysAndValues);
        }

        
    }
}
