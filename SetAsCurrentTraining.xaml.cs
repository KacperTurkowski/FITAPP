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
    /// Logika interakcji dla klasy SetAsCurrentTraining.xaml
    /// </summary>
    public partial class SetAsCurrentTraining : Window
    {
        Training training;
        public SetAsCurrentTraining(Training training)
        {
            this.training = training;
            
            InitializeComponent();
            this.nazwa_treningu.Content += training.name;
        }

        private void Akceptuj_Click(object sender, RoutedEventArgs e)
        {
            //podsumowanie
            bool[] days = new bool[7];
            days[0] = (bool)this.Poniedzialek.IsChecked;
            days[1] = (bool)this.Wtorek.IsChecked;
            days[2] = (bool)this.Sroda.IsChecked;
            days[3] = (bool)this.Czwartek.IsChecked;
            days[4] = (bool)this.Piatek.IsChecked;
            days[5] = (bool)this.Sobota.IsChecked;
            days[6] = (bool)this.Niedziela.IsChecked;

            bool check = false;
            foreach (bool b in days)
                if (b) check = true;

            if (!check)
                MessageBox.Show("Nie wybrano żadnego dnia treningowego");
            else
            {
                DateTime date;
                try
                {
                    date = (DateTime)this.Kalendarz.SelectedDate;//Wybrano datę
                }catch(InvalidOperationException)
                {
                    date = DateTime.Now;
                    MessageBox.Show("Nie wybrano daty\n Ustalono datę na dzisiejszą");//ustawia datę na dzisiejszą
                }
                
                if (date.ToString().Substring(0,10).Equals(DateTime.Now.ToString().Substring(0, 10)))//jeśli data ustalona to data dzisiejsza
                {

                    //czy dzień tyogdnia wybranej daty zgadza się z dniem treningowym                    
                    int a = (int)DateTime.Now.DayOfWeek;
                    if(days[(int)DateTime.Now.DayOfWeek])
                    {
                        DataBase.todayT = training;
                        DataBase.todayT.exercises = new List<Exercise>();
                    }
                    else//Dzień tygodnia zgadza się
                    {
                        DataBase.todayT = training;
                        DataBase.todayT.exercises = training.exercisesD[0];
                    }
                }
                else
                {
                    DataBase.todayT = training;
                    DataBase.todayT.exercises = new List<Exercise>();
                }
                this.Close();
            }
        }

        private void Wszystko_Checked(object sender, RoutedEventArgs e)
        {
            this.Poniedzialek.IsChecked = true;
            this.Wtorek.IsChecked = true;
            this.Sroda.IsChecked = true;
            this.Czwartek.IsChecked = true;
            this.Piatek.IsChecked = true;
            this.Sobota.IsChecked = true;
            this.Niedziela.IsChecked = true;
        }

        private void Wszystko_Unchecked(object sender, RoutedEventArgs e)
        {
            this.Poniedzialek.IsChecked = false;
            this.Wtorek.IsChecked = false;
            this.Sroda.IsChecked = false;
            this.Czwartek.IsChecked = false;
            this.Piatek.IsChecked = false;
            this.Sobota.IsChecked = false;
            this.Niedziela.IsChecked = false;
        }
    }
}
