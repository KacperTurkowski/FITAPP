using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITAPP
{
    class DataBase
    {
        public static Dictionary<string, string> passwords = new Dictionary<string, string>();
        static DataBase()//taki odpowiednik bloku statycznyego w Javie
        {
            passwords.Add("Kacper", "abc");
        }
    }
}
