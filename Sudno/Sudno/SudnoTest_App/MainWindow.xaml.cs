using System;
using System.Windows;
using System.Data;
using MySql.Data.MySqlClient;
using System.IO;
using System.Windows.Media.Imaging;

namespace SudnoTest_App
{
    //
    public partial class MainWindow : Window
    {
        



        public MainWindow()
        {
            InitializeComponent();
            double screenHeight = SystemParameters.FullPrimaryScreenHeight;
            double screenWidth = SystemParameters.FullPrimaryScreenWidth;


            this.Top = (screenHeight - this.Height) / 0x00000002;
            this.Left = (screenWidth - this.Width) / 0x00000002;

      
        }


   

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            if (passBox.Visibility == Visibility.Hidden)
                passBox.Password = passBox2.Text;

            String loginUser = textBoxLogin.Text;
            String passUser = passBox.Password;
            

            DB db = new DB();
       

            DataTable table = new DataTable();
            

            MySqlDataAdapter adapter = new MySqlDataAdapter();
          

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @login AND `pass` = @pass", db.GetConnection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = passUser;
           


            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                if(table.Rows[0][4].ToString() == "Администратор")
                {
                    this.Hide();
                    AdminMainWindow adminMainWindow = new AdminMainWindow(table.Rows[0][0].ToString());
                    adminMainWindow.Show();
                }   
                else if (table.Rows[0][4].ToString() == "Заявитель")
                {
                    this.Hide();
                    UserMainWindow userMainWindow = new UserMainWindow(table.Rows[0][0].ToString());
                    userMainWindow.Show();
                    
                }
                else if (table.Rows[0][4].ToString() == "Экзаменатор")
                {
                    this.Hide();
                    ExamerMainWindow examerMainWindow = new ExamerMainWindow(table.Rows[0][0].ToString());
                    examerMainWindow.Show();
                }

            }
               
            else
                MessageBox.Show("Такого пользователя нет");

        }
      

        private void ButtonParol_Click(object sender, RoutedEventArgs e)
        {
            if (passBox2.Visibility == Visibility.Hidden)
            {
                passBox2.Text = passBox.Password;
                passBox.Visibility = Visibility.Hidden;
                passBox2.Visibility = Visibility.Visible;
                parol.Content = "Скрыть пароль";
       
            }
            else
            {
                passBox.Password = passBox2.Text;
                passBox2.Visibility = Visibility.Hidden;
                passBox.Visibility = Visibility.Visible;
                parol.Content = "Показать пароль";
            }
        }
     
    }
}
