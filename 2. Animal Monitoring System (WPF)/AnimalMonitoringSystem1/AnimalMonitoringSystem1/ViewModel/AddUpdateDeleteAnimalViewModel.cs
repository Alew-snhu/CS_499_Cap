using AMS.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using AnimalMonitoringSystem.View;
using System.Windows;
using AnimalMonitoringSystem1.View;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AnimalMonitoringSystem1.ViewModel
{

    public class AddUpdateDeleteAnimalViewModel : INotifyPropertyChanged
    {                

        public event PropertyChangedEventHandler PropertyChanged;
        public List<string> AnimalsOnRecord { get; set; } = new List<string>();
        
        private string _animalType;
        private string _animalName;
        private string _animalAge;
        private string _healthConcerns;
        private string _feedingSchedule;
        private string _selectedAnimal;

        public string SelectedAnimal
        {
            get { return _selectedAnimal; }
            set
            {
                if (value != _selectedAnimal)
                {
                    _selectedAnimal = value;
                    UpdateTextBoxes();
                    OnPropertyChanged();
                }
            }
        }
        public string AnimalType
        {
            get { return _animalType; }
            set
            {
                if (value != _animalType)
                {
                    _animalType = value;
                    OnPropertyChanged();
                }
            }
        }
        public string AnimalName
        {
            get { return _animalName; }
            set
            {
                if (value != _animalName)
                {
                    _animalName = value;
                    OnPropertyChanged();
                }
            }
        }
        public string AnimalAge
        {
            get { return _animalAge; }
            set
            {
                if (value != _animalAge)
                {
                    _animalAge = value;
                    OnPropertyChanged();
                }
            }
        }
        public string HealthConcerns
        {
            get { return _healthConcerns; }
            set
            {
                if (value != _healthConcerns)
                {
                    _healthConcerns = value;
                    OnPropertyChanged();
                }
            }
        }
        public string FeedingSchedule
        {
            get { return _feedingSchedule; }
            set
            {
                if (value != _feedingSchedule)
                {
                    _feedingSchedule = value;
                    OnPropertyChanged();
                }
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //function to get a lits of animal types from the database and populate the listbox
        public Task<List<string>> GetAnimalsFromDb()
        {
            // Instantiate the DB context to access it
            using (var context = new AmsDbContext())
            {                         
                var animal = context.Animal;

                // loop through each property in the Animal DB set to find data assigned to the animal type
                foreach (var info in animal)
                {
                    //add the animal type found to the list
                    AnimalsOnRecord.Add(info.AnimalType.ToString());
                }
            }
            //return the list of animal types
            return Task.FromResult(AnimalsOnRecord);   
        }
        //function to add a new animal record
        public async Task AddNewAnimalRecord()
        {                        
            // Check for empty text boxes
            if (string.IsNullOrEmpty(AnimalType) ||
                string.IsNullOrEmpty(AnimalName) ||
                string.IsNullOrEmpty(AnimalAge) ||
                string.IsNullOrEmpty(FeedingSchedule) ||
                string.IsNullOrEmpty(HealthConcerns))
            {
                MessageBox.Show("You must enter a value for all of the text boxes", "Missing Field!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                //if all text boxes are filled in, the new animal is added
                AmsDbContext context = new AmsDbContext();
                var newAnimal = new Animal
                {
                    AnimalType = AnimalType,
                    AnimalName = AnimalName,
                    AnimalAge = AnimalAge,
                    FeedingSchedule = FeedingSchedule,
                    HealthConcerns = HealthConcerns
                };

                context.Animal.Add(newAnimal);
                await context.SaveChangesAsync();

                MessageBox.Show("A New Animal Has Been Added.", "New Animal Added", MessageBoxButton.OK, MessageBoxImage.Information);

                //refresh page
                App.AMS_Home.AMS_Frame.Navigate(new AddAnimal());
            }
        }
        //function to update an animal record
        public void UpdateAnimalRecord()
        {            

            if (SelectedAnimal == null)
            {
                MessageBox.Show("You must select an animal to update", "Invalid Selection!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                AmsDbContext context = new AmsDbContext();
                var animalInfo = context.Animal.Where(x => x.AnimalType == SelectedAnimal.ToString()).First();
                animalInfo.AnimalType = AnimalType;
                animalInfo.AnimalName = AnimalName;
                animalInfo.AnimalAge = AnimalAge;
                animalInfo.HealthConcerns = HealthConcerns;
                animalInfo.FeedingSchedule = FeedingSchedule;

                context.Animal.Update(animalInfo);
                context.SaveChanges();
                App.AMS_Home.AMS_Frame.Navigate(new UpdateOrDeleteAnimal());
                MessageBox.Show("The Animal Was Updated Successfully.", "New Animal Added", MessageBoxButton.OK, MessageBoxImage.Information);

            }

        }
        //function to delte an animal record
        public void DeleteAnimalRecord()
        {
            var deleteMessage = MessageBox.Show("Are you sure you want to delete this record?", "You are about to delete a record!", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

            

            // Check if user made a selection before pressing the delete button
            if (SelectedAnimal == null)
            {
                MessageBox.Show("You must select an animal to delete", "Invalid Selection!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (deleteMessage == MessageBoxResult.OK)
            {
                AmsDbContext context = new AmsDbContext();
                var animalToDelete = context.Animal.Where(x => x.AnimalType == SelectedAnimal.ToString()).First();
                context.Animal.Remove(animalToDelete);
                context.SaveChanges();

                // refresh the page 
                App.AMS_Home.AMS_Frame.Navigate(new UpdateOrDeleteAnimal());
            }
                                                  
        }
        //function to update the textboxes when an animal is selected from the listbox
        public void UpdateTextBoxes()
        {
            
            AmsDbContext context = new AmsDbContext();

            //search database for animal selected in the ListBox.
            var animalInfo = context.Animal.Where(x => x.AnimalType == SelectedAnimal);

            //return the values of the animal to the appropriate textbox
            foreach (var info in animalInfo)
            {
                AnimalType = info.AnimalType;
                AnimalName = info.AnimalName;
                AnimalAge = info.AnimalAge;
                HealthConcerns = info.HealthConcerns;
                FeedingSchedule = info.FeedingSchedule;
            }
        }
    }


}
