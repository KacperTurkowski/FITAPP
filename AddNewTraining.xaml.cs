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

namespace FITAPP
{
    /// <summary>
    /// Logika interakcji dla klasy AddNewTraining.xaml
    /// </summary>
    public partial class AddNewTraining : Window
    {
        List<Exercise>[] exercises = new List<Exercise>[7];
        List<int>[] exercisesAmount = new List<int>[7];
        List<Tag> tags = new List<Tag>();
        TrainingPage page;
        public AddNewTraining(TrainingPage page)
        {
            this.page = page;
            InitializeComponent();
            foreach(Tag tag in DataBase.trainingTag)
                this.wybierz_tag.Items.Add(tag);
            for(int i = 0; i < 7; i++)
            {
                exercises[i] = new List<Exercise>();
                exercisesAmount[i] = new List<int>();
            }
            createTabControl();
        }

        private void createTabControl()
        {

            lista_cwiczen.SelectionChanged += Tab_SelectionChanged;


            TabItem last = new TabItem();
            last.Header = "+";
            lista_cwiczen.Items.Add(last);

            createNewDay();//tworzę dzień pierwszy
        }
        private void createNewDay()
        {
            int number = lista_cwiczen.Items.Count;
            if (number <= 7)
            {
                TabItem item = new TabItem();
                item.Header = "Dzień" + number;
                lista_cwiczen.Items.Insert(number - 1, item);
                lista_cwiczen.SelectedIndex = number-1;
                ListBox listbox = new ListBox();
                listbox.SelectionChanged += List_SelectionChanged;
                listbox.MouseDoubleClick += List_MouseDoubleClick;

                Label last = new Label();
                last.Content = "Dodaj kolejne ćwiczenie";
                listbox.Items.Add(last);

                item.Content = listbox;
            }
        }

        private void List_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBox listbox = (ListBox)sender;
            int day = lista_cwiczen.SelectedIndex;
            Label label;
            try
            {
                label = (Label)listbox.SelectedItem;
            }catch(Exception )
            {
                listbox.Items.Remove(listbox.SelectedItem);
                return;
            }
            for (int i = 0; i < exercises[day].Count; i++)
            {
                string temp1 = exercises[day][i].name + "\nIlość Powtórzen: " + exercisesAmount[day][i];
                
                if (temp1.Equals(label.Content))
                {
                    exercises[day].RemoveAt(i);
                    exercisesAmount[day].RemoveAt(i);
                }
            }

            listbox.Items.Remove(listbox.SelectedItem);
        }

        private Label addnewExercise(Exercise exercise, int amount)
        {
            Label label = new Label();
            label.Content = exercise.name + "\nIlość Powtórzen: " + amount;
            this.exercises[lista_cwiczen.SelectedIndex].Add(exercise);
            this.exercisesAmount[lista_cwiczen.SelectedIndex].Add(amount);
            return label;
        }
        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabItem tabitem = (TabItem)lista_cwiczen.Items[lista_cwiczen.SelectedIndex];
            ListBox listbox = (ListBox)tabitem.Content;
            if(listbox.SelectedIndex == listbox.Items.Count - 1)
            {
                ComboBox combobox = new ComboBox();
                combobox.Text = "wybierz ćwiczenie";
                combobox.Width = this.lista_cwiczen.Width * 0.8;
                combobox.SelectionChanged += Combobox_SelectionChanged;
                foreach(Exercise x in DataBase.exercises)
                {
                    combobox.Items.Add(x);
                }
                TabItem tab = (TabItem)lista_cwiczen.Items[lista_cwiczen.SelectedIndex];
                ListBox listbox2 = (ListBox)tab.Content;
                listbox2.Items.Insert(listbox2.Items.Count - 1, combobox);

                listbox2.SelectedIndex = listbox2.Items.Count - 2;
            }
        }

        private void Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            int i;
            TabItem x = (TabItem)lista_cwiczen.Items[lista_cwiczen.SelectedIndex];
            ListBox listbox = (ListBox)x.Content;
            for(i = 0; i < listbox.Items.Count; i++)
            {
                if (listbox.Items[i].GetType() == typeof(ComboBox) && listbox.Items[i]==comboBox)
                {
                    break;
                }
            }
            Exercise exercise = (Exercise)comboBox.SelectedItem;
            //tu dodać wybieranie ilości
            listbox.Items[i] = addnewExercise(exercise, 5);

        }

        private void Tab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lista_cwiczen.SelectedIndex == lista_cwiczen.Items.Count-1)
            {
                if (lista_cwiczen.SelectedIndex == 7)
                {
                    lista_cwiczen.SelectedIndex --;
                }
                createNewDay();
            }
        }

        private void dodaj_tag_Click(object sender, RoutedEventArgs e)
        {
            Tag tag = (Tag)wybierz_tag.SelectedItem;
            tags.Add(tag);
            Label label = new Label();
            label.Content = tag.name +"   X";
            label.Background = Brushes.Gray;
            label.FontSize = 18;
            label.Margin = new Thickness(5);
            label.MouseDoubleClick += Label_MouseDoubleClick;
            this.tagi.Children.Add(label);
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Label tag = (Label)sender;
            foreach(Tag t in tags)
            {
                if (tag.Content.Equals(t.name + "   X"))
                {
                    tags.Remove(t);
                    break;
                }
            }
            this.tagi.Children.Remove(tag);
        }

        private void dodaj_trening_Click(object sender, RoutedEventArgs e)
        {
            if (!nazwa_treningu.Text.Equals(""))
            {
                foreach (Training training in DataBase.trainings)
                {
                    if (training.name.Equals(nazwa_treningu.Text))
                    {
                        System.Windows.MessageBox.Show("Trening o tej nazwie został już utworzony");
                        return;
                    }
                }
                //nazwa jest ok
                //ile dni utworzonych
                int count = 0;
                for (int i = 0; i < 7; i++)
                {
                    if (exercises[i].Count != 0)
                        count++;
                }
                if (count == 0)//wszystkie dni nie mają treningów
                {
                    MessageBox.Show("Nie dodano ćwiczeń");
                    return;
                }
                else if (count == 1)//trening jednodniowy
                {
                    for(int i = 0; i < 7; i++)
                    {
                        List<Exercise> x = exercises[i];
                        if(x.Count != 0)
                        {
                            Training training = new Training(nazwa_treningu.Text, x, exercisesAmount[i]);
                            training.description = opis_treningu.Text;
                            training.tags = tags;
                            DataBase.trainings.Add(training);
                        }
                    }
                }
                else
                { //jeśli jakiś dzień jest pusty to go usuwam
                    List<Exercise>[] resultList = new List<Exercise>[7];
                    List<int>[] resultAmount = new List<int>[7];
                    int temp = 0;
                    for(int i = 0; i < 7; i++)
                    {
                        resultList[i] = new List<Exercise>();
                        resultAmount[i] = new List<int>();

                        List<Exercise> x = exercises[i];
                        if (x.Count != 0)
                        {
                            resultList[temp] = x;
                            resultAmount[temp] = exercisesAmount[temp];
                            temp++;
                        }
                    }
                    Training training = new Training(nazwa_treningu.Text, resultList, resultAmount);
                    for(int i = 0; i < temp; i++)
                    {
                        training.days[i] = true;
                    }
                    training.description = opis_treningu.Text;
                    training.tags = tags;
                    DataBase.trainings.Add(training);
                }
            }
            else
                MessageBox.Show("Musisz podać nazwę treningu");
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
            page.grid = page.drawGrid(page.grid);
            page.grid = page.drawComponent(page.grid);
        }
    }
}
