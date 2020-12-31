using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FITAPP
{
    class DietPage : Parentpage
    {
        public override Grid drawComponent(Grid grid)
        {
            //lewa strona
            Label title = Helper.getLabel("lista_diet", "Lista Diet:", 0, 3, 1, 16);
            grid.Children.Add(title);

            Button button = Helper.getButton("otworz_diete", "Utwórz Dietę", 15, 2, 9, 6);
            grid.Children.Add(button);

            //tutaj listbox

            //prawa strona
            Label moja_dieta = Helper.getLabel("moja_dieta", "Moja Dieta", 0, 3, 16, 16);
            grid.Children.Add(moja_dieta);

            Label dzisiejsza_dieta = Helper.getLabel("dzisiejsza_dieta", "Dzisiejsza Dieta", 3, 3, 16, 16);
            grid.Children.Add(dzisiejsza_dieta);

            Label polubione_diety = Helper.getLabel("polubione_diety", "Polubione Diety", 6, 3, 16, 16);
            grid.Children.Add(polubione_diety);

            //tutaj listbox
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
