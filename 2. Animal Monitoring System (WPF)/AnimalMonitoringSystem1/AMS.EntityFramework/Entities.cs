using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.EntityFramework
{
                                   
    public class Animal
    {

        public long AnimalID { get; set; }

        public string AnimalType { get; set; }

        public string AnimalName { get; set; }
        public string AnimalAge { get; set; }
        public string HealthConcerns { get; set; }
        public string FeedingSchedule { get; set; }
    }


    public class Habitat
    {
        public long HabitatID { get; set; }

        public string HabitatType { get; set; }

        public string Temperature { get; set; }
        public string FoodSource { get; set; }
        public string Cleanliness { get; set; }
    }

    [Table("UserCredentials")]
    public class UserCredentials
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserID { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserPassword { get; set; }
    }
}
