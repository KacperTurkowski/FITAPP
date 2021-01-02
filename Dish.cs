using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITAPP
{
    class Dish
    {
        public string name;
        public int amount;
        public Dish(string name, int amount)
        {
            this.name = name;
            this.amount = amount;
        }
        public override string ToString()
        {
            return name + "   " + amount;
        }
    }
}
