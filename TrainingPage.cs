using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Image = System.Drawing.Image;

namespace FITAPP
{
    class TrainingPage : Parentpage
    {
        ListBox polubione_treningi_listbox, treningi;
        Grid grid;
        public override Grid drawComponent(Grid grid)
        {
            this.grid = grid;
            //lewa strona
            Label dostepne_treningi = Helper.getLabel("dostepne_treningi", "Dostępne Treningi", 0, 3, 0, 16);
            grid.Children.Add(dostepne_treningi);

            Button dodaj_trening = Helper.getButton("dodaj_trening", "Dodaj Trening", 15, 2, 9, 6);
            dodaj_trening.Click += Dodaj_trening_Click;
            grid.Children.Add(dodaj_trening);

            treningi = Helper.getListBox(DataBase.trainings, "exercises", 5, 9, 1, 15);
            treningi.SelectionChanged += Treningi_SelectionChanged;
            grid.Children.Add(treningi);

            //prawwa strona

            Label label = Helper.getLabel("moj_aktualny_trening", "Mój aktualny trening",0,3,16,16);
            grid.Children.Add(label);

            TextBlock dzisiejszy_trening = Helper.getTextBlock("dzisiejszy_trening", "Dzisiejszy trening", 3, 2, 16, 16);
            dzisiejszy_trening.PreviewMouseDown += Dzisiejszy_trening_PreviewMouseDown;
            dzisiejszy_trening.HorizontalAlignment = HorizontalAlignment.Center;
            dzisiejszy_trening.VerticalAlignment = VerticalAlignment.Center;
            dzisiejszy_trening.TextDecorations = TextDecorations.Underline;
            grid.Children.Add(dzisiejszy_trening);

            TextBlock nastepny_trening = Helper.getTextBlock("nastepny_trening", "Następny Trening", 5, 2, 16, 16);
            nastepny_trening.PreviewMouseDown += Nastepny_trening_PreviewMouseDown;
            nastepny_trening.HorizontalAlignment = HorizontalAlignment.Center;
            nastepny_trening.VerticalAlignment = VerticalAlignment.Center;
            nastepny_trening.TextDecorations = TextDecorations.Underline;
            grid.Children.Add(nastepny_trening);

            Label polubione_treningi = Helper.getLabel("polubione_treningi", "Polubione Treningi", 7, 3, 16, 16);
            grid.Children.Add(polubione_treningi);

            polubione_treningi_listbox= Helper.getListBox(DataBase.likedTrainings, "polubione_trenigni_listbox", 10, 8, 17, 14);
            polubione_treningi_listbox.SelectionChanged += Polubione_treningi_listbox_SelectionChanged;
            grid.Children.Add(polubione_treningi_listbox);

            return grid;
        }

        private void Nastepny_trening_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Training training = DataBase.nextTraining;
            Specific_trainingPage page = new Specific_trainingPage(training);
            grid = page.drawGrid(grid);
            grid = page.drawComponent(grid);
        }

        private void Dzisiejszy_trening_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Training training = DataBase.todayT;
            Specific_trainingPage page = new Specific_trainingPage(training);
            grid = page.drawGrid(grid);
            grid = page.drawComponent(grid);
        }

         private void Polubione_treningi_listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = polubione_treningi_listbox.SelectedIndex;
            Training training = DataBase.likedTrainings[index];
            Specific_trainingPage page = new Specific_trainingPage(training);
            grid = page.drawGrid(grid);
            grid = page.drawComponent(grid);
        }

        private void Treningi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = treningi.SelectedIndex;
            Training training = DataBase.trainings[index];
            Specific_trainingPage page = new Specific_trainingPage(training);
            grid = page.drawGrid(grid);
            grid = page.drawComponent(grid);
        }

        private void Dodaj_trening_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ta akcja nie została obsłużona\n znajdziesz ją w klasie TrainingPage w metodzie \"Dodaj_trening_Click\"");

        }

        public override Grid drawGrid(Grid grid)
        {
            Clear(grid);
            grid.RowDefinitions.Add(new RowDefinition());
            for (int i = 0; i < 32; i++)
            {
                ColumnDefinition column = new ColumnDefinition();

                column.Width = new GridLength(1, GridUnitType.Star);
                grid.ColumnDefinitions.Add(column);
            }
            for (int i = 0; i < 18; i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(1, GridUnitType.Star);
                grid.RowDefinitions.Add(row);
            }
            return grid;
        }
    }
}
