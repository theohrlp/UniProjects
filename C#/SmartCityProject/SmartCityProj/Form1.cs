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
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.BackgroundImage = Properties.Resources.City1Edited;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ExitBtn(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ElderlyMonitoring(object sender, EventArgs e)
        {
            var form2 = new Form2();   
            form2.Show();
            this.Hide();
        }

        private void SmarHome(object sender, EventArgs e)
        {
            var form3 = new Form3();    
            form3.Show();
            this.Hide();
        }

        private void Planner(object sender, EventArgs e)
        {
            var form4 = new Form4();
            form4.Show();
            this.Hide();
        }

        private void OnlineShop(object sender, EventArgs e)
        {
            var form5 = new Form5();
            form5.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("On-line help\n\n" +
                "Smart Home\nΕνεργοποιώντας την λειτουργία smart home θα σας εμφανιστούν 5 καινούργια κουμπιά με λειτουργίες.\n"
                +"\nSmart Planner\nΜε την επιλογή του Smart Planner θα σας εμφανιστούν κάποια πεδία τα οποία θα πρέπει να συμπληρώσετε κάποιες πληροφορίες.\n"
                +"\nElderly Monitoring\nΤο πρόγραμμα έχει την βασική αρμοδιότητα να εξασφαλίσει την ασφάλεια των ηλικιωμένων και σε περίπτωση ανάγκης ενεργοποιεί αυτόματα την κλήση ιατρικής βοήθειας αν δεν υπάρξει κάποια αντίδραση από τον χρήστη.\n"+
                "\nOnline Shop\nΣτο online shop ο χρήστης έχει την ικανότητα να αγοράσει προϊόντα από την άνεση του υπολογιστή του");
        }
    }
}
