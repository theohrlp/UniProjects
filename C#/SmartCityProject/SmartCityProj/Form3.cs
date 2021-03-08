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
    public partial class Form3 : Form
    {
        Boolean AddedItemsflag = false;
        Boolean KitchenHasLight = true;
        Boolean BedRoomHasLight = true;
        Boolean LivingRoomHasLight = true;
        Boolean WcHasLight = true;
        Boolean TvIsOn = true;
        Boolean RadioIsOn = true;
        Boolean CoffeeMakerIsOn = true;
        Boolean HeaterIsOn = true;
        Boolean AcIsOn = true;
        Boolean shouldShowFlag = false;

        public Form3()
        {
            this.BackgroundImage = Properties.Resources.City1Edited;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.outletEdited1;
            pictureBox2.Image = Properties.Resources.lightBulb;
            pictureBox3.Image = Properties.Resources.thermometerEdited;
            pictureBox4.Image = Properties.Resources.thermostat2Edited;
            //pictureBox5.Image = Properties.Resources.phone2Edited;
            pictureBox5.Hide();
            comboBox1.Hide();
            pictureBox6.Hide();
            pictureBox7.Hide();
            label2.Hide();
            label3.Hide();
            label3.MaximumSize = new Size(150, 0);
            label3.AutoSize = true;
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void ExitBtn(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BackToMainBtn(object sender, EventArgs e)
        {
            AddedItemsflag = false;
            var form4 = new Form1();
            form4.Show();
            this.Hide();
        }

        private void PowerOutlet_Click(object sender, EventArgs e)
        {

            if (!AddedItemsflag)
            {
                label3.Hide();
                pictureBox5.Image = Properties.Resources.whiteImg;
                comboBox1.Items.Clear();
                comboBox1.Items.Add("TV");
                comboBox1.Items.Add("Radio");
                comboBox1.Items.Add("Coffee Maker");
                comboBox1.Show();
                label2.Show();
                label2.Text = "Choose an appliance: ";
                shouldShowFlag = true;
                pictureBox6.Hide();
                pictureBox7.Hide();
                // AddedItemsflag = true;
            }
        }

        private void Thermometer_Click(object sender, EventArgs e)
        {
            if (!AddedItemsflag)
            {
                pictureBox5.Image = Properties.Resources.whiteImg;
                comboBox1.Items.Clear();
                comboBox1.Items.Add("36.6-");
                comboBox1.Items.Add("36.6-37.2");
                comboBox1.Items.Add("37.2-38");
                comboBox1.Items.Add("38+");
                comboBox1.Show();
                label2.Show();
                label2.Text = "Knock on door";
                pictureBox6.Hide();
                pictureBox7.Hide();
                shouldShowFlag = false;
                // AddedItemsflag = true;
            }
        }

        private void Thermostat_Click(object sender, EventArgs e)
        {
            if (!AddedItemsflag)
            {
                label3.Hide();
                pictureBox5.Image = Properties.Resources.whiteImg;
                Size size = new Size(135, 135);
                pictureBox5.Size = size;
                comboBox1.Items.Clear();
                comboBox1.Items.Add("Heater");
                comboBox1.Items.Add("AC");
                comboBox1.Show();
                label2.Show();
                label2.Text = "Choose heater or A/C: ";
                shouldShowFlag = true;
                pictureBox6.Hide();
                pictureBox7.Hide();
                // AddedItemsflag = true;
            }
        }

        private void Lights_Click(object sender, EventArgs e)
        {
            
            if (!AddedItemsflag)
            {
                label3.Hide();
                pictureBox5.Image = Properties.Resources.whiteImg;
                comboBox1.Items.Clear();
                comboBox1.Items.Add("Bedroom");
                comboBox1.Items.Add("Kitchen");
                comboBox1.Items.Add("WC");
                comboBox1.Items.Add("Living Room");
                comboBox1.Show();
                label2.Show();
                label2.Text = "Choose a room: ";
                shouldShowFlag = true;
                pictureBox6.Hide();
                pictureBox7.Hide();
                // AddedItemsflag = true;
            }


        }

        private void updateLights()
        {
            try
            {

                if (this.comboBox1.SelectedItem.ToString() == "Bedroom")
                {
                    pictureBox5.Show();
                    if (BedRoomHasLight)
                    {
                        pictureBox5.Image = Properties.Resources.bedroomLight1;
                    }
                    else
                    {
                        pictureBox5.Image = Properties.Resources.bedroomDark1;
                    }
                }
                else if (this.comboBox1.SelectedItem.ToString() == "Kitchen")
                {
                    pictureBox5.Show();
                    if (KitchenHasLight)
                    {
                        pictureBox5.Image = Properties.Resources.kitchenLight1;
                    }
                    else
                    {
                        pictureBox5.Image = Properties.Resources.kitchenDark1;
                    }
                }

                else if (this.comboBox1.SelectedItem.ToString() == "WC")
                {
                    pictureBox5.Show();
                    if (WcHasLight)
                    {
                        pictureBox5.Image = Properties.Resources.wcLight1;
                    }
                    else
                    {
                        pictureBox5.Image = Properties.Resources.wcDark1;
                    }
                }

                else if (this.comboBox1.SelectedItem.ToString() == "Living Room")
                {
                    pictureBox5.Show();
                    if (LivingRoomHasLight)
                    {
                        pictureBox5.Image = Properties.Resources.livingroomLight1;
                    }
                    else
                    {
                        pictureBox5.Image = Properties.Resources.livingroomDark1;
                    }
                }

                else
                {

                }
            }
            catch
            {

            }
        }

        private void updateAppliances()
        {
            if (this.comboBox1.SelectedItem.ToString() == "TV")
            {
                pictureBox5.Show();
                if (TvIsOn)
                {
                    pictureBox5.Image = Properties.Resources.tvIconOn;
                }
                else
                {
                    pictureBox5.Image = Properties.Resources.tvIconOff;
                }
            }
            else if (this.comboBox1.SelectedItem.ToString() == "Radio")
            {
                pictureBox5.Show();
                if (RadioIsOn)
                {
                    pictureBox5.Image = Properties.Resources.radioOnEdited;
                }
                else
                {
                    pictureBox5.Image = Properties.Resources.radioOffEdited;
                }
            }

            else if (this.comboBox1.SelectedItem.ToString() == "Coffee Maker")
            {
                pictureBox5.Show();
                if (CoffeeMakerIsOn)
                {
                    pictureBox5.Image = Properties.Resources.coffeeMakerOn;
                }
                else
                {
                    pictureBox5.Image = Properties.Resources.coffeeMakerOffEdited;
                }
            }

            else
            {
                
            }
        }

        private void updateThermostat()
        {
            if (this.comboBox1.SelectedItem.ToString() == "Heater")
            {
                pictureBox5.Show();
                if (HeaterIsOn)
                {
                    pictureBox5.Image = Properties.Resources.WarmAC;
                }
                else
                {
                    pictureBox5.Image = Properties.Resources.WarmAcOff;
                }
            }
            else if (this.comboBox1.SelectedItem.ToString() == "AC")
            {
                pictureBox5.Show();
                if (AcIsOn)
                {
                    pictureBox5.Image = Properties.Resources.ColdAC;
                }
                else
                {
                    pictureBox5.Image = Properties.Resources.ColdAcOff;
                }
            }

            else
            {

            }
        }

        private void updateWallThermometer()
        {

            if (this.comboBox1.SelectedItem.ToString() == "36.6-")
            {
                pictureBox5.Show();
                if (true)
                {
                    pictureBox5.Image = Properties.Resources.OkIcon;
                    label3.Show();
                    label3.Text = "You may enter";
                }
                else
                {

                }
            }
            else if (this.comboBox1.SelectedItem.ToString() == "36.6-37.2")
            {
                pictureBox5.Show();
                if (true)
                {
                    pictureBox5.Image = Properties.Resources.ClockIcon;
                    label3.Show();
                    label3.Text = "Please wait 5' and try again";
                }
                else
                {
                    
                }
            }
            else if (this.comboBox1.SelectedItem.ToString() == "37.2-38")
            {
                pictureBox5.Show();
                if (true)
                {
                    pictureBox5.Image = Properties.Resources.stopIcon;
                    label3.Show();
                    label3.Text = "You may not enter";
                }
                else
                {
                    
                }
            }

            else if (this.comboBox1.SelectedItem.ToString() == "38+")
            {
                pictureBox5.Show();
                if (true)
                {
                    pictureBox5.Image = Properties.Resources.DangerIcon;
                    label3.Show();
                    label3.Text = "Please seek medical advice";
                }
                else
                {
                    
                }
            }

            else
            {

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(shouldShowFlag)
            {
                pictureBox6.Show();
                pictureBox7.Show();
                pictureBox6.Image = Properties.Resources.powerOn;
                pictureBox7.Image = Properties.Resources.powerOff;
            }
            else
            {
                pictureBox6.Hide();
                pictureBox7.Hide();
            }
            updateLights();
            updateAppliances();
            updateThermostat();
            updateWallThermometer();
        }

        private void OnSwitch(object sender, EventArgs e)
        {
            KitchenHasLight = true;
            BedRoomHasLight = true;
            LivingRoomHasLight = true;
            WcHasLight = true;
            TvIsOn = true;
            RadioIsOn = true;
            CoffeeMakerIsOn = true;
            AcIsOn = true;
            HeaterIsOn = true;
            updateLights();
            updateAppliances();
            updateThermostat();
            updateWallThermometer();
        }

        private void OffSwitch(object sender, EventArgs e)
        {
            KitchenHasLight = false;
            BedRoomHasLight = false;
            LivingRoomHasLight = false;
            WcHasLight = false;
            TvIsOn = false;
            RadioIsOn = false;
            CoffeeMakerIsOn = false;
            AcIsOn = false;
            HeaterIsOn = false;
            updateLights();
            updateAppliances();
            updateThermostat();
            updateWallThermometer();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Η πριζα σας δίνει την ικανότητα να ενεργοποιήσετε μια οικιακή συσκευή η οποία θα πρέπει να είναι συνδεδεμένη στο πρόγραμμα smart home, αυτήν τη στιγμή συνδεδεμένες συσκευές είναι, η τηλεόραση στο σαλόνι, το ραδιόφωνο και η καφετέρια σας.\n\n" +
                            "Δεξιά της πρίζας έχετε το θερμόμετρο το οποίο εκτελεί την λειτουργία του επιτοίχιου ηλεκτρονικου θερμόμετρου εισόδου είναι τοποθετημένο στην είσοδο του σπιτιού δίπλα στο κουδούνι.Το θερμόμετρο θερμομετρά κάθε άνθρωπο που έχει χτυπήσει το κουδούνι ή έχει βάλει κλειδιά στην πόρτα.Αν η θερμοκρασία είναι κάτω από 36.6 δηλώνει ότι ο άνθρωπος μπορεί να περάσει, αν η θερμοκρασία είναι πάνω από 36.6 αλλά κάτω από 37.2, προτείνει στον άνθρωπο να ξεκουραστεί για 5’ και να ξαναδοκιμάσει, αν η θερμοκρασία είναι πάνω από 37.2 και κάτω από 38, δηλώνει ότι ο άνθρωπος δεν μπορεί να περάσει και προτείνει προσοχή, αν η θερμοκρασία είναι πάνω από 38 προτείνει στον άνθρωπο να κάνει τεστ κορονοϊού και ενημερώνει για το κοντινότερο διαγνωστικό κέντρο.\n\n" +
                            "Στην από κάτω γραμμή θα βρείτε το κουμπί που εκτελεί τις λειτουργίες του κλιματιστικού του χώρου σας.Ενεργοποιώντας την λειτουργία αυτή θα πρέπει να διαλέξετε μεταξύ θέρμανσης και ψύξης του χώρου και να πατήσετε ένα από τα 2 κουμπιά για να ολοκληρώσετε την ενέργεια σας.\n\n" +
                            "Στην συνέχεια πατώντας το κουμπί με τον εμφανιζόμενο λαμπτήρα έχετε την ικανότητα να ελέγχετε τα φώτα του σπιτιού επιλέγοντας το κουμπί αυτό και στην συνέχεια διαλέγοντας το δωμάτιο στο οποίο θα θέλατε να αλλάξετε την κατάσταση της λάμπας.");
        }
    }
}
