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
        public bool manyDays;
        public List<Exercise> exercises = new List<Exercise>();
        public double grade = 0.0;
        public string description = "Brak opisu";
        public List<Tag> tags = new List<Tag>();
        public List<Exercise>[] exercisesD = new List<Exercise>[7];
        public bool[] days = new bool[7];
        public Training(string name, List<Exercise> exercises)
        {
            this.name = name;
            this.exercises = exercises;
            manyDays = false;
        }
        public Training(string name, List<Exercise>[] exercises)
        {
            manyDays = true;
            this.name = name;
            this.exercisesD = exercises;
            for(int i = 0; i < 7; i++)
            {
                if(exercises[i].Count != 0)
                {
                    days[i] = true;
                }
            }
        }
        public override string ToString()
        {
            return name + " ";
        }
    }
}
