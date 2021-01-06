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
        Label sniadanie_nutr, IIsniadanie_nutr, lunch_nutr, obiad_nutr, przekaska_nutr, kolacja_nutr;
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
                tab.SelectionChanged += Tab_SelectionChanged;
                Grid.SetColumn(tab,0);
                Grid.SetColumnSpan(tab,32);
                Grid.SetRow(tab, 2);
                Grid.SetRowSpan(tab, 16);

                Label title = Helper.getLabel("tytul_diety", diet.name, 0, 2, 2, 16);
                grid.Children.Add(title);
                
                nutritional = Helper.getLabel("wartosc_odzywcze", "Kcal: " + string.Format("{0:.00}", diet.kcal_list_day[0]) + "   B: " + string.Format("{0:.00}", diet.protein_list_day[0]) + "   T: " + string.Format("{0:.00}", diet.fat_list_day[0]) + "   W: " + string.Format("{0:.00}", diet.carbs_list_day[0]) + "g", 0, 2, 18, 14);
                grid.Children.Add(nutritional);


                for (int i = 0; i < 7; i++)
                {
                    TabItem item = new TabItem();
                    item.Header = daysString[i];
                    Grid gridInTab = new Grid();
                    gridInTab = this.drawGrid(gridInTab);
                    item.Content = gridInTab;



                    Label sniadanie_tytul = Helper.getLabel("sniadanie_tytul", "Śniadanie", 0, 2, 0, 10);
                    gridInTab.Children.Add(sniadanie_tytul);

                    sniadanie = Helper.getListBox(diet.dish_list[i,0], "sniadanie_posilki", 2, 6, 0, 10);
                    sniadanie.SelectionChanged += Sniadanie_SelectionChanged_T;
                    gridInTab.Children.Add(sniadanie);

                    sniadanie_nutr = Helper.getLabel("wartosc_odzywcze", "Kcal: " + string.Format("{0:.00}", diet.kcal_list[0,0]) + "   B: " + string.Format("{0:.00}", diet.protein_list[0, 0]) + "   T: " + string.Format("{0:.00}", diet.fat_list[0, 0]) + "   W: " + string.Format("{0:.00}", diet.carbs_list[0, 0]) + "g", 8, 1, 0,10);
                    gridInTab.Children.Add(sniadanie_nutr);

                    Label IIsniadanie_tytul = Helper.getLabel("IIsniadanie_tytul", "II Śniadanie", 0, 2, 11, 10);
                    gridInTab.Children.Add(IIsniadanie_tytul);

                    IIsniadanie = Helper.getListBox(diet.dish_list[i,1], "IIsniadanie_posilki", 2, 6, 11, 10);
                    IIsniadanie.SelectionChanged += IIsniadanie_SelectionChanged_T;
                    gridInTab.Children.Add(IIsniadanie);

                    IIsniadanie_nutr = Helper.getLabel("wartosc_odzywcze", "Kcal: " + string.Format("{0:.00}", diet.kcal_list[0, 1]) + "   B: " + string.Format("{0:.00}", diet.protein_list[0, 1]) + "   T: " + string.Format("{0:.00}", diet.fat_list[0, 1]) + "   W: " + string.Format("{0:.00}", diet.carbs_list[0, 1]) + "g", 8, 1, 11, 10);
                    gridInTab.Children.Add(IIsniadanie_nutr);

                    Label lunch_tytul = Helper.getLabel("lunch_tytul", "Lunch", 0, 2, 22, 10);
                    gridInTab.Children.Add(lunch_tytul);

                    lunch = Helper.getListBox(diet.dish_list[i, 2], "lunch_posilki", 2, 6, 22, 10);
                    lunch.SelectionChanged += Lunch_SelectionChanged_T;
                    gridInTab.Children.Add(lunch);

                    lunch_nutr = Helper.getLabel("wartosc_odzywcze", "Kcal: " + string.Format("{0:.00}", diet.kcal_list[0, 2]) + "   B: " + string.Format("{0:.00}", diet.protein_list[0, 2]) + "   T: " + string.Format("{0:.00}", diet.fat_list[0, 2]) + "   W: " + string.Format("{0:.00}", diet.carbs_list[0, 2]) + "g", 8, 1, 22, 10);
                    gridInTab.Children.Add(lunch_nutr);

                    Label obiad_tytul = Helper.getLabel("obiad_tytul", "Obiad", 9, 2, 0, 10);
                    gridInTab.Children.Add(obiad_tytul);

                    obiad = Helper.getListBox(diet.dish_list[i,3], "obiad_posilki", 11, 6, 0, 10);
                    obiad.SelectionChanged += Obiad_SelectionChanged_T;
                    gridInTab.Children.Add(obiad);

                    obiad_nutr = Helper.getLabel("wartosc_odzywcze", "Kcal: " + string.Format("{0:.00}", diet.kcal_list[0, 3]) + "   B: " + string.Format("{0:.00}", diet.protein_list[0, 3]) + "   T: " + string.Format("{0:.00}", diet.fat_list[0, 3]) + "   W: " + string.Format("{0:.00}", diet.carbs_list[0, 3]) + "g", 17, 1, 0, 10);
                    gridInTab.Children.Add(obiad_nutr);

                    Label przekaska_tytul = Helper.getLabel("przekaska_tytul", "Przekąska", 9, 2, 11, 10);
                    gridInTab.Children.Add(przekaska_tytul);

                    przekaska = Helper.getListBox(diet.dish_list[i,4], "przekaska_posilki", 11, 6, 11, 10);
                    przekaska.SelectionChanged += Przekaska_SelectionChanged_T;
                    gridInTab.Children.Add(przekaska);

                    przekaska_nutr = Helper.getLabel("wartosc_odzywcze", "Kcal: " + string.Format("{0:.00}", diet.kcal_list[0, 4]) + "   B: " + string.Format("{0:.00}", diet.protein_list[0, 4]) + "   T: " + string.Format("{0:.00}", diet.fat_list[0, 4]) + "   W: " + string.Format("{0:.00}", diet.carbs_list[0, 4]) + "g", 17, 1, 11, 10);
                    gridInTab.Children.Add(przekaska_nutr);

                    Label kolacja_tytul = Helper.getLabel("kolacja_tytul", "Kolacja", 9, 2, 22, 10);
                    gridInTab.Children.Add(kolacja_tytul);

                    kolacja = Helper.getListBox(diet.dish_list[i,5], "kolacja_posilki", 11, 6, 22, 10);
                    kolacja.SelectionChanged += Kolacja_SelectionChanged_T;
                    gridInTab.Children.Add(kolacja);

                    kolacja_nutr = Helper.getLabel("wartosc_odzywcze", "Kcal: " + string.Format("{0:.00}", diet.kcal_list[0, 5]) + "   B: " + string.Format("{0:.00}", diet.protein_list[0, 5]) + "   T: " + string.Format("{0:.00}", diet.fat_list[0, 5]) + "   W: " + string.Format("{0:.00}", diet.carbs_list[0, 5]) + "g", 17, 1,22, 10);
                    gridInTab.Children.Add(kolacja_nutr);


                    tab.Items.Add(item); 
                }
                grid.Children.Add(tab);
            }
            else
            {
                Button back = new Helper().getBackButton(grid, parentpage, "back", 0, 2, 0, 2);
                grid.Children.Add(back);

                Label title = Helper.getLabel("tytul_diety", diet.name, 0, 2, 2, 16);
                grid.Children.Add(title);

                nutritional = Helper.getLabel("wartosc_odzywcze", "Kcal: " + string.Format("{0:.00}", diet.kcal) + "   B: " + string.Format("{0:.00}", diet.protein) + "   T: " + string.Format("{0:.00}", diet.fat) + "   W: " + string.Format("{0:.00}", diet.carbs) + "g", 0, 2, 18, 14);
                grid.Children.Add(nutritional);

                Label sniadanie_tytul = Helper.getLabel("sniadanie_tytul", "Śniadanie", 2, 2, 0, 10);
                grid.Children.Add(sniadanie_tytul);

                sniadanie = Helper.getListBox(diet.dish_one_day[0], "sniadanie_posilki", 4, 5, 0, 10);
                sniadanie.SelectionChanged += Sniadanie_SelectionChanged;
                grid.Children.Add(sniadanie);

                Label nutritional_sniadanie = Helper.getLabel("wartosc_odzywcze_sniadanie", "Kcal: " + string.Format("{0:.00}", diet.kcal_one_day[0]) + "   B: " + string.Format("{0:.00}", diet.protein_one_day[0]) + "   T: " + string.Format("{0:.00}", diet.fat_one_day[0]) + "   W: " + string.Format("{0:.00}", diet.carbs_one_day[0]) + "g", 9, 1, 0, 10);
                grid.Children.Add(nutritional_sniadanie);

                Label IIsniadanie_tytul = Helper.getLabel("IIsniadanie_tytul", "II Śniadanie", 2, 2, 11, 10);
                grid.Children.Add(IIsniadanie_tytul);

                IIsniadanie = Helper.getListBox(diet.dish_one_day[1], "IIsniadanie_posilki",4,5,11,10);
                IIsniadanie.SelectionChanged += IIsniadanie_SelectionChanged;
                grid.Children.Add(IIsniadanie);

                Label nutritional_IIsniadanie = Helper.getLabel("wartosc_odzywcze_IIsniadanie", "Kcal: " + string.Format("{0:.00}", diet.kcal_one_day[1]) + "   B: " + string.Format("{0:.00}", diet.protein_one_day[1]) + "   T: " + string.Format("{0:.00}", diet.fat_one_day[1]) + "   W: " + string.Format("{0:.00}", diet.carbs_one_day[1]) + "g", 9, 1, 11, 10);
                grid.Children.Add(nutritional_IIsniadanie);

                Label lunch_tytul = Helper.getLabel("lunch_tytul", "Lunch", 2, 2, 22, 10);
                grid.Children.Add(lunch_tytul);

                lunch = Helper.getListBox(diet.dish_one_day[2], "lunch_posilki", 4, 5, 22, 10);
                lunch.SelectionChanged += Lunch_SelectionChanged;
                grid.Children.Add(lunch);

                Label nutritional_lunch = Helper.getLabel("wartosc_odzywcze_lunch", "Kcal: " + string.Format("{0:.00}", diet.kcal_one_day[2]) + "   B: " + string.Format("{0:.00}", diet.protein_one_day[2]) + "   T: " + string.Format("{0:.00}", diet.fat_one_day[2]) + "   W: " + string.Format("{0:.00}", diet.carbs_one_day[2]) + "g", 9, 1, 22, 10);
                grid.Children.Add(nutritional_lunch);

                Label obiad_tytul = Helper.getLabel("obiad_tytul", "Obiad", 10, 2, 0, 10);
                grid.Children.Add(obiad_tytul);

                obiad = Helper.getListBox(diet.dish_one_day[3], "obiad_posilki", 12, 5, 0, 10);
                obiad.SelectionChanged += Obiad_SelectionChanged;
                grid.Children.Add(obiad);

                Label nutritional_obiad = Helper.getLabel("wartosc_odzywcze_obiad", "Kcal: " + string.Format("{0:.00}", diet.kcal_one_day[3]) + "   B: " + string.Format("{0:.00}", diet.protein_one_day[3]) + "   T: " + string.Format("{0:.00}", diet.fat_one_day[3]) + "   W: " + string.Format("{0:.00}", diet.carbs_one_day[3]) + "g", 17, 1, 0, 10);
                grid.Children.Add(nutritional_obiad);

                Label przekaska_tytul = Helper.getLabel("przekaska_tytul", "Przekąska", 10, 2, 11, 10);
                grid.Children.Add(przekaska_tytul);

                przekaska = Helper.getListBox(diet.dish_one_day[4], "przekaska_tytul", 12,5, 11, 10);
                przekaska.SelectionChanged += Przekaska_SelectionChanged;
                grid.Children.Add(przekaska);

                Label nutritional_przekaska = Helper.getLabel("wartosc_odzywcze_przekaska", "Kcal: " + string.Format("{0:.00}", diet.kcal_one_day[4]) + "   B: " + string.Format("{0:.00}", diet.protein_one_day[4]) + "   T: " + string.Format("{0:.00}", diet.fat_one_day[4]) + "   W: " + string.Format("{0:.00}", diet.carbs_one_day[4]) + "g", 17, 1, 11, 10);
                grid.Children.Add(nutritional_przekaska);

                Label kolacja_tytul = Helper.getLabel("kolacja_tytul", "Kolacja", 10, 2, 22, 10);
                grid.Children.Add(kolacja_tytul);

                kolacja = Helper.getListBox(diet.dish_one_day[5], "kolacja_tytul", 12, 5, 22, 10);
                kolacja.SelectionChanged += Kolacja_SelectionChanged;

                Label nutritional_kolacja = Helper.getLabel("wartosc_odzywcze_kolacja", "Kcal: " + string.Format("{0:.00}", diet.kcal_one_day[5]) + "   B: " + string.Format("{0:.00}", diet.protein_one_day[5]) + "   T: " + string.Format("{0:.00}", diet.fat_one_day[5]) + "   W: " + string.Format("{0:.00}", diet.carbs_one_day[5]) + "g", 17, 1, 22, 10);
                grid.Children.Add(nutritional_kolacja);

                grid.Children.Add(kolacja);
            }

            return grid;
        }
        private void Tab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = tab.SelectedIndex;
            nutritional.Content = "Kcal: " + string.Format("{0:.00}", diet.kcal_list_day[index]) + "   B: " + string.Format("{0:.00}", diet.protein_list_day[index]) + "   T: " + string.Format("{0:.00}", diet.fat_list_day[index]) + "   W: " + string.Format("{0:.00}", diet.carbs_list_day[index]) + "g";
            int k = 0;
            sniadanie_nutr.Content = "Kcal: " + string.Format("{0:.00}", diet.kcal_list[index, k]) + "   B: " + string.Format("{0:.00}", diet.protein_list[index, k]) + "   T: " + string.Format("{0:.00}", diet.fat_list[index, k]) + "   W: " + string.Format("{0:.00}", diet.carbs_list[index, k]) + "g";
            k = k + 1;
            IIsniadanie_nutr.Content = "Kcal: " + string.Format("{0:.00}", diet.kcal_list[index, k]) + "   B: " + string.Format("{0:.00}", diet.protein_list[index, k]) + "   T: " + string.Format("{0:.00}", diet.fat_list[index, k]) + "   W: " + string.Format("{0:.00}", diet.carbs_list[index, k]) + "g";
            k = k + 1;
            lunch_nutr.Content = "Kcal: " + string.Format("{0:.00}", diet.kcal_list[index, k]) + "   B: " + string.Format("{0:.00}", diet.protein_list[index, k]) + "   T: " + string.Format("{0:.00}", diet.fat_list[index, k]) + "   W: " + string.Format("{0:.00}", diet.carbs_list[index, k]) + "g";
            k = k + 1;
            obiad_nutr.Content = "Kcal: " + string.Format("{0:.00}", diet.kcal_list[index, k]) + "   B: " + string.Format("{0:.00}", diet.protein_list[index, k]) + "   T: " + string.Format("{0:.00}", diet.fat_list[index, k]) + "   W: " + string.Format("{0:.00}", diet.carbs_list[index, k]) + "g";
            k = k + 1;
            przekaska_nutr.Content = "Kcal: " + string.Format("{0:.00}", diet.kcal_list[index, k]) + "   B: " + string.Format("{0:.00}", diet.protein_list[index, k]) + "   T: " + string.Format("{0:.00}", diet.fat_list[index, k]) + "   W: " + string.Format("{0:.00}", diet.carbs_list[index, k]) + "g";
            k = k + 1;
            kolacja_nutr.Content = "Kcal: " + string.Format("{0:.00}", diet.kcal_list[index, k]) + "   B: " + string.Format("{0:.00}", diet.protein_list[index, k]) + "   T: " + string.Format("{0:.00}", diet.fat_list[index, k]) + "   W: " + string.Format("{0:.00}", diet.carbs_list[index, k]) + "g";
        }
        private void Sniadanie_SelectionChanged_T(object sender, SelectionChangedEventArgs e)
        {
            int tabpage = this.tab.SelectedIndex;
            TabItem item = (TabItem)this.tab.Items[tabpage];
            Grid gridInTab = (Grid)item.Content;
            ListBox list = (ListBox)gridInTab.Children.Cast<UIElement>()
                .First(e => Grid.GetRow(e) == 2 && Grid.GetColumn(e) ==0);
            int index = list.SelectedIndex;
            open_Dish((Dish)list.Items[index]);
        }
        private void IIsniadanie_SelectionChanged_T(object sender, SelectionChangedEventArgs e)
        {
            int tabpage = this.tab.SelectedIndex;
            TabItem item = (TabItem)this.tab.Items[tabpage];
            Grid gridInTab = (Grid)item.Content;
            ListBox list = (ListBox)gridInTab.Children.Cast<UIElement>()
                .First(e => Grid.GetRow(e) == 2 && Grid.GetColumn(e) == 11);
            int index = list.SelectedIndex;
            open_Dish((Dish)list.Items[index]);
        }
        private void Lunch_SelectionChanged_T(object sender, SelectionChangedEventArgs e)
        {
            int tabpage = this.tab.SelectedIndex;
            TabItem item = (TabItem)this.tab.Items[tabpage];
            Grid gridInTab = (Grid)item.Content;
            ListBox list = (ListBox)gridInTab.Children.Cast<UIElement>()
                .First(e => Grid.GetRow(e) == 2 && Grid.GetColumn(e) == 22);
            int index = list.SelectedIndex;
            open_Dish((Dish)list.Items[index]);
        }
        private void Obiad_SelectionChanged_T(object sender, SelectionChangedEventArgs e)
        {
            int tabpage = this.tab.SelectedIndex;
            TabItem item = (TabItem)this.tab.Items[tabpage];
            Grid gridInTab = (Grid)item.Content;
            ListBox list = (ListBox)gridInTab.Children.Cast<UIElement>()
                .First(e => Grid.GetRow(e) == 11 && Grid.GetColumn(e) == 0);
            int index = list.SelectedIndex;
            open_Dish((Dish)list.Items[index]);
        }
        private void Przekaska_SelectionChanged_T(object sender, SelectionChangedEventArgs e)
        {
            int tabpage = this.tab.SelectedIndex;
            TabItem item = (TabItem)this.tab.Items[tabpage];
            Grid gridInTab = (Grid)item.Content;
            ListBox list = (ListBox)gridInTab.Children.Cast<UIElement>()
                .First(e => Grid.GetRow(e) == 11 && Grid.GetColumn(e) == 11);
            int index = list.SelectedIndex;
            open_Dish((Dish)list.Items[index]);
        }
        private void Kolacja_SelectionChanged_T(object sender, SelectionChangedEventArgs e)
        {
            int tabpage = this.tab.SelectedIndex;
            TabItem item = (TabItem)this.tab.Items[tabpage];
            Grid gridInTab = (Grid)item.Content;
            ListBox list = (ListBox)gridInTab.Children.Cast<UIElement>()
                .First(e => Grid.GetRow(e) == 11 && Grid.GetColumn(e) == 22);
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
