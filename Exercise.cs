using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITAPP
{
    public class Exercise
    {
        public string name;
        public string description = "opis ćwiczenia";
        public string image;
        public Exercise(string name)
        {
            this.name = name;
            image = @"C:\Users\Kacper\source\repos\FITAPP\photo.png";
        }

        public override string ToString()
        {
            return name;
        }
    }
}
