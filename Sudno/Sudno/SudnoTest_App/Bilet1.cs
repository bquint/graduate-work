using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace SudnoTest_App
{

    public partial class Bilet1 : Form
    {
        string id;
        string tpofdistrict;
        string tpofship;
        int points = 0;
        int ostatok = 10;

        public Bilet1(string UserId, string UserTd, string UserSh)
        {
            InitializeComponent();
           
            id = UserId;
            tpofdistrict = UserTd;
            tpofship = UserSh;
            panel1.Paint += panel1_Paint;
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
            MySqlCommand command3 = new MySqlCommand("SELECT a.id, b.typeofdistrict, c.image ,`Text_question`, `trueanswer`, `var_1`, `var_2`, `var_3` FROM QuestionsTypeOfDistrict a inner join TypeOfDistrict b on b.id = a.id_typeofdistrict inner join Images c on c.id = a.id_picture WHERE `id_typeofdistrict` = @id_d", dbc);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Convert.ToInt32(id);
            command1.Parameters.Add("@id_d", MySqlDbType.VarChar).Value = Convert.ToInt32(tpofdistrict);
            command2.Parameters.Add("@id_s", MySqlDbType.VarChar).Value = Convert.ToInt32(tpofship);
            command3.Parameters.Add("@id_d", MySqlDbType.VarChar).Value = Convert.ToInt32(tpofdistrict);

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
            TypeOfDistrict.Text = ShowTD.Rows[0][0].ToString();
            TypeOfShip.Text = ShowSH.Rows[0][0].ToString();
            label3.Text = questions[0].Text;
            radioButton1.Text = questions[0].CorrectAnswer;
            radioButton2.Text = questions[0].Answer1;
            radioButton3.Text = questions[0].Answer2;
            radioButton4.Text = questions[0].Answer3;
            byte[] img = questions[0].Image;

            label4.Text = questions[1].Text;
            radioButton5.Text = questions[1].CorrectAnswer;
            radioButton6.Text = questions[1].Answer1;
            radioButton7.Text = questions[1].Answer2;
            radioButton8.Text = questions[1].Answer3;
            byte[] img1 = questions[1].Image;

            label5.Text = questions[2].Text;
            radioButton9.Text = questions[2].CorrectAnswer;
            radioButton10.Text = questions[2].Answer1;
            radioButton11.Text = questions[2].Answer2;
            radioButton12.Text = questions[2].Answer3;
            byte[] img2 = questions[2].Image;

            label6.Text = questions[3].Text;
            radioButton13.Text = questions[3].CorrectAnswer;
            radioButton14.Text = questions[3].Answer1;
            radioButton15.Text = questions[3].Answer2;
            radioButton16.Text = questions[3].Answer3;
            byte[] img3 = questions[3].Image;

            label7.Text = questions[4].Text;
            radioButton17.Text = questions[4].CorrectAnswer;
            radioButton18.Text = questions[4].Answer1;
            radioButton19.Text = questions[4].Answer2;
            radioButton20.Text = questions[4].Answer3;
            byte[] img4 = questions[4].Image;

            label8.Text = questions[5].Text;
            radioButton21.Text = questions[5].CorrectAnswer;
            radioButton22.Text = questions[5].Answer1;
            radioButton23.Text = questions[5].Answer2;
            radioButton24.Text = questions[5].Answer3;
            byte[] img5 = questions[5].Image;

            label9.Text = questions[6].Text;
            radioButton25.Text = questions[6].CorrectAnswer;
            radioButton26.Text = questions[6].Answer1;
            radioButton27.Text = questions[6].Answer2;
            radioButton28.Text = questions[6].Answer3;
            byte[] img6 = questions[6].Image;

            label10.Text = questions[7].Text;
            radioButton29.Text = questions[7].CorrectAnswer;
            radioButton30.Text = questions[7].Answer1;
            radioButton31.Text = questions[7].Answer2;
            radioButton32.Text = questions[7].Answer3;
            byte[] img7 = questions[7].Image;

            label11.Text = questions[8].Text;
            radioButton33.Text = questions[8].CorrectAnswer;
            radioButton34.Text = questions[8].Answer1;
            radioButton35.Text = questions[8].Answer2;
            radioButton36.Text = questions[8].Answer3;
            byte[] img8 = questions[8].Image;

            label12.Text = questions[9].Text;
            radioButton37.Text = questions[9].CorrectAnswer;
            radioButton38.Text = questions[9].Answer1;
            radioButton39.Text = questions[9].Answer2;
            radioButton40.Text = questions[9].Answer3;
            byte[] img9 = questions[9].Image;


            /*name.Text = ShowName.Rows[0][0].ToString();
            TypeOfDistrict.Text = ShowTD.Rows[0][0].ToString();
            TypeOfShip.Text = ShowSH.Rows[0][0].ToString();
            label3.Text = Content.Rows[0][3].ToString();
            checkBox1.Text = Content.Rows[0][4].ToString();
            checkBox2.Text  = Content.Rows[0][5].ToString();
            checkBox3.Text = Content.Rows[0][6].ToString();
            checkBox4.Text = Content.Rows[0][7].ToString();
            byte[] img = (byte[])Content.Rows[0][2];*/

            MemoryStream ms = new MemoryStream(img);
            pictureBox1.Image = Image.FromStream(ms);

            MemoryStream ms1 = new MemoryStream(img1);
            pictureBox3.Image = Image.FromStream(ms1);

            MemoryStream ms2 = new MemoryStream(img2);
            pictureBox4.Image = Image.FromStream(ms2);

            MemoryStream ms3 = new MemoryStream(img3);
            pictureBox5.Image = Image.FromStream(ms3);

            MemoryStream ms4 = new MemoryStream(img4);
            pictureBox6.Image = Image.FromStream(ms4);

            MemoryStream ms5 = new MemoryStream(img5);
            pictureBox7.Image = Image.FromStream(ms5);

            MemoryStream ms6 = new MemoryStream(img6);
            pictureBox8.Image = Image.FromStream(ms6);

            MemoryStream ms7 = new MemoryStream(img7);
            pictureBox9.Image = Image.FromStream(ms7);

            MemoryStream ms8 = new MemoryStream(img8);
            pictureBox10.Image = Image.FromStream(ms8);

            MemoryStream ms9 = new MemoryStream(img9);
            pictureBox11.Image = Image.FromStream(ms9);

            adapter3.Dispose();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Bilet1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.Clear(panel1.Parent.BackColor);
            Control control = panel1;
            int radius = 30;
            using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddLine(radius, 0, control.Width - radius, 0);
                path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
                path.AddLine(control.Width, radius, control.Width, control.Height - radius);
                path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
                path.AddLine(control.Width - radius, control.Height, radius, control.Height);
                path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
                path.AddLine(0, control.Height - radius, 0, radius);
                path.AddArc(0, 0, radius, radius, 180, 90);
                using (SolidBrush brush = new SolidBrush(control.BackColor))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
        
            if (radioButton1.Checked == true)
            {
                points = points + 1;
                label13.Text = points.ToString();
            
            }
            if (radioButton5.Checked == true)
            {
                points = points + 1;
                label13.Text = points.ToString();
            }
            if (radioButton9.Checked == true)
            {
                points = points + 1;
                label13.Text = points.ToString();
            }
            if (radioButton13.Checked == true)
            {
                points = points + 1;
                label13.Text = points.ToString();
            }
            if (radioButton17.Checked == true)
            {
                points = points + 1;
                label13.Text = points.ToString();
            }
            if (radioButton21.Checked == true)
            {
                points = points + 1;
                label13.Text = points.ToString();
            }
            if (radioButton25.Checked == true)
            {
                points = points + 1;
                label13.Text = points.ToString();
            }
            if (radioButton29.Checked == true)
            {
                points = points + 1;
                label13.Text = points.ToString();
            }
            if (radioButton33.Checked == true)
            {
                points = points + 1;
                label13.Text = points.ToString();
            }
            if (radioButton37.Checked == true)
            {
                points = points + 1;
                label13.Text = points.ToString();
            }
            if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false && radioButton4.Checked == false )
            {
                ostatok = ostatok - 1;

            }
            if (radioButton5.Checked == false && radioButton6.Checked == false && radioButton7.Checked == false && radioButton8.Checked == false)
            {
                ostatok = ostatok - 1;

            }
            if (radioButton9.Checked == false && radioButton10.Checked == false && radioButton11.Checked == false && radioButton12.Checked == false)
            {
                ostatok = ostatok - 1;

            }
            if (radioButton13.Checked == false && radioButton14.Checked == false && radioButton15.Checked == false && radioButton16.Checked == false)
            {
                ostatok = ostatok - 1;

            }
            if (radioButton17.Checked == false && radioButton18.Checked == false && radioButton19.Checked == false && radioButton20.Checked == false)
            {
                ostatok = ostatok - 1;


            }
            if (radioButton21.Checked == false && radioButton22.Checked == false && radioButton23.Checked == false && radioButton24.Checked == false)
            {
                ostatok = ostatok - 1;

            }
            if (radioButton25.Checked == false && radioButton26.Checked == false && radioButton27.Checked == false && radioButton28.Checked == false)
            {
                ostatok = ostatok - 1;

            }
            if (radioButton29.Checked == false && radioButton30.Checked == false && radioButton31.Checked == false && radioButton32.Checked == false)
            {
                ostatok = ostatok - 1;

            }
            if (radioButton33.Checked == false && radioButton34.Checked == false && radioButton35.Checked == false && radioButton36.Checked == false)
            {
                ostatok = ostatok - 1;

            }
            if (radioButton37.Checked == false && radioButton38.Checked == false && radioButton39.Checked == false && radioButton40.Checked == false)
            {
                ostatok = ostatok - 1;
                
            }
            
            this.Hide();
            Bilet2 bilet2 = new Bilet2(id, tpofdistrict, tpofship, points, ostatok);
            bilet2.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            tabPage1.Text = "Ответ дан";
        }
    }
}