using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FITAPP
{
    class DietPage : Parentpage
    {
        ListBox polubione_diety_listbox, diety;
        Label dostepne_diety, moja_aktualna_dieta, polubiona_dieta;
        Button dodaj_diete;
        TextBlock dzisiejsza_dieta, nastepna_dieta;
        Grid grid;
        List<Diet> diets;
        TextBox searchDiets;
        public override Grid drawComponent(Grid grid)
        {
            this.grid = grid;
            //lewa strona
            dostepne_diety = Helper.getLabel("dostepne_diety", "Dostępne Diety", 0, 3, 0, 16);
            grid.Children.Add(dostepne_diety);

            dodaj_diete = Helper.getButton("dodaj_diete", "Dodaj Dietę", 15, 2, 9, 6);
            dodaj_diete.Click += Dodaj_Diete_Click;
            grid.Children.Add(dodaj_diete);

            searchDiets = Helper.getTextBox("wyszukaj_diete", "", 3, 2, 1, 14);
            searchDiets.TextChanged += SearchDiet_TextChanged;
            grid.Children.Add(searchDiets);

            diets = DataBase.diets;
            diety = Helper.getListBox(diets, "diets", 5, 9, 1, 14);
            diety.SelectionChanged += Diety_SelectionChanged;
            grid.Children.Add(diety);

            //prawwa strona

            moja_aktualna_dieta = Helper.getLabel("moja_aktualna_dieta", "Moja aktualna dieta", 0, 3, 16, 16);
            grid.Children.Add(moja_aktualna_dieta);

            dzisiejsza_dieta = Helper.getTextBlock("dzisiejsza_dieta", "Dzisiejsza dieta", 3, 2, 16, 16);
            dzisiejsza_dieta.PreviewMouseDown += Dzisiejsza_Dieta_PreviewMouseDown;
            dzisiejsza_dieta.HorizontalAlignment = HorizontalAlignment.Center;
            dzisiejsza_dieta.VerticalAlignment = VerticalAlignment.Center;
            dzisiejsza_dieta.TextDecorations = TextDecorations.Underline;
            grid.Children.Add(dzisiejsza_dieta);

            nastepna_dieta = Helper.getTextBlock("nastepna_dieta", "Następna Dieta", 5, 2, 16, 16);
            nastepna_dieta.PreviewMouseDown += Nastepna_Dieta_PreviewMouseDown;
            nastepna_dieta.HorizontalAlignment = HorizontalAlignment.Center;
            nastepna_dieta.VerticalAlignment = VerticalAlignment.Center;
            nastepna_dieta.TextDecorations = TextDecorations.Underline;
            grid.Children.Add(nastepna_dieta);

            polubiona_dieta = Helper.getLabel("polubione_diety", "Polubione Diety", 7, 3, 16, 16);
            grid.Children.Add(polubiona_dieta);

            polubione_diety_listbox = Helper.getListBox(DataBase.likedDiets, "polubione_diety_listbox", 10, 8, 17, 14);
            polubione_diety_listbox.SelectionChanged += Polubione_diety_listbox_SelectionChanged;
            grid.Children.Add(polubione_diety_listbox);

            return grid;
        }

        private void SearchDiet_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.searchDiets.Text == "")
            {
                diets = DataBase.diets;
                this.diety.Items.Clear();
                foreach (Diet x in diets)
                {
                    this.diety.Items.Add(x);
                }
            }
            else
            {
                diets = DataBase.diets;
                string text = this.searchDiets.Text;
                List<Diet> temp = new List<Diet>();
                //tag
                foreach (Diet x in diets)
                {
                    foreach (Tag tag in x.tags)
                    {
                        if (tag.name.Equals(text))
                        {
                            temp.Add(x);
                        }
                    }
                }
                //text
                foreach (Diet x in diets)
                {
                    if (x.name.Equals(text))
                    {
                        temp.Add(x);
                    }
                }

                this.diety.Items.Clear();
                this.diets = temp;
                foreach (Diet x in temp)
                {
                    this.diety.Items.Add(x);
                }
            }
        }

        private void Nastepna_Dieta_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Diet diet = DataBase.nextDiet;
            Specific_dietPage page = new Specific_dietPage(diet, this);
            grid = page.drawGrid(grid);
            grid = page.drawComponent(grid);
        }

        private void Dzisiejsza_Dieta_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Diet diet = DataBase.todayD;
            Specific_dietPage page = new Specific_dietPage(diet, this);
            grid = page.drawGrid(grid);
            grid = page.drawComponent(grid);
        }

        private void Polubione_diety_listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = polubione_diety_listbox.SelectedIndex;
            Diet diet = DataBase.likedDiets[index];
            Specific_dietPage page = new Specific_dietPage(diet, this);
            grid = page.drawGrid(grid);
            grid = page.drawComponent(grid);
        }

        private void Diety_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = diety.SelectedIndex;
            Diet diet = diets[index];
            Specific_dietPage page = new Specific_dietPage(diet, this);
            grid = page.drawGrid(grid);
            grid = page.drawComponent(grid);
        }

        private void Dodaj_Diete_Click(object sender, RoutedEventArgs e)
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
