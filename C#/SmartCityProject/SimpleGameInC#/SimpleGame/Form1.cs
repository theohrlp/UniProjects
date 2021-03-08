using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace SampleGame
{
    public partial class Form1 : Form
    {
        private int temp;
        private static readonly string filePath = AppDomain.CurrentDomain.BaseDirectory + "Records.txt";
        private string gameDif;
        private Dictionary<string, int> myDict = new Dictionary<string, int>();     //Key is UserName, Value is Score

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            paintMe();
            importStats();
        }

        private void  paintMe()
        {
            listView1.BackColor = ColorTranslator.FromHtml("#ABDBFF");
            groupBox1.BackColor = ColorTranslator.FromHtml("#ABDBFF");
            button2.BackColor = Color.OrangeRed;
            this.BackColor = ColorTranslator.FromHtml("#2F5D80");
        }

        private void OnResize()
        {
           //TODO
        }

        private void importStats()
        {
            try
            {
                if (File.Exists(filePath) && new FileInfo(filePath).Length != 0)  //Checks if file exists and is not empty
                {
                    string[] lines = File.ReadAllLines(filePath);
                    string line;
                    for (var i = 0; i < lines.Length; i++)                        //Reads file and stores pair (UsrName-Score) to dict
                    {
                        line = lines[i];
                        string[] fields = line.Split(Form2.SEPARATOR2);
                        int tmp = Int32.Parse(fields[1]);
                        int value;
                        if (myDict.ContainsKey(fields[0]))                        //Checks if dictionary contains the usrName, if so, updates the score
                        {                                                         //Else it adds the pair (UsrName-Score) to dict
                            bool hasValue = myDict.TryGetValue(fields[0], out value);
                            if (hasValue)
                            {
                                temp = value;
                            }
                            else
                            {

                            }
                            if (temp < tmp)
                            {
                                myDict[fields[0]] = tmp;
                            }
                            else
                            {

                            }

                        }
                        else
                        {
                            myDict.Add(fields[0], tmp);
                        }

                    }

                }
                else if (!File.Exists(filePath) || new FileInfo(filePath).Length == 0)
                {
                    label11.Text = "No data.";
                    label12.Text = "No data.";
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Application.Exit();
            }

            displayHighScore();
        }

        private void displayHighScore()
        {
            myDict = myDict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);     //Sorts dict to get the top player
            foreach (KeyValuePair<string, int> kvp in myDict)
            {
                label11.Text = kvp.Key;                                                                 //Sets the name and score of the top player
                label12.Text = kvp.Value.ToString();
                break;
            }
            listView1.View = View.Details;                                                              //Sets the list in which the top 10 players
            listView1.GridLines = true;                                                                 //will be displayed
            listView1.Columns.Add("Player");
            listView1.Columns.Add("Score");
            if (myDict.Count <= 10 && myDict.Count > 0)                                                 //Checks the num. of players, to avoid
            {                                                                                           //"out of bounds" exceptions etc. and then
                var k = myDict.Count;                                                                   //prints the names in the listBox
                foreach (KeyValuePair<string, int> valuePair in myDict)
                {
                    k -= 1;
                    var playerName = valuePair.Key;
                    var score = valuePair.Value.ToString();
                    string[] row = { playerName, score };
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                    if (k == 0)
                    {
                        break;
                    }
                }
            }
            else if (myDict.Count > 10)
            {
                var k = 10;
                foreach (KeyValuePair<string, int> valuePair in myDict)
                {
                    k -= 1;
                    var playerName = valuePair.Key;
                    var score = valuePair.Value.ToString();
                    string[] row = { playerName, score };
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                    if (k == 0)
                    {
                        break;
                    }
                }
            }
            else
            {
                string[] row = { "No data.", "No data." };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (gameDif != null && textBox1.Text != "" )
            {
                var form2 = new Form2(textBox1.Text, gameDif, filePath);    //Opens "Game" form
                form2.Show();
                this.Hide();
            }
            else
            {
                DialogResult dr = MessageBox.Show("Please enter your name and the game difficulty!", "Incomplete  Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Cancel)
                {
                    this.Close();
                }
            }
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gameDif = "1";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gameDif = "2";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            gameDif = "3";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gameDif = "END";
            if (textBox1.Text != "")
            {
                DialogResult dr = MessageBox.Show("ENDLESS mode, are you sure you are up to this?", "You are NOT!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    var form2 = new Form2(textBox1.Text, gameDif, filePath);    //Opens "Game" form
                    form2.Show();
                    this.Hide();
                }
                else
                {
                    this.Close();
                }
                
            }
            else
            {
                DialogResult dr = MessageBox.Show("Please enter your name!", "Incomplete  Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Cancel)
                {
                    this.Close();
                }
            }

        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            OnResize();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

    }
}
