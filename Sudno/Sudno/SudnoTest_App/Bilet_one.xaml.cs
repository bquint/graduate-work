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
using MySql.Data.MySqlClient;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace SudnoTest_App
{
    /// <summary>
    /// Логика взаимодействия для Bilet_one.xaml
    /// </summary>
    public partial class Bilet_one : Window
    {
        string id;
        string tpofdistrict;
        string tpofship;
        string quest, quest2, quest3, quest4,
        quest5, quest6, quest7, quest8, quest9, 
        quest10, quest11, quest12, quest13, quest14,
        quest15, quest16, quest17, quest18, quest19, quest20;
        TimeSpan time;
        public Bilet_one(string UserId, string UserTd, string UserSh)
        {
            InitializeComponent();
            double screenHeight = SystemParameters.FullPrimaryScreenHeight;
            double screenWidth = SystemParameters.FullPrimaryScreenWidth;


            this.Top = (screenHeight - this.Height) / 0x00000002;
            this.Left = (screenWidth - this.Width) / 0x00000002;
            id = UserId;
            tpofdistrict = UserTd;
            tpofship = UserSh;
            quest = "d";
            quest2 = "";
            quest3 = "";
            quest4 = "";
            quest5 = "";
            quest6 = "";
            quest7 = "";
            quest8 = "";
            quest9 = "";
            quest10 = "";
            quest11 = "";
            quest12 = "";
            quest13 = "";
            quest14 = "";
            quest15 = "";
            quest16 = "";
            quest17 = "";
            quest18 = "";
            quest19 = "";
            quest20 = "";
            time = TimeSpan.FromMinutes(30);
            MainFrame.Content = new Page1( id, tpofdistrict, tpofship, quest, quest2, 
            quest3, quest4, quest5, quest6, quest7, quest8,quest9, quest10, quest11, 
            quest12, quest13, quest14, quest15, quest16,quest17, quest18, quest19, quest20, time);
        }

        private void back_button(object sender, RoutedEventArgs e)
        {

        }
    }
}
