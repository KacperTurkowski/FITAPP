using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace FITAPP
{
    class Specific_dishPage : Parentpage
    {
        Grid grid;
        Parentpage parent;
        Dish dish;
        public Specific_dishPage(Dish dish, Parentpage parent)
        {
            this.dish = dish;
            this.parent = parent;
        }
        public override Grid drawComponent(Grid grid)
        {
            this.grid = grid;
            Button back = new Helper().getBackButton(grid, parent, "back", 0, 2, 0, 2);
            grid.Children.Add(back);

            Label tytul = Helper.getLabel("tytul", dish.name, 0, 3, 0, 32);
            grid.Children.Add(tytul);

            Label skladniki = Helper.getLabel("skladniki", "Składniki", 3, 2, 0, 16);
            grid.Children.Add(skladniki);

            TextBlock skladniki_list = Helper.getTextBlock("skladniki_list", dish.ingredients, 5, 4, 1, 14);
            grid.Children.Add(skladniki_list);

            Label przepis_label = Helper.getLabel("przepis_label", "Przepis", 10, 2, 1, 14);
            grid.Children.Add(przepis_label);

            TextBlock przepis = Helper.getTextBlock("przepis",dish.recipe,13,4,1,14);
            grid.Children.Add(przepis);

            Image image = new Image();
            BitmapImage bit = new BitmapImage();
            bit.BeginInit();
            bit.UriSource = new Uri(dish.image);
            bit.EndInit();
            image.Source = bit;

            Grid.SetColumn(image, 17);
            Grid.SetRow(image, 2);
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
