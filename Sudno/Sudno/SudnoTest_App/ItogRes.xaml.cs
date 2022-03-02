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

    public class Task11
    {
        public string id { get; set; }
        public string FIO { get; set; }
        public string district { get; set; }
        public string ship { get; set; }
        public string res { get; set; }
        public string ball { get; set; }
    }

    public partial class ItogRes : Window
    {
        string id;
        public ItogRes(string UserId)
        {
            InitializeComponent();
            LoadUser();
            double screenHeight = SystemParameters.FullPrimaryScreenHeight;
            double screenWidth = SystemParameters.FullPrimaryScreenWidth;


            this.Top = (screenHeight - this.Height) / 0x00000002;
            this.Left = (screenWidth - this.Width) / 0x00000002;
            id = UserId;

            DB db = new DB();
            MySqlConnection dbc = db.GetConnection();
            if (dbc == null)
            {
                return;
            }
            DataTable ShowName = new DataTable();
            DataTable count1 = new DataTable();
            DataTable count2 = new DataTable();
            DataTable count3 = new DataTable();
            MySqlDataAdapter countAdapter1 = new MySqlDataAdapter();
            MySqlDataAdapter countAdapter2 = new MySqlDataAdapter();
            MySqlDataAdapter countAdapter3 = new MySqlDataAdapter();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand count1_command = new MySqlCommand("SELECT COUNT(*) FROM `FinalRes`", dbc);
            MySqlCommand count2_command = new MySqlCommand("SELECT COUNT(*) FROM `FinalRes` WHERE Result = 'Успешно' ", dbc);
            MySqlCommand count3_command = new MySqlCommand("SELECT COUNT(*) FROM `FinalRes` WHERE Result = 'Не удовлетворительно' ", dbc);
            MySqlCommand command = new MySqlCommand("SELECT id, name, login, pass FROM `users` Where `id` = @id", dbc);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Convert.ToInt32(id);

            countAdapter1.SelectCommand = count1_command;
            countAdapter2.SelectCommand = count2_command;
            countAdapter3.SelectCommand = count3_command;
            adapter.SelectCommand = command;
            adapter.Fill(ShowName);
            countAdapter1.Fill(count1);
            countAdapter2.Fill(count2);
            countAdapter3.Fill(count3);
            col.Text = count1.Rows[0][0].ToString();
            col2.Text = count2.Rows[0][0].ToString();
            col3.Text = count3.Rows[0][0].ToString();
            name.Text = ShowName.Rows[0][1].ToString();
        }

        void LoadUser()
        {
            DB db = new DB();
            MySqlConnection dbc = db.GetConnection();

            if (dbc == null)
            {
                return;
            }
            DataTable ValueTable = new DataTable();
            MySqlDataAdapter ValueAdapter = new MySqlDataAdapter();

            MySqlCommand ValueCommand = new MySqlCommand("SELECT id, FIO, TPdistrict, TPship, Result, Ball FROM `FinalRes` ", dbc);
            ValueAdapter.SelectCommand = ValueCommand;
            ValueAdapter.Fill(ValueTable);

            for (int i = 0; i < ValueTable.Rows.Count; i++)
            {
                Task11 dataUser = new Task11()
                {
                    id = ValueTable.Rows[i][0].ToString(),
                    FIO = ValueTable.Rows[i][1].ToString(),
                    district = ValueTable.Rows[i][2].ToString(),
                    ship = ValueTable.Rows[i][3].ToString(),
                    res = ValueTable.Rows[i][4].ToString(),
                    ball = ValueTable.Rows[i][5].ToString()
                };
                listItog.Items.Add(dataUser);
            }
        }
        private void back_button(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ExamerMainWindow examerMainWindow = new ExamerMainWindow(id);
            examerMainWindow.Show();
        }

        private void work_with_content(object sender, RoutedEventArgs e)
        {

        }
    }
}
