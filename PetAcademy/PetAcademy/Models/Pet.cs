using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetAcademy.Models
{
    public class Pet
    {

        // Properties
        public string Name { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public string History { get; set; }
        public string Image { get; set; }

        public Pet(string name, string species, string breed, string history, string image)
        {
            Name = name;
            Species = species;
            Breed = breed;
            History = history;
            Image = image;
        }
    }
}