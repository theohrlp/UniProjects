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
    public partial class Form4 : Form
    {

        Timer tm = new Timer();
        private int counter = 5;
        Boolean ClickedOnce = false;
        Boolean HasOrdered = false;
        Boolean HasSelectedTransportMethod = false;
        public Form4()
        {
            this.BackgroundImage = Properties.Resources.City1Edited;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            label5.Text = "Estimated time of arrival: 8:30 pm";
            label6.Text = "Write your order";
            label5.MaximumSize = new Size(150, 0);
            label5.AutoSize = true;
            label2.MaximumSize = new Size(150, 0);
            label2.AutoSize = true;
            label2.Text = "Please insert your destinations for the day";
            label3.Text = "Select form of trasnport";
            label3.MaximumSize = new Size(100, 0);
            label3.AutoSize = true;
            label4.Text = "Other: ";
            label4.MaximumSize = new Size(100, 0);
            label4.AutoSize = true;
            comboBox1.Items.Add("Car");
            comboBox1.Items.Add("Public trasport");
            comboBox1.Items.Add("By foot");
            comboBox1.Items.Add("Other");
            richTextBox2.Hide();
            label6.Hide();
            comboBox2.Items.Add("Order takeaway");
            pictureBox1.Hide();
            label5.Hide();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            richTextBox1.AppendText("Eg: " + Environment.NewLine + "Work at 8am" + Environment.NewLine + "Exercise at 7pm " + Environment.NewLine);
        }

        private void SaveBtn(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "" && HasSelectedTransportMethod)
            {
                if (HasOrdered)
                {
                    if (richTextBox2.Text != "")
                    {
                        MessageBox.Show("Your order has been sent");
                        MessageBox.Show("Your route for the day is getting ready...");
                        pictureBox1.Show();
                        pictureBox1.Image = Properties.Resources.hourglass;
                        timer1.Enabled = true;
                        label5.Show();
                    }
                    else
                    {
                        MessageBox.Show("Please enter your order");
                    }
                }
                else
                {
                    MessageBox.Show("Your route for the day is getting ready...");
                    pictureBox1.Show();
                    pictureBox1.Image = Properties.Resources.hourglass;
                    timer1.Enabled = true;
                    label5.Show();
                }
            }
            else
            {
                MessageBox.Show("Please enter some destinations and a desired method of transport.");
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0)
            {
                timer1.Stop();
                MessageBox.Show("Your route is ready!");
                pictureBox1.Image = Properties.Resources.gps;
            }
        }

        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!ClickedOnce)
            {
                richTextBox1.Clear();
                ClickedOnce = true;
            }
        }

        private void richTextBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!ClickedOnce)
            {
                richTextBox1.Clear();
                ClickedOnce = true;
            }
        }

        private void richTextBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (!ClickedOnce)
            {
                richTextBox1.Clear();
                ClickedOnce = true;
            }
        }

        private void ClearRichBox(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void InsertToComboboxes(object sender, EventArgs e)
        {
            string firstLine = richTextBox1.Lines[0];
            MessageBox.Show(firstLine);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox2.Show();
            label6.Show();
            HasOrdered = true;
        }

        private void GoBackBtn(object sender, EventArgs e)
        {
            var form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void ExitBtn(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DiscardBtn(object sender, EventArgs e)
        {
            HasOrdered = false;
            richTextBox2.Clear();
            richTextBox1.Clear();
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            richTextBox2.Hide();
            label6.Hide();
            pictureBox1.Hide();
            label5.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            HasSelectedTransportMethod = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Στο πρώτο κείμενο θα πρέπει να δώσετε στην τους ημερήσιους στόχους που θα θέλατε να κάνετε σήμερα, στην συνέχεια θα πρέπει να επιλέξετε μια από τις παρεχόμενες επιλογές για τον τρόπο με τον οποίο θα μετακινηθειτε. Αφού επιλέξετε τον τρόπο μετακίνησης έχετε την ικανότητα να επιλέξετε για take away και μετά να γράψετε την παραγγελία σας στο καινούργιο κείμενο το οποίο εμφανίζεται. Τέλος θα πρέπει να επιλέξετε <<Save>> για να γίνει ο υπολογισμός της διαδρομής. Στην περίπτωση που θα θέλατε να σβηστούν τα παρεχόμενα δεδομένα και να εισάγεται νέα θα πρέπει να πατήσετε το κουμπί <<Discard>> όπου θα σβήσει τα δεδομένα που έχετε εισάγει και θα πρέπει να τα ξανα εισαγεται. Με το που πατήσετε << Save >> το πρόγραμμα θα σας ενημερώσει ότι έχει καταχωρήσει τα στοιχεία που του δώσατε και θα πρέπει να περιμένετε λίγα δευτερόλεπτα μέχρι να σας επιστρέψει τον χάρτη με τον οποίο θα μπορείτε να κατατοπιστειτε στο προορισμό σας.Μπορείτε επίσης να πατήσετε και τώρα το κουμπί << Discard >> για να καθαρίσετε την οθόνη σας και να αναθέσετε νέο στόχο.");
        }
    }
}
