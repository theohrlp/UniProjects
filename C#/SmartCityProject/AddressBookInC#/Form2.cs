using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddressBookAgain
{
    public partial class Form2 : Form
    {
        String connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb";
        OleDbConnection connection;
        private static string usrInp;
        string pathToMusic;
        string pathToPicture;
        string oldName;
        string oldSurName;
        string oldPhone;
        bool nameFlag = false;
        bool surNameFlag = false;
        bool phoneFlag = false;
        bool deleteFlag;
        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

        public Form2(string flag)
        {
            InitializeComponent();
            usrInp = flag;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            PaintMe();
            checkUserInp();
            connection = new OleDbConnection(connectionString);
        }

        private void PaintMe()
        {
            this.MaximumSize = new Size(1460, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = ColorTranslator.FromHtml("#E5CD8C");
        }

        private void checkUserInp()
        {
            if (usrInp == "Edit")
            {
                label2.Text = "Edit section";
                label9.Text = "Updated Contact";
                deleteFlag = true;
                //TODO more stuff (for UI)
            }
            else if (usrInp == "Delete")
            {
                label2.Text = "Delete section";
                button8.Hide();
                tableLayoutPanel1.Hide();
            }
            else if (usrInp == "Search")
            {
                deleteFlag = true;
                label2.Text = "Search section";
                label6.Text = "Search Results";
                button6.Hide();
                button7.Hide();
                button8.Hide();
                label10.Hide();
                label14.Hide();
                button8.Text = "Find Them!";
            }
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

        private void findCont(string byWhat)
        {
            if (deleteFlag)
            {
                if (byWhat == "Name")
                {
                    nameFlag = true;
                    string name = textBox1.Text;
                    connection.Open();
                    string query = "Select * from Table1 Where NameOfUser=?";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("NameOfUser", name);
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        textBox5.Text = reader.GetString(1);
                        textBox6.Text = reader.GetString(2);
                        textBox4.Text = reader.GetString(3);
                        textBox8.Text = reader.GetString(4);
                        textBox7.Text = reader.GetString(5);
                        pathToPicture = reader.GetString(6);
                        pathToMusic = reader.GetString(7);
                        textBox9.Text = reader.GetString(8);

                    }
                    connection.Close();
                    if (textBox5.Text == "")
                    {
                        MessageBox.Show("No user found with the name of: " + name + ".");
                    }
                    else if (textBox5.Text != "")
                    {
                        playSimpleSound(pathToMusic);
                        pictureBox1.Image = Image.FromFile(pathToPicture);
                        MessageBox.Show("Contact found!");
                    }
                }
                else if (byWhat == "surName")
                {
                    surNameFlag = true;
                    string surName = textBox2.Text;
                    connection.Open();
                    string query = "Select * from Table1 Where SurName=?";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("SurName", surName);
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        textBox5.Text = reader.GetString(1);
                        textBox6.Text = reader.GetString(2);
                        textBox4.Text = reader.GetString(3);
                        textBox8.Text = reader.GetString(4);
                        textBox7.Text = reader.GetString(5);
                        pathToPicture = reader.GetString(6);
                        pathToMusic = reader.GetString(7);
                        textBox9.Text = reader.GetString(8);

                    }
                    connection.Close();
                    if (textBox9.Text == "")
                    {
                        MessageBox.Show("No user found with the surname of: " + surName + ".");
                    }
                    else if (textBox9.Text != "")
                    {
                        playSimpleSound(pathToMusic);
                        pictureBox1.Image = Image.FromFile(pathToPicture);
                        MessageBox.Show("Contact found!");
                    }
                }
                else if (byWhat == "Phone")
                {
                    phoneFlag = true;
                    string phone = textBox3.Text;
                    connection.Open();
                    string query = "Select * from Table1 Where Phone=?";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("Phone", phone);
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        textBox5.Text = reader.GetString(1);
                        textBox6.Text = reader.GetString(2);
                        textBox4.Text = reader.GetString(3);
                        textBox8.Text = reader.GetString(4);
                        textBox7.Text = reader.GetString(5);
                        pathToPicture = reader.GetString(6);
                        pathToMusic = reader.GetString(7);
                        textBox9.Text = reader.GetString(8);

                    }
                    connection.Close();
                    if (textBox4.Text == "")
                    {
                        MessageBox.Show("No user found with the phone number: " + phone + ".");
                    }
                    else if (textBox4.Text != "")
                    {
                        playSimpleSound(pathToMusic);
                        pictureBox1.Image = Image.FromFile(pathToPicture);
                        MessageBox.Show("Contact found!");
                    }
                }
                else
                {
                    MessageBox.Show("I fucked up...");
                }
            }
            else if(!deleteFlag)
            {
                if (byWhat == "Name")
                {
                    var tempy = "";
                    nameFlag = true;
                    string name = textBox1.Text;
                    connection.Open();
                    string query = "Select * from Table1 Where NameOfUser=?";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("NameOfUser", name);
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())

                    {
                        tempy = reader.GetString(1);
                    }
                    connection.Close();
                    if (tempy == "")
                    {
                        MessageBox.Show("No user found with the name of: " + name + ".");
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("Contact by name of: " +name+ " found. Are you sure you want to delete it?", "DELETION!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.Yes)
                        {
                            connection.Open();
                            //Deletion starts here
                            string query2 = "Delete from Table1 Where NameOfUser=?";
                            OleDbCommand command2 = new OleDbCommand(query2, connection);
                            command2.Parameters.AddWithValue("NameOfUser", oldName);
                            int count2 = command2.ExecuteNonQuery();
                            MessageBox.Show(count2.ToString() + " row(s) affected!");
                            //Ends here
                            connection.Close();
                        }
                        else
                        {
                            MessageBox.Show("Contact kept.");
                        }
                        
                    }
                }
                else if (byWhat == "surName")
                {
                    var tempy = "";
                    surNameFlag = true;
                    string surName = textBox2.Text;
                    connection.Open();
                    string query = "Select * from Table1 Where SurName=?";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("SurName", surName);
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())

                    {
                        tempy = reader.GetString(8);
                    }
                    connection.Close();
                    if (tempy == "")
                    {
                        MessageBox.Show("No user found with the surname of: " + surName + ".");
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("Contact by surname of: " + surName + " found. Are you sure you want to delete it?", "DELETION!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.Yes)
                        {
                            connection.Open();
                            //Deletion starts here
                            string query2 = "Delete from Table1 Where SurName=?";
                            OleDbCommand command2 = new OleDbCommand(query2, connection);
                            command2.Parameters.AddWithValue("SurName", oldSurName);
                            int count2 = command2.ExecuteNonQuery();
                            MessageBox.Show(count2.ToString() + " row(s) affected!");
                            //Ends here
                            connection.Close();
                        }
                        else
                        {
                            MessageBox.Show("Contact kept.");
                        }
                    }
                }
                else if (byWhat == "Phone")
                {
                    var tempy = "";
                    phoneFlag = true;
                    string phone = textBox3.Text;
                    connection.Open();
                    string query = "Select * from Table1 Where Phone=?";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("Phone", phone);
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())

                    {
                        tempy = reader.GetString(3);
                    }
                    connection.Close();
                    if (tempy == "")
                    {
                        MessageBox.Show("No user found with the phone number: " + phone + ".");
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("Contact with the phone number of: " + phone + " found. Are you sure you want to delete it?", "DELETION!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.Yes)
                        {
                            connection.Open();
                            //Deletion starts here
                            string query2 = "Delete from Table1 Where Phone=?";
                            OleDbCommand command2 = new OleDbCommand(query2, connection);
                            command2.Parameters.AddWithValue("Phone", oldPhone);
                            int count2 = command2.ExecuteNonQuery();
                            MessageBox.Show(count2.ToString() + " row(s) affected!");
                            //Ends here
                            connection.Close();
                        }
                        else
                        {
                            MessageBox.Show("Contact kept.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("I fucked up...");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter a name.");
            }
            else if (textBox1.Text != "")
            {
                string temp = "Name";
                oldName = textBox1.Text;
                findCont(temp);
            }
            else
            {
                MessageBox.Show("I fucked up...");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please enter a surname.");
            }
            else if (textBox2.Text != "")
            {
                oldSurName = textBox2.Text;
                string temp = "surName";
                findCont(temp);
            }
            else
            {
                MessageBox.Show("I fucked up...");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Please enter a phone number.");
            }
            else if (textBox3.Text != "")
            {
                oldPhone = textBox3.Text;
                string temp = "Phone";
                findCont(temp);
            }
            else
            {
                MessageBox.Show("I fucked up...");
            }
        }

        private void button6_Click(object sender, EventArgs e)
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
            }
            MessageBox.Show("Song selected!");
            //Play song when selected
        }

        private void button7_Click(object sender, EventArgs e)
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

        private void button8_Click(object sender, EventArgs e)
        {
            //Update contact
            string name = textBox5.Text;
            string surName = textBox9.Text;
            string phone = textBox4.Text;
            string email = textBox6.Text;
            string Bday = textBox7.Text;
            string addr = textBox8.Text;
            string path2Img = pathToPicture;
            string path2mp3 = pathToMusic;
            if (name != "" && surName != "" && phone != "" && email != "" && Bday != "" && addr != "" && path2Img != "" && path2mp3 != "")
            {
                connection.Open();
                if (nameFlag)
                {
                    //Deletion starts here
                    string query2 = "Delete from Table1 Where NameOfUser=?";
                    OleDbCommand command2 = new OleDbCommand(query2, connection);
                    command2.Parameters.AddWithValue("NameOfUser", oldName);
                    int count2 = command2.ExecuteNonQuery();
                    MessageBox.Show(count2.ToString() + " row(s) affected!");
                    //Ends here
                    nameFlag = false;
                }
                else if (surNameFlag)
                {
                    //Deletion starts here
                    string query2 = "Delete from Table1 Where SurName=?";
                    OleDbCommand command2 = new OleDbCommand(query2, connection);
                    command2.Parameters.AddWithValue("SurName", oldSurName);
                    int count2 = command2.ExecuteNonQuery();
                    MessageBox.Show(count2.ToString() + " row(s) affected!");
                    //Ends here
                    surNameFlag = false;
                }
                else if (phoneFlag)
                {
                    //Deletion starts here
                    string query2 = "Delete from Table1 Where Phone=?";
                    OleDbCommand command2 = new OleDbCommand(query2, connection);
                    command2.Parameters.AddWithValue("Phone", oldPhone);
                    int count2 = command2.ExecuteNonQuery();
                    MessageBox.Show(count2.ToString() + " row(s) affected!");
                    //Ends here
                    phoneFlag = false;
                }
                else
                {
                    MessageBox.Show("I fucked up...");
                }
                string query = "Insert into Table1(NameOfUser,Email,Phone,Address,BirthDate,PathToPhoto,PathToMusic,SurName) " + "values ('" + name + "','" + email + "','" + phone + "','" + addr + "','" + Bday + "','" + path2Img + "','" + path2mp3 + "','" + surName + "')";
                OleDbCommand command = new OleDbCommand(query, connection);
                int count = command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show(count.ToString() + " row(s) affected!");
            }
            else
            {
                MessageBox.Show("Please be sure to fill all the required fields.");
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            string tmp = "";
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            pictureBox1.Image = null;
            richTextBox1.Clear();
            playSimpleSound(tmp, true);
            MessageBox.Show("All fields successful cleared!");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer4_Panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
