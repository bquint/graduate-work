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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Windows.Threading;


namespace SudnoTest_App
{
    /// <summary>
    /// Логика взаимодействия для Page18.xaml
    /// </summary>
    public partial class Page18 : Page
    {
        string id;
        string tpofdistrict;
        string tpofship;
        string quest, quest2, quest3, quest4,
        quest5, quest6, quest7, quest8, quest9,
        quest10, quest11, quest12, quest13, quest14,
        quest15, quest16, quest17, quest18, quest19, quest20;
        int chk;
        DispatcherTimer dispatcherTimer;
        TimeSpan time;
        public Page18(string UserId, string UserTd, string UserSh, string Quest, string Quest2, string Quest3,
            string Quest4, string Quest5, string Quest6, string Quest7, string Quest8, string Quest9,
            string Quest10, string Quest11, string Quest12, string Quest13, string Quest14, string Quest15,
            string Quest16, string Quest17, string Quest18, string Quest19, string Quest20, TimeSpan Time)
        {
            InitializeComponent();
            time = Time;
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Start();
            double screenHeight = SystemParameters.FullPrimaryScreenHeight;
            double screenWidth = SystemParameters.FullPrimaryScreenWidth;
            chk = Properties.Settings.Default.chk18;

            id = UserId;
            tpofdistrict = UserTd;
            tpofship = UserSh;
            quest = Quest;
            quest2 = Quest2;
            quest3 = Quest3;
            quest4 = Quest4;
            quest5 = Quest5;
            quest6 = Quest6;
            quest7 = Quest7;
            quest8 = Quest8;
            quest9 = Quest9;
            quest10 = Quest10;
            quest11 = Quest11;
            quest12 = Quest12;
            quest13 = Quest13;
            quest14 = Quest14;
            quest15 = Quest15;
            quest16 = Quest16;
            quest17 = Quest17;
            quest18 = Quest18;
            quest19 = Quest19;
            quest20 = Quest20;

            if (Properties.Settings.Default.color1 == 1)
            {
                n1.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color2 == 1)
            {
                n2.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color3 == 1)
            {
                n3.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color4 == 1)
            {
                n4.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color5 == 1)
            {
                n5.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color6 == 1)
            {
                n6.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color7 == 1)
            {
                n7.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color8 == 1)
            {
                n8.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color9 == 1)
            {
                n9.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color10 == 1)
            {
                n10.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color11 == 1)
            {
                n11.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color12 == 1)
            {
                n12.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color13 == 1)
            {
                n13.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color14 == 1)
            {
                n14.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color15 == 1)
            {
                n15.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color16 == 1)
            {
                n16.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color17 == 1)
            {
                n17.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color18 == 1)
            {
                n18.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color19 == 1)
            {
                n19.Foreground = Brushes.Green;
            }
            if (Properties.Settings.Default.color20 == 1)
            {
                n20.Foreground = Brushes.Green;
            }


            if (chk == 1)
            {
                truevar2.IsChecked = true;
            }
            else if (chk == 2)
            {
                var4.IsChecked = true;
            }
            else if (chk == 3)
            {
                var5.IsChecked = true;
            }
            else if (chk == 4)
            {
                var6.IsChecked = true;
            }
            else
            {
                truevar2.IsChecked = false;
                var4.IsChecked = false;
                var5.IsChecked = false;
                var6.IsChecked = false;
                chk = 0;
            }
            if (quest18 == "")
            {
          
                DB db = new DB();
                MySqlConnection dbc = db.GetConnection();
                if (dbc == null)
                {
                    return;
                }
                DataTable ShowName = new DataTable();
                DataTable ShowTD = new DataTable();
                DataTable ShowSH = new DataTable();
                DataTable Content = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                MySqlDataAdapter adapter2 = new MySqlDataAdapter();
                MySqlDataAdapter adapter3 = new MySqlDataAdapter();



                MySqlCommand command = new MySqlCommand("SELECT name, login, pass FROM `users` Where `id` = @id", dbc);
                MySqlCommand command1 = new MySqlCommand("SELECT typeofdistrict FROM `TypeOfDistrict` Where `id` = @id_d", dbc);
                MySqlCommand command2 = new MySqlCommand("SELECT typeofship FROM `TypeOfShip` Where `id` = @id_s", dbc);
                MySqlCommand command3 = new MySqlCommand("SELECT a.id, b.typeofship, c.image ,`Text_question`, `trueanswer`, `var_1`, `var_2`, `var_3` FROM QuestionsTypeOfShip a inner join TypeOfShip b on b.id = a.id_typeofship inner join Images c on c.id = a.id_picture WHERE `id_typeofship` = @id_s " +
                    "AND Text_question != @check AND Text_question != @check2 AND Text_question != @check3  AND Text_question != @check4 AND Text_question != @check5 AND Text_question != @check6 AND Text_question != @check7", dbc);
                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Convert.ToInt32(id);
                command1.Parameters.Add("@id_d", MySqlDbType.VarChar).Value = Convert.ToInt32(tpofdistrict);
                command2.Parameters.Add("@id_s", MySqlDbType.VarChar).Value = Convert.ToInt32(tpofship);
                command3.Parameters.Add("@id_s", MySqlDbType.VarChar).Value = Convert.ToInt32(tpofship);
                command3.Parameters.Add("@check", MySqlDbType.VarChar).Value = Convert.ToString(quest11);
                command3.Parameters.Add("@check2", MySqlDbType.VarChar).Value = Convert.ToString(quest12);
                command3.Parameters.Add("@check3", MySqlDbType.VarChar).Value = Convert.ToString(quest13);
                command3.Parameters.Add("@check4", MySqlDbType.VarChar).Value = Convert.ToString(quest14);
                command3.Parameters.Add("@check5", MySqlDbType.VarChar).Value = Convert.ToString(quest15);
                command3.Parameters.Add("@check6", MySqlDbType.VarChar).Value = Convert.ToString(quest16);
                command3.Parameters.Add("@check7", MySqlDbType.VarChar).Value = Convert.ToString(quest17);


                adapter.SelectCommand = command;
                adapter1.SelectCommand = command1;
                adapter2.SelectCommand = command2;
                adapter3.SelectCommand = command3;
                adapter.Fill(ShowName);
                adapter1.Fill(ShowTD);
                adapter2.Fill(ShowSH);
                adapter3.Fill(Content);



                var questions = new List<Question>();
                foreach (DataRow row in Content.Rows)

                {
                    var question = new Question();
                    question.Text = row[3].ToString();
                    question.CorrectAnswer = row[4].ToString();
                    question.Answer1 = row[5].ToString();
                    question.Answer2 = row[6].ToString();
                    question.Answer3 = row[7].ToString();
                    question.Image = (byte[])row[2];
                    questions.Add(question);
                }

                for (int i = questions.Count - 1; i >= 1; i--)
                {
                    int j = new Random().Next(i + 1);
                    var temp = questions[j];
                    questions[j] = questions[i];
                    questions[i] = temp;
                }

                name.Text = ShowName.Rows[0][0].ToString();
                tpOfDis.Text = ShowTD.Rows[0][0].ToString();
                tpOfSh.Text = ShowSH.Rows[0][0].ToString();

                Question3.Text = questions[0].Text;
                truevar2.Content = questions[0].CorrectAnswer;
                var4.Content = questions[0].Answer1;
                var5.Content = questions[0].Answer2;
                var6.Content = questions[0].Answer3;
                BitmapImage img = new BitmapImage();
                byte[] data = (byte[])questions[0].Image;
                img.BeginInit();
                img.StreamSource = new MemoryStream(data);
                img.EndInit();
                pict2.Source = img;
                quest18 = Question3.Text;
            }
            else
            {
                LoadContent();
            }

            void LoadContent()
            {
                Question3.Text = Properties.Settings.Default.question18;
                DB db = new DB();
                MySqlConnection dbc = db.GetConnection();
                if (dbc == null)
                {
                    return;
                }
                DataTable ShowName = new DataTable();
                DataTable ShowTD = new DataTable();
                DataTable ShowSH = new DataTable();
                DataTable Content = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                MySqlDataAdapter adapter2 = new MySqlDataAdapter();
                MySqlDataAdapter adapter3 = new MySqlDataAdapter();



                MySqlCommand command = new MySqlCommand("SELECT name, login, pass FROM `users` Where `id` = @id", dbc);
                MySqlCommand command1 = new MySqlCommand("SELECT typeofdistrict FROM `TypeOfDistrict` Where `id` = @id_d", dbc);
                MySqlCommand command2 = new MySqlCommand("SELECT typeofship FROM `TypeOfShip` Where `id` = @id_s", dbc);
                MySqlCommand command3 = new MySqlCommand("SELECT a.id, b.typeofship, c.image ,`Text_question`, `trueanswer`, `var_1`, `var_2`, `var_3` FROM QuestionsTypeOfShip a inner join TypeOfShip b on b.id = a.id_typeofship inner join Images c on c.id = a.id_picture WHERE `id_typeofship` = @id_s  AND `Text_question` = @check", dbc);
                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Convert.ToInt32(id);
                command1.Parameters.Add("@id_d", MySqlDbType.VarChar).Value = Convert.ToInt32(tpofdistrict);
                command2.Parameters.Add("@id_s", MySqlDbType.VarChar).Value = Convert.ToInt32(tpofship);
                command3.Parameters.Add("@id_s", MySqlDbType.VarChar).Value = Convert.ToInt32(tpofship);
                command3.Parameters.Add("@check", MySqlDbType.VarChar).Value = Question3.Text;

                adapter.SelectCommand = command;
                adapter1.SelectCommand = command1;
                adapter2.SelectCommand = command2;
                adapter3.SelectCommand = command3;
                adapter.Fill(ShowName);
                adapter1.Fill(ShowTD);
                adapter2.Fill(ShowSH);
                adapter3.Fill(Content);

                var questions = new List<Question>();
                foreach (DataRow row in Content.Rows)
                {
                    var question = new Question();
                    question.Text = row[3].ToString();
                    question.CorrectAnswer = row[4].ToString();
                    question.Answer1 = row[5].ToString();
                    question.Answer2 = row[6].ToString();
                    question.Answer3 = row[7].ToString();
                    question.Image = (byte[])row[2];
                    questions.Add(question);

                }

                for (int i = questions.Count - 1; i >= 1; i--)
                {
                    int j = new Random().Next(i + 1);
                    var temp = questions[j];
                    questions[j] = questions[i];
                    questions[i] = temp;
                }

                name.Text = ShowName.Rows[0][0].ToString();
                tpOfDis.Text = ShowTD.Rows[0][0].ToString();
                tpOfSh.Text = ShowSH.Rows[0][0].ToString();
                Question3.Text = questions[0].Text;
                truevar2.Content = questions[0].CorrectAnswer;
                var4.Content = questions[0].Answer1;
                var5.Content = questions[0].Answer2;
                var6.Content = questions[0].Answer3;
                BitmapImage img = new BitmapImage();
                byte[] data = (byte[])questions[0].Image;
                img.BeginInit();
                img.StreamSource = new MemoryStream(data);
                img.EndInit();
                pict2.Source = img;
                quest18 = Question3.Text;
            }
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (time == TimeSpan.Zero) dispatcherTimer.Stop();
            else
            {
                time = time.Add(TimeSpan.FromSeconds(-1));
                MyTime.Text = time.ToString("c");
            }
        }
        private void to_3_page(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.question18 = Question3.Text;
            Properties.Settings.Default.chk18 = chk;
            Properties.Settings.Default.Save();
            NavigationService.Navigate(new Page17(id, tpofdistrict, tpofship, quest, quest2,
            quest3, quest4, quest5, quest6, quest7, quest8, quest9, quest10, quest11,
            quest12, quest13, quest14, quest15, quest16, quest17, quest18, quest19, quest20, time));
        }

        private void to_5_page(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.question18 = Question3.Text;
            Properties.Settings.Default.chk18 = chk;
            Properties.Settings.Default.Save();
            NavigationService.Navigate(new Page19(id, tpofdistrict, tpofship, quest, quest2,
            quest3, quest4, quest5, quest6, quest7, quest8, quest9, quest10, quest11,
            quest12, quest13, quest14, quest15, quest16, quest17, quest18, quest19, quest20, time));
        }
        private void var6_Checked(object sender, RoutedEventArgs e)
        {
            chk = 4;
            n18.Foreground = Brushes.Green;
            Properties.Settings.Default.color18 = 1;
        }

        private void var5_Checked(object sender, RoutedEventArgs e)
        {
            chk = 3;
            n18.Foreground = Brushes.Green;
            Properties.Settings.Default.color18 = 1;
        }

        private void var4_Checked(object sender, RoutedEventArgs e)
        {
            chk = 2;
            n18.Foreground = Brushes.Green;
            Properties.Settings.Default.color18 = 1;
        }

        private void truevar2_Checked(object sender, RoutedEventArgs e)
        {
            chk = 1;
            n18.Foreground = Brushes.Green;
            Properties.Settings.Default.color18 = 1;
        }
    }
}
