using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace FITAPP
{
    class Specific_exercisePage : Parentpage
    {
        Exercise exercise;
        Parentpage parentpage;
        public Specific_exercisePage(Exercise exercise, Parentpage parentpage)
        {
            this.parentpage = parentpage;
            this.exercise = exercise;
        }
        public override Grid drawComponent(Grid grid)
        {
            Button back = new Helper().getBackButton(grid, parentpage, "back", 0, 2, 0, 2);
            grid.Children.Add(back);

            Label tytul = Helper.getLabel("tytul",exercise.name,0,3,0,16);
            grid.Children.Add(tytul);

            Label opis_cwiczenia = Helper.getLabel("opis_cwiczenia","Opis Ćwiczenia",3,2,0,16);
            grid.Children.Add(opis_cwiczenia);

            ScrollViewer opis = Helper.getTextBlock("opis", exercise.description, 6, 11, 1, 14);
            grid.Children.Add(opis);

            Image image = new Image();
            BitmapImage bit = new BitmapImage();
            bit.BeginInit();
            bit.UriSource = new Uri(exercise.image);
            bit.EndInit();
            image.Source = bit;

            Grid.SetColumn(image,17);
            Grid.SetRow(image, 1);
            Grid.SetColumnSpan(image, 14);
            Grid.SetRowSpan(image, 17);
            grid.Children.Add(image);

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
