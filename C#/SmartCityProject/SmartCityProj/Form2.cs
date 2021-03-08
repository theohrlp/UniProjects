using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartCityProj
{
    public partial class Form2 : Form
    {
        Timer tm = new Timer();
        private int counter = 15;
        public Form2()
        {
            this.BackgroundImage = Properties.Resources.City1Edited;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.Hide();
        }

        private void ExitBtn(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Show();
            timer1.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedItem.ToString() == "Call a doctor")
            {
                label2.Hide();
                timer1.Stop();
                MessageBox.Show("Calling doctor");
                pictureBox1.Show();
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = Properties.Resources.phone2Edited;
            }
            else if (this.comboBox1.SelectedItem.ToString() == "Call Family")
            {
                label2.Hide();
                timer1.Stop();
                MessageBox.Show("Caling Family");
                pictureBox1.Show();
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = Properties.Resources.phone2Edited;
            }

            else if (this.comboBox1.SelectedItem.ToString() == "Order online")
            {
                label2.Hide();
                timer1.Stop();
                MessageBox.Show("Taking you to the ordering site");
                pictureBox1.Show();
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = Properties.Resources.basket2Edited;
                var form5 = new Form5();
                form5.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Something went wrong...");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter--;
            label2.Text = counter.ToString();
            if (counter == 0)
            {
                timer1.Stop();
                MessageBox.Show("Calling doctor");
                pictureBox1.Show();
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = Properties.Resources.phone2Edited;
            }
        }

        private void BackToMain(object sender, EventArgs e)
        {
            timer1.Stop();
            var form4 = new Form1();
            form4.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Το πρόγραμμα έχει την βασική αρμοδιότητα να εξασφαλίσει την ασφάλεια των ηλικιωμένων και σε περίπτωση ανάγκης ενεργοποιεί αυτόματα την κλήση ιατρικής βοήθειας αν δεν υπάρξει κάποια αντίδραση από τον χρήστη. Μπορεί επίσης ο ίδιος ο χρήστης να επιλέξει μια από τις υπάρχουσες επιλογές όπως: Να καλέσει ιατρική βοήθεια από μόνος, Να καλέσει ένα οικογενειακό μέλος της οικογένειας του είτε να καλέσει ένα τοπικό κατάστημα Super Market για προμήθειες.");
        }
    }
}
