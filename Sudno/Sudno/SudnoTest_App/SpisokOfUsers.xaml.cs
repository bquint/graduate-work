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
    /// Логика взаимодействия для SpisokOfUsers.xaml
    /// </summary>

    public class Task5
    {
        public string id { get; set; }
        public string FIO { get; set; }
        public string TypeOfDistrict { get; set; }
        public string TypeOfShip { get; set; }
        public string Javka { get; set; }
    }


    static class UserListSelect
    {
        public static string id { get; set; }
        public static string FIO { get; set; }
        public static string TypeOfDistrict { get; set; }
        public static string TypeOfShip { get; set; }
        public static string Javka { get; set; }
    }

    public partial class SpisokOfUsers : Window
    {
        string id;
        
        public SpisokOfUsers(string UserId)
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
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT name, login, pass FROM `users` Where `id` = @id", dbc);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Convert.ToInt32(id);
            adapter.SelectCommand = command;
            adapter.Fill(ShowName);
            name.Text = ShowName.Rows[0][0].ToString();

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
            DataTable countTable = new DataTable();
            DataTable countTable2 = new DataTable();
            MySqlDataAdapter ValueAdapter = new MySqlDataAdapter();
            MySqlDataAdapter adapter2 = new MySqlDataAdapter();
            MySqlDataAdapter adapter3 = new MySqlDataAdapter();
            MySqlCommand count = new MySqlCommand("SELECT COUNT(*) FROM `Results` ", dbc);
            MySqlCommand ValueCommand = new MySqlCommand("SELECT a.id, b.name, c.typeofdistrict, d.typeofship, javka from Results a inner join users b on b.id = a.id_users inner join TypeOfDistrict c on c.id = a.id_typeofdistrict inner join TypeOfShip d on d.id = a.id_typeofship   ", dbc);
            MySqlCommand count2 = new MySqlCommand("SELECT COUNT(*) FROM `Results` WHERE javka = 1", dbc);
            ValueAdapter.SelectCommand = ValueCommand;
            adapter2.SelectCommand = count;
            adapter3.SelectCommand = count2;
            ValueAdapter.Fill(ValueTable);
            adapter2.Fill(countTable);
            adapter3.Fill(countTable2);

            string ban = "Н";
            col.Text = countTable.Rows[0][0].ToString();
            col2.Text = countTable2.Rows[0][0].ToString();
            

            for (int i = 0; i < ValueTable.Rows.Count; i++)
            {
                if (ValueTable.Rows[i][4].ToString() == "1")
                    ban = "Присутствует";
                else if (ValueTable.Rows[i][4].ToString() != "1")
                    ban = "Не явился";
                Task5 dataUser = new Task5()
                {
                    id = ValueTable.Rows[i][0].ToString(),
                    FIO = ValueTable.Rows[i][1].ToString(),
                    TypeOfDistrict = ValueTable.Rows[i][2].ToString(),
                    TypeOfShip = ValueTable.Rows[i][3].ToString(),
                    Javka = ban
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
            if (e.AddedItems.Count > 0)
            {
                Task5 firstItem = e.AddedItems[0] as Task5;
                if (firstItem != null)
                {

                    UserListSelect.Javka = firstItem.Javka;
                    UserListSelect.id = firstItem.id;
                    UserListSelect.FIO = firstItem.FIO;
                    UserListSelect.TypeOfDistrict = firstItem.TypeOfDistrict;
                    UserListSelect.TypeOfShip = firstItem.TypeOfShip;


                }
            }

        }
        private void Utverd(object sender, RoutedEventArgs e)
        {
          
            if (UserListSelect.Javka == "Не явился")
            {
                missX.Text = UserListSelect.id;
                int b = 1;
                DB db = new DB();
                MySqlConnection dbc = db.GetConnection();
                db.openConnection();

                MySqlCommand command = new MySqlCommand("UPDATE `Results` SET `javka` = @javka WHERE `id` = @id", db.GetConnection());
                MySqlCommand command2 = new MySqlCommand("UPDATE `Results` SET `id_status` = 1 WHERE `id` = @id", db.GetConnection());

                command.Parameters.AddWithValue("javka", b);
                command.Parameters.AddWithValue("id", missX.Text);
                command2.Parameters.AddWithValue("id", missX.Text);


                command.ExecuteNonQuery();
                command2.ExecuteNonQuery();
                
                db.closeConnection();

            }
            else if (UserListSelect.Javka == "Присутствует")
            {
                missX.Text = UserListSelect.id;
                int b = 0;
                DB db = new DB();
                MySqlConnection dbc = db.GetConnection();
                db.openConnection();

                MySqlCommand command = new MySqlCommand("UPDATE `Results` SET `javka` = @javka WHERE `id` = @id", db.GetConnection());
                command.Parameters.AddWithValue("javka", b);
                command.Parameters.AddWithValue("id", missX.Text);
              

                command.ExecuteNonQuery();
                db.closeConnection();
            }
            UsersList.Items.Clear();
            LoadUser();

        }

        private void Utv(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CheckStatus checkStatus = new CheckStatus(id);
            checkStatus.Show();
        }
    }
}
