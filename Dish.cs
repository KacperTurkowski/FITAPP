using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITAPP
{
    public class Dish
    {
        public string name;
        public string recipe = "";
        public string image;
        public string ingredients = "";
        public double kcal, protein, fat, carbs;

        public Dish(string name)
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
