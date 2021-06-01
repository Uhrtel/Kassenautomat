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
        public void AddPrice(double preisstufe)
        {
            Buchung buchung = new Buchung();

            buchung.preisstufe = preisstufe;

            buchung.gesamtKosten = preisstufe;

            var result = DialogResult.None;

            double zuZahlen = 0.0;

            result = MessageBox.Show("Vier Fahrten Ticket?", "Vier Fahrten", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                buchung.gesamtKosten = (buchung.gesamtKosten * 0.75) * 4;
                buchung.vierFahrten = true;
            }
            else
            {
                result = MessageBox.Show("Nur ein Tagesticket?", "Tagesticket", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    buchung.gesamtKosten = buchung.gesamtKosten * 1.4;
                    buchung.tagesTicket = true;
                }
                else
                {
                    // Entweder Tagesticket oder Vier Fahrten
                    AddPrice(preisstufe);
                    return;
                }

            }

            result = MessageBox.Show("Gibt es eine Vergünstigung? (Kind, Hund, Fahrrad)", "Rabatt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                buchung.gesamtKosten = buchung.gesamtKosten * 0.5;
                buchung.verguenstigung = true;
            }

            result = MessageBox.Show("Möchten Sie in der 1. Klasse fahren?", "1. Klasse", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                buchung.gesamtKosten = buchung.gesamtKosten * 1.5;
                buchung.ersteKlasse = true;
            }

            if (buchung.ersteKlasse)
                buchung.klasseText = "Erste";
            else
                buchung.klasseText = "Zweite";

            if (buchung.verguenstigung)
                buchung.verguenstigungText = "Ja";
            else
                buchung.verguenstigungText = "Nein";

            // Umrechnung in €
            buchung.preisstufe /= 100;
            buchung.gesamtKosten /= 100;

            ListViewItem lv2 = new ListViewItem(new string[] { buchung.preisstufe.ToString() + "€", buchung.gesamtKosten.ToString() + "€", buchung.klasseText, buchung.verguenstigungText  });
            listView1.Items.Add(lv2);
            listView1.View = View.Details;

            foreach(ListViewItem row in listView1.Items)
            {
                zuZahlen += Double.Parse(row.SubItems[1].Text.Remove(row.SubItems[1].Text.IndexOf('€')));
            }

            lblGesamtkosten.Text = zuZahlen.ToString() + "€" ;

        }



        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddPrice(120);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddPrice(210);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddPrice(350);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddPrice(480);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddPrice(600);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddPrice(740);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vielen Dank für Ihren Einkauf!", "Abschluss", MessageBoxButtons.OK, MessageBoxIcon.None);
            listView1.Items.Clear();
        }
    }
}
