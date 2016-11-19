using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using interfataCategorii;

namespace Interfatagrafica
{
    public partial class Form1 : Form
    {
        private Singleton instance = Singleton.Instance;
        public Button btn1=new Button();
        public Button medium1 = new Button();
        public Button hard1 = new Button();
        public Button back = new Button();
        public Button backsecond = new Button();
        public  Label cronometruEticheta = new Label();
        public Label scorEticheta = new Label();
        public minioni m=new minioni();
        public paste p=new paste();
        public geometrie g=new geometrie();
        
        public Form1()
        {
            InitializeComponent();
            
        }

        //inapoi la meniul principal
        public void clickInapoi(object sender, EventArgs e)
        {
            instance.nrSecunde = 0;
            btn1.Visible = false;
            cronometruEticheta.Visible=false;
            scorEticheta.Visible=false;
            backsecond.Visible=false;
            medium1.Visible = false;
            hard1.Visible = false;
            back.Visible = false;
            Button1.Visible = true;
            Button2.Visible = true;
            Button3.Visible = true;
            Button4.Visible = true;
            Button5.Visible = true;
        }

        private void initializeazaButoane()
        {
            Button5.Visible = false;
            Button1.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;
            Button4.Visible = false;

        }

        private void adaugaControale()
        {
            Controls.Add(btn1);
            Controls.Add(medium1);
            Controls.Add(hard1);
            Controls.Add(back);
        }
        private void buton_creare_din_cod(ref Button x, String nivel, int XLocation, int YLocation)
        {
            x.Visible = true;
            x.Text = nivel;
            x.Location = new Point(XLocation, YLocation);
            x.Width = 200;
            x.Height = 80;
            x.Font = new Font("Arial", 18, FontStyle.Bold);
            x.FlatStyle = FlatStyle.Flat;
            x.BackgroundImageLayout = ImageLayout.Stretch;
        }
        public void secondBack(object sender, EventArgs e)
        {
            instance.nrSecunde = 0;
            Timer1.Stop();
            cronometruEticheta.Text="00:00:00";
            Timer1.Dispose();
            btn1.Visible = true;
            medium1.Visible = true;
            hard1.Visible = true;
            back.Visible = true;
            Button1.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;
            Button4.Visible = false;
            Button5.Visible = false;

            cronometruEticheta.Visible = false;
            scorEticheta.Visible = false;
            backsecond.Visible = false;
            instance.InitializeazaJoc();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            initializeazaButoane();
            //butonul usor

            buton_creare_din_cod(ref btn1,"Easy",100,50);
            btn1.BackgroundImage = Interfatagrafica.Properties.Resources.chenar;
            btn1.Click += new EventHandler(m.nivelUsor);

            //nivelul medium
            buton_creare_din_cod(ref medium1, "Medium",320,50);
            medium1.BackgroundImage = Interfatagrafica.Properties.Resources.chenar;
            medium1.Click += new EventHandler(m.nivelMedium);

            //nivelul greu
            buton_creare_din_cod(ref hard1, "Hard", 540,50);
            hard1.BackgroundImage = Interfatagrafica.Properties.Resources.chenar;
            hard1.Click += new EventHandler(m.nivelGreu);

            buton_creare_din_cod(ref back, "", 320,280);
            back.BackgroundImage = Interfatagrafica.Properties.Resources.backk1;
            back.Click += new EventHandler(clickInapoi);
            adaugaControale();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            initializeazaButoane();
            //butonul usor
            buton_creare_din_cod(ref btn1, "Easy", 100,50);
            btn1.BackgroundImage = Interfatagrafica.Properties.Resources.smile;
            btn1.Click += new EventHandler(p.nivelUsor);

            //butonul medium

            buton_creare_din_cod(ref medium1, "Medium", 320, 50);
            medium1.BackgroundImage = Interfatagrafica.Properties.Resources.chenar;
            medium1.Click += new EventHandler(p.nivelMedium);

            //nivelul greu

            buton_creare_din_cod(ref hard1, "Hard", 540, 50);
            hard1.BackgroundImage = Interfatagrafica.Properties.Resources.chenar;
            hard1.Click += new EventHandler(p.nivelGreu);

            buton_creare_din_cod(ref back, "", 320, 280);
            back.BackgroundImage = Interfatagrafica.Properties.Resources.backk1;
            back.Click += new EventHandler(clickInapoi);
            adaugaControale();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            initializeazaButoane();

            //butonul usor
            buton_creare_din_cod(ref btn1, "Easy", 100, 50);
            btn1.BackgroundImage = Interfatagrafica.Properties.Resources.smile;
            btn1.Click += new EventHandler(g.nivelUsor);
            //butonul medium

            buton_creare_din_cod(ref medium1, "Medium", 320, 50);
            medium1.BackgroundImage = Interfatagrafica.Properties.Resources.chenar;
            medium1.Click += new EventHandler(g.nivelMedium);

            //nivelul greu

            buton_creare_din_cod(ref hard1, "Hard", 540, 50);
            hard1.BackgroundImage = Interfatagrafica.Properties.Resources.chenar;
            hard1.Click += new EventHandler(g.nivelGreu);


            buton_creare_din_cod(ref back, "", 320, 280);
            back.BackgroundImage = Interfatagrafica.Properties.Resources.backk1;
            back.Click += new EventHandler(clickInapoi);
            adaugaControale();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sigur parasiti aplicatia?", "",MessageBoxButtons.YesNo)==DialogResult.Yes)
                this.Close();
        }
       }
    public class minioni : interfataPentruCategorii
    {
        //date membre
        private Singleton instance;
        private Interfatagrafica.Form1 formInstance = new Interfatagrafica.Form1();

