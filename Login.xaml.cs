using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Logika interakcji dla klasy Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Window Main;
        public Login(Window parent)
        {
            this.Main = parent;
            InitializeComponent();
        }

        private void zaloguj_Click(object sender, RoutedEventArgs e)
        {
            this.PassError.Content = "";
            this.LoginError.Content = "";
            string pass = "";
            if (DataBase.passwords.TryGetValue(this.LoginBox.Text, out pass))
            {
                if (!this.Password.Password.Equals(pass))//nie wiem dlaczego tu jest zaprzeczenie
                {
                    //złe hasło
                    this.PassError.Content = "Błędne Hasło";
                }
                else
                {
                    //dobre hasło
                    this.Main.Show();

                    this.Close();
                }
            }
            else
            {
                this.LoginError.Content = "Błędny Login";
                //zły login
            }
        }
        void Login_Closing(object sender, CancelEventArgs e)
        {
            if (!this.Main.IsVisible)
                this.Main.Close();
        }
    }
}
