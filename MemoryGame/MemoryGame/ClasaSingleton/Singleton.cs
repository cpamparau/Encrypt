using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Interfatagrafica;


namespace ClasaSingleton
{
    public class Singleton
    {
       //instanca privata
        private static Singleton instance;
        
        //date publice
        public int timpi, nrCopiiImagini, dimensiuneLista, nrSecunde, nrMinute, nrOre, greseli , ab, scor;
        public string name;
        public struct rezultat
        {
            int scor;
            DateTime timp;
            string nume;
            string gen;
        };
        public rezultat[] rezultate = new rezultat[100];
        public bool usor, medium, greu;
        public Button btn1, medium1, hard1, backsecond;
        public Label scorEticheta, cronometruEticheta;
        public PictureBox back;
        public List<int> Potriviri;
        public List<PictureBox> Imagini; // contine imagini
        public List<PictureBox> Alegeri; // contine imagini alese

        //constructor implicit privat
        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                if (instance==null)
                    instance = new Singleton();
                return instance;
            }
        }

        //metoda de intializare a unor variabile 'globale'
        public void initializare_date()
        {
            usor = false;
            medium = false;
            greu = false;
            scor = 0;
            ab = 0;
        }

        //curata jocul
        public void  InitializeazaJoc()
        {
            Form1 formInstance = new Form1();
            if (Imagini.Count > 0)
                for (int i = 0; i < Imagini.Count - 1; i++)
                   formInstance.Controls.Remove(Imagini.ElementAt(i));
            Imagini.Clear();
            Alegeri.Clear();
            Potriviri.Clear();
        }

        //metoda de amestecare a imaginilor
        public void Amesteca(ref List<PictureBox> imagini)
        {
            Random rnd = new Random();
            for (int i=0;i<imagini.Count-1;i++)
            {
                int index = rnd.Next(i, imagini.Count);
                if (i!=index)
                {
                    PictureBox img = imagini[i];
                    imagini[i] = imagini[index];
                    imagini[index] = img;
                }
            }
        }

        //metoda de afisare a imaginilor
        public void afiseazaImagini(int numarRanduri)
        {
            Form1 formInstance = new Form1();
            int Xx = 80;
            int Yy = 90;
            for (int i=0;i<Imagini.Count-1;i++)
            {
                Imagini[i].Top = Yy;
                Imagini[i].Left = Xx;
                Imagini[i].Size = new System.Drawing.Size(85, 85);
                formInstance.Controls.Add(Imagini[i]);
                Imagini[i].Visible = true;
                Xx += 100;
                if ((i+1) % numarRanduri==0)
                {
                    Xx = 80;
                    Yy += 90;
                }
            }
        }

        //metoda de alegere a perechilor
        public bool alegePerechi()
        {
            int primaAlegere=0;
            int aDouaAlegere = 0;
            for (int i = 0; i < Alegeri.Count - 1;i++ )
            {
                primaAlegere = (int) Alegeri[i - 1].Tag;
                aDouaAlegere = (int) Alegeri[i].Tag;
                if (primaAlegere != aDouaAlegere)
                    return false;
            }
            return true;
        }
    }
}
