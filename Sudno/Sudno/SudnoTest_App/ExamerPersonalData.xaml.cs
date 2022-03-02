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
    /// Логика взаимодействия для ExamerPersonalData.xaml
    /// </summary>
    public partial class ExamerPersonalData : Window
    {
        string id;
        public ExamerPersonalData(string UserId)
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
            MySqlCommand command = new MySqlCommand("SELECT name, login, pass FROM `users` Where `id` = @id", dbc);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Convert.ToInt32(id);
            adapter.SelectCommand = command;
            adapter.Fill(ShowName);
            name.Text = ShowName.Rows[0][0].ToString();
            fIO.Text = ShowName.Rows[0][0].ToString();
            login.Text = ShowName.Rows[0][1].ToString();
            pass.Text = ShowName.Rows[0][2].ToString();
            
        }


        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            DB db = new DB();
            MySqlConnection dbc = db.GetConnection();

            if (!string.IsNullOrWhiteSpace(name.Text) && !string.IsNullOrWhiteSpace(login.Text) && !string.IsNullOrWhiteSpace(pass.Text))
            {
                db.openConnection();

                MySqlCommand command = new MySqlCommand("UPDATE `users` SET `name` = @name, `login` = @login , `pass` = @pass WHERE `id` = @id", db.GetConnection());
                command.Parameters.AddWithValue("login", login.Text);
                command.Parameters.AddWithValue("pass", pass.Text);
                command.Parameters.AddWithValue("name", fIO.Text);
                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Convert.ToInt32(id);


                command.ExecuteNonQuery();
                MessageBox.Show("Вы успешно отредактировали данные");
                db.closeConnection();


            }
            else
            {
                MessageBox.Show("Не должно быть пустых полей");
            }

            DB db2 = new DB();
            MySqlConnection dbc2 = db2.GetConnection();
            if (dbc2 == null)
            {
                return;
            }
            DataTable ShowName = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command1 = new MySqlCommand("SELECT name, login, pass FROM `users` Where `id` = @id", dbc2);
            command1.Parameters.Add("@id", MySqlDbType.VarChar).Value = Convert.ToInt32(id);
            adapter.SelectCommand = command1;
            adapter.Fill(ShowName);
            name.Text = ShowName.Rows[0][0].ToString();
            fIO.Text = ShowName.Rows[0][0].ToString();
            login.Text = ShowName.Rows[0][1].ToString();
            pass.Text = ShowName.Rows[0][2].ToString();
            
        }

        private void back_button(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ExamerMainWindow examerMainWindow = new ExamerMainWindow(id);
            examerMainWindow.Show();
        }
    }
}
