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
    /// Логика взаимодействия для AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        string id;

        public AdminMainWindow()
        {
        }

        public AdminMainWindow(string UserId)
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

        }

        private void back_button(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void me_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdminPersonalData adminPersonalData = new AdminPersonalData(id);
            adminPersonalData.Show();
        }

        private void exam_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdminExamers adminExamers = new AdminExamers(id);
            adminExamers.Show();
        }


        private void zajav_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdminUsers adminUsers = new AdminUsers(id);
            adminUsers.Show();
        }

        private void add_button(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddQuestadmin form1 = new AddQuestadmin(id);
            form1.Show();
        }

        private void add2_button(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddQuestShip form2 = new AddQuestShip(id);
            form2.Show();
        }

        private void name_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
