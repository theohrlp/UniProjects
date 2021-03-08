using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Media;

namespace AddressBookAgain
{
    public partial class Form1 : Form
    {
        String connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb";
        OleDbConnection connection;
        string pathToMusic;
        string pathToPicture;
        string flag4Form2;
        bool flag4Phone = false;
        bool flag4Email = false;
        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
        List<string> Bdays = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new OleDbConnection(connectionString);
            PaintMe();
            hasBday();
            
        }

        private void PaintMe()
        {
            this.MaximumSize = new Size(1460, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = ColorTranslator.FromHtml("#E5CD8C");
        }

        private bool IsEmailValid()
        {
            Match match = Regex.Match(textBox4.Text, @"^[\w.-]+@(?=[a-z\d][^.]*\.)[a-z\d.-]*[^.]$");
            if (match.Success)
            {
                return true;
            }
            return false;
        }

        private bool IsPhoneValid()
        {
            Match match = Regex.Match(textBox2.Text, @"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$");
            if (match.Success)
            {
                return true;
            }
            return false;
        }

        private void playSimpleSound(string path, [Optional] bool playOrStop)
        {
            if (playOrStop)
            {
                wplayer.controls.stop();
            }
            else
            {
                wplayer.URL = path;
                wplayer.controls.play();
            }
        }

        private void hasBday()
        {
            DateTime today = DateTime.Today;

            connection.Open();

            String query = "Select * from Table1";

            OleDbCommand command = new OleDbCommand(query, connection);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var surName = reader.GetString(8);
                var temp = reader.GetString(5);
                if (today.ToString("d")==temp)
                {
                    Bdays.Add(surName);
                }
                else
                {
                    
                }
            }
            connection.Close();
            printBdays();
        }

        private void printBdays()
        {
            if (Bdays.Count > 0)
            {
                foreach (string str in Bdays)
                {
                    richTextBox2.AppendText("Surname: " + str + "\n");
                }
                Bdays.Clear();
            }
            else
            {
                richTextBox2.Hide();
                label12.Hide();
            }
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            if (IsPhoneValid())
            {
                flag4Phone = true;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (IsEmailValid())
            {
                flag4Email = true;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (flag4Email && flag4Phone)
            {
                //AddContact
                string name = textBox1.Text;
                string surName = textBox6.Text;
                string phone = textBox2.Text;
                string email = textBox4.Text;
                string Bday = textBox5.Text;
                string addr = textBox3.Text;
                string path2Img = pathToPicture;
                string path2mp3 = pathToMusic;
                if (name != "" && surName != "" && phone != "" && email != "" && Bday != "" && addr != "" && path2Img != "" && path2mp3 != "")
                {
                    connection.Open();
                    string query = "Insert into Table1(NameOfUser,Email,Phone,Address,BirthDate,PathToPhoto,PathToMusic,SurName) " + "values ('" + name + "','" + email + "','" + phone + "','" + addr + "','" + Bday + "','" + path2Img + "','" + path2mp3 + "','" + surName + "')";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    int count = command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show(count.ToString() + " row affected!");
                    flag4Phone = false;
                    flag4Email = false;
                }
                else
                {
                    MessageBox.Show("Please be sure to fill all the required fields.");
                }
                
            }
            else
            {
                MessageBox.Show("Please be sure to enter a valid Email and phone number.");
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            string tmp = "";
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            richTextBox1.Clear();
            richTextBox2.Clear();
            pictureBox1.Image = null;
            playSimpleSound(tmp, true);
            MessageBox.Show("All fields successful cleared!");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //View All
            connection.Open();

            String query = "Select * from Table1";

            OleDbCommand command = new OleDbCommand(query, connection);

            OleDbDataReader reader = command.ExecuteReader();

            StringBuilder builder = new StringBuilder();
            while (reader.Read())
            {
                builder.AppendLine("Name: " + reader.GetString(1) + "\n" + "Surname: " + reader.GetString(8) + "\n" + "Email: " + reader.GetString(2) + "\n" + "Phone: " + reader.GetString(3) + "\n" + "Address: " + reader.GetString(4) + "\n" + "BirthDay: " + reader.GetString(5) + "\n" + "----------------------------------------------" + "\n");
            }

            connection.Close();

            richTextBox1.Clear();

            richTextBox1.AppendText(builder.ToString());
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "Image Files (*.jpeg)|*.png|All Files (*.*)|*.*";
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("No picture selected.");
            }
            else
            {
                pictureBox1.Image = Image.FromFile(dlg.FileName);
                pathToPicture = dlg.FileName;
            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            var dlg2 = new OpenFileDialog();
            dlg2.Filter = "Audio Files (*.mp3)|*.mp3|All Files (*.*)|*.*";
            if (dlg2.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("No song selected.");
            }
            else
            {
                pathToMusic = dlg2.FileName;
                MessageBox.Show("Song selected!");
                DialogResult dr = MessageBox.Show("Do you want me to play your selected song?", "Play song?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.Yes)
                {
                    playSimpleSound(pathToMusic);
                }
                else
                {

                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            flag4Form2 = "Edit";
            var form2 = new Form2(flag4Form2);
            form2.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            flag4Form2 = "Delete";
            var form2 = new Form2(flag4Form2);
            form2.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            flag4Form2 = "Search";
            var form2 = new Form2(flag4Form2);
            form2.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //Nuke'em
            connection.Open();
            //Deletion starts here
            string query2 = "Delete from Table1 Where ID > 2";
            OleDbCommand command2 = new OleDbCommand(query2, connection);
            int count2 = command2.ExecuteNonQuery();
            MessageBox.Show(count2.ToString() + " row(s) affected!");
            //Ends here
            connection.Close();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            richTextBox2.Show();
            label12.Show();
            richTextBox2.Clear();
            hasBday();
        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer4_Panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
