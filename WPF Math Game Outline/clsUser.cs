using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Math_Game_Outline
{
    class clsUser
    {
        //Static Name
        private static string name;
        public static string Name
        {
            get { return name; }
            set { name = value; }
        }
        //Static Age
        private static int age;
        public static int Age
        {
            get { return age; }
            set { age = value; }
        }
        //Static iNumberCorrect
        private static int iNumberCorrect;
        public static int INumberCorrect
        {
            get { return iNumberCorrect; }
            set { iNumberCorrect = value; }
        }
        //Static iGameSeconds
        private static int iGameSeconds;
        public static int GameSeconds
        {
            get { return iGameSeconds; }
            set { iGameSeconds = value;}
        }
    }
}
