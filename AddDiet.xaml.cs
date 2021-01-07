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
        WrapPanel panel;
        TabControl tabControl;
        bool manydays;
        AddDiet tempWindow;
        TextBox dietName;
        Label[,] nutri = new Label[6, 4];

        List<Dish>[,] dish_many_days = new List<Dish>[7, 6];
        List<double>[,] amount_many_days = new List<double>[7, 6];

        List<Dish>[] dish_one_day = new List<Dish>[6];
        List<double>[] amount_one_day = new List<double>[6];

        List<Tag> tags = new List<Tag>();

        public AddDiet(DietPage page)
        {
            for (int i=0; i < 6; i++)
            {
                for(int j = 0; j < 7; j++)
                {
                    dish_many_days[j, i] = new List<Dish>();
                    amount_many_days[j, i] = new List<double>();
                }
                dish_one_day[i] = new List<Dish>();
                amount_one_day[i] = new List<double>();
            }
            this.page = page;
            InitializeComponent();
            type_Of_Diet();
        }
        private void type_Of_Diet()
        {
            this.grid = drawGrid(grid);
            this.pasekPostepu.Maximum = 4;
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
            this.pasekPostepu.Value = 2;

            manydays = true;
            tabControl = new TabControl();
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
            string[] time_of_day = { "Śniadanie", "IIŚniadanie", "Lunch", "Obiad", "Przekąska", "Kolacja" };

            for(int i = 0; i < 6; i++)
            {
                Label x = Helper.getLabel("label" + i, time_of_day[i], 3 + 3 * i, 3, 0, 6);
                grid.Children.Add(x);
            }

            Label kcal_title, protein_title, carbs_title, fat_title;
            kcal_title = Helper.getLabel("kcal_title", "Kcal", 0, 3, 20, 3);
            protein_title = Helper.getLabel("protein_title", "Białka", 0, 3, 23, 3);
            fat_title = Helper.getLabel("fat_title", "Tłuszcze", 0, 3, 26, 3);
            carbs_title = Helper.getLabel("carbs_title", "Węglowodany", 0, 3, 29, 3);
            grid.Children.Add(kcal_title);
            grid.Children.Add(protein_title);
            grid.Children.Add(fat_title);
            grid.Children.Add(carbs_title);

            for(int i = 0; i < 6; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    nutri[i,j] = new Label();
                    nutri[i, j].HorizontalContentAlignment = HorizontalAlignment.Center;
                    nutri[i, j].VerticalContentAlignment = VerticalAlignment.Center;
                    nutri[i, j].Content = 0.0;
                    Grid.SetColumn(nutri[i, j],20+j*3);
                    Grid.SetRow(nutri[i, j], 3 + 3 * i);
                    Grid.SetColumnSpan(nutri[i, j], 3);
                    Grid.SetRowSpan(nutri[i, j], 3);
                    grid.Children.Add(nutri[i, j]);
                }
            }



            for(int i = 0; i < 6; i++)
            {
                ListBox listbox = new ListBox();
                listbox.Name = "_" + i + "_";
                listbox.SelectionChanged += Listbox_SelectionChanged;
                listbox.PreviewMouseRightButtonDown += Delete_dish;
                Label label = new Label();
                label.Content = "Dodaj nowy posiłek";
                listbox.Items.Add(label);
                Grid.SetRow(listbox,3 + 3 * i);
                Grid.SetColumn(listbox, 6);
                Grid.SetColumnSpan(listbox, 14);
                Grid.SetRowSpan(listbox, 3);
                grid.Children.Add(listbox);
            }
            Button back = Helper.getButton("wroc", "Wróć", 22, 2, 0, 6);
            back.Margin = new Thickness(5);
            back.Click += Back_Click;
            grid.Children.Add(back);

            Button next = Helper.getButton("dalej", "Dalej", 22, 2, 26, 6);
            next.Margin = new Thickness(5);
            next.Click += Next_Click;
            grid.Children.Add(next);

        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            grid = drawGrid(grid);
            
            
            this.pasekPostepu.Value = 3;

            Label label = Helper.getLabel("title", "Podaj nazwę diety", 0, 3, 4, 24);
            grid.Children.Add(label);

            dietName = Helper.getTextBox("tytul", "", 3, 2, 10, 12);
            grid.Children.Add(dietName);
            
            Label label2 = Helper.getLabel("tagi", "Wybierz tagi", 5, 3, 4, 24);
            grid.Children.Add(label2);

            ComboBox comboBox = new ComboBox();
            Grid.SetRow(comboBox, 8);
            Grid.SetColumn(comboBox,7);
            Grid.SetColumnSpan(comboBox, 18);
            Grid.SetRowSpan(comboBox, 2);
            comboBox.SelectionChanged += ComboBox_SelectionChanged;
            comboBox.ItemsSource = DataBase.dietTags;
            grid.Children.Add(comboBox);

            ScrollViewer scrollViewer = new ScrollViewer();
            scrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            scrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            Grid.SetColumn(scrollViewer, 4);
            Grid.SetRow(scrollViewer, 11);
            Grid.SetColumnSpan(scrollViewer, 24);
            Grid.SetRowSpan(scrollViewer, 8);
            panel = new WrapPanel();
            scrollViewer.Content = panel;
            grid.Children.Add(scrollViewer);

            Button button = Helper.getButton("koniec", "Dodaj Dietę", 20, 3, 10, 12);
            button.Click += Button_Click;
            grid.Children.Add(button);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (dietName.Text != "")
            {
                if (manydays)
                {
                    Diet diet = new Diet(dietName.Text, dish_many_days, amount_many_days);
                    diet.tags = tags;
                    DataBase.diets.Add(diet);
                }
                else
                {
                    Diet diet = new Diet(dietName.Text, dish_one_day, amount_one_day);
                    diet.tags = tags;
                    DataBase.diets.Add(diet);
                }
                this.Close();
            }
            else
                System.Windows.MessageBox.Show("Dieta musi mieć nazwę");
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            Tag tag = (Tag)comboBox.SelectedItem;

            Label label = new Label();
            label.Background = Brushes.Gray;
            label.Content = tag.name;
            label.MouseDoubleClick += Label_MouseDoubleClick;
            label.Margin = new Thickness(5);
            panel.Children.Add(label);
            tags.Add(tag);
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Label label = (Label)sender;
            foreach(Tag tag in tags)
            {
                if (label.Content.Equals(tag.name))
                {
                    tags.Remove(tag);
                    break;
                }
            }
            panel.Children.Remove(label);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            type_Of_Diet();
        }

        private void Delete_dish(object sender, MouseButtonEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            if(listBox.SelectedIndex != -1)
            {
                if (listBox.SelectedItem.GetType() == typeof(Label))
                {
                    Label label = (Label)listBox.SelectedItem;

                    int time_of_day = int.Parse(listBox.Name[1].ToString());
                    if (manydays)
                    {
                        Dish dish = null;
                        double amount = 0;
                        int day = tabControl.SelectedIndex;
                        for(int i = 0; i < this.dish_many_days[day,time_of_day].Count; i++)
                        {
                            dish = this.dish_many_days[day, time_of_day][i];
                            amount = this.amount_many_days[day, time_of_day][i];
                            string temp = dish.name + "\n Ilość: " + amount;
                            if (label.Content.Equals(temp))
                            {
                                this.dish_many_days[day, time_of_day].RemoveAt(i);
                                this.amount_many_days[day, time_of_day].RemoveAt(i);
                                break;
                            }
                        }
                        listBox.Items.RemoveAt(listBox.SelectedIndex);

                        Grid grid = (Grid)tabControl.SelectedContent;//siatka dla danego dnia
                        int row = 3 + 3 * time_of_day;
                        Label kcal = (Label)grid.Children.Cast<UIElement>()
                            .First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == 20);
                        double tempN = (double)kcal.Content - dish.kcal * amount;
                        kcal.Content = tempN;

                        Label protein = (Label)grid.Children.Cast<UIElement>()
                            .First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == 23);
                        tempN = (double)protein.Content - dish.protein * amount;
                        protein.Content = tempN;

                        Label fat = (Label)grid.Children.Cast<UIElement>()
                            .First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == 26);
                        tempN = (double)fat.Content - dish.fat * amount;
                        fat.Content = tempN;

                        Label carbs = (Label)grid.Children.Cast<UIElement>()
                            .First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == 29);
                        tempN = (double)carbs.Content - dish.carbs * amount;
                        carbs.Content = tempN;
                    }
                    else
                    {
                        Dish dish = null;
                        double amount = 0;
                        for(int i = 0; i < this.dish_one_day[time_of_day].Count; i++)
                        {
                            dish = this.dish_one_day[time_of_day][i];
                            amount = this.amount_one_day[time_of_day][i];
                            string temp = dish.name + "\n Ilość: " + amount;
                            if (label.Content.Equals(temp))
                            {
                                this.dish_one_day[time_of_day].RemoveAt(i);
                                this.amount_one_day[time_of_day].RemoveAt(i);
                            }
                        }
                        listBox.Items.RemoveAt(listBox.SelectedIndex);
                        int row = 3 + 3 * time_of_day;
                        Label kcal = (Label)grid.Children.Cast<UIElement>()
                            .First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == 20);
                        double tempN = (double)kcal.Content - dish.kcal * amount;
                        kcal.Content = tempN;

                        Label protein = (Label)grid.Children.Cast<UIElement>()
                            .First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == 23);
                        tempN = (double)protein.Content - dish.protein * amount;
                        protein.Content = tempN;

                        Label fat = (Label)grid.Children.Cast<UIElement>()
                            .First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == 26);
                        tempN = (double)fat.Content - dish.fat * amount;
                        fat.Content = tempN;

                        Label carbs = (Label)grid.Children.Cast<UIElement>()
                            .First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == 29);
                        tempN = (double)carbs.Content - dish.carbs * amount;
                        carbs.Content = tempN;
                    }
                }
                else
                {
                    WrapPanel panel = (WrapPanel)listBox.SelectedItem;
                    listBox.Items.RemoveAt(listBox.Items.IndexOf(panel));
                }
            }
        }

        private void Listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listbox = (ListBox)sender;
            if(listbox.SelectedIndex == listbox.Items.Count - 1)
            {
                WrapPanel panel = new WrapPanel();

                ComboBox comboBox = new ComboBox();
                comboBox.ItemsSource = DataBase.dishes;
                comboBox.Text = "Wybierz posiłek";
                comboBox.IsEditable = true;
                panel.Children.Add(comboBox);

                Label label = new Label();
                label.Content = "Ilość: ";
                panel.Children.Add(label);

                DoubleUpDown doubleUpDown = new DoubleUpDown();
                doubleUpDown.Value = 1;
                panel.Children.Add(doubleUpDown);

                Button OK = new Button();
                OK.Click += OK_Click;
                OK.Content = "OK";
                panel.Children.Add(OK);

                listbox.Items.Insert(listbox.Items.Count - 1, panel);
                listbox.SelectedIndex = listbox.Items.Count - 2;
            }
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            Button OK = (Button)sender;
            WrapPanel panel = (WrapPanel)OK.Parent;
            ListBox listbox = (ListBox)panel.Parent;
            ComboBox comboBox = (ComboBox)panel.Children[0];
            DoubleUpDown doubleUpDown = (DoubleUpDown)panel.Children[2];

            if (doubleUpDown.Value <= 0)
            {
                System.Windows.MessageBox.Show("Podana ilość jest za mała");
                return;
            }
            if( comboBox.SelectedIndex == -1)
            {
                System.Windows.MessageBox.Show("Wybierz posiłek");
                return;
            }
            Dish dish = (Dish)comboBox.SelectedItem;
            double amount = (double)doubleUpDown.Value;
            int time_of_day = int.Parse(listbox.Name[1].ToString());
            if (manydays)
            {
                int day = tabControl.SelectedIndex;
                this.dish_many_days[day, time_of_day].Add(dish);
                this.amount_many_days[day, time_of_day].Add(amount);

                int indexOfSelected = listbox.Items.IndexOf(panel);
                listbox.Items.RemoveAt(indexOfSelected);
                Label label = new Label();
                label.Content = dish.name + "\n Ilość: " + amount;
                listbox.Items.Insert(indexOfSelected, label);

                Grid grid = (Grid)tabControl.SelectedContent;//siatka dla danego dnia
                int row = 3 + 3 * time_of_day;
                Label kcal = (Label)grid.Children.Cast<UIElement>()
                    .First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == 20);
                double temp = (double)kcal.Content + dish.kcal * amount;
                kcal.Content = temp;
                
                Label protein = (Label)grid.Children.Cast<UIElement>()
                    .First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == 23);
                temp = (double)protein.Content + dish.protein * amount;
                protein.Content = temp;

                Label fat = (Label)grid.Children.Cast<UIElement>()
                    .First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == 26);
                temp = (double)fat.Content + dish.fat * amount;
                fat.Content = temp;

                Label carbs = (Label)grid.Children.Cast<UIElement>()
                    .First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == 29);
                temp = (double)carbs.Content + dish.carbs * amount;
                carbs.Content = temp;
            }
            else
            {
                this.dish_one_day[time_of_day].Add(dish);
                this.amount_one_day[time_of_day].Add(amount);

                int indexOfSelected = listbox.Items.IndexOf(panel);
                listbox.Items.RemoveAt(indexOfSelected);
                Label label = new Label();
                label.Content = dish.name + "\n Ilość: " + amount;
                listbox.Items.Insert(indexOfSelected, label);

                int row = 3 + 3 * time_of_day;
                Label kcal = (Label)grid.Children.Cast<UIElement>()
                    .First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == 20);
                double temp = (double)kcal.Content + dish.kcal * amount;
                kcal.Content = temp;

                Label protein = (Label)grid.Children.Cast<UIElement>()
                    .First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == 23);
                temp = (double)protein.Content + dish.protein * amount;
                protein.Content = temp;

                Label fat = (Label)grid.Children.Cast<UIElement>()
                    .First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == 26);
                temp = (double)fat.Content + dish.fat * amount;
                fat.Content = temp;

                Label carbs = (Label)grid.Children.Cast<UIElement>()
                    .First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == 29);
                temp = (double)carbs.Content + dish.carbs * amount;
                carbs.Content = temp;
            }
                     
        }

        public Grid drawGrid(Grid grid)
        {
            Clear(grid);
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
