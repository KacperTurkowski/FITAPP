using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FITAPP
{
    public abstract class Parentpage
    {
        public abstract Grid drawGrid(Grid grid);
        public abstract Grid drawComponent(Grid grid);
        public void Clear(Grid grid)
        {
            grid.Children.Clear();
            grid.ColumnDefinitions.Clear();
            grid.RowDefinitions.Clear();
        }
    }
}
