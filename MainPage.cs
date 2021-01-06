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
        ListBox listBox,listBox2;
        Grid grid;
        public override Grid drawComponent(Grid grid)
        {
            this.grid = grid;
            //lewa strona
            Label training = Helper.getLabel("dzisiejszy_trening","Dzisiejszy Trening",0,3,0,16);
            grid.Children.Add(training);

            Button otworz_dzisiejszy_trening = Helper.getButton("otworz_dzisiejszy_trening", "Otwórz Dzisiejszy Trening", 15, 3, 9, 6);
            otworz_dzisiejszy_trening.Click += otworz_dzisiejszy_trening_Click;
            grid.Children.Add(otworz_dzisiejszy_trening);
            if (DataBase.todayT.exercises.Count != 0)
            {
                Label trainingName = Helper.getLabel("nazwa_treningu", DataBase.todayT.name, 3, 3, 0, 16);
                grid.Children.Add(trainingName);

                listBox = Helper.getListBox(DataBase.todayT.exercises, "treningi", 6, 8, 1, 14);
                listBox.SelectionChanged += trening_SelectedIndexChanged;
                grid.Children.Add(listBox);
            }
            else
            {
                Label trainingName = Helper.getLabel("nazwa_treningu", "Dzisiaj jest dzień bez treningu", 3, 3, 0, 16);
                grid.Children.Add(trainingName);
            }
            //prawa strona

            Label diet = Helper.getLabel("dzisiejsza_dieta", "Dzisiejsza Dieta", 0,3,16, 16);
            grid.Children.Add(diet);

            Button otworz_dzisiejsza_diete = Helper.getButton("otworz_dzisiejsza_diete", "Otwórz Dzisiejszą Dietę", 15, 3, 25, 6);
            otworz_dzisiejsza_diete.Click += Otworz_dzisiejsza_diete_Click;
            grid.Children.Add(otworz_dzisiejsza_diete);

            Label dietName = Helper.getLabel("nazwa_diety", DataBase.todayD.name, 3, 3, 16, 16);
            grid.Children.Add(dietName);


            //Śniadanie
            //IIŚniadanie
            //lunch
            //Obiad
            //Przekąska
            //Kolacja
            List<Dish> dishes = new List<Dish>();
            if (!DataBase.todayD.manyDays)
                for (int i = 0; i < 6; i++)
                    dishes.AddRange(DataBase.todayD.dish_one_day[i]);
            else
                for (int i = 0; i < 6; i++)
                    dishes.AddRange(DataBase.todayD.dish_list[(int)DateTime.Now.DayOfWeek, i]);

            listBox2 = Helper.getListBox(dishes, "diety", 6, 8, 17, 14);
            listBox2.SelectionChanged += dieta_SelectedIndexChanged;
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
        private void trening_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int index = listBox.SelectedIndex;
            Exercise exercise = DataBase.todayT.exercises[index];
            Specific_exercisePage page = new Specific_exercisePage(exercise, this);
            grid = page.drawGrid(grid);
            grid = page.drawComponent(grid);
        }
        private void dieta_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = listBox2.SelectedIndex;
            Dish dish = (Dish)listBox2.Items[index];
            Specific_dishPage page = new Specific_dishPage(dish,this);
            grid = page.drawGrid(grid);
            grid = page.drawComponent(grid);
        }
        private void Otworz_dzisiejsza_diete_Click(object sender, RoutedEventArgs e)
        {
            Specific_dietPage page = new Specific_dietPage(DataBase.todayD, this);
            this.grid = page.drawGrid(grid);
            this.grid = page.drawComponent(grid);
        }
        private void otworz_dzisiejszy_trening_Click(object sender, RoutedEventArgs e)
        {
            Specific_trainingPage page = new Specific_trainingPage(DataBase.todayT,this);
            this.grid = page.drawGrid(grid);
            this.grid = page.drawComponent(grid);
        }
    }
}
