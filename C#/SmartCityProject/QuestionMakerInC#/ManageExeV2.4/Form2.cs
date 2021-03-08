using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageExe
{
    public partial class Form2 : Form
    {
        //Made by Theodore Haralampopoulos 2019-2020
        String connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database2.mdb";
        OleDbConnection connection;
        string oldQst;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            connection = new OleDbConnection(connectionString);
            PaintMe();
        }

        private void PaintMe()
        {
            this.MinimumSize = new Size(1455, 793);
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.BackColor = ColorTranslator.FromHtml("#A8C4FF");B39F9F
            this.BackColor = ColorTranslator.FromHtml("#8DB398");
            this.textBox1.BackColor = ColorTranslator.FromHtml("#FFFCFC");
            this.textBox2.BackColor = ColorTranslator.FromHtml("#FFFCFC");
            this.textBox3.BackColor = ColorTranslator.FromHtml("#FFFCFC");
            this.textBox4.BackColor = ColorTranslator.FromHtml("#FFFCFC");
            this.textBox5.BackColor = ColorTranslator.FromHtml("#FFFCFC");
            this.textBox6.BackColor = ColorTranslator.FromHtml("#FFFCFC");
            this.textBox7.BackColor = ColorTranslator.FromHtml("#FFFCFC");
            this.textBox8.BackColor = ColorTranslator.FromHtml("#FFFCFC");
            this.textBox9.BackColor = ColorTranslator.FromHtml("#FFFCFC");
            this.textBox11.BackColor = ColorTranslator.FromHtml("#FFFCFC");
            this.label1.BackColor = ColorTranslator.FromHtml("#FFFCFC");
            this.richTextBox1.BackColor = ColorTranslator.FromHtml("#FFFCFC");
        }

        private void findQuest()
        {
            //Finds Questions and/or Courses
            if (textBox11.Text == "")
            {
                if (textBox9.Text == "")
                {
                    MessageBox.Show("Please enter either the name of a question or the name of a course.");
                }
                else if (textBox9.Text != "")
                {
                    string crs = textBox9.Text;
                    connection.Open();
                    String query = "Select * from Table1 where Lesson=?";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("Lesson", crs);
                    OleDbDataReader reader = command.ExecuteReader();
                    StringBuilder builder = new StringBuilder();
                    while (reader.Read())
                    {
                        builder.AppendLine("Course: " + reader.GetString(1) + "\n" + "Chapter: " + reader.GetString(2) + "\n" + "Question: " + reader.GetString(3) + "\n" + "Answer: " + reader.GetString(4) + "\n" + "Difficulty: " + reader.GetString(5) + "\n" + "FirstWrongAnswer: " + reader.GetString(5) + "\n" + "SecondWrongAnswer: " + reader.GetString(6) + "\n" + "ThirdWrongAnswer: " + reader.GetString(7) + "\n" + "----------------------------------------------" + "\n");
                    }
                    connection.Close();
                    richTextBox1.Clear();
                    richTextBox1.AppendText(builder.ToString());
                    if (richTextBox1.Text == "")
                    {
                        var tmp = textBox9.Text;
                        MessageBox.Show("No course found with the name of: \"" + tmp + "\".");
                    }
                }
                else
                {
                    MessageBox.Show("Something went wrong...");
                    Application.Exit();
                }
            }
            else if (textBox11.Text != "")
            {
                string qst = textBox11.Text;
                connection.Open();
                string query = "Select * from Table1 Where Question=?";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("Question", qst);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    textBox1.Text = reader.GetString(1);
                    textBox2.Text = reader.GetString(2);
                    textBox3.Text = reader.GetString(3);
                    textBox4.Text = reader.GetString(4);
                    textBox5.Text = reader.GetString(5);
                    textBox6.Text = reader.GetString(6);
                    textBox7.Text = reader.GetString(7);
                    textBox8.Text = reader.GetString(8);
                }
                connection.Close();
                if (textBox3.Text == "")
                {
                    MessageBox.Show("No question found with the name of: \"" + qst + "\".");
                }
                else if (textBox3.Text != "")
                {
                    
                }
                else
                {

                }
            }
            else
            {
                MessageBox.Show("Something went wrong...");
                Application.Exit();
            }
        }
        
        private void deleteQuest()
        {
            //Deletes said Questions
            var tempy = "";
            string qst = textBox11.Text;
            if (qst != "")
            {
                connection.Open();
                string query = "Select * from Table1 Where Question=?";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("Question", qst);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tempy = reader.GetString(1);
                }
                connection.Close();
                if (tempy == "")
                {
                    MessageBox.Show("No question found with the name of: " + qst + ".");
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Question by name of: " + qst + " found. Are you sure you want to delete it?", "DELETION!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        connection.Open();
                        //Deletion starts here
                        string query2 = "Delete from Table1 Where Question=?";
                        OleDbCommand command2 = new OleDbCommand(query2, connection);
                        command2.Parameters.AddWithValue("Question", qst);
                        int count2 = command2.ExecuteNonQuery();
                        MessageBox.Show("Question deleted.");
                        //Ends here
                        connection.Close();
                    }
                    else
                    {
                        MessageBox.Show("Question kept.");
                    }

                }
            }
            else
            {
                MessageBox.Show("First search the question, then you can proceed to delete it.");
            }
        }

        private void UpdateContactButton(object sender, EventArgs e)
        {
            //Update contact
            string course = textBox1.Text;
            string chapter = textBox2.Text;
            string question = textBox3.Text;
            string answer = textBox4.Text;
            string difficulty = textBox5.Text;
            string wrongAns1 = textBox6.Text;
            string wrongAns2 = textBox7.Text;
            string wrongAns3 = textBox8.Text;
            if (course != "" && chapter != "" && question != "" && answer != "" && difficulty != "" && wrongAns1 != "" && wrongAns2 != "" && wrongAns3 != "")
            {
                if (difficulty == "1" || difficulty == "2" || difficulty == "3")
                {
                    connection.Open();
                    //Deletion starts here
                    string query2 = "Delete from Table1 Where Question=?";
                    OleDbCommand command2 = new OleDbCommand(query2, connection);
                    command2.Parameters.AddWithValue("Question", oldQst);
                    int count2 = command2.ExecuteNonQuery();
                    //Ends Here
                    string query = "Insert into Table1(Lesson, Chapter, Question, Answer, Difficulty, 1wrongAnswer, 2wrongAnswer, 3wrongAnswer) " + "values ('" + course + "','" + chapter + "','" + question + "','" + answer + "','" + difficulty + "','" + wrongAns1 + "','" + wrongAns2 + "','" + wrongAns3 + "')";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    int count = command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Question updated.");
                }
                else
                {
                    MessageBox.Show("Please be sure to enter a number between 1 and 3 for the difficulty.");
                }
            }
            else
            {
                MessageBox.Show("Please be sure to fill all the required fields.");
            }
        }

        private void CourseSearchButton(object sender, EventArgs e)
        {
            textBox11.Clear();
            findQuest();
        }

        private void DeleteQuestButton(object sender, EventArgs e)
        {
            deleteQuest();
        }

        private void ExitButton(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QuestionSearchButton(object sender, EventArgs e)
        {
            textBox9.Clear();
            oldQst = textBox11.Text;
            findQuest();
        }

        private void ClearAllButton(object sender, EventArgs e)
        {
            //Clear all
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            richTextBox1.Clear();
            MessageBox.Show("All fields successful cleared!");
        }

        private void HelpButton(object sender, EventArgs e)
        {
            MessageBox.Show("To edit or delete a question, enter the name of the question in the field above, and all the details will be shown in the respected boxes.");
            MessageBox.Show("Alternatively you can enter the name of the course itself, and all the available questions will be shown in the box on the right.");
        }
    }
}
