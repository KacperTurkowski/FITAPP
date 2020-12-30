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
        }
        public void Log_out(object sender, RoutedEventArgs e)
        {
            Login oknologowania = new Login(this);
            oknologowania.Show();
            this.Hide();
        }
    }
}
