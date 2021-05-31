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


        public void AddPrice(double preisstufe)
        {
            buchung = new Buchung();

           

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
                if (buchungen.Count >= 1)
                {
                    gesamtkosten = item.Kosten + gesamtkosten;

                }
                else
                {

                    buchungen.Add(buchung);
                }
               
            }
           
            buchungen.Add(buchung);
            gesamtkosten = buchung.Kosten;

            

            foreach (Buchung buchung in buchungen)
            {

                ListViewItem lv2 = new ListViewItem(new string[] { buchung.Kosten.ToString(), buchung.vergünstigung.ToString() });
                listView1.Items.Add(lv2);
                listView1.View = View.Details;
            }

            //label1.Text = ();

        }



        public Form1()
        {
            InitializeComponent();
            
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            ListViewItem lv = new ListViewItem(new string[] { "Preis", "Rabatt" });
            listView1.Items.Add(lv);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddPrice(100);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddPrice(200);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddPrice(300);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddPrice(400);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddPrice(500);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddPrice(600);
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
