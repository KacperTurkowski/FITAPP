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
        public Diet(string name, List<Dish> dishes)
        {
            this.name = name;
            this.dishes = dishes;
        }
        public override string ToString()
        {
            return name +" ";
        }
    }
}