         //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
       
        private void creare_cronometru()
        {
            //eticheta cronometru
            formInstance.cronometruEticheta.Width=200;
            formInstance.cronometruEticheta.Height=40;
            formInstance.cronometruEticheta.Location = new Point(730,100);
            formInstance.cronometruEticheta.Font = new Font("Arial", 18, FontStyle.Bold);
            formInstance.cronometruEticheta.Text="00:00:00";
            formInstance.cronometruEticheta.BorderStyle = BorderStyle.FixedSingle;
            formInstance.cronometruEticheta.Visible=true;
        }

         //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        
        private void creare_scor()
        {
             //eticheta scor
            formInstance.scorEticheta.Width=200;
            formInstance.scorEticheta.Height=40;
            formInstance.scorEticheta.Location=new Point(730,50);
            formInstance.scorEticheta.Font = new Font("Arial", 18, FontStyle.Bold);
            formInstance.scorEticheta.BorderStyle=BorderStyle.FixedSingle;
            formInstance.scorEticheta.Visible=true;
            formInstance.scorEticheta.Text = "Score : 0";
        }

        private void vizibilitati()
        {
            formInstance.btn1.Visible=false;
            formInstance.medium1.Visible=false;
            formInstance.hard1.Visible=false;
            formInstance.Timer1.Enabled=true;
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        
        private void adauga_controale_pe_forma()
        {
            //adaugare controale
            formInstance.Controls.Add(formInstance.scorEticheta);
            formInstance.Controls.Add(formInstance.cronometruEticheta);
            formInstance.Controls.Add(formInstance.backsecond);
        }

         //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        
        private void creare_buton_inapoi()
        {
             //butonul back
            formInstance.backsecond.Width=200;
            formInstance.backsecond.Height=40;
            formInstance.backsecond.Location=new Point(730,400);
            formInstance.backsecond.Text="Back";
            formInstance.backsecond.Font=new Font("Arial", 18, FontStyle.Bold);
            formInstance.backsecond.Click+=new EventHandler(formInstance.clickInapoi);
            formInstance.backsecond.Visible=true;

        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void deseneazaImagine(int numarTipImagine, int numarCopiiImagini)
        {
            instance = Singleton.Instance;
            instance.Imagini = new List<PictureBox>();
            instance.nrCopiiImagini = numarCopiiImagini; //deseneazaImagine(4,2) unde 2 reprezinta numarul de copii
            instance.InitializeazaJoc(); // se sterg datele de joc existente
            int indexImagini = 0; // tine evidenta cu care imagine lucram
            instance.dimensiuneLista = numarTipImagine * numarCopiiImagini; // punem imaginile intr-un PictureBox si copiile cu care lucram
            for (int i = 0; i < instance.dimensiuneLista; i += numarCopiiImagini)
            {
                for (int j = 1; j < numarCopiiImagini; j++) // Copie pentru fiecare imagine si retine indexul pentru fiecare imagine din lista
                {
                    PictureBox poza = new PictureBox();
                    poza.Image = formInstance.Minion.Images[formInstance.Minion.Images.Count-1]; // imaginea de background este ultima din lista
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
            instance = Singleton.Instance;
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
                        formInstance.Timer1.Enabled = true;
                        formInstance.scorEticheta.Text = "Score: "+ instance.scor;
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
                            string string_terminare_joc = "Your score: " + instance.scor + "\nYour time: " /*instance.cronometruEticheta.Txt*/ + "\nMistakes :" + instance.greseli;
                            instance.scor = 0;
                            formInstance.backsecond.Visible=false;
                            formInstance.btn1.Visible=true;
                            formInstance.medium1.Visible=true;
                            formInstance.hard1.Visible=true;
                            formInstance.back.Visible=true;
                            formInstance.scorEticheta.Text="";
                            formInstance.cronometruEticheta.Visible=false;
                            formInstance.scorEticheta.Visible=false;
                            
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
            //inlocuieste imaginea curenta cu cea anterioara(cea de background care ascunde imaginile)
            imagine.Image=formInstance.Minion.Images[formInstance.Minion.Images.Count - 1];
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void arataimagine(PictureBox imagine)
        {
            imagine.Image=formInstance.Minion.Images[Convert.ToInt32(imagine.Tag)];
            formInstance.Refresh();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void nivelUsor(object sender, EventArgs e)
        {
            deseneazaImagine(4, 2);
            formInstance.Timer1.Start();
            instance.nrSecunde=0;
            instance.greseli=0;
            instance.usor=true;
            instance.timpi=1;
            creare_buton_inapoi();
            creare_scor();
            adauga_controale_pe_forma();
            vizibilitati();
            creare_cronometru();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void nivelMedium(object sender, EventArgs e)
        {
            instance = Singleton.Instance;
            formInstance.Timer1.Start();
            instance.nrSecunde=0;
            instance.greseli=0;
            instance.medium=true;
            instance.timpi=1;
            deseneazaImagine(8,2);
            creare_buton_inapoi();
            creare_scor();
            adauga_controale_pe_forma();
            vizibilitati();
            creare_cronometru();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void nivelGreu(object sender, EventArgs e)
        {

        }
    }
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
                            string string_terminare_joc = "Your score: " + instance.scor + "\nYour time: "/*instance.cronometruEticheta.Txt*/ + "\nMistakes :" + instance.greseli;
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

        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void arataimagine(PictureBox imagine)
        {

        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void nivelUsor(object sender, EventArgs e)
        {

        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void nivelMedium(object sender, EventArgs e)
        {

        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void nivelGreu(object sender, EventArgs e)
        {

        }
    }
    public class geometrie : interfataPentruCategorii
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
                    //poza.Image = Gemoetrie.Images(Minion.Images.Count-1); // imaginea de background este ultima din lista
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
                            string string_terminare_joc = "Your score: " + instance.scor + "\nYour time: "/*instance.cronometruEticheta.Txt*/ + "\nMistakes :" + instance.greseli;
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

        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void arataimagine(PictureBox imagine)
        {

        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void nivelUsor(object sender, EventArgs e)
        {

        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void nivelMedium(object sender, EventArgs e)
        {

        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void nivelGreu(object sender, EventArgs e)
        {

        }
    }
    public class Singleton
    {
        //instata privata
        private static Singleton instance;

        //date publice
        public int timpi, nrCopiiImagini, dimensiuneLista, nrSecunde, nrMinute, nrOre, greseli, ab, scor;
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
                if (instance == null)
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
        public void InitializeazaJoc()
        {
            Form1 formInstance = new Form1();
            if (Imagini != null)
            {
                if (Imagini.Count > 0)
                    for (int i = 0; i < Imagini.Count - 1; i++)
                        formInstance.Controls.Remove(Imagini.ElementAt(i));
                Imagini.Clear();
                if (Alegeri != null)
                    Alegeri.Clear();
                if (Potriviri != null)
                    Potriviri.Clear();
            }
        }

        //metoda de amestecare a imaginilor
        public void Amesteca(ref List<PictureBox> imagini)
        {
            Random rnd = new Random();
            for (int i = 0; i < imagini.Count - 1; i++)
            {
                int index = rnd.Next(i, imagini.Count);
                if (i != index)
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
            for (int i = 0; i < Imagini.Count - 1; i++)
            {
                Imagini[i].Top = Yy;
                Imagini[i].Left = Xx;
                Imagini[i].Size = new System.Drawing.Size(85, 85);
                formInstance.Controls.Add(Imagini[i]);
                Imagini[i].Visible = true;
                Xx += 100;
                if ((i + 1) % numarRanduri == 0)
                {
                    Xx = 80;
                    Yy += 90;
                }
            }
        }

        //metoda de alegere a perechilor
        public bool alegePerechi()
        {
            int primaAlegere = 0;
            int aDouaAlegere = 0;
            for (int i = 0; i < Alegeri.Count - 1; i++)
            {
                primaAlegere = (int)Alegeri[i - 1].Tag;
                aDouaAlegere = (int)Alegeri[i].Tag;
                if (primaAlegere != aDouaAlegere)
                    return false;
            }
            return true;
        }

    }
}
