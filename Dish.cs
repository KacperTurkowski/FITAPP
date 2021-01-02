using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITAPP
{
    class Dish
    {
        public int amount;
        public string name;
        public string recipe = "";
        public string image;
        public string ingredients = "";
        public Dish(string name, int amount)
        {
            this.name = name;
            this.amount = amount;
            image = @"C:\Users\Kacper\source\repos\FITAPP\photo.png";
        }

        public override string ToString()
        {
            return name + "   " + amount;
        }
    }
}
