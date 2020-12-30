using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FITAPP
{
    class MainPage: Parentpage
    {
        public Grid drawComponent(Grid grid)
        {
            Label training = Helper.getlabel("dzisiejszy_trening","Dzisiejszy Trening",0,3,0,16);
            grid.Children.Add(training);
            return grid;
        }

        public Grid drawGrid(Grid grid)
        {
            grid.RowDefinitions.Add(new RowDefinition());
            for(int i = 0; i < 32; i++)
            {
                ColumnDefinition column = new ColumnDefinition();
                
                column.Width = new GridLength(1, GridUnitType.Star);
                grid.ColumnDefinitions.Add(column);
            }
            for(int i = 0; i<32; i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(1, GridUnitType.Star);
                grid.RowDefinitions.Add(row);
            }
            return grid;
        }

    }
}
