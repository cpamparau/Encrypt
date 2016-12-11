using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;


namespace Interfatagrafica
{
   /// <summary>
   /// Clasa va prelucra imaginile dintr-un ImageList si se va crea o instanta a acesteia in clasa Nivele
   /// </summary>
    class OperatiiImagini
    {
        /// <summary>
        /// Variabila de tip ImageList care contine imaginile pentru care se vor executa operatiile 
        /// din clasa curenta(metodele)
        /// </summary>
        ImageList ilGrupajImagini;
        /// <summary>
        /// Instanta a clasei care lucreaza cu fisiere prin care se vor permite operatiile cu fisiere
        /// doar prin accesarea unor simple metode ale acestei clase. Pentru informatii suplimentare,
        /// accesati documentatia clasei 'ClasaFisiere'
        /// </summary>
        ClasaFisiere files = new ClasaFisiere();

        /// <summary>
        /// Constructor implicit al clasei curente care ceeaza pentru metoda ilGrupajImagini un obiect nou de tip ImageList
        /// </summary>
        public OperatiiImagini()
        {
          
            ilGrupajImagini = new ImageList();
        }
        /// <summary>
        /// Constructor cu parametri pentru clasa curenta; in acest constructor, se va seta numele fisierului care va contine
        /// istoricul jocului la "istoric.txt"; NU se va negocia acest nume al fisierului cu utilizatorul!!!!
        /// </summary>
        /// <param name="x">Variabila de tip ImageList care va fi atribuita datei ilGrupajImagini</param>
        public OperatiiImagini(ImageList x)
        {
            ilGrupajImagini = x;
            files.NumeFisier = "istoric.txt";
        }
        /// <summary>
        /// Metoda care deseneaza Imaginile pe forma
        /// </summary>
        /// <param name="numarTipImagine">Numarul de imagini dispuse pe coloana</param>
        /// <param name="numarCopiiImagini">Numarul de iamgini dispuse pe linie</param>
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
        /// <summary>
        /// Metoda care trateaza click-ul pe o imagine si verifica daca imaginea curenta selectata este identica sau nu cu cea anterioara
        /// </summary>
        /// <param name="sender">Obiectul sender standard asociat unei proceduri-eveniment</param>
        /// <param name="e">Variabila de tip EventArgs standard asociata unei proceduri-eveniment</param>
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
                            string nume_categorie = "";
                            string nume = "";
                            if (ilGrupajImagini == Form1.ff.Minion)
                                nume_categorie = "Minion";
                            else if (ilGrupajImagini == Form1.ff.Easter)
                                nume_categorie = "Paste";
                            else
                                nume_categorie="Geometrie";
                            Form1.timer1.Stop();
                            DateTime data = new DateTime();
                            nume = Microsoft.VisualBasic.Interaction.InputBox("Introduceti numele dvs", "", "NEPRECIZAT");
                            //salvare date pentru scriere in fisier
                            string string_terminare_joc = "Your score: " + Form1.Scor + "\nYour time: " + Form1.CronometruEticheta.Text + "\nMistakes :" + Form1.Greseli;
                            bool deschiderefis = files.deschideScriereInFisier("istoric.txt");
                            MessageBox.Show(string_terminare_joc);
                            if (deschiderefis)
                                MessageBox.Show(files.scrieInFisier(nume + " " + Form1.Scor + " " + Form1.CronometruEticheta.Text + " " + Form1.Greseli + " " + DateTime.Now +" "+ nume_categorie+"\n"));
                            files.inchideScriereFisier();
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
        /// <summary>
        /// Metoda care ascunde imaginea, in sensul ca intr-o pozitie anume, se va afisa imaginea generica cu semnul intrebarii,
        /// adica ultima imagine din controlul ilGrupajImagini
        /// </summary>
        /// <param name="imagine">Variabila de tip PictureBox care reprezinta imaginea curenta care va fi 'ascunsa'</param>
        public void ascundeImagini(PictureBox imagine)
        {
            //inlocuieste imaginea curenta cu cea anterioara(cea de background care ascunde imaginile)
            imagine.Image = ilGrupajImagini.Images[ilGrupajImagini.Images.Count - 1];
        }
        /// <summary>
        /// Metoda care afiseaza in imaginea unde s-a efectuat click, imaginea specificata ca parametru
        /// </summary>
        /// <param name="imagine">Variabila de tip PictureBox care reprezinta imaginea care va fi afisata</param>
        public void arataimagine(PictureBox imagine)
        {
            imagine.Image = ilGrupajImagini.Images[Convert.ToInt32(imagine.Tag)];
            Form1.ff.Refresh(); //neaparata nevoie de o instanta a Formei principale
        }
    }
}
