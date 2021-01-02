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

            Label trainingName = Helper.getLabel("nazwa_treningu", DataBase.todayT.name,3,3,0,16);
            grid.Children.Add(trainingName);

            listBox = Helper.getListBox(DataBase.todayT.exercises,"treningi", 6, 8, 1, 14);
            listBox.SelectionChanged += trening_SelectedIndexChanged;
            grid.Children.Add(listBox);
            //prawa strona

            Label diet = Helper.getLabel("dzisiejsza_dieta", "Dzisiejsza Dieta", 0,3,16, 16);
            grid.Children.Add(diet);

            Button otworz_dzisiejsza_diete = Helper.getButton("otworz_dzisiejsza_diete", "Otwórz Dzisiejszą Dietę", 15, 3, 25, 6);
            otworz_dzisiejsza_diete.Click += Otworz_dzisiejsza_diete_Click;
            grid.Children.Add(otworz_dzisiejsza_diete);

            listBox2 = Helper.getListBox(DataBase.todayD.dishes, "diety", 6, 8, 17, 14);
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
            //MessageBox.Show("Ta akcja nie została obsłużona\n znajdziesz ją w klasie MainPage w metodzie \"trening_SelectedIndexChanged\"");
            int index = listBox.SelectedIndex;
            Exercise exercise = DataBase.todayT.exercises[index];
            Specific_exercisePage page = new Specific_exercisePage(exercise);
            grid = page.drawGrid(grid);
            grid = page.drawComponent(grid);
        }
        private void dieta_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("Ta akcja nie została obsłużona\n znajdziesz ją w klasie MainPage w metodzie \"trening_SelectedIndexChanged\"");
        }
        private void Otworz_dzisiejsza_diete_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ta akcja nie została obsłużona\n znajdziesz ją w klasie MainPage w metodzie \"trening_SelectedIndexChanged\"");
        }
        private void otworz_dzisiejszy_trening_Click(object sender, RoutedEventArgs e)
        {
            Specific_trainingPage page = new Specific_trainingPage(DataBase.todayT);
            this.grid = page.drawGrid(grid);
            this.grid = page.drawComponent(grid);
        }
    }
}
