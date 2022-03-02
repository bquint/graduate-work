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
    public class Task12
    {
        public string id { get; set; }
        public string FIO { get; set; }
        public string status { get; set; }
        
    }
    public partial class CheckStatus : Window
    {
        string id;

        public CheckStatus(string UserId)
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
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlDataAdapter adapter2 = new MySqlDataAdapter();
            MySqlCommand count1_command = new MySqlCommand("SELECT COUNT(*) FROM `Results`", dbc);
            MySqlCommand command = new MySqlCommand("SELECT name, login, pass FROM `users` Where `id` = @id", dbc);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Convert.ToInt32(id);
            adapter.SelectCommand = command;
            adapter2.SelectCommand = count1_command;
            adapter2.Fill(count1);
            adapter.Fill(ShowName);
            name.Text = ShowName.Rows[0][0].ToString();
            col.Text = count1.Rows[0][0].ToString();

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

            MySqlCommand ValueCommand = new MySqlCommand("SELECT a.id, b.name, c.status from Results a inner join users b on b.id = a.id_users inner join Status c on c.id = a.id_status ", dbc);
            ValueAdapter.SelectCommand = ValueCommand;
            ValueAdapter.Fill(ValueTable);




            for (int i = 0; i < ValueTable.Rows.Count; i++)
            {
               
                Task12 dataUser = new Task12()
                {
                    id = ValueTable.Rows[i][0].ToString(),
                    FIO = ValueTable.Rows[i][1].ToString(),
                    status = ValueTable.Rows[i][2].ToString()
                   
                };
                UsersList.Items.Add(dataUser);
            }
        }

        private void back_button(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ExamerMainWindow examerMainWindow = new ExamerMainWindow(id);
            examerMainWindow.Show();
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Utv(object sender, RoutedEventArgs e)
        {
            DB db = new DB();
            MySqlConnection dbc = db.GetConnection();

            if (!string.IsNullOrWhiteSpace(id_box.Text))
            {
                db.openConnection();

                MySqlCommand command = new MySqlCommand("UPDATE `Results` SET `id_status` = 3 WHERE `id` = @id", db.GetConnection());
             
                command.Parameters.AddWithValue("id", id_box.Text);


                command.ExecuteNonQuery();
                MessageBox.Show("Вы успешно отредактировали данные");
                db.closeConnection();


            }
            else
            {
                MessageBox.Show("Не должно быть пустых полей");
            }
            UsersList.Items.Clear();
            DB db2 = new DB();
            MySqlConnection dbc2 = db2.GetConnection();

            if (dbc2 == null)
            {
                return;
            }
            DataTable ValueTable = new DataTable();
            MySqlDataAdapter ValueAdapter = new MySqlDataAdapter();

            MySqlCommand ValueCommand = new MySqlCommand("SELECT a.id, b.name, c.status from Results a inner join users b on b.id = a.id_users inner join Status c on c.id = a.id_status ", dbc2);
            ValueAdapter.SelectCommand = ValueCommand;
            ValueAdapter.Fill(ValueTable);




            for (int i = 0; i < ValueTable.Rows.Count; i++)
            {

                Task12 dataUser = new Task12()
                {
                    id = ValueTable.Rows[i][0].ToString(),
                    FIO = ValueTable.Rows[i][1].ToString(),
                    status = ValueTable.Rows[i][2].ToString()

                };
                UsersList.Items.Add(dataUser);
            }
        }

        private void Upd(object sender, RoutedEventArgs e)
        {
            UsersList.Items.Clear();
            DB db2 = new DB();
            MySqlConnection dbc2 = db2.GetConnection();

            if (dbc2 == null)
            {
                return;
            }
            DataTable ValueTable = new DataTable();
            MySqlDataAdapter ValueAdapter = new MySqlDataAdapter();

            MySqlCommand ValueCommand = new MySqlCommand("SELECT a.id, b.name, c.status from Results a inner join users b on b.id = a.id_users inner join Status c on c.id = a.id_status ", dbc2);
            ValueAdapter.SelectCommand = ValueCommand;
            ValueAdapter.Fill(ValueTable);




            for (int i = 0; i < ValueTable.Rows.Count; i++)
            {

                Task12 dataUser = new Task12()
                {
                    id = ValueTable.Rows[i][0].ToString(),
                    FIO = ValueTable.Rows[i][1].ToString(),
                    status = ValueTable.Rows[i][2].ToString()

                };
                UsersList.Items.Add(dataUser);
            }
        }
    }
    
}
