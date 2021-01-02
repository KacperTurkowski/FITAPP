using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITAPP
{
    class DataBase
    {
        public static Dictionary<string, string> passwords = new Dictionary<string, string>();//uzytkownicy
        public static Training todayT;//dzisiejszy trening
        public static Diet todayD;//dzisiejsza dieta
        public static List<Exercise> exercises;//lista ćwiczeń
        public static List<Dish> dishes;//lista posiłków
        public static List<Training> trainings;//lista treningów
        public static List<Diet> diets;//lista diet
        public static List<Training> likedTrainings;
        public static List<Diet> likedDiets;
        static DataBase()//taki odpowiednik bloku statycznyego w Javie
        {
            passwords.Add("Kacper", "abc");

            exercises = new List<Exercise>();
            for(int i = 0; i < 50; i++)
            {
                exercises.Add(new Exercise("exercise" + i, i));
            }

            dishes = new List<Dish>();
            for(int i = 0; i < 50; i++)
            {
                dishes.Add(new Dish("dish" + i, i));
            }

            trainings = new List<Training>();
            for(int i=0; i< 50; i++)
            {
                trainings.Add(new Training("training" + i, exercises.GetRange(15, 5)));
            }

            todayT = new Training("Siłowy", exercises.GetRange(5, 10));

            todayD = new Diet("wege", dishes.GetRange(5, 10));

            diets = new List<Diet>();
            for(int i = 0; i < 50; i++)
            {
                diets.Add(new Diet("diet" + i, dishes.GetRange(15, 5)));
            }

            likedTrainings = trainings.GetRange(10, 5);
            likedDiets = diets.GetRange(10, 5);
        }
    }
}
