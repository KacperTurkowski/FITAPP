using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FITAPP
{
    class DetailsDiet : Parentpage
    {
        Diet diet;
        Parentpage parentpage;
        Grid grid;
        Label nutritional;
        TabControl tab;
        string[] daysString = { "Poniedziałek", "Wtorek", "Środa", "Czwartek", "Piątek", "Sobota", "Niedziela" };
        ListBox sniadanie, IIsniadanie, lunch, obiad, przekaska, kolacja;
        public DetailsDiet(Diet diet, Parentpage parentpage)
        {
            this.diet = diet;
            this.parentpage = parentpage;
        }
        public override Grid drawComponent(Grid grid)
        {
            this.grid = grid;

            if (diet.manyDays)
            {
                Button back = new Helper().getBackButton(grid, parentpage, "back", 0, 2, 0, 2);
                grid.Children.Add(back);

                //tabbed page
                tab = new TabControl();
                Grid.SetColumn(tab,0);
                Grid.SetColumnSpan(tab,32);
                Grid.SetRow(tab, 2);
                Grid.SetRowSpan(tab, 16);

                Label title = Helper.getLabel("tytul_diety", diet.name, 0, 2, 2, 19);
                grid.Children.Add(title);

                for (int i = 0; i < 7; i++)
                {
                    TabItem item = new TabItem();
                    item.Header = daysString[i];
                    Grid gridInTab = new Grid();
                    gridInTab = this.drawGrid(gridInTab);
                    item.Content = gridInTab;


                    nutritional = Helper.getLabel("wartosc_odzywcze", "", 0, 2, 21, 9);
                    gridInTab.Children.Add(nutritional);

                    Label sniadanie_tytul = Helper.getLabel("sniadanie_tytul", "Śniadanie", 2, 1, 0, 10);
                    gridInTab.Children.Add(sniadanie_tytul);

                    sniadanie = Helper.getListBox(diet.dish_list[i,0], "sniadanie_posilki", 3, 6, 0, 10);
                    sniadanie.SelectionChanged += Sniadanie_SelectionChanged_T;
                    gridInTab.Children.Add(sniadanie);

                    Label IIsniadanie_tytul = Helper.getLabel("IIsniadanie_tytul", "II Śniadanie", 2, 1, 11, 10);
                    gridInTab.Children.Add(IIsniadanie_tytul);

                    IIsniadanie = Helper.getListBox(diet.dish_list[i,1], "IIsniadanie_posilki", 3, 6, 11, 10);
                    IIsniadanie.SelectionChanged += IIsniadanie_SelectionChanged_T;
                    gridInTab.Children.Add(IIsniadanie);

                    Label lunch_tytul = Helper.getLabel("lunch_tytul", "Lunch", 2, 1, 22, 10);
                    gridInTab.Children.Add(lunch_tytul);

                    lunch = Helper.getListBox(diet.dish_list[i, 2], "lunch_posilki", 3, 6, 22, 10);
                    lunch.SelectionChanged += Lunch_SelectionChanged_T;
                    gridInTab.Children.Add(lunch);

                    Label obiad_tytul = Helper.getLabel("obiad_tytul", "Obiad", 5, 1, 0, 10);
                    gridInTab.Children.Add(obiad_tytul);

                    obiad = Helper.getListBox(diet.dish_list[i,3], "obiad_posilki", 10, 6, 0, 10);
                    obiad.SelectionChanged += Obiad_SelectionChanged_T;
                    gridInTab.Children.Add(obiad);

                    Label przekaska_tytul = Helper.getLabel("przekaska_tytul", "Przekąska", 5, 1, 11, 10);
                    gridInTab.Children.Add(przekaska_tytul);

                    przekaska = Helper.getListBox(diet.dish_list[i,4], "przekaska_tytul", 10, 6, 11, 10);
                    przekaska.SelectionChanged += Przekaska_SelectionChanged_T;
                    gridInTab.Children.Add(przekaska);

                    Label kolacja_tytul = Helper.getLabel("kolacja_tytul", "Kolacja", 5, 1, 22, 10);
                    gridInTab.Children.Add(kolacja_tytul);

                    kolacja = Helper.getListBox(diet.dish_list[i,5], "kolacja_tytul", 10, 6, 22, 10);
                    kolacja.SelectionChanged += Kolacja_SelectionChanged_T;
                    gridInTab.Children.Add(kolacja);


                    tab.Items.Add(item); 
                }
                grid.Children.Add(tab);
            }
            else
            {
                Button back = new Helper().getBackButton(grid, parentpage, "back", 0, 2, 0, 2);
                grid.Children.Add(back);

                Label title = Helper.getLabel("tytul_diety", diet.name, 0, 2, 2, 19);
                grid.Children.Add(title);

                nutritional = Helper.getLabel("wartosc_odzywcze", "", 0, 2, 21, 9);
                grid.Children.Add(nutritional);

                Label sniadanie_tytul = Helper.getLabel("sniadanie_tytul", "Śniadanie", 2, 1, 0, 10);
                grid.Children.Add(sniadanie_tytul);

                sniadanie = Helper.getListBox(diet.dish_one_day[0], "sniadanie_posilki", 3, 6, 0, 10);
                sniadanie.SelectionChanged += Sniadanie_SelectionChanged;
                grid.Children.Add(sniadanie);

                Label IIsniadanie_tytul = Helper.getLabel("IIsniadanie_tytul", "II Śniadanie", 2, 1, 11, 10);
                grid.Children.Add(IIsniadanie_tytul);

                IIsniadanie = Helper.getListBox(diet.dish_one_day[1], "IIsniadanie_posilki",3,6,11,10);
                IIsniadanie.SelectionChanged += IIsniadanie_SelectionChanged;
                grid.Children.Add(IIsniadanie);

                Label lunch_tytul = Helper.getLabel("lunch_tytul", "Lunch", 2, 1, 22, 10);
                grid.Children.Add(lunch_tytul);

                lunch = Helper.getListBox(diet.dish_one_day[2], "lunch_posilki", 3, 6, 22, 10);
                lunch.SelectionChanged += Lunch_SelectionChanged;
                grid.Children.Add(lunch);

                Label obiad_tytul = Helper.getLabel("obiad_tytul", "Obiad", 10, 1, 0, 10);
                grid.Children.Add(obiad_tytul);

                obiad = Helper.getListBox(diet.dish_one_day[3], "obiad_posilki", 10, 6, 0, 10);
                obiad.SelectionChanged += Obiad_SelectionChanged;
                grid.Children.Add(obiad);

                Label przekaska_tytul = Helper.getLabel("przekaska_tytul", "Przekąska", 10, 1, 11, 10);
                grid.Children.Add(przekaska_tytul);

                przekaska = Helper.getListBox(diet.dish_one_day[4], "przekaska_tytul", 10, 6, 11, 10);
                przekaska.SelectionChanged += Przekaska_SelectionChanged;
                grid.Children.Add(przekaska);

                Label kolacja_tytul = Helper.getLabel("kolacja_tytul", "Kolacja", 10, 1, 22, 10);
                grid.Children.Add(kolacja_tytul);

                kolacja = Helper.getListBox(diet.dish_one_day[5], "kolacja_tytul", 10, 6, 22, 10);
                kolacja.SelectionChanged += Kolacja_SelectionChanged;
                grid.Children.Add(kolacja);
            }

            return grid;
        }
        private void Sniadanie_SelectionChanged_T(object sender, SelectionChangedEventArgs e)
        {
            int tabpage = this.tab.SelectedIndex;
            TabItem item = (TabItem)this.tab.Items[tabpage];
            Grid gridInTab = (Grid)item.Content;
            ListBox list = (ListBox)gridInTab.Children.Cast<UIElement>()
                .First(e => Grid.GetRow(e) == 3 && Grid.GetColumn(e) ==0);
            int index = list.SelectedIndex;
            open_Dish((Dish)list.Items[index]);
        }
        private void IIsniadanie_SelectionChanged_T(object sender, SelectionChangedEventArgs e)
        {
            int tabpage = this.tab.SelectedIndex;
            TabItem item = (TabItem)this.tab.Items[tabpage];
            Grid gridInTab = (Grid)item.Content;
            ListBox list = (ListBox)gridInTab.Children.Cast<UIElement>()
                .First(e => Grid.GetRow(e) == 3 && Grid.GetColumn(e) == 11);
            int index = list.SelectedIndex;
            open_Dish((Dish)list.Items[index]);
        }
        private void Lunch_SelectionChanged_T(object sender, SelectionChangedEventArgs e)
        {
            int tabpage = this.tab.SelectedIndex;
            TabItem item = (TabItem)this.tab.Items[tabpage];
            Grid gridInTab = (Grid)item.Content;
            ListBox list = (ListBox)gridInTab.Children.Cast<UIElement>()
                .First(e => Grid.GetRow(e) == 3 && Grid.GetColumn(e) == 22);
            int index = list.SelectedIndex;
            open_Dish((Dish)list.Items[index]);
        }
        private void Obiad_SelectionChanged_T(object sender, SelectionChangedEventArgs e)
        {
            int tabpage = this.tab.SelectedIndex;
            TabItem item = (TabItem)this.tab.Items[tabpage];
            Grid gridInTab = (Grid)item.Content;
            ListBox list = (ListBox)gridInTab.Children.Cast<UIElement>()
                .First(e => Grid.GetRow(e) == 10 && Grid.GetColumn(e) == 0);
            int index = list.SelectedIndex;
            open_Dish((Dish)list.Items[index]);
        }
        private void Przekaska_SelectionChanged_T(object sender, SelectionChangedEventArgs e)
        {
            int tabpage = this.tab.SelectedIndex;
            TabItem item = (TabItem)this.tab.Items[tabpage];
            Grid gridInTab = (Grid)item.Content;
            ListBox list = (ListBox)gridInTab.Children.Cast<UIElement>()
                .First(e => Grid.GetRow(e) == 10 && Grid.GetColumn(e) == 11);
            int index = list.SelectedIndex;
            open_Dish((Dish)list.Items[index]);
        }
        private void Kolacja_SelectionChanged_T(object sender, SelectionChangedEventArgs e)
        {
            int tabpage = this.tab.SelectedIndex;
            TabItem item = (TabItem)this.tab.Items[tabpage];
            Grid gridInTab = (Grid)item.Content;
            ListBox list = (ListBox)gridInTab.Children.Cast<UIElement>()
                .First(e => Grid.GetRow(e) == 10 && Grid.GetColumn(e) == 22);
            int index = list.SelectedIndex;
            open_Dish((Dish)list.Items[index]);
        }
        private void Kolacja_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = kolacja.SelectedIndex;
            open_Dish((Dish)kolacja.Items[index]);
        }
        private void Przekaska_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = przekaska.SelectedIndex;
            open_Dish((Dish)przekaska.Items[index]);
        }
        private void Obiad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = obiad.SelectedIndex;
            open_Dish((Dish)obiad.Items[index]);
        }
        private void Lunch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lunch.SelectedIndex;
            open_Dish((Dish)lunch.Items[index]);
        }
        private void IIsniadanie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = IIsniadanie.SelectedIndex;
            open_Dish((Dish)IIsniadanie.Items[index]);
        }
        private void Sniadanie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = sniadanie.SelectedIndex;
            open_Dish((Dish)sniadanie.Items[index]);
        }
        private void open_Dish(Dish dish)
        {
            Specific_dishPage page = new Specific_dishPage(dish, this);
            grid = page.drawGrid(grid);
            grid = page.drawComponent(grid);
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
