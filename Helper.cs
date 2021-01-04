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
using System.Windows.Media.Imaging;

namespace FITAPP
{
    class Helper
    {
        Grid grid;
        Parentpage page;
        int temp;
        Diet diet;
        ListBox list;
        ListBox[] days = new ListBox[7];
        Training training;
        string[] daysString = { "Poniedziałek", "Wtorek", "Środa", "Czwartek", "Piątek", "Sobota", "Niedziela" };
        TabControl tab;
        public Button getBackButton(Grid grid, Parentpage page, string name, int row, int rowspan, int column, int columnspan)
        {
            Button button = new Button();
            button.Name = name;
            Grid.SetColumn(button, column);
            Grid.SetRow(button, row);
            Grid.SetColumnSpan(button, columnspan);
            Grid.SetRowSpan(button, rowspan);
            button.Click += Button_Click;
            button.Content = new Image
            {
                Source = new BitmapImage(new Uri(@"C:\Users\Kacper\source\repos\FITAPP\back.png")),
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch
            };
            this.grid = grid;
            this.page = page;
            return button;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            grid = page.drawGrid(grid);
            grid = page.drawComponent(grid);
        }
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
        public TabControl GetTabControl_T(Parentpage page, Grid grid, Training training, string name, int row, int rowspan, int column, int columnspan)
        {
            this.grid = grid;
            this.page = page;
            tab = new TabControl();
            Grid.SetColumn(tab, column);
            Grid.SetRow(tab, row);
            Grid.SetColumnSpan(tab, columnspan);
            Grid.SetRowSpan(tab, rowspan);
            this.training = training;
            if (training.manyDays)
            {
                for(int i = 0; i < 7; i++)
                {
                    if (training.days[i])
                    {
                        TabItem item = new TabItem();
                        item.Header = daysString[i];
                        this.days[i] = new ListBox();

                        this.days[i].SelectionChanged += Helper_SelectionChanged;
                        foreach (Exercise x in training.exercisesD[i])
                            this.days[i].Items.Add(x);
                        item.Content = this.days[i];
                        tab.Items.Add(item);
                    }
                }
            }
            else
            {
                TabItem item = new TabItem();
                item.Header = "Ćwiczenia";
                this.list = new ListBox();
                list.SelectionChanged += List_SelectionChanged;
                foreach (Exercise x in training.exercises)
                    list.Items.Add(x);
                item.Content = list;
                tab.Items.Add(item);
            }
            return tab;
        }
        /*public TabControl GetTabControl_D(Parentpage page, Grid grid, Diet diet, string name, int row, int rowspan, int column, int columnspan)
        {
            this.grid = grid;
            this.page = page;
            tab = new TabControl();
            Grid.SetColumn(tab, column);
            Grid.SetRow(tab, row);
            Grid.SetColumnSpan(tab, columnspan);
            Grid.SetRowSpan(tab, rowspan);
            this.diet = diet;
            if (diet.manyDays)
            {
                for (int i = 0; i < 7; i++)
                {
                    TabItem item = new TabItem();
                    item.Header = daysString[i];
                    this.days[i] = new ListBox();

                    this.days[i].SelectionChanged += Helper_SelectionChanged;
                    foreach (Exercise x in training.exercisesD[i])
                        this.days[i].Items.Add(x);
                    item.Content = this.days[i];
                    tab.Items.Add(item);
                }
            }
            else
            {
                TabItem item = new TabItem();
                item.Header = "Ćwiczenia";
                this.list = new ListBox();
                list.SelectionChanged += List_SelectionChanged;
                foreach (Exercise x in training.exercises)
                    list.Items.Add(x);
                item.Content = list;
                tab.Items.Add(item);
            }
            return tab;
        }*/

        private void Helper_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            TabItem item = (TabItem)tab.Items[tab.SelectedIndex];
            int index = 0;
            for (index = 0; index < this.daysString.Length; index++)
            {
                if (item.Header.Equals(this.daysString[index]))
                    break;
            }
            Specific_exercisePage page = new Specific_exercisePage(training.exercisesD[index][this.days[index].SelectedIndex], this.page);
            grid = page.drawGrid(grid);
            grid = page.drawComponent(grid);
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = list.SelectedIndex;
            Specific_exercisePage page = new Specific_exercisePage(training.exercises[index],this.page);
            grid = page.drawGrid(grid);
            grid = page.drawComponent(grid);
        }
    }
}
