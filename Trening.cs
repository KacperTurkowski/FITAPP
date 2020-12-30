using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITAPP
{
    class Training
    {
        public string name;
        public List<Exercise> exercises = new List<Exercise>();
        public Training(string name, List<Exercise> exercises)
        {
            this.name = name;
            this.exercises = exercises;
        }
    }
}
