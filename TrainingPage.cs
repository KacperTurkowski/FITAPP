using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FITAPP
{
    class TrainingPage : Parentpage
    {
        public override Grid drawComponent(Grid grid)
        {
            //lewa strona
            Label dostepne_treningi = Helper.getLabel("dostepne_treningi", "Dostępne Treningi", 0, 3, 0, 16);
            grid.Children.Add(dostepne_treningi);

            Button dodaj_trening = Helper.getButton("dodaj_trening", "Dodaj Trening", 13, 2, 9, 6);
            grid.Children.Add(dodaj_trening);
            //tutaj listbox

            //prawwa strona

            Label label = Helper.getLabel("moj_aktualny_trening", "Mój aktualny trening",0,3,16,16);
            grid.Children.Add(label);

            Label dzisiejszy_trening = Helper.getLabel("dzisiejszy_trening", "Dzisiejszy trening", 3, 2, 16, 16);
            grid.Children.Add(dzisiejszy_trening);

            Label nastepny_trening = Helper.getLabel("nastepny_trening", "Następny Trening", 5, 2, 16, 16);
            grid.Children.Add(nastepny_trening);

            Label polubione_treningi = Helper.getLabel("polubione_treningi", "Polubione Treningi", 7, 3, 16, 16);
            grid.Children.Add(polubione_treningi);

            return grid;
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
