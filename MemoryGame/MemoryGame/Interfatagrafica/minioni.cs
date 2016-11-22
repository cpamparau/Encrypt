using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using interfataCategorii;

namespace Interfatagrafica
{
    public class minioni : interfataPentruCategorii
    {
        Form1 instance;

        public minioni(ref Form1 i)
        {
            instance = i;

        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public void deseneazaImagine(int numarTipImagine, int numarCopiiImagini)
        {
            instance.Imagini = new List<PictureBox>();
            instance.nrCopiiImagini = numarCopiiImagini; //deseneazaImagine(4,2) unde 2 reprezinta numarul de copii
            int indexImagini = 0; // tine evidenta cu care imagine lucram
            instance.dimensiuneLista = numarTipImagine * numarCopiiImagini; // punem imaginile intr-un PictureBox si copiile cu care lucram
            for (int i = 0; i < instance.dimensiuneLista - 1; i += numarCopiiImagini)
            {
                for (int j = 0; j < numarCopiiImagini; j++) // Copie pentru fiecare imagine si retine indexul pentru fiecare imagine din lista
                {
                    PictureBox poza = new PictureBox();
                    poza.Image = instance.Minion.Images[instance.Minion.Images.Count - 1]; // imaginea de background este ultima din lista
                    poza.Tag = indexImagini;
                    poza.Click += new EventHandler(imagineClick);
                    instance.Imagini.Add(poza);
                }
                indexImagini++;
            }
            instance.Amesteca(ref instance.Imagini);
            if (numarTipImagine > 8)
                instance.afiseazaImagini(6);
            else
                instance.afiseazaImagini(4);
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void imagineClick(Object sender, EventArgs e)
        {

            PictureBox poza = (PictureBox)sender; //convertim obiectul sender la PictureBox
            int idTag = (int)poza.Tag; // converteste tag-ul la int
            if (instance.Alegeri.Contains(poza) == false && instance.Potriviri.Contains(idTag) == false)
            {
                //formInstance.Computer.Audio.Play(formInstance.Resources.move, AudioPlayMode.Background);
                instance.Alegeri.Add(poza);
                arataimagine(poza);
                if (instance.Alegeri.Count == instance.nrCopiiImagini)
                {
                    if (instance.alegePerechi())
                    {
                        Thread.Sleep(1000);
                        instance.scor += 20;
                        instance.Timer1.Enabled = true;
                        instance.scorEticheta.Text = "Score: " + instance.scor;
                        for (int j = 0; j < instance.Alegeri.Count; j++) //ascunde perechile de imagini gasite (dupa 1 secunda) pentru a vedea perechea gasita
                        {
                            instance.Alegeri[j].Visible = false;
                            instance.Potriviri.Add(idTag);
                        }
                        //daca numarul total al indecsilor din Potriviri este egal cu lungimea imaginilor care se afiseaza
                        //atunci jocul s-a terminat
                        if (instance.Potriviri.Count == instance.dimensiuneLista)
                        {
                            //salvare date pentru scriere in fisier
                            string string_terminare_joc = "Your score: " + instance.scor + "\nYour time: " /*instance.cronometruEticheta.Txt*/ + "\nMistakes :" + instance.greseli;
                            instance.scor = 0;
                            instance.backsecond.Visible = false;
                            instance.btn1.Visible = true;
                            instance.medium1.Visible = true;
                            instance.hard1.Visible = true;
                            instance.back.Visible = true;
                            instance.scorEticheta.Text = "";
                            instance.cronometruEticheta.Visible = false;
                            instance.scorEticheta.Visible = false;

                        }
                    }
                    else
                    {
                        instance.greseli += 1;
                        Thread.Sleep(1000);
                        for (int i = 0; i < instance.Alegeri.Count; i++)
                            ascundeImagini(instance.Alegeri[i]);
                    }
                    instance.Alegeri.Clear();
                }
            }

        }


        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void ascundeImagini(PictureBox imagine)
        {
            //inlocuieste imaginea curenta cu cea anterioara(cea de background care ascunde imaginile)
            imagine.Image = instance.Minion.Images[instance.Minion.Images.Count - 1];
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void arataimagine(PictureBox imagine)
        {
            imagine.Image = instance.Minion.Images[Convert.ToInt32(imagine.Tag)];
            instance.Refresh();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void nivelUsor(object sender, EventArgs e)
        {
            instance.Alegeri = new List<PictureBox>();
            instance.Potriviri = new List<int>();
            deseneazaImagine(4, 2);
            instance.activare_cronometru();
            instance.nrSecunde = 0;
            instance.greseli = 0;
            instance.medium = false;
            instance.greu = false;
            instance.usor = true;
            instance.timpi = 1;

            //eticheta scor
            instance.scorEticheta.Width = 200;
            instance.scorEticheta.Height = 40;
            instance.scorEticheta.Location = new Point(730, 50);
            instance.scorEticheta.Font = new Font("Arial", 18, FontStyle.Bold);
            instance.scorEticheta.BorderStyle = BorderStyle.FixedSingle;
            instance.scorEticheta.Visible = true;
            instance.scorEticheta.Text = "Score : 0";

            //butonul backsecond
            instance.backsecond.Width = 200;
            instance.backsecond.Height = 40;
            instance.backsecond.Location = new Point(730, 400);
            instance.backsecond.Text = "Back";
            instance.backsecond.Font = new Font("Arial", 18, FontStyle.Bold);
            instance.backsecond.Click += new EventHandler(instance.secondBack);
            instance.backsecond.Visible = true;

            //eticheta cronometru
            instance.cronometruEticheta.Width = 200;
            instance.cronometruEticheta.Height = 40;
            instance.cronometruEticheta.Location = new Point(730, 100);
            instance.cronometruEticheta.Font = new Font("Arial", 18, FontStyle.Bold);
            instance.cronometruEticheta.Text = "00:00:00";
            instance.cronometruEticheta.BorderStyle = BorderStyle.FixedSingle;
            instance.cronometruEticheta.Visible = true;

            //adaugare controale
            instance.Controls.Add(instance.scorEticheta);
            instance.Controls.Add(instance.cronometruEticheta);
            instance.Controls.Add(instance.backsecond);

            instance.btn1.Visible = false;
            instance.medium1.Visible = false;
            instance.hard1.Visible = false;
            instance.back.Visible = false;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void nivelMedium(object sender, EventArgs e)
        {
            instance.Alegeri = new List<PictureBox>();
            instance.Potriviri = new List<int>();
            deseneazaImagine(8, 2);
            instance.Timer1.Start();
            instance.nrSecunde = 0;
            instance.greseli = 0;
            instance.usor = false;
            instance.greu = false;
            instance.medium = true;
            instance.timpi = 1;

            //butonul backsecond
            instance.backsecond.Width = 200;
            instance.backsecond.Height = 40;
            instance.backsecond.Location = new Point(730, 400);
            instance.backsecond.Text = "Back";
            instance.backsecond.Font = new Font("Arial", 18, FontStyle.Bold);
            instance.backsecond.Click += new EventHandler(instance.secondBack);
            instance.backsecond.Visible = true;

            //eticheta cronometru
            instance.cronometruEticheta.Width = 200;
            instance.cronometruEticheta.Height = 40;
            instance.cronometruEticheta.Location = new Point(730, 100);
            instance.cronometruEticheta.Font = new Font("Arial", 18, FontStyle.Bold);
            instance.cronometruEticheta.Text = "00:00:00";
            instance.cronometruEticheta.BorderStyle = BorderStyle.FixedSingle;
            instance.cronometruEticheta.Visible = true;

            //eticheta scor
            instance.scorEticheta.Width = 200;
            instance.scorEticheta.Height = 40;
            instance.scorEticheta.Location = new Point(730, 50);
            instance.scorEticheta.Font = new Font("Arial", 18, FontStyle.Bold);
            instance.scorEticheta.BorderStyle = BorderStyle.FixedSingle;
            instance.scorEticheta.Visible = true;
            instance.scorEticheta.Text = "Score : 0";


            //adaugare controale
            instance.Controls.Add(instance.scorEticheta);
            instance.Controls.Add(instance.cronometruEticheta);
            instance.Controls.Add(instance.backsecond);

            instance.back.Visible = false;
            instance.btn1.Visible = false;
            instance.medium1.Visible = false;
            instance.hard1.Visible = false;
            instance.Timer1.Enabled = true;

        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void nivelGreu(object sender, EventArgs e)
        {
            instance.Alegeri = new List<PictureBox>();
            instance.Potriviri = new List<int>();
            deseneazaImagine(12, 2);
            instance.nrMinute = 0;
            instance.nrSecunde = 0;
            instance.greseli = 0;
            instance.usor = false;
            instance.greu = true;
            instance.medium = false;
            instance.timpi = 1;

            //butonul backsecond
            instance.backsecond.Width = 200;
            instance.backsecond.Height = 40;
            instance.backsecond.Location = new Point(730, 400);
            instance.backsecond.Text = "Back";
            instance.backsecond.Font = new Font("Arial", 18, FontStyle.Bold);
            instance.backsecond.Click += new EventHandler(instance.secondBack);
            instance.backsecond.Visible = true;

            //eticheta cronometru
            instance.cronometruEticheta.Width = 200;
            instance.cronometruEticheta.Height = 40;
            instance.cronometruEticheta.Location = new Point(730, 100);
            instance.cronometruEticheta.Font = new Font("Arial", 18, FontStyle.Bold);
            instance.cronometruEticheta.Text = "00:00:00";
            instance.cronometruEticheta.BorderStyle = BorderStyle.FixedSingle;
            instance.cronometruEticheta.Visible = true;

            //eticheta scor
            instance.scorEticheta.Width = 200;
            instance.scorEticheta.Height = 40;
            instance.scorEticheta.Location = new Point(730, 50);
            instance.scorEticheta.Font = new Font("Arial", 18, FontStyle.Bold);
            instance.scorEticheta.BorderStyle = BorderStyle.FixedSingle;
            instance.scorEticheta.Visible = true;
            instance.scorEticheta.Text = "Score : 0";


            //adaugare controale
            instance.Controls.Add(instance.scorEticheta);
            instance.Controls.Add(instance.cronometruEticheta);
            instance.Controls.Add(instance.backsecond);

            instance.back.Visible = false;
            instance.btn1.Visible = false;
            instance.medium1.Visible = false;
            instance.hard1.Visible = false;
            instance.Timer1.Enabled = true;
        }
    }
}
