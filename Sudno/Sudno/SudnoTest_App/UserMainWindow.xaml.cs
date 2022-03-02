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
    /// Логика взаимодействия для UserMainWindow.xaml
    /// </summary>
    public partial class UserMainWindow : Window
    {
        string id;
        string tpofdistrict;
        string tpofship;
   
     
        public UserMainWindow(string UserId)
        {
            InitializeComponent();
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
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT name  FROM `users` Where `id` = @id", dbc);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Convert.ToInt32(id);
            adapter.SelectCommand = command;
            adapter.Fill(ShowName);
            name.Text = ShowName.Rows[0][0].ToString();
            enab.IsEnabled = false;
       
        }

        private void back_button(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {


            DB db = new DB();

            DataTable table1 = new DataTable();
            DataTable table2 = new DataTable();
            DataTable table3 = new DataTable();
            DataTable table4 = new DataTable();

            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            MySqlDataAdapter adapter2 = new MySqlDataAdapter();
            MySqlDataAdapter adapter3 = new MySqlDataAdapter();
            MySqlDataAdapter adapter4 = new MySqlDataAdapter();

            MySqlCommand command1 = new MySqlCommand("SELECT id FROM `users` WHERE `name` = @name ", db.GetConnection());
            command1.Parameters.Add("@name", MySqlDbType.VarChar).Value = name.Text;

            MySqlCommand command2 = new MySqlCommand("SELECT id FROM `TypeOfDistrict` WHERE `typeofdistrict` = @identic ", db.GetConnection());
            command2.Parameters.Add("@identic", MySqlDbType.VarChar).Value = identic.Text;

            MySqlCommand command3 = new MySqlCommand("SELECT id FROM `TypeOfShip` WHERE `typeofship` = @identic2 ", db.GetConnection());
            command3.Parameters.Add("@identic2", MySqlDbType.VarChar).Value = identic2.Text;

            adapter1.SelectCommand = command1;
            adapter1.Fill(table1);
            adapter2.SelectCommand = command2;
            adapter2.Fill(table2);
            tpofdistrict = table2.Rows[0][0].ToString(); 
            adapter3.SelectCommand = command3;
            adapter3.Fill(table3);
            tpofship = table3.Rows[0][0].ToString();

            MySqlCommand command4 = new MySqlCommand("INSERT INTO `Results` (`id_users`, `id_typeofdistrict`, `id_typeofship`, `id_status`) VALUES (@str1, @str2, @str3, 4)", db.GetConnection());
            command4.Parameters.Add("@str1", MySqlDbType.VarChar).Value = table1.Rows[0][0].ToString();
            command4.Parameters.Add("@str2", MySqlDbType.VarChar).Value = table2.Rows[0][0].ToString();
            command4.Parameters.Add("@str3", MySqlDbType.VarChar).Value = table3.Rows[0][0].ToString();

              


            adapter4.SelectCommand = command4;
            adapter4.Fill(table4);
            MessageBox.Show("Спасибо, ожидайте, когда экзаменатор начнет экзамен");
            enab.IsEnabled = true;
            ena.IsEnabled = false;
        }

        private void Go_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            StartExamWindow startExamWindow = new StartExamWindow( id, tpofdistrict, tpofship) ;
            startExamWindow.Show();
        }
    }
}
