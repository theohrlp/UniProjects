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
    public partial class Form5 : Form
    {
        Boolean ClickedOnce = false;
        Boolean ClickedOnce1 = false;
        Boolean hasSelected = false;
        public Form5()
        {
            this.BackgroundImage = Properties.Resources.City1Edited;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            label2.MaximumSize = new Size(150, 0);
            label2.AutoSize = true;
            label2.Text = "Please enter your personal information";
            label3.Text = "Card details";
            label4.Text = "Items to order";
            richTextBox1.AppendText("Name: " + Environment.NewLine + Environment.NewLine + "Surname: " + Environment.NewLine + Environment.NewLine + "Phone number: " + Environment.NewLine + Environment.NewLine + "Address: ");
            richTextBox2.AppendText("Card Number: " + Environment.NewLine + Environment.NewLine + "Exp date: " + Environment.NewLine + Environment.NewLine + "CSV: " + Environment.NewLine + Environment.NewLine + "Name of the  " + Environment.NewLine + "card holder:");
            comboBox1.Items.Add("Tv");
            comboBox1.Items.Add("Radio");
            comboBox1.Items.Add("Coffee maker");
            pictureBox1.Hide();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

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

        private void richTextBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (!ClickedOnce1)
            {
                richTextBox2.Clear();
                ClickedOnce1 = true;
            }
        }

        private void richTextBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!ClickedOnce1)
            {
                richTextBox2.Clear();
                ClickedOnce1 = true;
            }
        }

        private void richTextBox2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (!ClickedOnce1)
            {
                richTextBox2.Clear();
                ClickedOnce1 = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.comboBox1.SelectedItem.ToString() == "Tv")
                {
                    pictureBox1.Show();
                    if (true)
                    {
                        pictureBox1.Image = Properties.Resources.tvIconOn;
                        hasSelected = true;
                    }
                    else
                    {

                    }
                }
                else if (this.comboBox1.SelectedItem.ToString() == "Radio")
                {
                    pictureBox1.Show();
                    if (true)
                    {
                        pictureBox1.Image = Properties.Resources.radioOnEdited;
                        hasSelected = true;
                    }
                    else
                    {

                    }
                }

                else if (this.comboBox1.SelectedItem.ToString() == "Coffee maker")
                {
                    pictureBox1.Show();
                    if (true)
                    {
                        pictureBox1.Image = Properties.Resources.coffeeMakerOn;
                        hasSelected = true;
                    }
                    else
                    {

                    }
                }

                else
                {

                }
            }
            catch (Exception)
            {

                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (hasSelected && richTextBox2.Text != "" && richTextBox1.Text != "")
            {
                MessageBox.Show("Your order has been sent!");
                pictureBox1.Image = Properties.Resources.OkIcon;
            }
            else
            {
                MessageBox.Show("Please fill all the required fields");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your order has been canceled");
            pictureBox1.Hide();
            comboBox1.SelectedItem = null;
            richTextBox1.Clear();
            richTextBox2.Clear();
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Στο online shop ο χρήστης έχει την ικανότητα να αγοράσει προϊόντα από την άνεση του υπολογιστή του. Θα πρέπει βέβαια να παρέχει τα στοιχεία του όπως ονοματεπώνυμο, το τηλεφωνικό του αριθμού και την διεύθυνση κατοικίας, Στο επόμενο κείμενο θα πρέπει να εισαχθούν τα στοιχεία της κάρτας με την οποία ο χρήστης επιθυμεί να πληρώσει.\n\n"+
                            "Με την συμπλήρωση των στοιχείων σας μπορείτε να επιλέξετε ένα από τα παρεχόμενα προϊόντα και με την επιλογή του αντικειμένου μπορείτε είτε να πατήσετε το κουμπί << Send Order >> όπου θα αποστείλει την παραγγελία σας στο κατάστημα είτε να πατήσετε το κουμπί << Discard order >> όπου με το οποίο θα σβηστούν όλα τα παρεχόμενα δεδομένα που έχετε δώσει και θα πρέπει να ξανά εισαχθούν από την αρχή.");
        }
    }
}
