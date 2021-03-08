using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageExe
{
    public partial class Form3 : Form
    {
        //Made by Theodore Haralampopoulos 2019-2020
        String connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database2.mdb";
        OleDbConnection connection;
        private static readonly string filePath = AppDomain.CurrentDomain.BaseDirectory + "Test.txt";
        int total = 0;
        int temp2 = 0;
        int temp3 = 0;
        int temp4 = 0;
        private List<string> myList = new List<string>();

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            connection = new OleDbConnection(connectionString);
            PaintMe();
        }

        private void PaintMe()
        {
            this.MinimumSize = new Size(1405, 688);
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.BackColor = ColorTranslator.FromHtml("#A8C4FF");B39F9F
            this.BackColor = ColorTranslator.FromHtml("#8DB398");
            this.textBox1.BackColor = ColorTranslator.FromHtml("#FFFCFC");
            this.textBox2.BackColor = ColorTranslator.FromHtml("#FFFCFC");
            this.textBox3.BackColor = ColorTranslator.FromHtml("#FFFCFC");
            this.textBox4.BackColor = ColorTranslator.FromHtml("#FFFCFC");
            this.textBox5.BackColor = ColorTranslator.FromHtml("#FFFCFC");
            this.textBox6.BackColor = ColorTranslator.FromHtml("#FFFCFC");
            this.label1.BackColor = ColorTranslator.FromHtml("#FFFCFC");
            this.richTextBox1.BackColor = ColorTranslator.FromHtml("#FFFCFC");
            this.richTextBox2.BackColor = ColorTranslator.FromHtml("#FFFCFC");
            this.richTextBox3.BackColor = ColorTranslator.FromHtml("#FFFCFC");
            this.richTextBox4.BackColor = ColorTranslator.FromHtml("#FFFCFC");
            this.richTextBox5.BackColor = ColorTranslator.FromHtml("#FFFCFC");
            this.richTextBox6.BackColor = ColorTranslator.FromHtml("#FFFCFC");
            this.richTextBox7.BackColor = ColorTranslator.FromHtml("#FFFCFC");
            richTextBox7.Hide();
        }

        private void FindQuestions()
        {
            myList.Clear();
            richTextBox7.Clear();
            string crs = textBox5.Text;
            string qst = textBox6.Text;
            string numOfQuestions = textBox1.Text;
            if (temp2==0 && temp3==0 && temp4==0)
            {
                //Selects from db and outputs to txt (TODO output to Word)
                //if all of the fields for easy, med, hard questions are empty, this will run, and select (randomly) the number of easy/med/hard questions
                connection.Open();
                String query = "Select TOP " + numOfQuestions + " * from Table1 Where Lesson='" + crs + "' AND Chapter='" + qst + "' ORDER BY Rnd(INT(NOW*ID)-NOW*ID)";
                OleDbCommand command = new OleDbCommand(query, connection);
                OleDbDataReader reader = command.ExecuteReader();
                StringBuilder builder = new StringBuilder();
                builder.Clear();
                while (reader.Read())
                {
                    if (!builder.ToString().Contains(reader.GetString(3)))
                    {
                        builder.AppendLine("Question: " + reader.GetString(3) + "\r\n" + "\t "+ "a): " + reader.GetString(4) + "\r\n" + "\t "+ "b): " + reader.GetString(5) + "\r\n" + "\t " + "c) : " + reader.GetString(6) + "\r\n" + "\t " + "d) : " + reader.GetString(7) + "\r\n" + "----------------------------------------------" + "\r\n");
                    }
                }
                connection.Close();
                myList.Add(builder.ToString());
                richTextBox7.Clear();
            }
            else if (temp2!=0 || temp3 != 0 || temp4 != 0)
            {
                StringBuilder builder = new StringBuilder();
                builder.Clear();
                if (temp2 != 0)
                {
                    string numOfEasy = textBox2.Text;
                    connection.Open();
                    String query = "Select TOP " + numOfEasy + " * from Table1 Where Lesson='" + crs + "' AND Chapter='" + qst + "' AND Difficulty='1' ORDER BY Rnd(INT(NOW*ID)-NOW*ID)";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        builder.AppendLine("Question: " + reader.GetString(3) + "\r\n" + "\t " + "a): " + reader.GetString(4) + "\r\n" + "\t " + "b): " + reader.GetString(5) + "\r\n" + "\t " + "c) : " + reader.GetString(6) + "\r\n" + "\t " + "d) : " + reader.GetString(7) + "\r\n" + "----------------------------------------------" + "\r\n");
                    }
                    connection.Close();
                    myList.Clear();
                    myList.Add(builder.ToString());
                }
                if (temp3 != 0)
                {
                    string numOfMedium = textBox3.Text;
                    connection.Open();
                    String query2 = "Select TOP " + numOfMedium + " * from Table1 Where Lesson='" + crs + "' AND Chapter='" + qst + "' AND Difficulty='2' ORDER BY Rnd(INT(NOW*ID)-NOW*ID)";
                    OleDbCommand command2 = new OleDbCommand(query2, connection);
                    OleDbDataReader reader2 = command2.ExecuteReader();
                    while (reader2.Read())
                    {
                        builder.AppendLine("Question: " + reader2.GetString(3) + "\r\n" + "\t " + "a): " + reader2.GetString(4) + "\r\n" + "\t " + "b): " + reader2.GetString(5) + "\r\n" + "\t " + "c) : " + reader2.GetString(6) + "\r\n" + "\t " + "d) : " + reader2.GetString(7) + "\r\n" + "----------------------------------------------" + "\r\n");
                    }
                    connection.Close();
                    myList.Clear();
                    myList.Add(builder.ToString());
                }
                if (temp4 != 0)
                {
                    string numOfHard = textBox4.Text;
                    connection.Open();
                    String query3 = "Select TOP " + numOfHard + " * from Table1 Where Lesson='" + crs + "' AND Chapter='" + qst + "' AND Difficulty='3' ORDER BY Rnd(INT(NOW*ID)-NOW*ID)";
                    OleDbCommand command3 = new OleDbCommand(query3, connection);
                    OleDbDataReader reader3 = command3.ExecuteReader();
                    while (reader3.Read())
                    {
                        builder.AppendLine("Question: " + reader3.GetString(3) + "\r\n" + "\t " + "a): " + reader3.GetString(4) + "\r\n" + "\t " + "b): " + reader3.GetString(5) + "\r\n" + "\t " + "c) : " + reader3.GetString(6) + "\r\n" + "\t " + "d) : " + reader3.GetString(7) + "\r\n" + "----------------------------------------------" + "\r\n");
                    }
                    connection.Close();
                    myList.Clear();
                    myList.Add(builder.ToString());
                }
            }
            ExportToTxt();
        }

        private void ExportToTxt()
        {
            foreach (string str in myList)
            {
                richTextBox7.AppendText(str);
            }
            if (richTextBox7.Text == "")
            {
                string course = textBox5.Text;
                string chpt = textBox6.Text;
                MessageBox.Show("No questions found with the Course name of: \"" + course + "\" and Chapter: \"" + chpt + "\". File not saved.");
                MessageBox.Show("Please keep in mind that all names are case-sensitive.");
            }
            else
            {
                richTextBox7.Show();
                DialogResult dr = MessageBox.Show("These are the questions to be added to the file, click yes to proceed.", "Final check", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                {
                    richTextBox7.Clear();
                    richTextBox7.Hide();
                    myList.Clear();
                    MessageBox.Show("File not saved, please enter new parameters.");
                }
                else
                {
                    richTextBox7.Clear();
                    try
                    {
                        if (File.Exists(filePath))
                        {
                            //MessageBox.Show("There is already a file with the name of \"Test.txt\" ");
                            //MessageBox.Show("If you continue know that the process will override the data in that file");
                            StreamWriter sw = new StreamWriter(filePath, false);
                            foreach (string str in myList)
                            {
                                sw.WriteLine(str);
                                richTextBox7.AppendText(str);
                            }
                            sw.Close();
                            MessageBox.Show("Question(s) successfully added to the .txt file named: Test.txt");
                            if (richTextBox7.Text == "")
                            {
                                string course = textBox5.Text;
                                string chpt = textBox6.Text;
                                MessageBox.Show("No questions found with the Course name of: \"" + course + "\" and Chapter: \"" + chpt + "\". File not saved.");
                                MessageBox.Show("Please keep in mind that all names are case-sensitive.");
                            }
                        }
                        else if (!File.Exists(filePath))
                        {
                            MessageBox.Show("We had to make a new file to save the data.");
                            StreamWriter sw = File.CreateText(filePath);
                            foreach (string str in myList)
                            {
                                sw.WriteLine(str);
                                richTextBox7.AppendText(str);
                            }
                            MessageBox.Show("Question(s) successfully added to the .txt file named: Test.txt");
                            sw.Close();
                            if (richTextBox7.Text == "")
                            {
                                string course = textBox5.Text;
                                string chpt = textBox6.Text;
                                MessageBox.Show("No questions found with the Course name of: \"" + course + "\" and Chapter: \"" + chpt + "\". File not saved.");
                                MessageBox.Show("Please keep in mind that all names are case-sensitive.");
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Something went wrong... File not saved.");
                    }
                }
            }
            
        }

        private void CheckMe()
        {
            //Checks for: if all the required fields are filled, and also if the number of easy/med/hard questions does not exceed
            //than the number of total questions
            if (textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Please select a Course and a Chapter to draw the questions from.");
            }
            else if (total == 0)
            {
                MessageBox.Show("Please enter the TOTAL number of questions.");
            }
            else if (textBox5.Text != "" || textBox6.Text != "")
            {
                if (total < temp2 + temp3 + temp4)
                {
                    MessageBox.Show("The sum of EASY, MEDIUM, and HARD questions must not exceed the number of TOTAL questions.");
                }
                else if (total == temp2 + temp3 + temp4)
                {
                    FindQuestions();
                }
                else if (temp2 == 0 && temp3 == 0 && temp4 == 0)
                {
                    FindQuestions();
                }
                else if (total > temp2 + temp3 + temp4)
                {
                    MessageBox.Show("Please make sure the number of TOTAL questions is equal to the sum of EASY, MEDIUM, and HARD questions!");
                }
            }
        }

        private void CheckButton(object sender, EventArgs e)
        {
            CheckMe();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Checks for: if the number is a number and greater than zero
            if (int.TryParse(textBox1.Text, out total))
            {
                if(total <= 0)
                {
                    MessageBox.Show("Please enter a number greater than zero.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a number");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //Checks for: if the number is a number and greater or equal to zero
            if (int.TryParse(textBox2.Text, out temp2))
            {
                if (temp2 < 0)
                {
                    MessageBox.Show("Please enter a number greater or equal to zero.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a number");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //Checks for: if the number is a number and greater or equal to zero
            if (int.TryParse(textBox3.Text, out temp3))
            {
                if (temp3 < 0)
                {
                    MessageBox.Show("Please enter a number greater or equal to zero.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a number");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //Checks for: if the number is a number and greater or equal to zero
            if (int.TryParse(textBox4.Text, out temp4))
            {
                if (temp4 < 0)
                {
                    MessageBox.Show("Please enter a number greater or equal to zero.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a number");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            CheckMe();
        }

    }
}
