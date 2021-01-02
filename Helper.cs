using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Dynamic;
using System.Windows;
using System.Windows.Data;

namespace FITAPP
{
    class Helper
    {
        public static Label getLabel(string name, string content, int row, int rowspan, int column, int columnspan)
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
        public static Button getButton(string name, string content, int row, int rowspan, int column, int columnspan)
        {
            Button button = new Button();
            button.Name = name;
            button.Content = content;
            Grid.SetColumn(button, column);
            Grid.SetRow(button, row);
            Grid.SetColumnSpan(button, columnspan);
            button.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            button.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            Grid.SetRowSpan(button, rowspan);

            return button;
        }
        public static TextBox getTextBox(string name, string content, int row, int rowspan, int column, int columnspan)
        {
            TextBox textbox = new TextBox();
            textbox.Foreground = Brushes.Gray;
            textbox.Text = content;
            textbox.Name = name;
            Grid.SetRow(textbox, row);
            Grid.SetColumn(textbox, column);
            Grid.SetColumnSpan(textbox, columnspan);
            Grid.SetRowSpan(textbox, rowspan);

            return textbox;
        }
        public static ListBox getListBox<T>(List<T> data, string name, int row, int rowspan, int column, int columnspan)
        {
            ListBox listbox = new ListBox();            
            foreach(T x in data)
            {
                listbox.Items.Add(x.ToString());
            }
            listbox.Name = name;
            Grid.SetColumn(listbox, column);
            Grid.SetRow(listbox, row);
            Grid.SetColumnSpan(listbox, columnspan);
            Grid.SetRowSpan(listbox, rowspan);
            return listbox;
        }
        public static TextBlock getTextBlock(string name, string content, int row, int rowspan, int column, int columnspan)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Name = name;
            textBlock.Text = content;
            Grid.SetColumn(textBlock, column);
            Grid.SetRow(textBlock, row);
            Grid.SetColumnSpan(textBlock, columnspan);
            Grid.SetRowSpan(textBlock, rowspan);
            return textBlock;
        }
    }
}
