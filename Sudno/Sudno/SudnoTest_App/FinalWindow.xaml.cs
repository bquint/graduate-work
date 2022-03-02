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
    public class Task10
    {
        public string id { get; set; }
        public string FIO { get; set; }
        public string TypeOfDistrict { get; set; }
        public string TypeOfShip { get; set; }
        public string Result { get; set; }
        public string Ball { get; set; }
    }

    public partial class FinalWindow : Window
    {
        string id;
        string tpofdistrict;
        string tpofship;
        int result;
        string res_res;

        public FinalWindow(string UserId, string UserTd, string UserSh, int Result, string Res_Res)
        {
            InitializeComponent();
            LoadUser(UserId);
            double screenHeight = SystemParameters.FullPrimaryScreenHeight;
            double screenWidth = SystemParameters.FullPrimaryScreenWidth;


            this.Top = (screenHeight - this.Height) / 0x00000002;
            this.Left = (screenWidth - this.Width) / 0x00000002;

            id = UserId;
            tpofdistrict = UserTd;
            tpofship = UserSh;
            result = Result;
            res_res = Res_Res;

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

            MySqlCommand command = new MySqlCommand("SELECT id, name, login, pass FROM `users` Where `id` = @id", dbc);
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

            name.Text = ShowName.Rows[0][1].ToString();
            tpOfDis.Text = ShowTD.Rows[0][0].ToString();
            tpOfSh.Text = ShowSH.Rows[0][0].ToString();
            ball.Text = result.ToString();
            resultat.Text = res_res.ToString();
        }

        void LoadUser(string Userid)
        {
            DB db = new DB();
            MySqlConnection dbc = db.GetConnection();

            if (dbc == null)
            {
                return;
            }
            DataTable ValueTable = new DataTable();
            DataTable Table1 = new DataTable();
            MySqlDataAdapter ValueAdapter = new MySqlDataAdapter();
            MySqlDataAdapter Adapter1 = new MySqlDataAdapter();

            MySqlCommand ValueCommand = new MySqlCommand("SELECT a.id, b.name, c.typeofdistrict, d.typeofship,  result, ball from Results a inner join users b on b.id = a.id_users inner join TypeOfDistrict c on c.id = a.id_typeofdistrict inner join TypeOfShip d on d.id = a.id_typeofship  WHERE  a.id_users = @id" , dbc);
            ValueCommand.Parameters.Add("@id", MySqlDbType.Int32).Value = Convert.ToInt32(Userid);
            ValueAdapter.SelectCommand = ValueCommand;
            ValueAdapter.Fill(ValueTable);

            for (int i = 0; i < ValueTable.Rows.Count; i++)
            {
                Task10 dataUser = new Task10()
                {
                    id = ValueTable.Rows[i][0].ToString(),
                    FIO = ValueTable.Rows[i][1].ToString(),
                    TypeOfDistrict = ValueTable.Rows[i][2].ToString(),
                    TypeOfShip = ValueTable.Rows[i][3].ToString(),
                    Result = ValueTable.Rows[i][4].ToString(),
                    Ball = ValueTable.Rows[i][5].ToString()
                };
                ResList.Items.Add(dataUser);
            }
            MySqlCommand command2 = new MySqlCommand("INSERT INTO `FinalRes` (`FIO`, `TPdistrict`, `TPship`, `Result`, `Ball`) VALUES (@str1, @str2, @str3, @str4, @str5)", db.GetConnection());
            command2.Parameters.Add("@str1", MySqlDbType.VarChar).Value = ValueTable.Rows[0][1].ToString();
            command2.Parameters.Add("@str2", MySqlDbType.VarChar).Value = ValueTable.Rows[0][2].ToString();
            command2.Parameters.Add("@str3", MySqlDbType.VarChar).Value = ValueTable.Rows[0][3].ToString();
            command2.Parameters.Add("@str4", MySqlDbType.VarChar).Value = ValueTable.Rows[0][4].ToString();
            command2.Parameters.Add("@str5", MySqlDbType.VarChar).Value = ValueTable.Rows[0][5].ToString();

            Adapter1.SelectCommand = command2;
            Adapter1.Fill(Table1);

        }

        private void ResList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void work_with_content(object sender, RoutedEventArgs e)
        {

            Application.Current.Shutdown();

        }

        private void ResList_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
