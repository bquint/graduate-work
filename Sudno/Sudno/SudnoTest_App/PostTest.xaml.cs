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
using System.Data;

namespace SudnoTest_App
{
    public class Task4
    {
        public string id { get; set; }
        public string FIO { get; set; }
        public string login { get; set; }
        public string pass { get; set; }
        public string role { get; set; }
    }
    public partial class PostTest : Window
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
        public PostTest(string UserId, string UserTd, string UserSh, string Quest, string Quest2, string Quest3,
            string Quest4, string Quest5, string Quest6, string Quest7, string Quest8, string Quest9,
            string Quest10, string Quest11, string Quest12, string Quest13, string Quest14, string Quest15,
            string Quest16, string Quest17, string Quest18, string Quest19, string Quest20)
        {
            InitializeComponent();
            double screenHeight = SystemParameters.FullPrimaryScreenHeight;
            double screenWidth = SystemParameters.FullPrimaryScreenWidth;


            this.Top = (screenHeight - this.Height) / 0x00000002;
            this.Left = (screenWidth - this.Width) / 0x00000002;
            id = UserId;
            tpofdistrict = UserTd;
            tpofship = UserSh;

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

            if  (result >= 8 && result2 >= 8)
            {
                res_text.Text = "Успешно";
            }
            else
            {
                res_text.Text = "Не удовлетворительно";
            }

           
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {

            DB db = new DB();
            
            DataTable table2 = new DataTable();

       
            MySqlDataAdapter adapter2 = new MySqlDataAdapter();


            MySqlCommand command2 = new MySqlCommand("UPDATE `Results` SET `ball` = @ball, `result` = @result WHERE `id_users` = @id", db.GetConnection());
            command2.Parameters.Add("@ball", MySqlDbType.VarChar).Value = result;
            command2.Parameters.Add("@result", MySqlDbType.VarChar).Value = res_text.Text;
            command2.Parameters.Add("@id", MySqlDbType.VarChar).Value = Convert.ToInt32(id);

            adapter2.SelectCommand = command2;
            adapter2.Fill(table2);

            res_res = res_text.Text;
            this.Hide();
            FinalWindow finalWindow = new FinalWindow(id, tpofdistrict, tpofship, result, res_res );
            finalWindow.Show();
        }

        private void n1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
