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
    public partial class Form1 : Form
    {
        //Made by Theodore Haralampopoulos 2019-2020
        String connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database2.mdb";
        OleDbConnection connection;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new OleDbConnection(connectionString);
            PaintMe();
        }

        private void PaintMe()
        {
            this.MinimumSize = new Size(1390, 640);
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
            this.label1.BackColor = ColorTranslator.FromHtml("#FFFCFC");
            this.richTextBox1.BackColor = ColorTranslator.FromHtml("#FFFCFC");
        }

        private void ViewAllButton(object sender, EventArgs e)
        {
            //View all questions from all chapters and courses
            connection.Open();
            String query = "Select * from Table1";
            OleDbCommand command = new OleDbCommand(query, connection);
            OleDbDataReader reader = command.ExecuteReader();
            StringBuilder builder = new StringBuilder();
            while (reader.Read())
            {
                builder.AppendLine("Course: " + reader.GetString(1) + "\n" + "Chapter: " + reader.GetString(2) + "\n" + "Question: " + reader.GetString(3) + "\n" + "Answer: " + reader.GetString(4) + "\n" + "Difficulty: " + reader.GetString(5) + "\n" + "FirstWrongAnswer: " + reader.GetString(6) + "\n" + "SecondWrongAnswer: " + reader.GetString(7) + "\n" + "ThirdWrongAnswer: " + reader.GetString(8) + "\n" + "----------------------------------------------" + "\n");
            }
            connection.Close();
            richTextBox1.Clear();
            richTextBox1.AppendText(builder.ToString());
        }

        private void AddButton(object sender, EventArgs e)
        {
            //Add question
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
                if (difficulty != "1" && difficulty != "2" && difficulty != "3" )
                {
                    MessageBox.Show("Please be sure to enter a number between 1 and 3 for the difficulty." +"\n"+ "Select \"1\" for Easy, \"2\" for Medium and \"3\" for hard difficulty.");
                }
                else
                {
                    connection.Open();
                    string query = "Insert into Table1(Lesson, Chapter, Question, Answer, Difficulty, 1wrongAnswer, 2wrongAnswer, 3wrongAnswer) " + "values ('" + course + "','" + chapter + "','" + question + "','" + answer + "','" + difficulty + "','" + wrongAns1 + "','" + wrongAns2 + "','" + wrongAns3 + "')";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    int count = command.ExecuteNonQuery();
                    connection.Close();
                    //MessageBox.Show(count.ToString() + " row affected!");
                    MessageBox.Show("Question added!");
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                }
            }
            else
            {
                MessageBox.Show("Please be sure to fill all the required fields.");
            }
        }

        private void EditDelteButton(object sender, EventArgs e)
        {
            //Edit-Search-Delete form
            var form2 = new Form2();
            form2.Show();
            //this.WindowState = FormWindowState.Minimized;
        }

        private void ClearAllButton(object sender, EventArgs e)
        {
            //Clear all textboxes
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

        private void ExportButton(object sender, EventArgs e)
        {
            //Export form
            var form3 = new Form3();
            form3.Show();
            //this.WindowState = FormWindowState.Minimized;
        }

        private void ExitButton(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HelpButton(object sender, EventArgs e)
        {
            MessageBox.Show("To add a question simply fill all the fields and then press the " + "\r\n" + " \"Add a question\" button. ");

            MessageBox.Show("To Edit/Delete a question or make your test, "+"\n"+ "press the \"Search/Edit a question\" button or the " + "\n"+ "\"Make your test\" button respectively. ");
        }

        private void HelpButton2(object sender, EventArgs e)
        {
            MessageBox.Show("In the difficulty box select \"1\" for Easy, \"2\" for Medium and \"3\" for Hard difficulty.");
        }

    }
}
