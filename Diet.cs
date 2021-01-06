using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FITAPP
{
    public class Diet
    {
        public string name;//nazwa diety

        public bool manyDays;//czy jest to dieta wielodniowa

        public double grade = 0.0;//ocena diety
        public string description = "Brak opisu";//opis diety

        public List<Tag> tags = new List<Tag>();//tagi

        public List<Dish>[,] dish_list = new List<Dish>[7,6];//listy posiłków
        public List<double>[,] dish_list_amount = new List<double>[7, 6];//ilość
        public List<Dish>[] dish_one_day = new List<Dish>[6];//listy posiłków
        public List<double>[] dish_one_day_amount = new List<double>[6];//ilość 

        public double kcal = 0, protein = 0, fat = 0, carbs = 0;//suma dla całego dnia
        public double[] kcal_one_day = new double[6], protein_one_day = new double[6], fat_one_day = new double[6], carbs_one_day = new double[6];//dla diety jednodniowej poszczególne częsci dni
        public double[] kcal_list_day = new double[7], protein_list_day = new double[7], fat_list_day = new double[7], carbs_list_day = new double[7];//suma kcal itp dla całego dnia
        public double[,] kcal_list = new double[7, 6], protein_list = new double[7, 6], fat_list = new double[7, 6], carbs_list = new double[7,6];//dla diety wielodniowej poszczególne częsci dnia
        public Diet(string name, List<Dish>[] dishes, List<double>[] amount)
        {
            this.name = name;
            this.dish_one_day = dishes;
            this.dish_one_day_amount = amount;
            manyDays = false;
            for(int i = 0; i < 6; i++)
            {
                for(int j=0;j<dish_one_day[i].Count;j++)
                {
                    Dish x = dish_one_day[i][j];
                    double y = dish_one_day_amount[i][j];
                    kcal_one_day[i] += x.kcal * y;
                    protein_one_day[i] += x.protein*y;
                    fat_one_day[i] += x.fat*y;
                    carbs_one_day[i] += x.carbs*y; 
                }
                kcal += kcal_one_day[i];
                protein += protein_one_day[i];
                fat += fat_one_day[i];
                carbs += carbs_one_day[i];
            }
        }
        public Diet(string name, List<Dish>[,] dishes, List<double>[,] amount)
        {
            this.name = name;
            this.dish_list = dishes;
            this.dish_list_amount = amount;
            manyDays = true;
            for(int i = 0; i < 7; i++)
            {
                for(int j = 0; j < 6; j++)
                {
                    for(int k=0; k<dish_list[i,j].Count;k++)
                    {
                        Dish x = dish_list[i, j][k];
                        double y = dish_list_amount[i, j][k];
                        kcal_list[i, j] += x.kcal*y;
                        protein_list[i,j] += x.protein*y;
                        fat_list[i,j] += x.fat*y;
                        carbs_list[i,j] += x.carbs*y;
                    }
                    kcal_list_day[i] += kcal_list[i, j];
                    protein_list_day[i] += protein_list[i, j];
                    fat_list_day[i] += fat_list[i, j];
                    carbs_list_day[i] += carbs_list[i, j];

                    kcal += kcal_list[i,j];
                    protein += protein_list[i,j];
                    fat += fat_list[i,j];
                    carbs += carbs_list[i,j];
                }
            }
        }
        public override string ToString()
        {
            return name +" ";
        }
    }
}
