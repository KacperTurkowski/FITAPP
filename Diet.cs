using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITAPP
{
    public class Diet
    {
        public string name;//nazwa diety

        public bool manyDays;//czy jest to dieta wielodniowa

        public double grade = 0.0;//ocena diety
        public string description = "Brak opisu";//opis diety

        public List<Tag> tags = new List<Tag>();//tagi

        public List<Dish>[,] dish_list = new List<Dish>[7,6];
        public List<double>[,] dish_list_amount = new List<double>[7, 6];
        public List<Dish>[] dish_one_day = new List<Dish>[6];//listy posiłków
        public List<double>[] dish_one_day_amount = new List<double>[6];

        public Diet(string name, List<Dish>[] dishes, List<double>[] amount)
        {
            this.name = name;
            this.dish_one_day = dishes;
            this.dish_one_day_amount = amount;
            manyDays = false;
        }
        public Diet(string name, List<Dish>[,] dishes, List<double>[,] amount)
        {
            this.name = name;
            this.dish_list = dishes;
            this.dish_list_amount = amount;
            manyDays = true;
        }
        public override string ToString()
        {
            return name +" ";
        }
    }
}
