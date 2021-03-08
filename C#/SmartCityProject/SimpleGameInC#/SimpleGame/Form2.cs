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
    public partial class Form2 : Form
    {
       
        Timer tm = new Timer();
        public static readonly char SEPARATOR2 = ':';
        private int score = 0;
        private Random rnd;
        private static string difficulty;
        private static string filePath;
        private readonly string usrName;
        private int counter = 30;
        private int ENDcounter = 0;
        Size size4Dif1 = new Size(200, 110);                                //Sets the size of the picture for the 3 difficulty levels
        Size size4Dif2 = new Size(150, 100);
        Size size4Dif3 = new Size(120, 100);
        public Form2(string uName, string gameDif, string path2File)        //Takes info from user (from Form1)  
        {
            InitializeComponent();
            label8.Text = uName;
            usrName = uName;
            label6.Text = gameDif;
            difficulty = gameDif;
            filePath = path2File;
        }
        private void paintMe()
        {
            this.MaximumSize = new Size(1460, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = ColorTranslator.FromHtml("#ABDBFF");
            groupBox1.BackColor = ColorTranslator.FromHtml("#ABDBFF");
            pictureBox2.Hide();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            tm.Tick += new EventHandler(tm_Tick);
            rnd = new Random();    
            if (difficulty == "1")                                          //Difficulty levels
            {
                pictureBox1.Size = size4Dif1;
                timer1.Interval = 1000;
                timer1.Enabled = true;
                timer2.Enabled = true;
            }
            else if (difficulty == "2")
            {
                pictureBox1.Size = size4Dif2;
                timer1.Interval = 500;
                timer1.Enabled = true;
                timer2.Enabled = true;
            }
            else if (difficulty == "3")
            {
                pictureBox1.Size = size4Dif3;
                timer1.Interval = 400;
                timer1.Enabled = true;
                timer2.Enabled = true;
            }
            else if (difficulty == "END")
            {
                pictureBox1.Size = size4Dif1;
                label6.Text = "ENDLESS!!!";
                timer1.Interval = 850;
                timer1.Enabled = true;
                timer3.Interval = 1000;
                timer3.Enabled = true;
            }
            else
            {
                pictureBox1.Size = size4Dif1;
                timer1.Interval = 1000;
                timer1.Enabled = true;
                timer2.Enabled = true;
            }
            paintMe();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (difficulty == "1")
            {
                score += 1;
            }
            else if (difficulty == "2")
            {
                score += 5;
            }
            else if (difficulty =="3")
            {
                score += 10;
            }
            else
            {
                score += 5;
            }
            label2.Text = score.ToString();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (difficulty == "1")
            {
                score += 1;
            }
            else if (difficulty == "2")
            {
                score += 5;
            }
            else if (difficulty == "3")
            {
                score += 10;
            }
            else
            {
                score += 5;
            }
            label2.Text = score.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveStats(int hits, string playerName)                 //Save stats to txt
        {
            
            try
            {
                if (File.Exists(filePath))
                {
                    StreamWriter sw = new StreamWriter(filePath, true);
                    sw.WriteLine(playerName + " " + SEPARATOR2 + hits.ToString());
                    sw.Close();
                }
                else if (!File.Exists(filePath))
                {
                    System.Windows.Forms.MessageBox.Show("We had to make a new file to save the data.");
                    StreamWriter sw = File.CreateText(filePath);
                    sw.WriteLine(playerName + " " + SEPARATOR2 + hits.ToString());
                    sw.Close();
                        
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Something went wrong... We could not save the data.");
                MessageBox.Show(ex.ToString());
                Application.Exit();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)                //Sets random location for the pictureBox
        {
            pictureBox1.Location = new Point(rnd.Next(0, groupBox1.Width - pictureBox1.Width), rnd.Next(0, groupBox1.Height - pictureBox1.Height));
        }

        private void timer2_Tick(object sender, EventArgs e)                //Countdown timer
        {
            counter--;
            if (counter == 0)
            {
                timer1.Stop();
                timer2.Stop();
                label4.Text = counter.ToString();
                saveStats(score, usrName);
                System.Windows.Forms.MessageBox.Show("Game over!\nYour Score was: " + score.ToString());
                DialogResult dr = MessageBox.Show("Wanna play again?!", "LoremIpsum", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    var form3 = new Form1();
                    form3.Show();
                    this.Close();
                }
                else
                {
                    Application.Exit();
                }
            }
            label4.Text = counter.ToString();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            ENDcounter += 1;
            label4.Text = ENDcounter.ToString();
            if (ENDcounter == 15)
            {
                System.Windows.Forms.MessageBox.Show("Get ready for trouble...");
                timer1.Interval = 650;
            }
            if (ENDcounter == 20)
            {
                System.Windows.Forms.MessageBox.Show("Now you are ASKING for it!!!");
                this.BackColor = Color.White;
                tm.Interval = 300;
                tm.Enabled = true;
            }
            if (ENDcounter == 30)
            {
                System.Windows.Forms.MessageBox.Show("Prepare ot feel my WRATH!!!!");
                tm.Interval = 200;
            }
            if (ENDcounter == 40)
            {
                System.Windows.Forms.MessageBox.Show("Prepare ot feel my WRATH!!!!");
                pictureBox2.Show();
                tm.Interval = 100;
            }
            if (ENDcounter == 9999)
            {
                tm.Enabled = false;
                System.Windows.Forms.MessageBox.Show("God Tier reached.\nCongrats :)");
                timer3.Enabled = false;
            }
            pictureBox2.Location = new Point(rnd.Next(0, groupBox1.Width - pictureBox2.Width), rnd.Next(0, groupBox1.Height - pictureBox2.Height));
        }
        private void tm_Tick(object sender, EventArgs e)
        {
            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            groupBox1.BackColor = randomColor;
            
        }
        
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("WRONG!!!!");
        }

        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("WRONG!!!!");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

    }
}
