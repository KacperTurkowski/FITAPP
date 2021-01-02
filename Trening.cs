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
        public double grade = 0.0;
        public string description = "Brak opisu";
        public List<string> tags = new List<string>();
        public Training(string name, List<Exercise> exercises)
        {
            this.name = name;
            this.exercises = exercises;
        }
        public override string ToString()
        {
            return name + " ";
        }
    }
}
