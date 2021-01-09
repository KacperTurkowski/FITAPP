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
    public class TrainingPage : Parentpage
    {
        ListBox polubione_treningi_listbox, treningi;
        Label dostepne_treningi, moj_aktualny_trening, polubione_treningi;
        Button dodaj_trening;
        ScrollViewer dzisiejszy_trening, nastepny_trening;
        public Grid grid;
        List<Training> trainings;
        TextBox searchTraining;
        public override Grid drawComponent(Grid grid)
        {
            this.grid = grid;
            //lewa strona
            dostepne_treningi = Helper.getLabel("dostepne_treningi", "Dostępne Treningi", 0, 3, 0, 16);
            dostepne_treningi.FontSize = 25;
            grid.Children.Add(dostepne_treningi);

            dodaj_trening = Helper.getButton("dodaj_trening", "Dodaj Trening", 15, 2, 9, 6);
            dodaj_trening.FontSize = 20;
            dodaj_trening.Click += Dodaj_trening_Click;
            grid.Children.Add(dodaj_trening);

            searchTraining = Helper.getTextBox("wyszukaj_trening", "Wyszukaj", 3, 2, 1, 14);
            searchTraining.TextChanged += SearchTraining_TextChanged;
            searchTraining.PreviewMouseDown += SearchTraining_PreviewMouseDown;
            searchTraining.FontSize = 18;
            searchTraining.HorizontalContentAlignment = HorizontalAlignment.Center;
            searchTraining.VerticalContentAlignment = VerticalAlignment.Center;
            grid.Children.Add(searchTraining);

            String temp = String.Format("{0,-40} {1,10}", "Nazwa Treningu", "Śr. Ocen");
            Label label = Helper.getLabel("objasnienie", temp, 5, 2, 1, 14);
            label.HorizontalContentAlignment = HorizontalAlignment.Center;
            label.FontSize = 15;
            label.VerticalAlignment = VerticalAlignment.Bottom;
            label.FontFamily = new System.Windows.Media.FontFamily("Consolas");
            grid.Children.Add(label);

            trainings = DataBase.trainings;
            treningi = Helper.getListBox(trainings, "exercises", 7, 7, 1, 14);
            treningi.SelectionChanged += Treningi_SelectionChanged;
            treningi.FontSize = 15;
            treningi.FontFamily = new System.Windows.Media.FontFamily("Consolas");
            grid.Children.Add(treningi);

            //prawwa strona

            moj_aktualny_trening = Helper.getLabel("moj_aktualny_trening", "Mój aktualny trening",0,3,16,16);
            moj_aktualny_trening.FontSize = 25;
            grid.Children.Add(moj_aktualny_trening);

            dzisiejszy_trening = Helper.getTextBlock("dzisiejszy_trening", "Dzisiejszy trening", 3, 2, 16, 16);
            dzisiejszy_trening.PreviewMouseDown += Dzisiejszy_trening_PreviewMouseDown;
            dzisiejszy_trening.HorizontalAlignment = HorizontalAlignment.Center;
            dzisiejszy_trening.VerticalAlignment = VerticalAlignment.Center;
            dzisiejszy_trening.FontSize = 20;
            TextBlock tb = (TextBlock)dzisiejszy_trening.Content;
            tb.TextDecorations = TextDecorations.Underline;
            grid.Children.Add(dzisiejszy_trening);

            nastepny_trening = Helper.getTextBlock("nastepny_trening", "Następny Trening", 5, 2, 16, 16);
            nastepny_trening.PreviewMouseDown += Nastepny_trening_PreviewMouseDown;
            nastepny_trening.HorizontalAlignment = HorizontalAlignment.Center;
            nastepny_trening.FontSize = 20;
            nastepny_trening.VerticalAlignment = VerticalAlignment.Center;
            TextBlock tb1 = (TextBlock)nastepny_trening.Content;
            tb1.TextDecorations = TextDecorations.Underline;
            grid.Children.Add(nastepny_trening);

            polubione_treningi = Helper.getLabel("polubione_treningi", "Polubione Treningi", 7, 3, 16, 16);
            polubione_treningi.FontSize = 25;
            grid.Children.Add(polubione_treningi);

            Label label2 = Helper.getLabel("objasnienie", temp, 10, 2, 17, 14);
            label2.HorizontalContentAlignment = HorizontalAlignment.Center;
            label2.FontSize = 15;
            label2.VerticalAlignment = VerticalAlignment.Bottom;
            label2.FontFamily = new System.Windows.Media.FontFamily("Consolas");
            grid.Children.Add(label2);

            polubione_treningi_listbox = Helper.getListBox(DataBase.likedTrainings, "polubione_trenigni_listbox", 12,5 , 17, 14);
            polubione_treningi_listbox.SelectionChanged += Polubione_treningi_listbox_SelectionChanged;
            polubione_treningi_listbox.Margin = new Thickness(0, 0, 0, 3);
            polubione_treningi_listbox.FontSize = 15;
            polubione_treningi_listbox.FontFamily = new System.Windows.Media.FontFamily("Consolas");
            grid.Children.Add(polubione_treningi_listbox);

            return grid;
        }

        private void SearchTraining_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = "";
        }

        private void SearchTraining_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(this.searchTraining.Text == "")
            {
                trainings = DataBase.trainings;
                this.treningi.Items.Clear();
                foreach (Training x in trainings)
                {
                    this.treningi.Items.Add(x);
                }
            }
            else
            {
                trainings = DataBase.trainings;
                string text = this.searchTraining.Text;
                List<Training> temp = new List<Training>();
                //tag
                foreach (Training x in trainings)
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
                foreach (Training x in trainings)
                {
                    if (x.name.Contains(text))
                    {
                        temp.Add(x);
                    }
                }

                this.treningi.Items.Clear();
                this.trainings = temp;
                foreach(Training x in temp)
                {
                    this.treningi.Items.Add(x);
                }
            }
        }

        private void Nastepny_trening_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Training training = DataBase.nextTraining;
            Specific_trainingPage page = new Specific_trainingPage(training,this);
            grid = page.drawGrid(grid);
            grid = page.drawComponent(grid);
        }

        private void Dzisiejszy_trening_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Training training = DataBase.todayT;
            Specific_trainingPage page = new Specific_trainingPage(training,this);
            grid = page.drawGrid(grid);
            grid = page.drawComponent(grid);
        }

        private void Polubione_treningi_listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = polubione_treningi_listbox.SelectedIndex;
            Training training = DataBase.likedTrainings[index];
            Specific_trainingPage page = new Specific_trainingPage(training,this);
            grid = page.drawGrid(grid);
            grid = page.drawComponent(grid);
        }

        private void Treningi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = treningi.SelectedIndex;
            Training training = trainings[index];
            Specific_trainingPage page = new Specific_trainingPage(training,this);
            grid = page.drawGrid(grid);
            grid = page.drawComponent(grid);
        }

        private void Dodaj_trening_Click(object sender, RoutedEventArgs e)
        {
            AddNewTraining window = new AddNewTraining(this);
            window.Show();
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
