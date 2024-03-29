﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FITAPP
{
    class Specific_dietPage : Parentpage
    {
        Diet diet;
        Parentpage parentpage;
        Label ocen_diete;
        Slider grade;
        Grid grid;
        Button zapisz_ocene;
        public Specific_dietPage(Diet diet, Parentpage parentpage)
        {
            this.diet = diet;
            this.parentpage = parentpage;
        }
        public override Grid drawComponent(Grid grid)
        {
            this.grid = grid;
            Button back = new Helper().getBackButton(grid, parentpage, "back", 0, 2, 0, 2);
            grid.Children.Add(back);

            Label dietTitle = Helper.getLabel("_title", diet.name, 0, 3, 2, 30);
            dietTitle.FontSize = 30;
            grid.Children.Add(dietTitle);

            Label lista_diet = Helper.getLabel("lista_diet", "Lista Posiłków", 3, 2, 0, 16);
            lista_diet.FontSize = 25;
            grid.Children.Add(lista_diet);

            //listbox
            TabControl lista_diet_list = new Helper().GetTabControl_D(this, grid, diet, "lista-cwiczen_list", 5, 11, 1, 15);
            grid.Children.Add(lista_diet_list);

            Button szczegoly = Helper.getButton("szczegoly_diety", "Zobacz szczegóły diety", 16, 2, 1, 15);
            szczegoly.Click += Szczegoly_Click;
            szczegoly.FontSize = 18;
            szczegoly.Margin = new Thickness(5, 5, 5, 5);
            grid.Children.Add(szczegoly);

            //prawa strona

            Label opis_diety = Helper.getLabel("opis_diety", "Opis Diet", 3, 3, 16, 16);
            opis_diety.FontSize = 25;
            grid.Children.Add(opis_diety);

            ScrollViewer opis = Helper.getTextBlock("opis", diet.description, 6, 3, 17, 14);
            opis.FontSize = 16;
            grid.Children.Add(opis);

            Button dodaj_do_ulubionych = Helper.getButton("dodaj_do_ulubionych", "  Dodaj do\n ulubionych", 9, 2, 17, 6);
            if (DataBase.likedDiets.Contains(diet))
            {
                dodaj_do_ulubionych.Content = "  Usuń z \n ulubionych";
            }
            dodaj_do_ulubionych.FontSize = 16;
            dodaj_do_ulubionych.Click += Dodaj_do_ulubionych_Click;
            grid.Children.Add(dodaj_do_ulubionych);

            Button ustaw_jako_aktualna_diete = Helper.getButton("ustaw_jako_aktualna_diete", "   Ustaw jako\n aktualną dietę", 9, 2, 25, 6);
            ustaw_jako_aktualna_diete.Click += Ustaw_jako_aktualna_diete_Click;
            ustaw_jako_aktualna_diete.FontSize = 16;
            grid.Children.Add(ustaw_jako_aktualna_diete);

            ocen_diete = Helper.getLabel("ocen_diety", "Oceń dietę: ", 11, 2, 16, 5);
            ocen_diete.FontSize = 18;
            grid.Children.Add(ocen_diete);

            //wybierz ocene
            grade = Helper.getSlider("ocen_diete", 11, 2, 21, 6);

            grade.ValueChanged += Grade_ValueChanged;
            grid.Children.Add(grade);

            zapisz_ocene = Helper.getButton("zapisz_ocene", "Oceń na _", 11,2,27,4);
            zapisz_ocene.Click += Zapisz_ocene_Click;
            zapisz_ocene.Margin = new Thickness(0,2,0,2);
            zapisz_ocene.FontSize = 18;
            grid.Children.Add(zapisz_ocene);


            if (diet.grade != 0)
            {
                grade.Value = diet.grade;
                zapisz_ocene.Content = "Oceń na " + diet.grade;
            }

            //panel z tagami
            ScrollViewer SV = new ScrollViewer();
            SV.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            SV.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            Grid.SetRow(SV, 14);
            Grid.SetColumn(SV, 17);
            Grid.SetRowSpan(SV, 5);
            Grid.SetColumnSpan(SV, 14);

            WrapPanel list = new WrapPanel();
            
                        
            list.Orientation = Orientation.Horizontal;
            list.HorizontalAlignment = HorizontalAlignment.Left;
            list.VerticalAlignment = VerticalAlignment.Top;
            
            //ilość rzędów tagów
            int count = diet.tags.Count;
            foreach(Tag tag in diet.tags)
            {
                Label label = new Label();
                label.FontSize = 17;
                label.Content = tag.name;
                label.Background = Brushes.Gray;
                label.Margin = new Thickness(5);
                list.Children.Add(label);
            }
            SV.Content = list;
            grid.Children.Add(SV);

            return grid;

        }

        private void Szczegoly_Click(object sender, RoutedEventArgs e)
        {
            DetailsDiet page = new DetailsDiet(diet, this);
            grid = page.drawGrid(grid);
            grid = page.drawComponent(grid);
        }

        private void Zapisz_ocene_Click(object sender, RoutedEventArgs e)
        {
            if(grade.Value != 0)
            {
                diet.grade = grade.Value;
                MessageBox.Show("Dieta " + diet.name + " została oceniona na " + grade.Value,"Informacja",MessageBoxButton.OK,MessageBoxImage.Information);
            }
        }

        private void Grade_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //zapisywanie oceny
            if (grade.Value != 0)
                zapisz_ocene.Content = "Oceń na " + grade.Value;
            else
                zapisz_ocene.Content = "Oceń na _";
        }

        private void Ustaw_jako_aktualna_diete_Click(object sender, RoutedEventArgs e)
        {
            DataBase.todayD = diet;
            MessageBox.Show("Ustawiono " + diet.name + " jako aktualną dietę","Informacja",MessageBoxButton.OK,MessageBoxImage.Information);
        }

        private void Dodaj_do_ulubionych_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (!DataBase.likedDiets.Contains(diet))
            {
                DataBase.likedDiets.Add(diet);
                button.Content = "  Usuń z \n ulubionych";
                MessageBox.Show("Dieta została dodana od ulubionych","Informacja",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            else
            {
                DataBase.likedDiets.Remove(diet);
                button.Content = "  Dodaj do\n ulubionych";
                MessageBox.Show("Dieta została usunięta z ulubionych", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public override Grid drawGrid(Grid grid)
        {
            Clear(grid);
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
