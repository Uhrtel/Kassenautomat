using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fahrkartenautomat
{

    public partial class Form1 : Form
    {
        Buchung buchung = new Buchung();
        List<Buchung> buchungen = new List<Buchung>();
        double gesamtkosten = 0;


        public void AddPrice(Buchung buchung, double preisstufe)
        {
            buchung = new Buchung();

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            //Add column header
            listView1.Columns.Add("Preis", 100);
            listView1.Columns.Add("Rabatt", 70);
            //listView1.Columns.Add("Quantit", 70);

            buchung.Kosten = preisstufe;

            listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            var result = MessageBox.Show("Gibt es eine Vergünstigung ?", "schließen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                buchung.Kosten = buchung.Kosten * 0.85;
                buchung.rabatt = true;
            }

            if (buchungen.Count >= 4)
            {
                foreach (var item in buchungen)
                {
                    if (buchung.rabatt)
                    {
                        buchung.Kosten = buchung.Kosten * 0.85;
                        buchung.rabatt = true;
                    }                  
                }
            }


            foreach (var item in buchungen)
            {
                
                listView1.Items.Add(item.rabatt.ToString());
                listView1.Items.Add(item.rabatt.ToString());
            }

            buchung.counter++;
            //label1.Text = ();

        }



        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddPrice(buchung, 100);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddPrice(buchung, 200);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddPrice(buchung, 300);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddPrice(buchung, 400);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddPrice(buchung, 500);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddPrice(buchung, 600);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
