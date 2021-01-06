using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;

namespace FITAPP
{
    /// <summary>
    /// Logika interakcji dla klasy AddDiet.xaml
    /// </summary>
    public partial class AddDiet : Window
    {
        DietPage page;
        bool manydays;
        public AddDiet(DietPage page)
        {
            this.page = page;
            InitializeComponent();
            type_Of_Diet();
        }
        private void type_Of_Diet()
        {
            this.grid = drawGrid(grid);
            this.pasekPostepu.Maximum = 3;
            this.pasekPostepu.Minimum = 0;
            this.pasekPostepu.Value = 1;
            Label question = Helper.getLabel("question", "Chcesz utworzyć dietę jednodniową czy tygodniową", 0, 12, 0, 32);
            this.grid.Children.Add(question);

            Button jednodniowa = Helper.getButton("jednodniowa", "Jednodniowa", 16, 4, 5, 6);
            jednodniowa.Click += Jednodniowa_Click;
            this.grid.Children.Add(jednodniowa);

            Button tygodniowa = Helper.getButton("tygodniowa", "Tygodniowa", 16, 4, 21, 6);
            tygodniowa.Click += Tygodniowa_Click;
            this.grid.Children.Add(tygodniowa);
        }

        private void Tygodniowa_Click(object sender, RoutedEventArgs e)
        {

            manydays = true;
            TabControl tabControl = new TabControl();
            Grid.SetColumn(tabControl, 0);
            Grid.SetRow(tabControl, 0);
            Grid.SetColumnSpan(tabControl, 32);
            Grid.SetRowSpan(tabControl, 24);


            string[] days = { "Poniedziałek", "Wtorek", "Środa", "Czwartek", "Piątek", "Sobota", "Niedziela" };

            for(int i = 0; i < 7; i++)
            {
                Grid gridInTab = new Grid();
                gridInTab = drawGrid(gridInTab);
                drawComponents(gridInTab,days[i]);
                TabItem item = new TabItem();
                item.Content = gridInTab;
                item.Header = days[i];
                tabControl.Items.Add(item);
            }
            grid.Children.Add(tabControl);
        }

        private void Jednodniowa_Click(object sender, RoutedEventArgs e)
        {
            this.pasekPostepu.Value = 2;
            manydays = false;
            drawComponents(grid,"Dieta Jednodniowa");
        }

        private void drawComponents(Grid grid,string title)
        {
            grid = drawGrid(grid);

            Label day = Helper.getLabel("title", title, 0, 3, 0, 20);
            grid.Children.Add(day);
            //tu te wszystkie labele

            for(int i = 0; i < 6; i++)
            {
                ListBox listbox = new ListBox();
                Label label = new Label();
                label.Content = "Dodaj nowy posiłek";
                listbox.Items.Add(label);
                Grid.SetRow(listbox,3 + 3 * i);
                Grid.SetColumn(listbox, 6);
                Grid.SetColumnSpan(listbox, 14);
                Grid.SetRowSpan(listbox, 3);
                grid.Children.Add(listbox);
            }

        }

        public Grid drawGrid(Grid grid)
        {
            Clear(grid);
            grid.RowDefinitions.Add(new RowDefinition());
            for (int i = 0; i < 32; i++)
            {
                ColumnDefinition column = new ColumnDefinition();

                column.Width = new GridLength(1, GridUnitType.Star);
                grid.ColumnDefinitions.Add(column);
            }
            for (int i = 0; i < 24; i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(1, GridUnitType.Star);
                grid.RowDefinitions.Add(row);
            }
            return grid;
        }
        public void Clear(Grid grid)
        {
            grid.Children.Clear();
            grid.ColumnDefinitions.Clear();
            grid.RowDefinitions.Clear();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            page.grid = page.drawGrid(page.grid);
            page.grid = page.drawComponent(page.grid);
        }
    }
}
