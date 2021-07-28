using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Anket.Helpers;

namespace Anket
{
    public partial class Form1 : Form
    {
        public static bool Bachelors { get; set; } = false;
        public static bool Master { get; set; } = false;
        public static bool Doctoral { get; set; } = false;
        public static string Educations { get; set; } = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(208, 188, 213);
        }

        public void CreatObject()
        {
            string name = nametxtbox.Text;
            string surname = surnametxtbox.Text;
            DateTime birth = dateTimePicker1.Value;
            string email = emailtxtbox.Text;
            string phone = phonemaskedbox.Text;
            Questions anket = new Questions
            {
                Name = name,
                Surname = surname,
                Birthday = birth,
                Education = Educations,
                Email = email,
                Phone = phone,
            };
            Database db = new Database();
            db.AddAnket(anket);
            FileHelpers FH = new FileHelpers();

            if (File.Exists("Anket.json"))
            {
                FH.JsonDeserialize(db);
                FH.JsonSerialization(db.Ankets);
            }
            else
            {
                List<Questions> questions = new List<Questions>();
                questions.Add(anket);
                FH.JsonSerialization(questions);
            }
            MessageBox.Show("Anket Saved");
        }

        private void bachelorsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Educations += " Bachelors ";
            Bachelors = true;
        }

        private void MasterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Educations += " Master ";
            Master = true;
        }

        private void doctoralCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Educations += " Doctoral ";
            Doctoral = true;
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            CreatObject();
            nametxtbox.Text = default;
            surnametxtbox.Text = default;
            //dateTimePicker1.Value = DateTime.Now;
            emailtxtbox.Text = default;
            phonemaskedbox.Text = default;
            bachelorsCheckBox.Checked = false;
            MasterCheckBox.Checked = false;
            doctoralCheckBox.Checked = false;
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            FileHelpers FH = new FileHelpers();
            Database db = new Database();

            if (File.Exists("Anket.json"))
            {
                FH.JsonDeserialize(db);
            }
            else
            {
                MessageBox.Show("Database is empty");
            }
            var ph = searchMaskedTextBox1.Text;
            int counter = 0;
            foreach (var anket in db.Ankets)
            {
                if (ph == anket.Phone)
                {
                    nametxtbox.Text = anket.Name;
                    surnametxtbox.Text = anket.Surname;
                    dateTimePicker1.Value = anket.Birthday;
                    emailtxtbox.Text = anket.Email;
                    phonemaskedbox.Text = anket.Phone;
                    if (Bachelors)
                    {
                        bachelorsCheckBox.Checked = true;
                        Bachelors = false;
                    }
                    if (Master)
                    {
                        MasterCheckBox.Checked = true;
                        Master = false;
                    }
                    if (Doctoral)
                    {
                        doctoralCheckBox.Checked = true;
                        Doctoral = false;
                    }
                    ++counter;
                }
                if(counter!=0)
                {
                    MessageBox.Show("This number isn't in Database");
                }
            }
        }

        
    }
}
