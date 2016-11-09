using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using interfataCategorii;
using Interfatagrafica;
using ClasaSingleton;

namespace Paste
{
    public class paste : interfataPentruCategorii
    {
        //date membre
        private Singleton instance = Singleton.Instance;
        private Form1 formInstance = new Form1();

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void deseneazaImagine(int numarTipImagine, int numarCopiiImagini)
        {
            instance.nrCopiiImagini = numarCopiiImagini; //deseneazaImagine(4,2) unde 2 reprezinta numarul de copii
            instance.InitializeazaJoc(); // se sterg datele de joc existente
            int indexImagini = 0; // tine evidenta cu care imagine lucram
            instance.dimensiuneLista = numarTipImagine * numarCopiiImagini; // punem imaginile intr-un PictureBox si copiile cu care lucram
            for (int i = 0; i < instance.dimensiuneLista; i += numarCopiiImagini)
            {
                for (int j = 1; j < numarCopiiImagini; j++) // Copie pentru fiecare imagine si retine indexul pentru fiecare imagine din lista
                {
                    PictureBox poza = new PictureBox();
                    //poza.Image = Paste.Images(Minion.Images.Count-1); // imaginea de background este ultima din lista
                    poza.Tag = indexImagini;
                    //AddHandler pictureImg.Click, AddressOf Me.image_clickMinion 'de verificat 
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

        public void imagineClick(Object sender)
        {
            PictureBox poza = (PictureBox)sender; //convertim obiectul sender la PictureBox
            int idTag = (int)poza.Tag; // converteste tag-ul la int
            if (!instance.Alegeri.Contains(poza) && !instance.Potriviri.Contains(idTag))
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
                        //formInstance.Timer1.Enabled = true;
                        //formInstance.scorEticheta.Txt = "Score: "+ scor;
                        for (int j = 0; j < instance.Alegeri.Count - 1; j++) //ascunde perechile de imagini gasite (dupa 1 secunda) pentru a vedea perechea gasita
                        {
                            instance.Alegeri[j].Visible = false;
                            instance.Potriviri.Add(idTag);
                        }
                        //daca numarul total al indecsilor din Potriviri este egal cu lungimea imaginilor care se afiseaza
                        //atunci jocul s-a terminat
                        if (instance.Potriviri.Count == instance.dimensiuneLista)
                        {
                            //salvare date pentru scriere in fisier
                            string string_terminare_joc = "Your score: " + Convert.ToString(instance.scor) + "\nYour time: " /*instance.cronometruEticheta.Txt*/ + "\nMistakes :" + Convert.ToString(instance.greseli);
                            instance.scor = 0;
                            /* formInstance.backsecond.Visible=False;
                             * formInstance.btn1.Visible=true;
                             * formInstance.medium1.Visible=true;
                             * formInstance.hard1.Visible=true;
                             * formInstance.back.Visible=true;
                             * instance.scorEticheta.Text="";
                             * instance.cronometruEticheta=false;
                             * instance.scorEticheta=false;
                             */
                        }
                        else
                        {
                            instance.greseli += 1;
                            Thread.Sleep(1000);
                            for (int i = 0; i < instance.Alegeri.Count - 1; i++)
                                ascundeImagini(instance.Alegeri[i]);
                        }
                        instance.Alegeri.Clear();
                    }
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void ascundeImagini(PictureBox imagine)
        {
            //imagine.Image = formInstance.Paste.Images(formInstance.Paste.Images.Count - 1) 
            //inlocuieste imaginea curenta cu cea anterioara 
            //imaginea anterioara fiinde cea de background , care ascunde imaginile
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void arataimagine(PictureBox imagine)
        {
            //image.Image = formInstance.Paste.Images(Convert.ToInt32(image.Tag))
            formInstance.Refresh();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void nivelUsor()
        {

        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void nivelMedium()
        {

        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void nivelGreu()
        {

        }
    }
}
