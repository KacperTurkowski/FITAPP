using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FITAPP
{
    class Helper
    {
        public static Label getlabel(string name, string content, int row, int rowspan, int column, int columnspan)
        {
            Label label = new Label();
            label.Name = name;
            label.Content = content;
            Grid.SetColumn(label, column);
            Grid.SetRow(label, row);
            Grid.SetColumnSpan(label, columnspan);
            label.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            label.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            Grid.SetRowSpan(label, rowspan);

            return label;
        }
    }
}
