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
    public partial class Form2 : Form
    {
        bool Lewo, Prawo, Skok, Przegrana;
        int PredkoscSkoku;
        int Sila;
        int Wynik = 0;
        int PredkoscPostaci = 10;

        int PredkoscPozioma = 7;
        int PredkoscPozioma2 = 5;
        int predkoscPozioma3 = 3;
       /// <summary>
       /// 
       /// </summary>
        public Form2()
        {
            InitializeComponent();
            MessageBox.Show("Czas na poziom drugi. Teraz bedzie nieco trudniej. Zbierz wszystkie kola i dojdź do drzwi. Unikaj kwadratow, gdy ich dotkniesz to przegrasz. Esc-restart gry, q-wyjscie z gry","Opis poziomu 2.");

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
            Punkty.Text = "Wynik: " + Wynik;                        ///wyswietlanie wyniku

            Postac.Top += PredkoscSkoku;                            ///predkosc z jaka ma sie poruszac postac prawo/lewo oraz predkosc skoku/spadania

            if (Skok && Sila < 0)                   
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

                if ((String)x.Tag == "Kolo")            ///zdobywanie punktow za zebrane kolo
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
                        else {
                            Application.Exit();
                        }
                        
                                 
                        
                    }
                }

                if ((String)x.Tag == "Meta")
                {
                    if (Postac.Bounds.IntersectsWith(x.Bounds) && Wynik == 4 )          ///ilosc ksztaltow jakie nalezy zebrac, aby wygrac
                    {
                        timer1.Stop();

                        if (MessageBox.Show("Ciekawostka: Srednica kola to dwukrotnosc jego promienia. Brawo, udalo Ci sie wygrac.", "Wygrana", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            Application.Exit();
                        }


                    }
                }
            }
            
            bloczekRuchomy.Left -= PredkoscPozioma;             ///warunki odpowiadajace za poruszajace sie bloczki oraz poruszajacy sie kwadrat        

            if(bloczekRuchomy.Left < 0 || bloczekRuchomy.Left + bloczekRuchomy.Width > this.ClientSize.Width)
            {
                PredkoscPozioma = -PredkoscPozioma;
            }
            
            bloczekRuchomy2.Left -= PredkoscPozioma2;

            if (bloczekRuchomy2.Left < 155 || bloczekRuchomy2.Left > 341)
            {
                PredkoscPozioma2 = -PredkoscPozioma2;
            }

            kwadratRuchomy.Left -= predkoscPozioma3;

            if (kwadratRuchomy.Left < pictureBox9.Left || kwadratRuchomy.Left + kwadratRuchomy.Width > pictureBox9.Left + pictureBox9.Width)
            {
                predkoscPozioma3 = -predkoscPozioma3;
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

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Wcisniety(object sender, KeyEventArgs e)           ///"akcja", ktora ma sie zdarzyc po wcisnieciu klawisza
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
            if (e.KeyCode == Keys.Escape && Przegrana == true)
            {
                Application.Exit();
                Application.Restart();
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
        private void NieWcisniety(object sender, KeyEventArgs e)            ///gdy klawisz nie wcisniety - brak ruchu postaci
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
