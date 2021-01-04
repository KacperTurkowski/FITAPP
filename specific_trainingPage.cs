using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FITAPP
{
    class Specific_trainingPage : Parentpage
    {
        Slider grade;
        Label ocen_trening;
        Training training;
        Button zapisz_ocene;
        Parentpage parentpage;
        public Specific_trainingPage(Training training, Parentpage parentpage)
        {
            this.training = training;
            this.parentpage = parentpage;
        }
        public override Grid drawComponent(Grid grid)
        {
            Button back = new Helper().getBackButton(grid, parentpage, "back", 0, 2, 0, 2);
            grid.Children.Add(back);

            Label trainingTitle = Helper.getLabel(training.name + "_title", training.name, 0, 3, 0, 16);
            grid.Children.Add(trainingTitle);

            Label lista_cwiczen = Helper.getLabel("lista_cwiczen", "Lista Ćwiczeń", 3, 2, 0, 16);
            grid.Children.Add(lista_cwiczen);

            //listbox
            TabControl lista_cwiczen_list = new Helper().GetTabControl_T(this,grid,training, "lista-cwiczen_list", 5, 10, 1, 15);
            grid.Children.Add(lista_cwiczen_list);


            //prawa strona

            Label opis_treningu = Helper.getLabel("opis_treningu", "Opis Treningu", 0, 3, 16, 16);
            grid.Children.Add(opis_treningu);

            ScrollViewer opis = Helper.getTextBlock("opis", training.description, 3, 6, 17, 14);
            grid.Children.Add(opis);

            Button dodaj_do_ulubionych = Helper.getButton("dodaj_do_ulubionych", "Dodaj do ulubionych", 9, 2, 17, 6);
            dodaj_do_ulubionych.Click += Dodaj_do_ulubionych_Click;
            grid.Children.Add(dodaj_do_ulubionych);

            Button ustaw_jako_aktualny_trening = Helper.getButton("ustaw_jako_aktualny_trening", "Ustaw jako aktualny trening", 9, 2, 25, 6);
            ustaw_jako_aktualny_trening.Click += Ustaw_jako_aktualny_trening_Click;
            grid.Children.Add(ustaw_jako_aktualny_trening);

            ocen_trening = Helper.getLabel("ocen_diety", "Oceń dietę: ", 11, 2, 16, 5);
            grid.Children.Add(ocen_trening);

            grade = Helper.getSlider("ocen_diete", 11, 2, 21, 6);

            grade.ValueChanged += Grade_ValueChanged;
            grid.Children.Add(grade);

            zapisz_ocene = Helper.getButton("zapisz_ocene", "Oceń na _", 11, 2, 27, 4);
            zapisz_ocene.Click += Zapisz_ocene_Click;
            grid.Children.Add(zapisz_ocene);


            if (training.grade != 0)
            {
                grade.Value = training.grade;
                zapisz_ocene.Content = "Oceń na " + training.grade;
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
            int count = training.tags.Count;
            foreach (Tag tag in training.tags)
            {
                Label label = new Label();
                label.Content = tag.name;
                label.Background = Brushes.Gray;
                label.Margin = new Thickness(5);
                list.Children.Add(label);
            }
            SV.Content = list;
            grid.Children.Add(SV);

            return grid;

        }

        private void Zapisz_ocene_Click(object sender, RoutedEventArgs e)
        {
            if (grade.Value != 0)
            {
                training.grade = grade.Value;
                MessageBox.Show("Dieta " + training.name + " została oceniona na " + grade.Value);
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

        private void Ustaw_jako_aktualny_trening_Click(object sender, RoutedEventArgs e)
        {
            if (training.manyDays)
            {
                SetAsCurrentTraining window = new SetAsCurrentTraining(training);
                window.Show();
                
            }
            else
            {
                DataBase.todayT = training;
                MessageBox.Show("Ustawiono " + training.name + " jako aktualny trening");
            }
        }

        private void Dodaj_do_ulubionych_Click(object sender, RoutedEventArgs e)
        {
            DataBase.likedTrainings.Add(training);
            MessageBox.Show("Trening został dodany od ulubionych");
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
