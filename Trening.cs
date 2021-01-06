using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITAPP
{
    public class Training
    {
        public string name;
        public bool manyDays;
        public List<Exercise> exercises = new List<Exercise>();
        public List<int> exerciseAmount = new List<int>();
        public double grade = 0.0;
        public string description = "Brak opisu";
        public List<Tag> tags = new List<Tag>();
        public List<Exercise>[] exercisesD = new List<Exercise>[7];
        public List<int>[] exerciseDAmount = new List<int>[7];
        public bool[] days = new bool[7];
        public Training(string name, List<Exercise> exercises, List<int> exerciseAmount)
        {
            this.name = name;
            this.exercises = exercises;
            this.exerciseAmount = exerciseAmount;
            manyDays = false;
        }
        public Training(string name, List<Exercise>[] exercises, List<int>[] exerciseDAmount)
        {
            manyDays = true;
            this.name = name;
            this.exercisesD = exercises;
            this.exerciseDAmount = exerciseDAmount;
            for(int i = 0; i < 7; i++)
            {
                if (exercises[i].Count != 0)
                {
                    days[i] = true;
                }
                else
                    days[i] = false;
            }
        }
        public override string ToString()
        {
            return name + " ";
        }
    }
}
