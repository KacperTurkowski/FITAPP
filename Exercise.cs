using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITAPP
{
    class Exercise
    {
        public int amount;
        public string name;
        public Exercise(string name, int amount)
        {
            this.name = name;
            this.amount = amount;
        }
        public override string ToString()
        {
            return name+"   "+amount;
        }
    }
}
