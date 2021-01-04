using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FITAPP
{
    class Specific_dietPage : Parentpage
    {
        Diet diet;
        Parentpage parentpage;
        public Specific_dietPage(Diet diet, Parentpage parentpage)
        {
            this.diet = diet;
            this.parentpage = parentpage;
        }
        public override Grid drawComponent(Grid grid)
        {
            Button back = new Helper().getBackButton(grid, parentpage, "back", 0, 2, 0, 2);
            grid.Children.Add(back);

            Label dietTitle = Helper.getLabel(diet.name + "_title", diet.name, 0, 3, 0, 16);
            grid.Children.Add(dietTitle);

            Label lista_diet = Helper.getLabel("lista_diet", "Lista Diet", 3, 2, 0, 16);
            grid.Children.Add(lista_diet);

            //listbox
            //TabControl lista_diet_list = new Helper().GetTabControl(this, grid, diet, "lista-cwiczen_list", 5, 10, 1, 15);
            //grid.Children.Add(lista_diet_list);


            //prawa strona

            Label opis_diety = Helper.getLabel("opis_diety", "Opis Diet", 0, 3, 16, 16);
            grid.Children.Add(opis_diety);

            TextBlock opis = Helper.getTextBlock("opis", diet.description, 3, 6, 17, 14);
            grid.Children.Add(opis);

            Button dodaj_do_ulubionych = Helper.getButton("dodaj_do_ulubionych", "Dodaj do ulubionych", 9, 2, 17, 6);
            dodaj_do_ulubionych.Click += Dodaj_do_ulubionych_Click;
            grid.Children.Add(dodaj_do_ulubionych);

            Button ustaw_jako_aktualna_diete = Helper.getButton("ustaw_jako_aktualna_diete", "Ustaw jako aktualną dietę", 9, 2, 25, 6);
            ustaw_jako_aktualna_diete.Click += Ustaw_jako_aktualna_diete_Click;
            grid.Children.Add(ustaw_jako_aktualna_diete);

            Label ocen_diete = Helper.getLabel("ocen_diety", "Oceń diety", 11, 2, 17, 8);
            grid.Children.Add(ocen_diete);

            //wybierz ocene

            //panel z tagami

            return grid;

        }

        private void Ustaw_jako_aktualna_diete_Click(object sender, RoutedEventArgs e)
        {
            if (diet.manyDays)
            {
                MessageBox.Show("Dla diety wielodniowego operacja nie została obsłużona");
            }
            else
            {
                DataBase.todayD = diet;
                MessageBox.Show("Ustawiono " + diet.name + " jako aktualną dietę");
            }
        }

        private void Dodaj_do_ulubionych_Click(object sender, RoutedEventArgs e)
        {
            DataBase.likedDiets.Add(diet);
            MessageBox.Show("Dieta została dodana od ulubionych");
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
