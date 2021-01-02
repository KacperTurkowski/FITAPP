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

            Button otworz_diete = Helper.getButton("otworz_diete", "Utwórz Dietę", 15, 2, 9, 6);
            otworz_diete.Click += Otworz_diete_Click;
            grid.Children.Add(otworz_diete);

            TextBox wyszukaj_diete = Helper.getTextBox("wyszukaj_diete","Wyszukaj Dietę",3,2,1,15);
            wyszukaj_diete.TextChanged += Wyszukaj_diete_TextChanged;
            grid.Children.Add(wyszukaj_diete);

            ListBox diety = Helper.getListBox(DataBase.dishes,"diety", 5, 9, 1, 15);
            diety.SelectionChanged += Diety_SelectionChanged;
            grid.Children.Add(diety);

            //koniec
            //prawa strona
            Label moja_dieta = Helper.getLabel("moja_dieta", "Moja Dieta", 0, 3, 16, 16);
            grid.Children.Add(moja_dieta);

            Label dzisiejsza_dieta = Helper.getLabel("dzisiejsza_dieta", "Dzisiejsza Dieta", 3, 3, 16, 16);
            grid.Children.Add(dzisiejsza_dieta);

            Label polubione_diety = Helper.getLabel("polubione_diety", "Polubione Diety", 6, 3, 16, 16);
            grid.Children.Add(polubione_diety);

            ListBox polubione_diety_listbox = Helper.getListBox(DataBase.dishes, "polubione_diety", 9, 8, 17, 15);
            polubione_diety_listbox.SelectionChanged += Polubione_diety_listbox_SelectionChanged;
            grid.Children.Add(polubione_diety_listbox);


            return grid;
        }

        private void Polubione_diety_listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("Ta akcja nie została obsłużona\n znajdziesz ją w klasie DietPage w metodzie \" Polubione_diety_listbox_SelectionChanged\"");
        }

        private void Diety_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("Ta akcja nie została obsłużona\n znajdziesz ją w klasie DietPage w metodzie \" Diety_SelectionChanged\"");
        }

        private void Wyszukaj_diete_TextChanged(object sender, TextChangedEventArgs e)
        {
            MessageBox.Show("Ta akcja nie została obsłużona\n znajdziesz ją w klasie DietPage w metodzie \" Wyszukaj_diete_TextChanged\"");
        }

        private void Otworz_diete_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ta akcja nie została obsłużona\n znajdziesz ją w klasie DietPage w metodzie \" Otworz_diete_click\"");
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
