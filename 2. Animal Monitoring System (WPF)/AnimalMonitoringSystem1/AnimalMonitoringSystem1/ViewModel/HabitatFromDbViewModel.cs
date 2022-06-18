using AMS.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalMonitoringSystem1.ViewModel
{
    public class HabitatFromDbViewModel
    {
    
        public object SelectedHabitat { get; set; }
        public List<string> HabitatsFromDb { get; set; } = new List<string>();
        public List<string> HabitatInfoFromDb { get; set; } = new List<string>();
        public Dictionary<string, string> DbHabitatKeysAndValues { get; set; } = new Dictionary<string, string>();

        
        
        public async Task<List<string>> GetHabitatsFromDbAsync()
        {
            // Instantiate the DB context to access it
            using (var context = new AmsDbContext())
            {
                var habitat = context.Habitat;

                // loop through each property in the Animal DB set to find data assigned to the animal type
                foreach (var info in habitat)
                {
                    //add the animal type found to the list
                    HabitatsFromDb.Add(info.HabitatType.ToString());
                }
            }
            //return the list of animal types
            return await Task.FromResult(HabitatsFromDb);
        }

        public async Task<List<string>> GetHabitatInfoFromDbAsync()
        {
            // Instantiate the DB context to access it
            using (var context = new AmsDbContext())
            {
                var habitat = context.Habitat;

                // loop through each property in the DB set and pull out necessary info
                foreach (var info in habitat)
                {
                    //Concatinate data into a single string to add it as a single entry to the list

                    var habitatInfo = $" Habitat ID: {info.HabitatID} \n " +
                        $"Habitat Type: {info.HabitatType} \n Temperature: {info.Temperature} \n " +
                        $"Food Source: {info.FoodSource} \n Cleanliness: {info.Cleanliness}";

                    //Add to list
                    HabitatInfoFromDb.Add(habitatInfo);
                }
            }
            //return list
            return await Task.FromResult(HabitatsFromDb);
        }

        public async Task<Dictionary<string, string>> ReturnDbHabitatKeysAndValues()
        {
            // Zip will take the two lists and create a dictionary from them. Animal types will be the key, Animal info will be the values. 
            // This is used for the combobox and text box on the XAML page. When the User selects an animal type, the value will appear in the text box. 
            DbHabitatKeysAndValues = HabitatsFromDb.Zip(HabitatInfoFromDb, (k, v) => new { k, v })
              .ToDictionary(x => x.k, x => x.v);

            return await Task.FromResult(DbHabitatKeysAndValues);
        }
    }
}
    

