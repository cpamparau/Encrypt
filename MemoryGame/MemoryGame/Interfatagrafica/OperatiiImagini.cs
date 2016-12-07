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
        Form1 instance;

        //constructor implicit
        public OperatiiImagini()
        {
            
            ilGrupajImagini = new ImageList();
        }
        //constructor cu parametri
        public OperatiiImagini(ImageList x, ref Form1 i)
        {
            ilGrupajImagini = x;
            instance = i;
        }

        public Form1 instance_f1
        {
            get { return instance; } 
            set {instance=value;}
        }
        public void deseneazaImagine(int numarTipImagine, int numarCopiiImagini)
        {
            Form1.imagini = new List<PictureBox>();
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
                    Form1.imagini.Add(poza);
                }
                indexImagini++;
            }
            instance.Amesteca(ref Form1.Imagini);
            if (numarTipImagine > 8)
                instance.afiseazaImagini(6);
            else
                instance.afiseazaImagini(4);
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
                    if (instance.alegePerechi())
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
                            string string_terminare_joc = "Your score: " + Form1.Scor + "\nYour time: " /*instance.cronometruEticheta.Txt*/ + "\nMistakes :" + Form1.Greseli;
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
                            instance.Timpi = 1;
                            Form1.NrMinute = 0;
                            Form1.timer1.Stop();
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
            instance.Refresh();
        }
    }
}
