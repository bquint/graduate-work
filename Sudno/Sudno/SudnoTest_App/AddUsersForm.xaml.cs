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
    /// Логика взаимодействия для AddUsersForm.xaml
    /// </summary>
    public partial class AddUsersForm : Window
    {
        string id;
        public AddUsersForm(string UserId)
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
            AdminUsers adminUsers = new AdminUsers(id);
            adminUsers.Show();
        }

        private void Gen_click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            Char[] pwdChars = new Char[26] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            login.Text = String.Empty;
            for (int i = 0; i < 6; i++)
                login.Text += pwdChars[rnd.Next(0, 25)];
        }

        private void Gen_click2(object sender, RoutedEventArgs e)
        {
            Random rnd1 = new Random();
            Char[] pwdChars1 = new Char[36] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            pass.Text = String.Empty;
            for (int j = 0; j < 6; j++)
                pass.Text += pwdChars1[rnd1.Next(0, 35)];
        }

        private void Add_click(object sender, RoutedEventArgs e)
        {
            if (FIO.Text == "" && login.Text == "" && pass.Text == "" && Role.Text == "")
            {
                MessageBox.Show("Заполните поля!");
                return;
            }
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `pass`, `name`, `role`) VALUES (@login, @pass, @name, @role)", db.GetConnection());

            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass.Text;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = FIO.Text;
            command.Parameters.Add("@role", MySqlDbType.VarChar).Value = Role.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Данные были записаны");
                this.Hide();
                AdminUsers adminUsers = new AdminUsers(id);
                adminUsers.Show();
            }
            else
                MessageBox.Show("Не удалось записать данные");

            db.closeConnection();
        }

    }
}
