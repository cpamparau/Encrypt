using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Interfatagrafica
{
    class OperatiiImagini
    {
        ImageList ilGrupajImagini;
        ClasaFisiere files = new ClasaFisiere();

        //constructor implicit
        public OperatiiImagini()
        {
            
            ilGrupajImagini = new ImageList();
        }
        //constructor cu parametri
        public OperatiiImagini(ImageList x)
        {
            ilGrupajImagini = x;
            files.NumeFisier = "istoric.txt";
        }

        public void deseneazaImagine(int numarTipImagine, int numarCopiiImagini)
        {
            Form1.Imagini = new List<PictureBox>();
            Form1.NrCopiiImagini = numarCopiiImagini; //deseneazaImagine(4,2) unde 2 reprezinta numarul de copii
            int indexImagini = 0; // tine evidenta cu care imagine lucram
            Form1.DimensiuneLista = numarTipImagine * numarCopiiImagini; // punem imaginile intr-un PictureBox si copiile cu care lucram
            for (int i = 0; i < Form1.DimensiuneLista - 1; i += numarCopiiImagini)
            {
                for (int j = 0; j < numarCopiiImagini; j++) // Copie pentru fiecare imagine si retine indexul pentru fiecare imagine din lista
                {
                    PictureBox poza = new PictureBox();
                    poza.Image = ilGrupajImagini.Images[ilGrupajImagini.Images.Count - 1]; // imaginea de background este ultima din lista
                    poza.Tag = indexImagini;
                    poza.Click += new EventHandler(imagineClick);
                    Form1.Imagini.Add(poza);
                }
                indexImagini++;
            }
            Form1.ff.Amesteca(ref Form1.Imagini);
            if (numarTipImagine > 8)
                Form1.ff.afiseazaImagini(6);
            else
                Form1.ff.afiseazaImagini(4);
        }

        public void imagineClick(Object sender, EventArgs e)
        {
            PictureBox poza = (PictureBox)sender; //convertim obiectul sender la PictureBox
            int idTag = (int)poza.Tag; // converteste tag-ul la int
            if (Form1.alegeri.Contains(poza) == false && Form1.potriviri.Contains(idTag) == false)
            {
                //formInstance.Computer.Audio.Play(formInstance.Resources.move, AudioPlayMode.Background);
                Form1.alegeri.Add(poza);
                arataimagine(poza);
                if (Form1.alegeri.Count == Form1.NrCopiiImagini)
               {
                    if (Form1.ff.alegePerechi())
                    {
                        Thread.Sleep(1000);
                        Form1.Scor += 20;
                        Form1.timer1.Enabled = true;
                        Form1.ScorEticheta.Text = "Score: " + Form1.Scor;
                        for (int j = 0; j < Form1.alegeri.Count; j++) //ascunde perechile de imagini gasite (dupa 1 secunda) pentru a vedea perechea gasita
                        {
                            Form1.alegeri[j].Visible = false;
                            Form1.potriviri.Add(idTag);
                        }
                        //daca numarul total al indecsilor din Potriviri este egal cu lungimea imaginilor care se afiseaza
                        //atunci jocul s-a terminat
                        if (Form1.potriviri.Count == Form1.DimensiuneLista)
                        {
                            //salvare date pentru scriere in fisier
                            string string_terminare_joc = "Your score: " + Form1.Scor + "\nYour time: " + Form1.CronometruEticheta.Text + "\nMistakes :" + Form1.Greseli;
                            
                            Form1.Scor = 0;
                            Form1.Backsecond.Visible = false;
                            Form1.Btn1.Visible = true;
                            Form1.Medium1.Visible = true;
                            Form1.Hard1.Visible = true;
                            Form1.Back.Visible = true;
                            Form1.ScorEticheta.Text = "";
                            Form1.CronometruEticheta.Visible = false;
                            Form1.ScorEticheta.Visible = false;
                            Form1.NrSecunde = 0;
                            Form1.ff.Timpi = 1;
                            Form1.NrMinute = 0;
                            Form1.timer1.Stop();
                            Form1.Name = Microsoft.VisualBasic.Interaction.InputBox("Introduceti numele dvs", "", "NEPRECIZAT");
                            bool deschiderefis = files.deschideScriereInFisier();
                            if (deschiderefis)
                                MessageBox.Show(files.scrieInFisier(Form1.Name + " " + Form1.Scor + " " + Form1.CronometruEticheta.Text + " " + Form1.Greseli + " " + ilGrupajImagini.ToString()));
                            
                        }
                    }
                    else
                    {
                        Form1.Greseli += 1;
                        Thread.Sleep(1000);
                        for (int i = 0; i < Form1.alegeri.Count; i++)
                            ascundeImagini(Form1.alegeri[i]);
                    }
                    Form1.alegeri.Clear();
                }
            }
        }

        public void ascundeImagini(PictureBox imagine)
        {
            //inlocuieste imaginea curenta cu cea anterioara(cea de background care ascunde imaginile)
            imagine.Image = ilGrupajImagini.Images[ilGrupajImagini.Images.Count - 1];
        }

        public void arataimagine(PictureBox imagine)
        {
            imagine.Image = ilGrupajImagini.Images[Convert.ToInt32(imagine.Tag)];
            Form1.ff.Refresh(); //neaparata nevoie de o instanta a Formei principale
        }
    }
}
