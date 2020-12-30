using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITAPP
{
    class DataBase
    {
        public static Dictionary<string, string> passwords = new Dictionary<string, string>();
        public static Training todayT;
        public static Diet todayD;
        public static List<Exercise> exercises;
        public static List<Dish> dishes;
        static DataBase()//taki odpowiednik bloku statycznyego w Javie
        {
            passwords.Add("Kacper", "abc");

            exercises = new List<Exercise>();
            exercises.Add(new Exercise("przysiady", 100));
            exercises.Add(new Exercise("pompki", 20));
            for(int i = 0; i < 50; i++)
            {
                exercises.Add(new Exercise("ex" + i, i));
            }
            todayT = new Training("Siłowy", exercises);

            dishes = new List<Dish>();
            for(int i = 0; i < 50; i++)
            {
                dishes.Add(new Dish("dish" + i, i));
            }
            todayD = new Diet("wege", dishes);
        }
    }
}
