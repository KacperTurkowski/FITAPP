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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FITAPP
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //Najpierw należy się zalogować
            Login oknoLogowania = new Login(this);
            oknoLogowania.Show();
            this.Hide();
            //po wpisanniu loginu i hasła main się pokaże
            InitializeComponent();
            panel = getPanel(grid);
            
            panel = new MainPage().drawGrid(panel);
            panel = new MainPage().drawComponent(panel);
        }

        public void Log_out(object sender, RoutedEventArgs e)
        {
            Login oknologowania = new Login(this);
            oknologowania.Show();
            this.Hide();
        }
        private static Grid getPanel(Grid grid)
        {
            return (Grid)grid.Children
                .Cast<UIElement>()
                .First(e => Grid.GetRow(e) == 12 && Grid.GetColumn(e) == 16);
        }
        private void strona_glowna_Click(object sender, RoutedEventArgs e)
        {
            Grid panel = getPanel(grid);
            panel = new MainPage().drawGrid(panel);
            panel = new MainPage().drawComponent(panel);
        }

        private void diety_Click(object sender, RoutedEventArgs e)
        {
            Grid panel = getPanel(grid);
            panel = new DietPage().drawGrid(panel);
            panel = new DietPage().drawComponent(panel);
        }
    }
}
