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
    /// Логика взаимодействия для EditUsers.xaml
    /// </summary>
    public partial class EditUsers : Window
    {
        string id;

        public EditUsers(string UserId)
        {
            InitializeComponent();
            identic.Text = adminData.id;
            FIO.Text = adminData.FIO;
            login.Text = adminData.login;
            pass.Text = adminData.pass;
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

            db.openConnection();
            MySqlCommand getComboBoxValues;
            DataTable comboBoxTable = new DataTable();
            MySqlDataAdapter comboBoxAdapter = new MySqlDataAdapter();
            getComboBoxValues = new MySqlCommand("SELECT id, role FROM `users` WHERE role = 'Заявитель'", dbc);
            getComboBoxValues.Parameters.Add("@id", MySqlDbType.VarChar).Value = identic;

            comboBoxAdapter.SelectCommand = getComboBoxValues;
            comboBoxAdapter.Fill(comboBoxTable);
            mainPanel.DataContext = comboBoxTable.DefaultView;
            db.closeConnection();
        }

        private void back_button(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdminUsers adminUsers = new AdminUsers(id);
            adminUsers.Show();
        }

        private void Show_click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(identic.Text))
            {
                String Search_id = identic.Text;
                DB db = new DB();
                MySqlConnection dbc = db.GetConnection();
                if (dbc == null)
                {
                    return;
                }
                DataTable ShowName = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT * FROM `users` Where `id` = @id", dbc);
                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Search_id;
                adapter.SelectCommand = command;
                adapter.Fill(ShowName);
                if (ShowName.Rows.Count > 0)
                {
                    if (ShowName.Rows[0][4].ToString() == "Заявитель")
                    {
                        FIO.Text = ShowName.Rows[0][3].ToString();
                        login.Text = ShowName.Rows[0][1].ToString();
                        pass.Text = ShowName.Rows[0][2].ToString();
                    }
                    else
                        MessageBox.Show("Нет экзаменатора с таким айди");
                }
                else
                {
                    MessageBox.Show("Нет экзаменатора с таким айди");
                }
            }
            else
            {
                MessageBox.Show("Поле айди не должно быть пустым");
            }
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
                command.Parameters.AddWithValue("name", FIO.Text);
                command.Parameters.AddWithValue("id", identic.Text);


                command.ExecuteNonQuery();
                MessageBox.Show("Вы успешно отредактировали данные");
                db.closeConnection();


            }
            else
            {
                MessageBox.Show("Не должно быть пустых полей");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DB db = new DB();
            MySqlConnection dbc = db.GetConnection();
            if (dbc == null)
            {
                return;
            }
            db.openConnection();
            if (!string.IsNullOrEmpty(identic.Text))
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("SELECT * FROM `users` WHERE `id` = @id ", db.GetConnection());
                command1.Parameters.Add("@id", MySqlDbType.VarChar).Value = identic.Text;

                adapter.SelectCommand = command1;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    MySqlCommand command = new MySqlCommand("DELETE FROM `users` WHERE `id`=@id", db.GetConnection());
                    command.Parameters.AddWithValue("id", identic.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Вы успешно удалили договор");

                    db.openConnection();
                    MySqlCommand getComboBoxValues;
                    DataTable comboBoxTable = new DataTable();
                    MySqlDataAdapter comboBoxAdapter = new MySqlDataAdapter();
                    getComboBoxValues = new MySqlCommand("SELECT id, role FROM `users` WHERE role = 'Заявитель'", dbc);
                    getComboBoxValues.Parameters.Add("@id", MySqlDbType.VarChar).Value = identic;

                    comboBoxAdapter.SelectCommand = getComboBoxValues;
                    comboBoxAdapter.Fill(comboBoxTable);
                    mainPanel.DataContext = comboBoxTable.DefaultView;
                    db.closeConnection();
                    FIO.Text = "";
                    login.Text = "";
                    pass.Text = "";
                }
                else
                {
                    MessageBox.Show("Поля с данным ID не существует !");
                }
            }
            else
            {
                MessageBox.Show("Укажите ID договора который хотите удалить!");
            }
            db.closeConnection();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddUsersForm addUsersForm = new AddUsersForm(id);
            addUsersForm.Show();
        }

    }
}
