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
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Threading;


namespace SudnoTest_App
{
    public class Task100
    {
        public string id { get; set; }
        public string FIO { get; set; }
        public string login { get; set; }
        public string pass { get; set; }
        public string role { get; set; }
    }
    public partial class PostPage : Page
    {
        string id;
        string tpofdistrict;
        string tpofship;
        int ostatokO;
        string res_res;
        int a1 = Properties.Settings.Default.chk1;
        int a2 = Properties.Settings.Default.chk2;
        int a3 = Properties.Settings.Default.chk3;
        int a4 = Properties.Settings.Default.chk4;
        int a5 = Properties.Settings.Default.chk5;
        int a6 = Properties.Settings.Default.chk6;
        int a7 = Properties.Settings.Default.chk7;
        int a8 = Properties.Settings.Default.chk8;
        int a9 = Properties.Settings.Default.chk9;
        int a10 = Properties.Settings.Default.chk10;
        int b1 = Properties.Settings.Default.chk11;
        int b2 = Properties.Settings.Default.chk12;
        int b3 = Properties.Settings.Default.chk13;
        int b4 = Properties.Settings.Default.chk14;
        int b5 = Properties.Settings.Default.chk15;
        int b6 = Properties.Settings.Default.chk16;
        int b7 = Properties.Settings.Default.chk17;
        int b8 = Properties.Settings.Default.chk18;
        int b9 = Properties.Settings.Default.chk19;
        int b10 = Properties.Settings.Default.chk20;
        int result = 0;
        int result2 = 0;
        int ost1;
        int ost2;
        string quest, quest2, quest3, quest4,
        quest5, quest6, quest7, quest8, quest9,
        quest10, quest11, quest12, quest13, quest14,
        quest15, quest16, quest17, quest18, quest19, quest20;
        DispatcherTimer dispatcherTimer;
        TimeSpan time;
        private void n16_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page16(id, tpofdistrict, tpofship, quest, quest2,
        quest3, quest4, quest5, quest6, quest7, quest8, quest9, quest10, quest11,
        quest12, quest13, quest14, quest15, quest16, quest17, quest18, quest19, quest20, time));
        }

        private void n17_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page17(id, tpofdistrict, tpofship, quest, quest2,
        quest3, quest4, quest5, quest6, quest7, quest8, quest9, quest10, quest11,
        quest12, quest13, quest14, quest15, quest16, quest17, quest18, quest19, quest20, time));
        }

        private void n18_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page18(id, tpofdistrict, tpofship, quest, quest2,
        quest3, quest4, quest5, quest6, quest7, quest8, quest9, quest10, quest11,
        quest12, quest13, quest14, quest15, quest16, quest17, quest18, quest19, quest20, time));
        }

        private void n19_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page19(id, tpofdistrict, tpofship, quest, quest2,
        quest3, quest4, quest5, quest6, quest7, quest8, quest9, quest10, quest11,
        quest12, quest13, quest14, quest15, quest16, quest17, quest18, quest19, quest20, time));
        }

        private void n20_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page20(id, tpofdistrict, tpofship, quest, quest2,
        quest3, quest4, quest5, quest6, quest7, quest8, quest9, quest10, quest11,
        quest12, quest13, quest14, quest15, quest16, quest17, quest18, quest19, quest20, time));
        }

        private void n15_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page15(id, tpofdistrict, tpofship, quest, quest2,
        quest3, quest4, quest5, quest6, quest7, quest8, quest9, quest10, quest11,
        quest12, quest13, quest14, quest15, quest16, quest17, quest18, quest19, quest20, time));
        }

        private void n14_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page14(id, tpofdistrict, tpofship, quest, quest2,
        quest3, quest4, quest5, quest6, quest7, quest8, quest9, quest10, quest11,
        quest12, quest13, quest14, quest15, quest16, quest17, quest18, quest19, quest20, time));
        }

        private void n13_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page13(id, tpofdistrict, tpofship, quest, quest2,
        quest3, quest4, quest5, quest6, quest7, quest8, quest9, quest10, quest11,
        quest12, quest13, quest14, quest15, quest16, quest17, quest18, quest19, quest20, time));
        }

        private void n12_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page12(id, tpofdistrict, tpofship, quest, quest2,
        quest3, quest4, quest5, quest6, quest7, quest8, quest9, quest10, quest11,
        quest12, quest13, quest14, quest15, quest16, quest17, quest18, quest19, quest20, time));
        }

        private void n11_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page11(id, tpofdistrict, tpofship, quest, quest2,
        quest3, quest4, quest5, quest6, quest7, quest8, quest9, quest10, quest11,
        quest12, quest13, quest14, quest15, quest16, quest17, quest18, quest19, quest20, time));
        }

        private void n10_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page10(id, tpofdistrict, tpofship, quest, quest2,
        quest3, quest4, quest5, quest6, quest7, quest8, quest9, quest10, quest11,
        quest12, quest13, quest14, quest15, quest16, quest17, quest18, quest19, quest20, time));
        }

        private void n9_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page9(id, tpofdistrict, tpofship, quest, quest2,
        quest3, quest4, quest5, quest6, quest7, quest8, quest9, quest10, quest11,
        quest12, quest13, quest14, quest15, quest16, quest17, quest18, quest19, quest20, time));
        }

        private void n8_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page8(id, tpofdistrict, tpofship, quest, quest2,
        quest3, quest4, quest5, quest6, quest7, quest8, quest9, quest10, quest11,
        quest12, quest13, quest14, quest15, quest16, quest17, quest18, quest19, quest20, time));
        }

        private void n7_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page7(id, tpofdistrict, tpofship, quest, quest2,
        quest3, quest4, quest5, quest6, quest7, quest8, quest9, quest10, quest11,
        quest12, quest13, quest14, quest15, quest16, quest17, quest18, quest19, quest20, time));
        }

        private void n6_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page6(id, tpofdistrict, tpofship, quest, quest2,
        quest3, quest4, quest5, quest6, quest7, quest8, quest9, quest10, quest11,
        quest12, quest13, quest14, quest15, quest16, quest17, quest18, quest19, quest20, time));
        }

        private void n5_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page5(id, tpofdistrict, tpofship, quest, quest2,
        quest3, quest4, quest5, quest6, quest7, quest8, quest9, quest10, quest11,
        quest12, quest13, quest14, quest15, quest16, quest17, quest18, quest19, quest20, time));
        }

        private void n4_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page4(id, tpofdistrict, tpofship, quest, quest2,
        quest3, quest4, quest5, quest6, quest7, quest8, quest9, quest10, quest11,
        quest12, quest13, quest14, quest15, quest16, quest17, quest18, quest19, quest20, time));
        }

        private void n3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page3(id, tpofdistrict, tpofship, quest, quest2,
        quest3, quest4, quest5, quest6, quest7, quest8, quest9, quest10, quest11,
        quest12, quest13, quest14, quest15, quest16, quest17, quest18, quest19, quest20, time));
        }

        private void n2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2(id, tpofdistrict, tpofship, quest, quest2,
         quest3, quest4, quest5, quest6, quest7, quest8, quest9, quest10, quest11,
         quest12, quest13, quest14, quest15, quest16, quest17, quest18, quest19, quest20, time));
        }

        private void n1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1(id, tpofdistrict, tpofship, quest, quest2,
         quest3, quest4, quest5, quest6, quest7, quest8, quest9, quest10, quest11,
         quest12, quest13, quest14, quest15, quest16, quest17, quest18, quest19, quest20, time));
        }

        int chk;
        public PostPage(string UserId, string UserTd, string UserSh, string Quest, string Quest2, string Quest3,
            string Quest4, string Quest5, string Quest6, string Quest7, string Quest8, string Quest9,
            string Quest10, string Quest11, string Quest12, string Quest13, string Quest14, string Quest15,
            string Quest16, string Quest17, string Quest18, string Quest19, string Quest20, TimeSpan Time)
        {
            InitializeComponent();
            time = Time;
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Start();
            double screenHeight = SystemParameters.FullPrimaryScreenHeight;
            double screenWidth = SystemParameters.FullPrimaryScreenWidth;

            id = UserId;
            tpofdistrict = UserTd;
            tpofship = UserSh;

            if (Properties.Settings.Default.color1 == 1)
            {
                n1.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color2 == 1)
            {
                n2.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color3 == 1)
            {
                n3.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color4 == 1)
            {
                n4.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color5 == 1)
            {
                n5.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color6 == 1)
            {
                n6.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color7 == 1)
            {
                n7.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color8 == 1)
            {
                n8.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color9 == 1)
            {
                n9.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color10 == 1)
            {
                n10.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color11 == 1)
            {
                n11.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color12 == 1)
            {
                n12.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color13 == 1)
            {
                n13.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color14 == 1)
            {
                n14.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color15 == 1)
            {
                n15.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color16 == 1)
            {
                n16.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color17 == 1)
            {
                n17.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color18 == 1)
            {
                n18.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color19 == 1)
            {
                n19.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color20 == 1)
            {
                n20.Foreground = Brushes.Green;
            }

            if (a1 == 1)
            {
                result = result + 1;
            }
            if (a2 == 1)
            {
                result = result + 1;
            }
            if (a3 == 1)
            {
                result = result + 1;
            }
            if (a4 == 1)
            {
                result = result + 1;
            }
            if (a5 == 1)
            {
                result = result + 1;
            }
            if (a6 == 1)
            {
                result = result + 1;
            }
            if (a7 == 1)
            {
                result = result + 1;
            }
            if (a8 == 1)
            {
                result = result + 1;
            }
            if (a9 == 1)
            {
                result = result + 1;
            }
            if (a10 == 1)
            {
                result = result + 1;
            }
            if (b1 == 1)
            {
                result2 = result2 + 1;
            }
            if (b2 == 1)
            {
                result2 = result2 + 1;
            }
            if (b3 == 1)
            {
                result2 = result2 + 1;
            }
            if (b4 == 1)
            {
                result2 = result2 + 1;
            }
            if (b5 == 1)
            {
                result2 = result2 + 1;
            }
            if (b6 == 1)
            {
                result2 = result2 + 1;
            }
            if (b7 == 1)
            {
                result2 = result2 + 1;
            }
            if (b8 == 1)
            {
                result2 = result2 + 1;
            }
            if (b9 == 1)
            {
                result2 = result2 + 1;
            }
            if (b10 == 1)
            {
                result2 = result2 + 1;
            }
            if (a1 == 0)
            {
                ost1 = ost1 + 1;
            }
            if (a2 == 0)
            {
                ost1 = ost1 + 1;
            }
            if (a3 == 0)
            {
                ost1 = ost1 + 1;
            }
            if (a4 == 0)
            {
                ost1 = ost1 + 1;
            }
            if (a5 == 0)
            {
                ost1 = ost1 + 1;
            }
            if (a6 == 0)
            {
                ost1 = ost1 + 1;
            }
            if (a7 == 0)
            {
                ost1 = ost1 + 1;
            }
            if (a8 == 0)
            {
                ost1 = ost1 + 1;
            }
            if (a9 == 0)
            {
                ost1 = ost1 + 1;
            }
            if (a10 == 0)
            {
                ost1 = ost1 + 1;
            }
            if (b1 == 0)
            {
                ost2 = ost2 + 1;
            }
            if (b2 == 0)
            {
                ost2 = ost2 + 1;
            }
            if (b3 == 0)
            {
                ost2 = ost2 + 1;
            }
            if (b4 == 0)
            {
                ost2 = ost2 + 1;
            }
            if (b5 == 0)
            {
                ost2 = ost2 + 1;
            }
            if (b6 == 0)
            {
                ost2 = ost2 + 1;
            }
            if (b7 == 0)
            {
                ost2 = ost2 + 1;
            }
            if (b8 == 0)
            {
                ost2 = ost2 + 1;
            }
            if (b9 == 0)
            {
                ost2 = ost2 + 1;
            }
            if (b10 == 0)
            {
                ost2 = ost2 + 1;
            }
            result = result + result2;
            ostatokO = ost1 + ost2;
            ost1 = 10 - ost1;
            ost2 = 10 - ost2;
            DB db = new DB();
            MySqlConnection dbc = db.GetConnection();
            if (dbc == null)
            {
                return;
            }
            DataTable ShowName = new DataTable();
            DataTable ShowTD = new DataTable();
            DataTable ShowSH = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            MySqlDataAdapter adapter2 = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT  name, login, pass FROM `users` Where `id` = @id", dbc);
            MySqlCommand command1 = new MySqlCommand("SELECT typeofdistrict FROM `TypeOfDistrict` Where `id` = @id_d", dbc);
            MySqlCommand command2 = new MySqlCommand("SELECT typeofship FROM `TypeOfShip` Where `id` = @id_s", dbc);

            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Convert.ToInt32(id);
            command1.Parameters.Add("@id_d", MySqlDbType.VarChar).Value = Convert.ToInt32(tpofdistrict);
            command2.Parameters.Add("@id_s", MySqlDbType.VarChar).Value = Convert.ToInt32(tpofship);

            adapter.SelectCommand = command;
            adapter1.SelectCommand = command1;
            adapter2.SelectCommand = command2;

            adapter.Fill(ShowName);
            adapter1.Fill(ShowTD);
            adapter2.Fill(ShowSH);
            name.Text = ShowName.Rows[0][0].ToString();
            tpOfDis.Text = ShowTD.Rows[0][0].ToString();
            tpOfSh.Text = ShowSH.Rows[0][0].ToString();
            bil1.Text = ost1.ToString();
            bil2.Text = ost2.ToString();
            otv.Text = ostatokO.ToString();
            res.Text = result.ToString();

            if (result >= 8 && result2 >= 8)
            {
                res_text.Text = "Успешно";
            }
            else
            {
                res_text.Text = "Не удовлетворительно";
            }

        }


        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (time == TimeSpan.Zero) dispatcherTimer.Stop();
            else
            {
                time = time.Add(TimeSpan.FromSeconds(-1));
                MyTime.Text = time.ToString("c");
            }
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {

            DB db = new DB();

            DataTable table2 = new DataTable();
            DataTable table3 = new DataTable();


            MySqlDataAdapter adapter2 = new MySqlDataAdapter();
            MySqlDataAdapter adapter3 = new MySqlDataAdapter();


            MySqlCommand command2 = new MySqlCommand("UPDATE `Results` SET `ball` = @ball, `result` = @result WHERE `id_users` = @id", db.GetConnection());
            MySqlCommand command3 = new MySqlCommand("UPDATE `Results` SET `id_status` = 2 WHERE `id_users` = @id", db.GetConnection());
            command2.Parameters.Add("@ball", MySqlDbType.VarChar).Value = result;
            command2.Parameters.Add("@result", MySqlDbType.VarChar).Value = res_text.Text;
            command2.Parameters.Add("@id", MySqlDbType.VarChar).Value = Convert.ToInt32(id);
            command3.Parameters.Add("@id", MySqlDbType.VarChar).Value = Convert.ToInt32(id);
            adapter2.SelectCommand = command2;
            adapter3.SelectCommand = command3;
            adapter2.Fill(table2);
            adapter3.Fill(table3);
            res_res = res_text.Text;

            NavigationService.Navigate(new FinalPage(id, tpofdistrict, tpofship, result, res_res));
            /*this.Hide();
            FinalWindow finalWindow = new FinalWindow(id, tpofdistrict, tpofship, result, res_res);
            finalWindow.Show();*/
        }

        private void Back(object sender, RoutedEventArgs e)
        {
          
            NavigationService.Navigate(new Page20(id, tpofdistrict, tpofship, quest, quest2,
            quest3, quest4, quest5, quest6, quest7, quest8, quest9, quest10, quest11,
            quest12, quest13, quest14, quest15, quest16, quest17, quest18, quest19, quest20, time));
        }
    }
}
