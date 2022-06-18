using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.EntityFramework
{
                                               
    public static class AMSDbContextSeeder
    {
        public static void Seed(AmsDbContext context)
        {
            context.Animal.Add(new Animal
            {
                AnimalID = 1,
                AnimalType = "Lion",
                AnimalName = "Leo",
                AnimalAge = "5",
                HealthConcerns = "Cut on left front paw",
                FeedingSchedule = "Twice Daily"
            });

            context.Animal.Add(new Animal
            {
                AnimalID = 2,
                AnimalType = "Tiger",
                AnimalName = "Maj",
                AnimalAge = "15",
                HealthConcerns = "None",
                FeedingSchedule = "3x daily"
            });

            context.Animal.Add(new Animal
            {
                AnimalID = 3,
                AnimalType = "Bear",
                AnimalName = "Baloo",
                AnimalAge = "1",
                HealthConcerns = "None",
                FeedingSchedule = "None on record"
            });

            context.Animal.Add(new Animal
            {
                AnimalID = 4,
                AnimalType = "Giraffe",
                AnimalName = "Spots",
                AnimalAge = "12",
                HealthConcerns = "None",
                FeedingSchedule = "Grazing"
            });

            context.Habitat.Add(new Habitat
            {
                HabitatID = 1,
                HabitatType = "Penguin",
                Temperature = "Freezing",
                FoodSource = "Fish in water running low",
                Cleanliness = "Passed"
            });

            context.Habitat.Add(new Habitat
            {
                HabitatID = 2,
                HabitatType = "Bird",
                Temperature = "Moderate",
                FoodSource = "Natural from environment",
                Cleanliness = "Passed"
            });

            context.Habitat.Add(new Habitat
            {
                HabitatID = 3,
                HabitatType = "Aquarium",
                Temperature = "Varies with output temperature",
                FoodSource = "Added daily",
                Cleanliness = "Needs cleaning from algae"
            });
            

            context.SaveChanges();
        }

    }
}
