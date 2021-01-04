using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITAPP
{
    class Diet
    {
        public string name;
        public List<Dish> dishes;
        public bool manyDays;
        public double grade = 0.0;
        public string description = "Brak opisu";
        public List<Diet>[] dishD = new List<Diet>[7];
        public List<Tag> tags = new List<Tag>();
        public Diet(string name, List<Dish> dishes)
        {
            this.name = name;
            this.dishes = dishes;
            manyDays = false;
        }
        public Diet(string name, List<Diet>[] dish)
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
