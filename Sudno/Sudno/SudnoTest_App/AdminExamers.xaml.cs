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
      public class selectExamer
    {
        public string id { get; set; }
        public string FIO{ get; set; }
        public string login { get; set; }
        public string pass { get; set; }
        public string role { get; set; }
    }
    static class examerData
    {
        public static string id { get; set; }
        public static string FIO { get; set; }
        public static string login { get; set; }
        public static string pass { get; set; }
        public static string role { get; set; }
    }


    public partial class AdminExamers : Window
    {
        string id;
        public AdminExamers(string UserId)
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
            DataTable Count = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlDataAdapter CountAdapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT name, login, pass FROM `users` Where `id` = @id", dbc);
            MySqlCommand count = new MySqlCommand("SELECT COUNT(*) FROM `users` WHERE role = 'Экзаменатор'", dbc);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Convert.ToInt32(id);
            adapter.SelectCommand = command;
            adapter.Fill(ShowName);
            CountAdapter.SelectCommand = count;
            CountAdapter.Fill(Count);

            name.Text = ShowName.Rows[0][0].ToString();
            col.Text = Count.Rows[0][0].ToString();
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

            MySqlCommand ValueCommand = new MySqlCommand("SELECT id, name, login, pass, role FROM `users`  WHERE role = 'Экзаменатор'", dbc);
            ValueAdapter.SelectCommand = ValueCommand;
            ValueAdapter.Fill(ValueTable);

            for (int i = 0; i < ValueTable.Rows.Count; i++)
            {
                Task4 dataUser = new Task4()
                {
                    id = ValueTable.Rows[i][0].ToString(),
                    FIO = ValueTable.Rows[i][1].ToString(),
                    login = ValueTable.Rows[i][2].ToString(),
                    pass = ValueTable.Rows[i][3].ToString(),
                    role = ValueTable.Rows[i][4].ToString()
                };
                    listExamers.Items.Add(dataUser);
            }
        }

        private void back_button(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdminMainWindow adminMainWindow = new AdminMainWindow(id);
            adminMainWindow.Show();
        }

       

        private void work_with_content(object sender, RoutedEventArgs e)
        {
            this.Hide();
            EditExamers editExamers = new EditExamers(id);
            editExamers.Show();
        }

        private void listExamers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                  if (e.AddedItems.Count > 0)
            {
                Task4 selectedAdmin = e.AddedItems[0] as Task4;
                if (selectedAdmin != null)
                {

                    examerData.id = selectedAdmin.id;
                    examerData.FIO = selectedAdmin.FIO;
                    examerData.login = selectedAdmin.login;
                    examerData.pass = selectedAdmin.pass;
                    examerData.role = selectedAdmin.role;

                }
            }
        }

        private void add_content(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddExamersForm addExamersForm = new AddExamersForm(id);
            addExamersForm.Show();
        }

        private void delete_content(object sender, RoutedEventArgs e)
        {
            DB db = new DB();
            MySqlConnection dbc = db.GetConnection();
            if (dbc == null)
            {
                return;
            }
            db.openConnection();
            if (!string.IsNullOrEmpty(examerData.id))
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("SELECT * FROM `users` WHERE `id` = @id ", db.GetConnection());
                command1.Parameters.Add("@id", MySqlDbType.VarChar).Value = examerData.id;

                adapter.SelectCommand = command1;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    MySqlCommand command = new MySqlCommand("DELETE FROM `users` WHERE `id`=@id", db.GetConnection());
                    command.Parameters.AddWithValue("id", examerData.id);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Вы успешно удалили пользователя");
                }
                listExamers.Items.Clear();
                DataTable ValueTable = new DataTable();
                MySqlDataAdapter ValueAdapter = new MySqlDataAdapter();

                MySqlCommand ValueCommand = new MySqlCommand("SELECT id, name, login, pass, role FROM `users`  WHERE role = 'Экзаменатор'", dbc);
                ValueAdapter.SelectCommand = ValueCommand;
                ValueAdapter.Fill(ValueTable);

                for (int i = 0; i < ValueTable.Rows.Count; i++)
                {
                    Task4 dataUser = new Task4()
                    {
                        id = ValueTable.Rows[i][0].ToString(),
                        FIO = ValueTable.Rows[i][1].ToString(),
                        login = ValueTable.Rows[i][2].ToString(),
                        pass = ValueTable.Rows[i][3].ToString(),
                        role = ValueTable.Rows[i][4].ToString()
                    };
                    listExamers.Items.Add(dataUser);
                }
            }
        }
    }
}
