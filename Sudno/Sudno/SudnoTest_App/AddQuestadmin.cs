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
    public partial class AddQuestadmin : Form
    {
        string id;

        public AddQuestadmin(string UserId)
        {
            InitializeComponent();
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
            panel2.Paint += panel2_Paint;

           
        }


        private void button2_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            MySqlConnection dbc = db.GetConnection();
            if (dbc == null)
            {
                return;
            }
            DataTable table1 = new DataTable();
            DataTable table2 = new DataTable();
            DataTable table3 = new DataTable();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            MySqlDataAdapter adapter2 = new MySqlDataAdapter();
            MySqlDataAdapter adapter3 = new MySqlDataAdapter();
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] img = ms.ToArray();
            MySqlCommand command = new MySqlCommand("INSERT INTO `Images` (`image`) Values (@image)", db.GetConnection());
            db.openConnection();
            command.Parameters.Add("@image", MySqlDbType.Blob);
            command.Parameters["@image"].Value = img;



            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Вопрос добавлен в БД!");
            }
            db.closeConnection();

            MySqlCommand command1 = new MySqlCommand("SELECT id FROM `TypeOfDistrict` WHERE `typeofdistrict` = @identic ", db.GetConnection());
            command1.Parameters.Add("@identic", MySqlDbType.VarChar).Value = comboBox1.Text;

            MySqlCommand command2 = new MySqlCommand("SELECT id FROM `Images` WHERE `image` = @image", db.GetConnection());
            command2.Parameters.Add("@image", MySqlDbType.Blob).Value = img;

            adapter1.SelectCommand = command1;
            adapter1.Fill(table1);
            adapter2.SelectCommand = command2;
            adapter2.Fill(table2);

            MySqlCommand command3 = new MySqlCommand("INSERT INTO `QuestionsTypeOfDistrict` (`id_typeofdistrict`, `id_picture`, `Text_question`, `trueanswer`, `var_1`,`var_2`,`var_3`) VALUES (@str1, @str2, @str3, @str4, @str5, @str6, @str7 )", db.GetConnection());
            command3.Parameters.Add("@str1", MySqlDbType.VarChar).Value = table1.Rows[0][0].ToString();
            command3.Parameters.Add("@str2", MySqlDbType.VarChar).Value = table2.Rows[0][0].ToString();
            command3.Parameters.Add("@str3", MySqlDbType.VarChar).Value = textBox1.Text;
            command3.Parameters.Add("@str4", MySqlDbType.VarChar).Value = textBox2.Text;
            command3.Parameters.Add("@str5", MySqlDbType.VarChar).Value = textBox3.Text;
            command3.Parameters.Add("@str6", MySqlDbType.VarChar).Value = textBox4.Text;
            command3.Parameters.Add("@str7", MySqlDbType.VarChar).Value = textBox5.Text;

            adapter3.SelectCommand = command3;
            adapter3.Fill(table3);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Выберите картинку(*.jpg; *.png; *.gif) |*.jpg; *.png *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminMainWindow adminMainWindow = new AdminMainWindow(id);
            adminMainWindow.Show();
        }

            void panel2_Paint(object sender, PaintEventArgs e)
            {

                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.Clear(panel2.Parent.BackColor);
                Control control = panel2;
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminMainWindow adminMainWindow = new AdminMainWindow(id);
            adminMainWindow.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
