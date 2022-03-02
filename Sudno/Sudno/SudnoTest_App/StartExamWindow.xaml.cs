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
    /// <summary>
    /// Логика взаимодействия для StartExamWindow.xaml
    /// </summary>
    public partial class StartExamWindow : Window
    {
        string id;
        string tpofdistrict;
        string tpofship;
        public StartExamWindow(string UserId, string UserTd, string UserSh)
        {
            InitializeComponent();
            double screenHeight = SystemParameters.FullPrimaryScreenHeight;
            double screenWidth = SystemParameters.FullPrimaryScreenWidth;


            this.Top = (screenHeight - this.Height) / 0x00000002;
            this.Left = (screenWidth - this.Width) / 0x00000002;
            id = UserId;
            tpofdistrict = UserTd;
            tpofship = UserSh;

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
        
            MySqlCommand command = new MySqlCommand("SELECT name, login, pass FROM `users` Where `id` = @id", dbc);
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

        }

        private void back_button(object sender, RoutedEventArgs e)
        {
            this.Hide();
            UserMainWindow userMainWindow = new UserMainWindow(id);
            userMainWindow.Show();
        }
            
        

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Bilet_one bilet_One  = new Bilet_one(id, tpofdistrict, tpofship);
            bilet_One.Show();
        }
    }
}
