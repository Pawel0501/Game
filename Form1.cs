using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skaczace_ksztalty
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Form1 : Form
    {
        bool Lewo, Prawo, Skok, Przegrana;
        int PredkoscSkoku;
        int Sila;
        int Wynik = 0;
        int PredkoscPostaci = 10;
        
       /// <summary>
       /// 
       /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
   
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {

        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer(object sender, EventArgs e)
        {
            Punkty.Text = "Wynik: " + Wynik;            ///wyswietlanie wyniku

            Postac.Top += PredkoscSkoku;

            if (Skok && Sila < 0)                       ///predkosc z jaka ma sie poruszac postac prawo/lewo oraz predkosc skoku/spadania
            {
                Skok = false;
            }

            if (Lewo)
            {
                Postac.Left -= PredkoscPostaci;
            }

            if (Prawo)
            {
                Postac.Left += PredkoscPostaci;
            }

            if (Skok)
            {
                PredkoscSkoku = -18;
                Sila -= 1;
            }
            else
            {
                PredkoscSkoku = 8;
            }

            foreach (Control x in this.Controls)            ///ustawienia kolizji z elemtanmi gry
            {
                if (x is PictureBox)
                {
                    if ((String)x.Tag == "Bloczek")
                    {
                        if (Postac.Bounds.IntersectsWith(x.Bounds))
                        {
                            Sila = 5;
                            Postac.Top = x.Top - Postac.Height;
                        }
                        x.BringToFront();
                    }
                }

                if ((String)x.Tag == "Trojkat")             ///zdobywanie punktow za zebrany trojkat
                {
                    if (Postac.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                    {
                        x.Visible = false;
                        Wynik++;
                    }
                }

                if ((String)x.Tag == "Kwadrat")             ///przegrana gdy dotknie sie kwadratu
                {
                    if (Postac.Bounds.IntersectsWith(x.Bounds))
                        {
                        timer1.Stop();
                        Przegrana = true;
                        if (MessageBox.Show("Niestety tym razem nie udalo Ci sie wygrac. Czy chcesz rozpoczac gre od nowa?.", ":(", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            Application.Exit();
                            Application.Restart();
                        }
                        else
                        {
                            Application.Exit();
                        }

                    }
                }

                if ((String)x.Tag == "Meta")
                {
                    if (Postac.Bounds.IntersectsWith(x.Bounds) && Wynik >= 5)           ///ilosc ksztaltow jakie nalezy zebrac, aby wygrac
                    {
                        timer1.Stop();

                        if (MessageBox.Show("Ciekawostka: W kazdym trojkacie suma miar katow wewnetrznych miedzy bokami wynosi 180 stopni.", "wygrana", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {

                            this.Hide();
                            Form2 f2 = new Form2();
                            
                            f2.ShowDialog();
                           
                            this.Close();
                        }
                        

                    }
                }
            }
        }

        private void Postac_Click(object sender, EventArgs e)
        {

        }

        private void Form1_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void Punkty_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Meta_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Wcisniety(object sender, KeyEventArgs e)       ///"akcja", ktora ma sie zdarzyc po wcisnieciu klawisza
        {
            if (e.KeyCode == Keys.Space && !Skok)
            {
                Skok = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                Lewo = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                Prawo = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
                Application.Restart();
            }
            if (e.KeyCode == Keys.Q)
            {
                Application.Exit();
            }
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void NieWcisniety(object sender, KeyEventArgs e)        ///gdy klawisz nie wcisniety - brak ruchu postaci
        {
            if (e.KeyCode == Keys.Left)
            {
                Lewo = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                Prawo = false;
            }
            if (Skok)
            {
                Skok = false;
            }
            
        }

      }
}
