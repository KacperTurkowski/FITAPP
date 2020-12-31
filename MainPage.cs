using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FITAPP
{
    class MainPage: Parentpage
    {
        public override Grid drawComponent(Grid grid)
        {
            //lewa strona
            Label training = Helper.getLabel("dzisiejszy_trening","Dzisiejszy Trening",0,3,0,16);
            grid.Children.Add(training);

            Button button = Helper.getButton("otworz_dzisiejszy_trening", "Otwórz Dzisiejszy Trening", 15, 3, 9, 6);
            grid.Children.Add(button);

            Label trainingName = Helper.getLabel("nazwa_treningu", DataBase.todayT.name,3,3,0,16);
            grid.Children.Add(trainingName);

            ListBox listBox = Helper.getListBox("treningi", 6, 8, 1, 14);
            foreach(Exercise exercise in DataBase.todayT.exercises)
            {
                listBox.Items.Add(exercise.name + "    " + exercise.amount.ToString());
            }
            grid.Children.Add(listBox);
            //prawa strona

            Label diet = Helper.getLabel("dzisiejsza_dieta", "Dzisiejsza Dieta", 0,3,16, 16);
            grid.Children.Add(diet);

            Button button2 = Helper.getButton("otworz_dzisiejsza_diete", "Otwórz Dzisiejszą Dietę", 15, 3, 25, 6);
            grid.Children.Add(button2);

            ListBox listBox2 = Helper.getListBox("diety", 6, 8, 17, 14);
            foreach (Dish dish in DataBase.todayD.dishes)
            {
                listBox2.Items.Add(dish.name + "    " + dish.amount.ToString());
            }
            grid.Children.Add(listBox2);

            return grid;
        }

        public override Grid drawGrid(Grid grid)
        {
            Clear(grid);
            grid.RowDefinitions.Add(new RowDefinition());
            for(int i = 0; i < 32; i++)
            {
                ColumnDefinition column = new ColumnDefinition();
                
                column.Width = new GridLength(1, GridUnitType.Star);
                grid.ColumnDefinitions.Add(column);
            }
            for(int i = 0; i<18; i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(1, GridUnitType.Star);
                grid.RowDefinitions.Add(row);
            }
            return grid;
        }

    }
}
