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
using Microsoft.VisualBasic;
using interfataCategorii;

namespace Interfatagrafica
{
    public partial class Form1 : Form
    {
        public Button btn1;
        public Button medium1;
        public Button hard1;
        public Button back;
        public Button backsecond ;
        public Label cronometruEticheta;
        public Label scorEticheta;
        //public static Control.ControlCollection c;
        public minioni m;
        public paste p;
        public geometrie g;

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
        //public PictureBox back;
        public List<int> Potriviri;
        public List<PictureBox> Imagini; // contine imagini
        public List<PictureBox> Alegeri; // contine imagini alese
        public Form1()
        {
            InitializeComponent();
            btn1=new Button();
            medium1 = new Button();
            hard1= new Button();
            back= new Button();
            backsecond= new Button();
            cronometruEticheta = new Label();
            scorEticheta=new Label();
            Form1 f = this;
            m=new minioni(ref f);
            p = new paste(ref f);
            g = new geometrie(ref f);
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void creare_cronometru()
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

        public void creare_scor()
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

        public void vizibilitati()
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
            Controls.Add(btn1);
            Controls.Add(medium1);
            Controls.Add(hard1);
            Controls.Add(back);
        }
        
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void creare_buton_inapoi()
        {
            //butonul backsecond
            backsecond.Width = 200;
            backsecond.Height = 40;
            backsecond.Location = new Point(730, 400);
            backsecond.Text = "Back";
            backsecond.Font = new Font("Arial", 18, FontStyle.Bold);
            backsecond.Click += new EventHandler(secondBack);
            backsecond.Visible = true;

        }
        
        //curata jocul
        
        public void InitializeazaJoc()
        {
            if (Imagini != null)
            {
                if (Imagini.Count > 0)
                    for (int i = 0; i < Imagini.Count; i++)
                        Controls.Remove(Imagini.ElementAt(i));
                Imagini.Clear();
                if (Alegeri != null)
                    Alegeri.Clear();
                if (Potriviri != null)
                    Potriviri.Clear();
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
            for (int i = 0; i < Imagini.Count; i++)
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
        public bool alegePerechi()
        {
            for (int i = 1; i < Alegeri.Count ; i++)
            {
                int primaAlegere = (int)Alegeri[i - 1].Tag;
                int aDouaAlegere = (int)Alegeri[i].Tag;
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
            Controls.Add(backsecond);
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
            timpi = 0;
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
            InitializeazaJoc();
            
        }
       
        private void Button1_Click(object sender, EventArgs e)
        {
            initializeazaButoane();
            InitializeazaJoc();
             // se sterg datele de joc existente
            //butonul usor

            btn1 = new Button();
            buton_creare_din_cod(ref btn1,"Easy",100,50);
            btn1.BackgroundImage = Interfatagrafica.Properties.Resources.chenar;
            btn1.Click += new EventHandler(m.nivelUsor);

            //nivelul medium
            medium1 = new Button();
            buton_creare_din_cod(ref medium1, "Medium",320,50);
            medium1.BackgroundImage = Interfatagrafica.Properties.Resources.chenar;
            medium1.Click += new EventHandler(m.nivelMedium);

            //nivelul greu
            hard1 = new Button();
            buton_creare_din_cod(ref hard1, "Hard", 540,50);
            hard1.BackgroundImage = Interfatagrafica.Properties.Resources.chenar;
            hard1.Click += new EventHandler(m.nivelGreu);

            buton_creare_din_cod(ref back, "", 320,280);
            back.BackgroundImage = Interfatagrafica.Properties.Resources.backk1;
            back.Click += new EventHandler(clickInapoi);
            adauga_controale_pe_forma();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            initializeazaButoane();
            InitializeazaJoc(); // se sterg datele de joc existente
            //butonul usor
            btn1 = new Button();
            buton_creare_din_cod(ref btn1, "Easy", 100,50);
            btn1.BackgroundImage = Interfatagrafica.Properties.Resources.smile;
            btn1.Click += new EventHandler(p.nivelUsor);

            //butonul medium
            medium1 = new Button();
            buton_creare_din_cod(ref medium1, "Medium", 320, 50);
            medium1.BackgroundImage = Interfatagrafica.Properties.Resources.smile;
            medium1.Click += new EventHandler(p.nivelMedium);

            //nivelul greu
            hard1 = new Button();
            buton_creare_din_cod(ref hard1, "Hard", 540, 50);
            hard1.BackgroundImage = Interfatagrafica.Properties.Resources.smile;
            hard1.Click += new EventHandler(p.nivelGreu);

            buton_creare_din_cod(ref back, "", 320, 280);
            back.BackgroundImage = Interfatagrafica.Properties.Resources.backk1;
            back.Click += new EventHandler(clickInapoi);
            adauga_controale_pe_forma();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            initializeazaButoane();
            InitializeazaJoc(); // se sterg datele de joc existente
            //butonul usor
            btn1 = new Button();
            buton_creare_din_cod(ref btn1, "Easy", 100, 50);
            btn1.BackgroundImage = Interfatagrafica.Properties.Resources.absc;
            btn1.Click += new EventHandler(g.nivelUsor);

            //butonul medium
            medium1 = new Button();
            buton_creare_din_cod(ref medium1, "Medium", 320, 50);
            medium1.BackgroundImage = Interfatagrafica.Properties.Resources.absc;
            medium1.Click += new EventHandler(g.nivelMedium);

            //nivelul greu
            hard1 = new Button();
            buton_creare_din_cod(ref hard1, "Hard", 540, 50);
            hard1.BackgroundImage = Interfatagrafica.Properties.Resources.absc;
            hard1.Click += new EventHandler(g.nivelGreu);

            buton_creare_din_cod(ref back, "", 320, 280);
            back.BackgroundImage = Interfatagrafica.Properties.Resources.backk1;
            back.Click += new EventHandler(clickInapoi);
            adauga_controale_pe_forma();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sigur parasiti aplicatia?", "",MessageBoxButtons.YesNo)==DialogResult.Yes)
                this.Close();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if ((greu==true && timpi>90) || (medium==true && timpi>60) || (usor==true && timpi>25))
            {
                Timer1.Stop();
                MessageBox.Show("Ne pare rau, ati depasit limita medie alocata!\nScorul dvs: " +scor+"\nYour time: "+cronometruEticheta.Text+"\nMistakes: " +greseli);
                secondBack(sender, e);
                timpi = 1;
                nrSecunde = 0;
            }
            timpi++;
            nrSecunde++;
            if (nrSecunde>59)
            {
                nrSecunde = 0;
                nrMinute++;
            }
            cronometruEticheta.Text = Microsoft.VisualBasic.Strings.Format(nrOre, "00") +":" +Microsoft.VisualBasic.Strings.Format(nrMinute, "00")+":"+Microsoft.VisualBasic.Strings.Format(nrSecunde, "00");
            
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("student: Pamparau Cristian, grupa 3131a\n\nIndrumator: s.l. dr. ing. Gîză-Belciug Felicia");
        }
       }
}
