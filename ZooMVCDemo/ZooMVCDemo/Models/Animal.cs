﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooMVCDemo.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Species { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }
        public Animal()
        {

        }
    }
}
