﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITAPP
{
    class Exercise
    {
        public int amount;
        public string name;
        public string description = "";
        public string image;
        public Exercise(string name, int amount)
        {
            this.name = name;
            this.amount = amount;
            image = @"C:\Users\Kacper\source\repos\FITAPP\photo.png";
        }

        public override string ToString()
        {
            return name+"   "+amount;
        }
    }
}
