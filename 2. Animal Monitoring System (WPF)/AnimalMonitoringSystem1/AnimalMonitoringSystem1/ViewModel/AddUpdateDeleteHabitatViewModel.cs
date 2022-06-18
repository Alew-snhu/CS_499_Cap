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
    public class AddUpdateDeleteHabitatViewModel : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;
        public List<string> HabitatsOnRecord { get; set; } = new List<string>();
        
        private string _selectedHabitat;
        private string _habitatType;
        private string _temperature;
        private string _foodSource;
        private string _cleanliness;
        public string SelectedHabitat
        {
            get { return _selectedHabitat; }
            set
            {
                if (value != _selectedHabitat)
                {
                    _selectedHabitat = value;
                    UpdateTextBoxes();
                    OnPropertyChanged();
                }

            }
        }
        public string HabitatType
        {
            get { return _habitatType; }
            set
            {
                if (value != _habitatType)
                {
                    _habitatType = value;
                    OnPropertyChanged();
                }

            }
        }
        public string Temperature
        {
            get { return _temperature; }
            set
            {
                if (value != _temperature)
                {
                    _temperature = value;
                    OnPropertyChanged();
                }
            }
        }
        public string FoodSource
        {
            get { return _foodSource; }
            set
            {
                if (value != _foodSource)
                {
                    _foodSource = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Cleanliness
        {
            get { return _cleanliness; }
            set
            {
                if (value != _cleanliness)
                {
                    _cleanliness = value;
                    OnPropertyChanged();
                }
            }
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // function to get a list of habitat types from the database
        public Task<List<string>> GetHabitatsFromDb()
        {
            // Instantiate the DB context to access it
            using (var context = new AmsDbContext())
            {
                var habitat = context.Habitat;

                // loop through each property in the Animal DB set to find data assigned to the animal type
                foreach (var info in habitat)
                {
                    //add the animal type found to the list
                    HabitatsOnRecord.Add(info.HabitatType.ToString());
                }
            }
            //return the list of animal types
            return Task.FromResult(HabitatsOnRecord);
        }
        // function to add a new habitat record
        public async Task AddNewHabitatRecord()
        {
            // Check for empty text boxes
            if (string.IsNullOrEmpty(HabitatType) ||
                string.IsNullOrEmpty(Temperature) ||
                string.IsNullOrEmpty(FoodSource) ||
                string.IsNullOrEmpty(Cleanliness))
            {
                MessageBox.Show("You must enter a value for all of the fields", "Missing Field!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                //if all text boxes are filled in, the new animal is added
                AmsDbContext context = new AmsDbContext();
                var newHabitat = new Habitat
                {
                    HabitatType = HabitatType,
                    Temperature = Temperature,
                    FoodSource = FoodSource,
                    Cleanliness = Cleanliness,         
                };

                context.Habitat.Add(newHabitat);
                await context.SaveChangesAsync();

                MessageBox.Show("A New Habitat Has Been Added.", "New Habitat Added", MessageBoxButton.OK, MessageBoxImage.Information);

                //refresh page
                App.AMS_Home.AMS_Frame.Navigate(new AddHabitat());
            }
        }
        // function to update an existing habitat record
        public void UpdateHabitatRecord()
        {

            if (SelectedHabitat == null)
            {
                MessageBox.Show("You must select a habitat to update", "Invalid Selection!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                AmsDbContext context = new AmsDbContext();
                var habitatInfo = context.Habitat.Where(x => x.HabitatType == SelectedHabitat.ToString()).First();
                habitatInfo.HabitatType = HabitatType;
                habitatInfo.Temperature = Temperature;
                habitatInfo.FoodSource = FoodSource;
                habitatInfo.Cleanliness = Cleanliness;
                

                context.Habitat.Update(habitatInfo);
                context.SaveChanges();
                App.AMS_Home.AMS_Frame.Navigate(new UpdateOrDeleteHabitat());
                MessageBox.Show("The Animal Was Updated Successfully.", "New Animal Added", MessageBoxButton.OK, MessageBoxImage.Information);

            }

        }
        //function to delete a record from the database
        public void DeleteHabitatRecord()
        {
            var deleteMessage = MessageBox.Show("Are you sure you want to delete this record?", "You are about to delete a record!", MessageBoxButton.OKCancel, MessageBoxImage.Warning);



            // Check if user made a selection before pressing the delete button
            if (SelectedHabitat == null)
            {
                MessageBox.Show("You must select an animal to delete", "Invalid Selection!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (deleteMessage == MessageBoxResult.OK)
            {
                AmsDbContext context = new AmsDbContext();
                var habitatToDelete = context.Habitat.Where(x => x.HabitatType == SelectedHabitat.ToString()).First();
                context.Habitat.Remove(habitatToDelete);
                context.SaveChanges();

                // refresh the page 
                App.AMS_Home.AMS_Frame.Navigate(new UpdateOrDeleteHabitat());
            }

        }
        //function to up date the textboxes based on the animal type selcted in the listbox
        public void UpdateTextBoxes()
        {            
            AmsDbContext context = new AmsDbContext();
            
            //search database for habitat selected in the ListBox.
            var habitatInfo = context.Habitat.Where(x => x.HabitatType == SelectedHabitat);

            //return the values of the habitat to the appropriate textbox
            foreach (var info in habitatInfo)
            {
                HabitatType = info.HabitatType;
                Temperature = info.Temperature;
                FoodSource= info.FoodSource;
                Cleanliness = info.Cleanliness;
            }
        }
    }

}
