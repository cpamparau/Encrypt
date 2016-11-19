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
        public static Button btn1;
        public static Button medium1;
        public static Button hard1;
        public static Button back;
        public static Button backsecond ;
        public static System.Windows.Forms.Timer Timer1;
        public static Label cronometruEticheta;
        public static Label scorEticheta;
        //public static Control.ControlCollection c;
        public minioni m;
        public paste p;
        public geometrie g;

        //date publice
        public static int timpi, nrCopiiImagini, dimensiuneLista, nrSecunde, nrMinute, nrOre, greseli, ab, scor;
        public static string name;
        public struct rezultat
        {
            int scor;
            DateTime timp;
            string nume;
            string gen;
        };
        public static rezultat[] rezultate = new rezultat[100];
        public static bool usor, medium, greu;
        //public PictureBox back;
        public static List<int> Potriviri;
        public static List<PictureBox> Imagini; // contine imagini
        public static List<PictureBox> Alegeri; // contine imagini alese
        public Form1()
        {
            InitializeComponent();
            btn1=new Button();
            medium1 = new Button();
            //c = this.Controls;
            hard1= new Button();
            back= new Button();
            backsecond= new Button();
            cronometruEticheta = new Label();
            scorEticheta=new Label();
            Timer1 = new System.Windows.Forms.Timer();
            Timer1.Interval = 1000;
            Form1 f = this;
            m=new minioni(ref f);
            p = new paste(ref f);
            g = new geometrie(ref f);
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public static void creare_cronometru()
        {
            //eticheta cronometru
            cronometruEticheta.Width = 200;
            cronometruEticheta.Height = 40;
            cronometruEticheta.Location = new Point(730, 100);
            cronometruEticheta.Font = new Font("Arial", 18, FontStyle.Bold);
            cronometruEticheta.Text = "00:00:00";
            cronometruEticheta.BorderStyle = BorderStyle.FixedSingle;
            cronometruEticheta.Visible = true;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public static void creare_scor()
        {
            //eticheta scor
            scorEticheta.Width = 200;
            scorEticheta.Height = 40;
            scorEticheta.Location = new Point(730, 50);
            scorEticheta.Font = new Font("Arial", 18, FontStyle.Bold);
            scorEticheta.BorderStyle = BorderStyle.FixedSingle;
            scorEticheta.Visible = true;
            scorEticheta.Text = "Score : 0";
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public static void vizibilitati()
        {
            btn1.Visible = false;
            medium1.Visible = false;
            hard1.Visible = false;
            Timer1.Enabled = true;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void adauga_controale_pe_forma()
        {
            //adaugare controale
            Controls.Add(scorEticheta);
            Controls.Add(cronometruEticheta);
            Controls.Add(backsecond);
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void creare_buton_inapoi()
        {
            //butonul back
            backsecond.Width = 200;
            backsecond.Height = 40;
            backsecond.Location = new Point(730, 400);
            backsecond.Text = "Back";
            backsecond.Font = new Font("Arial", 18, FontStyle.Bold);
            backsecond.Click += new EventHandler(clickInapoi);
            backsecond.Visible = true;

        }
        //curata jocul
        public void InitializeazaJoc()
        {
            if (Imagini != null)
            {
                if (Imagini.Count > 0)
                    for (int i = 0; i < Form1.Imagini.Count - 1; i++)
                        Controls.Remove(Form1.Imagini.ElementAt(i));
                Form1.Imagini.Clear();
                if (Alegeri != null)
                    Alegeri.Clear();
                if (Potriviri != null)
                    Potriviri.Clear();
            }
        }
        //metoda de intializare a unor variabile 'globale'
        public static void initializare_date()
        {
            usor = false;
            medium = false;
            greu = false;
            scor = 0;
            ab = 0;
        }
        //inapoi la meniul principal

        public void clickInapoi(object sender, EventArgs e)
        {
            nrSecunde = 0;
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

        //metoda de amestecare a imaginilor
        public static void Amesteca(ref List<PictureBox> imagini)
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
        private void initializeazaButoane()
        {
            Button5.Visible = false;
            Button1.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;
            Button4.Visible = false;

        }

        //metoda de afisare a imaginilor
        public void afiseazaImagini(int numarRanduri)
        {
            int Xx = 80;
            int Yy = 90;
            for (int i = 0; i < Imagini.Count - 1; i++)
            {
                Imagini[i].Top = Yy;
                Imagini[i].Left = Xx;
                Imagini[i].Size = new System.Drawing.Size(85, 85);
                Controls.Add(Imagini[i]);
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
        public static bool alegePerechi()
        {
            int primaAlegere = 0;
            int aDouaAlegere = 0;
            for (int i = 0; i < Form1.Alegeri.Count - 1; i++)
            {
                primaAlegere = (int)Form1.Alegeri[i - 1].Tag;
                aDouaAlegere = (int)Form1.Alegeri[i].Tag;
                if (primaAlegere != aDouaAlegere)
                    return false;
            }
            return true;
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
          
            nrSecunde = 0;
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
            if (Imagini != null)
            {
                if (Imagini.Count > 0)
                    for (int i = 0; i < Imagini.Count - 1; i++)
                       Controls.Remove(Imagini.ElementAt(i));
                Imagini.Clear();
                if (Alegeri != null)
                    Alegeri.Clear();
                if (Potriviri != null)
                    Potriviri.Clear();
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            initializeazaButoane();
            InitializeazaJoc(); // se sterg datele de joc existente
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
            InitializeazaJoc(); // se sterg datele de joc existente
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
            InitializeazaJoc(); // se sterg datele de joc existente
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
        Form1 instance;
        public minioni(ref Form1 i)
        {
            instance = i;
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        
        public void deseneazaImagine(int numarTipImagine, int numarCopiiImagini)
        {
            Form1.Imagini = new List<PictureBox>();
            Form1.nrCopiiImagini = numarCopiiImagini; //deseneazaImagine(4,2) unde 2 reprezinta numarul de copii
            int indexImagini = 0; // tine evidenta cu care imagine lucram
            Form1.dimensiuneLista = numarTipImagine * numarCopiiImagini; // punem imaginile intr-un PictureBox si copiile cu care lucram
            for (int i = 0; i < Form1.dimensiuneLista; i += numarCopiiImagini)
            {
                for (int j = 1; j < numarCopiiImagini; j++) // Copie pentru fiecare imagine si retine indexul pentru fiecare imagine din lista
                {
                    PictureBox poza = new PictureBox();
                    //poza.Image = instance.formInstance.Minion.Images[instance.formInstance.Minion.Images.Count-1]; // imaginea de background este ultima din lista
                    poza.Tag = indexImagini;
                    poza.Click += new EventHandler(imagineClick);
                    //AddHandler pictureImg.Click, AddressOf Me.image_clickMinion 'de verificat 
                    Form1.Imagini.Add(poza);
                }
                indexImagini++;
            }
            Form1.Amesteca(ref Form1.Imagini);
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
            if (!Form1.Alegeri.Contains(poza) && !Form1.Potriviri.Contains(idTag))
            {
                //formInstance.Computer.Audio.Play(formInstance.Resources.move, AudioPlayMode.Background);
                Form1.Alegeri.Add(poza);
                arataimagine(poza);
                if (Form1.Alegeri.Count == Form1.nrCopiiImagini)
                {
                    if (Form1.alegePerechi())
                    {
                        Thread.Sleep(1000);
                        Form1.scor += 20;
                        Form1.Timer1.Enabled = true;
                        Form1.scorEticheta.Text = "Score: " + Form1.scor;
                        for (int j = 0; j < Form1.Alegeri.Count - 1; j++) //ascunde perechile de imagini gasite (dupa 1 secunda) pentru a vedea perechea gasita
                        {
                            Form1.Alegeri[j].Visible = false;
                            Form1.Potriviri.Add(idTag);
                        }
                        //daca numarul total al indecsilor din Potriviri este egal cu lungimea imaginilor care se afiseaza
                        //atunci jocul s-a terminat
                        if (Form1.Potriviri.Count == Form1.dimensiuneLista)
                        {
                            //salvare date pentru scriere in fisier
                            string string_terminare_joc = "Your score: " + Form1.scor + "\nYour time: " /*instance.cronometruEticheta.Txt*/ + "\nMistakes :" + Form1.greseli;
                            Form1.scor = 0;
                            Form1.backsecond.Visible = false;
                            Form1.btn1.Visible = true;
                            Form1.medium1.Visible = true;
                            Form1.hard1.Visible = true;
                            Form1.back.Visible = true;
                            Form1.scorEticheta.Text = "";
                            Form1.cronometruEticheta.Visible = false;
                            Form1.scorEticheta.Visible = false;
                            
                        }
                        else
                        {
                            Form1.greseli += 1;
                            Thread.Sleep(1000);
                            for (int i = 0; i < Form1.Alegeri.Count - 1; i++)
                                ascundeImagini(Form1.Alegeri[i]);
                        }
                        Form1.Alegeri.Clear();
                    }
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void ascundeImagini(PictureBox imagine)
        {
            //inlocuieste imaginea curenta cu cea anterioara(cea de background care ascunde imaginile)
            imagine.Image=instance.Minion.Images[instance.Minion.Images.Count - 1];
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void arataimagine(PictureBox imagine)
        {
            imagine.Image=instance.Minion.Images[Convert.ToInt32(imagine.Tag)];
            instance.Refresh();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void nivelUsor(object sender, EventArgs e)
        {
            deseneazaImagine(4, 2);
            Form1.Timer1.Start();
            Form1.nrSecunde = 0;
            Form1.greseli = 0;
            Form1.usor = true;
            Form1.timpi = 1;
            instance.creare_buton_inapoi();
            Form1.creare_scor();
            instance.adauga_controale_pe_forma();
            Form1.vizibilitati();
            Form1.creare_cronometru();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void nivelMedium(object sender, EventArgs e)
        {
            Form1.Timer1.Start();
            Form1.nrSecunde = 0;
            Form1.greseli = 0;
            Form1.medium = true;
            Form1.timpi = 1;
            deseneazaImagine(8,2);
            instance.creare_buton_inapoi();
            Form1.creare_scor();
            instance.adauga_controale_pe_forma();
            Form1.vizibilitati();
            Form1.creare_cronometru();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void nivelGreu(object sender, EventArgs e)
        {

        }
    }
    public class paste : interfataPentruCategorii
    {
        Form1 instance;
        public paste(ref Form1 i)
        {
            instance = i;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void deseneazaImagine(int numarTipImagine, int numarCopiiImagini)
        {
            Form1.nrCopiiImagini = numarCopiiImagini; //deseneazaImagine(4,2) unde 2 reprezinta numarul de copii
            instance.InitializeazaJoc(); // se sterg datele de joc existente
            int indexImagini = 0; // tine evidenta cu care imagine lucram
            Form1.dimensiuneLista = numarTipImagine * numarCopiiImagini; // punem imaginile intr-un PictureBox si copiile cu care lucram
            for (int i = 0; i < Form1.dimensiuneLista; i += numarCopiiImagini)
            {
                for (int j = 1; j < numarCopiiImagini; j++) // Copie pentru fiecare imagine si retine indexul pentru fiecare imagine din lista
                {
                    PictureBox poza = new PictureBox();
                    //poza.Image = Paste.Images(Minion.Images.Count-1); // imaginea de background este ultima din lista
                    poza.Tag = indexImagini;
                    //AddHandler pictureImg.Click, AddressOf Me.image_clickMinion 'de verificat 
                    Form1.Imagini.Add(poza);
                }
                indexImagini++;
            }
            Form1.Amesteca(ref Form1.Imagini);
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
            if (!Form1.Alegeri.Contains(poza) && !Form1.Potriviri.Contains(idTag))
            {
                //formInstance.Computer.Audio.Play(formInstance.Resources.move, AudioPlayMode.Background);
                Form1.Alegeri.Add(poza);
                arataimagine(poza);
                if (Form1.Alegeri.Count == Form1.nrCopiiImagini)
                {
                    if (Form1.alegePerechi())
                    {
                        Thread.Sleep(1000);
                        Form1.scor += 20;
                        Form1.Timer1.Enabled = true;
                        Form1.scorEticheta.Text = "Score: " + Form1.scor;
                        for (int j = 0; j < Form1.Alegeri.Count - 1; j++) //ascunde perechile de imagini gasite (dupa 1 secunda) pentru a vedea perechea gasita
                        {
                            Form1.Alegeri[j].Visible = false;
                            Form1.Potriviri.Add(idTag);
                        }
                        //daca numarul total al indecsilor din Potriviri este egal cu lungimea imaginilor care se afiseaza
                        //atunci jocul s-a terminat
                        if (Form1.Potriviri.Count == Form1.dimensiuneLista)
                        {
                            //salvare date pentru scriere in fisier
                            string string_terminare_joc = "Your score: " + Form1.scor + "\nYour time: "/*instance.cronometruEticheta.Txt*/ + "\nMistakes :" + Form1.greseli;
                            Form1.scor = 0;
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
                            Form1.greseli += 1;
                            Thread.Sleep(1000);
                            for (int i = 0; i < Form1.Alegeri.Count - 1; i++)
                                ascundeImagini(Form1.Alegeri[i]);
                        }
                        Form1.Alegeri.Clear();
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
        Form1 instance;
        public geometrie(ref Form1 i)
        {
            instance = i;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void deseneazaImagine(int numarTipImagine, int numarCopiiImagini)
        {
            Form1.nrCopiiImagini = numarCopiiImagini; //deseneazaImagine(4,2) unde 2 reprezinta numarul de copii
            instance.InitializeazaJoc(); // se sterg datele de joc existente
            int indexImagini = 0; // tine evidenta cu care imagine lucram
            Form1.dimensiuneLista = numarTipImagine * numarCopiiImagini; // punem imaginile intr-un PictureBox si copiile cu care lucram
            for (int i = 0; i < Form1.dimensiuneLista; i += numarCopiiImagini)
            {
                for (int j = 1; j < numarCopiiImagini; j++) // Copie pentru fiecare imagine si retine indexul pentru fiecare imagine din lista
                {
                    PictureBox poza = new PictureBox();
                    //poza.Image = Gemoetrie.Images(Minion.Images.Count-1); // imaginea de background este ultima din lista
                    poza.Tag = indexImagini;
                    //AddHandler pictureImg.Click, AddressOf Me.image_clickMinion 'de verificat 
                    Form1.Imagini.Add(poza);
                }
                indexImagini++;
            }
            Form1.Amesteca(ref Form1.Imagini);
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
            if (!Form1.Alegeri.Contains(poza) && !Form1.Potriviri.Contains(idTag))
            {
                //formInstance.Computer.Audio.Play(formInstance.Resources.move, AudioPlayMode.Background);
                Form1.Alegeri.Add(poza);
                arataimagine(poza);
                if (Form1.Alegeri.Count == Form1.nrCopiiImagini)
                {
                    if (Form1.alegePerechi())
                    {
                        Thread.Sleep(1000);
                        Form1.scor += 20;
                        //formInstance.Timer1.Enabled = true;
                        //formInstance.scorEticheta.Txt = "Score: "+ scor;
                        for (int j = 0; j < Form1.Alegeri.Count - 1; j++) //ascunde perechile de imagini gasite (dupa 1 secunda) pentru a vedea perechea gasita
                        {
                            Form1.Alegeri[j].Visible = false;
                            Form1.Potriviri.Add(idTag);
                        }
                        //daca numarul total al indecsilor din Potriviri este egal cu lungimea imaginilor care se afiseaza
                        //atunci jocul s-a terminat
                        if (Form1.Potriviri.Count == Form1.dimensiuneLista)
                        {
                            //salvare date pentru scriere in fisier
                            string string_terminare_joc = "Your score: " + Form1.scor + "\nYour time: "/*instance.cronometruEticheta.Txt*/ + "\nMistakes :" + Form1.greseli;
                            Form1.scor = 0;
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
                            Form1.greseli += 1;
                            Thread.Sleep(1000);
                            for (int i = 0; i < Form1.Alegeri.Count - 1; i++)
                                ascundeImagini(Form1.Alegeri[i]);
                        }
                        Form1.Alegeri.Clear();
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
        public Form1 formInstance = new Form1();

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
  
    }
}
