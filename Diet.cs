using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITAPP
{
    public class Diet
    {
        public string name;
        public List<Dish> dishes;
        public bool manyDays;
        public double grade = 0.0;
        public string description = "Brak opisu";
        public List<Dish>[] dishD = new List<Dish>[7];
        public List<Tag> tags = new List<Tag>();
        public Diet(string name, List<Dish> dishes)
        {
            this.name = name;
            this.dishes = dishes;
            manyDays = false;
        }
        public Diet(string name, List<Dish>[] dish)
        {
            manyDays = true;
            this.name = name;
            this.dishD = dish;
        }
        public override string ToString()
        {
            return name +" ";
        }
    }
}
