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
using System.Timers;


namespace Interfatagrafica
{
    /// <summary>
    /// Clasa Form1 a Formei principale care va fi afisata.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Instanta statica si privata a Butonului pentru nivelul 'Easy'
        /// </summary>
        static private Button btn1;
        /// <summary>
        /// Instanta statica si privata a Butonului pentru nivelul 'Medium'
        /// </summary>
        static private Button medium1;
        /// <summary>
        /// Instanta statica si privata a Butonului pentru nivelul 'Hard
        /// </summary>
        static private Button hard1;
        /// <summary>
        /// Instanta statica si privata a Butonului pentru revenirea la meniul principal
        /// din meniul unde se alege nivelul unei categorii de joc
        /// </summary>
        static private Button back;
        /// <summary>
        /// instanta statica a formei curente
        /// </summary>
        static Form1 f;
        /// <summary>
        /// Instanta statica si privata a Butonului pentru revenirea dintr-un nivel de joc(din Easy, de exemplu)
        /// la meniul unde se poate alege alt nivel de joc, dar in cadrul aceleiasi categorii
        /// </summary>
        static private Button backsecond;
        /// <summary>
        /// Instanta statica si privata a etichetei care afiseaza cronometru
        /// </summary>
        static private Label cronometruEticheta;
        /// <summary>
        /// Instanta statica statica si privata a unei etichete care arata scorul curent al jucatorului 
        /// </summary>
        static private Label scorEticheta;
        /// <summary>
        /// Variabila statica membra privata de tip int care retine numarul de copii ale unei imagini; in cazul proiectului de fata,
        /// a versiunii curente, nrCopiiImagini este 2.
        /// </summary>
        static private int  nrCopiiImagini;
        /// <summary>
        /// Variabila statica membra privata de tip int care retine numarul de imagini dintr*un control ImageList
        /// </summary>
        static private int dimensiuneLista;
        /// <summary>
        /// Variabila statica membra privata de tip int care contorizeaza numarul de secunde;
        /// atunci cand aceasa devine 60, se va reseta la valoarea 0
        /// </summary>
        static private int nrSecunde;
        /// <summary>
        /// Variabila statica membra privata de tip int care contorizeaza numarul de minute;
        /// atunci cand aceasta devine 60, se va reseta la valoarea 0
        /// </summary>
        static private int nrMinute;
        /// <summary>
        /// Variabila membra privata de tip int care contorizeaza numarul de ore;
        /// atunci cand valoarea acesteia devine 60, se va reseta la valoarea 0
        /// </summary>
        static private int nrOre;
        /// <summary>
        /// Variabila statica membra privata de tip int care retine numarul de greseli;
        /// prin greseala intelegem asocierea dintre doua imagini distincte
        /// </summary>
        static private int greseli;
        /// <summary>
        /// Variabila statica membra privata de tip int care retine scorul jucatorului
        /// </summary>
        static private int scor;
        /// <summary>
        /// Variabila statica membra privata de tip int care retine limita medie acordata fiecarui nivel al jocului;
        /// Nivel easy - 25 secunde 
        /// Nivelul medium - 60 secunde
        /// Nivelul hard - 90 secunde
        /// </summary>
        private int timpi;
        /// <summary>
        /// Variabila statica privata de tip boolean care are valoarea true in cazul in care s-a optat nivelul usor
        /// </summary>
        static private bool usor;
        /// <summary>
        /// variabila statica privata de tip boolean care are valoarea true in cazul in care s-a optat nivelul mediu
        /// </summary>
        static private bool medium;
        /// <summary>
        /// variabila statica privata de tip boolean care are valoarea true in cazul in care s-a optat nivelul greu
        /// </summary>
        static private bool greu;
        /// <summary>
        /// Lista de intregi statica si privata care retine indecsii a doua imagini care se potrivesc, care sunt asemena 
        /// </summary>
        static private List<int> Potriviri;
        /// <summary>
        /// Lista de PictureBox-uri statica si privata care retine imaginile dintr-o anumita categorie
        /// </summary>
        static public List<PictureBox> Imagini; 
        /// <summary>
        /// Lista de PictureBox-uri care contine doua imagini care au fost alese si care vor fi verificate daca sunt asemena
        /// </summary>
        static private List<PictureBox> Alegeri; 

        /// <summary>
        /// Proprietate statica prin care se permite accesul read-write din alte clase a controlului de tip Timer (Timer1) 
        /// </summary>
        static public System.Windows.Forms.Timer timer1 { get { return Timer1; } set { Timer1 = value; } }
        /// <summary>
        /// Proprietate statica prin care se permite accesul read-write din alte clase la Lista de int-uri Potriviri 
        /// </summary>
        static public List<int> potriviri { get { return Potriviri; } set { Potriviri = value; } }
        /// <summary>
        /// Prorietate statica prin care se permite accesul read-write din alte clase la Lista de PictureBox-uri Alegeri
        /// </summary>
        static public List<PictureBox> alegeri { get { return Alegeri; } set { Alegeri = value; } }
        /// <summary>
        /// Proprietate statica care permite accesul read-write din alte clase la variabila booleana Usor
        /// </summary>
        static public bool Usor { get { return usor; } set { usor = value; } }
        /// <summary>
        /// Proprietate statica care permite accesul read-write din alte clase a variabilei booleene Medium
        /// </summary>
        static public bool Medium { get { return medium; } set { medium = value; } }
        /// <summary>
        /// Proprietate statica care permite accesul read-write din alte clase a variabilei booleene Greu
        /// </summary>
        static public bool Greu { get { return greu; } set { greu = value; } }
        /// <summary>
        /// Proprietate care permite accesul read-write din alte clase a variabilei de tip int timpi
        /// </summary>
        public int Timpi { get { return timpi; } set { timpi = value; } }
        /// <summary>
        /// Proprietate statica care permite accesul read-write din alte clase a variabilei de tip int nrCopiiImagine
        /// </summary>
        static public int NrCopiiImagini { get { return nrCopiiImagini; } set { nrCopiiImagini = value; } }
        /// <summary>
        /// Proprietate statica care permite accesul read-write din alte clase a variabilei de tip int dimensiuneLista
        /// </summary>
        static public int DimensiuneLista { get { return dimensiuneLista; } set { dimensiuneLista = value; } }
        /// <summary>
        /// Proprietate statica care permite accesul read-write din alte clase a variabilei de tip int nrSecunde
        /// </summary>
        static public int NrSecunde { get{return nrSecunde;} set{nrSecunde=value;}}
        /// <summary>
        /// Proprietate statica care permite accesul read-write din alte clase a variabilei de tip int nrMinute
        /// </summary>
        static public int NrMinute { get { return nrMinute; } set { nrMinute = value; } }
        /// <summary>
        /// Proprietate statica care permite accesul read-write din alte clase a variabilei de tip int nrore
        /// </summary>
        static public int NrOre { get { return nrOre; } set { nrOre = value; } }
        /// <summary>
        /// Proprietate statica care permite accesul read-write din alte clase a variabilei de tip int greseli
        /// </summary>
        static public int Greseli { get { return greseli; } set { greseli = value; } }
        /// <summary>
        /// Proprietate statica care permite accesul read-write din alte clase a variabilei de tip int scor
        /// </summary>
        static public int Scor { get; set; }
        /// <summary>
        /// Proprietate startica care permite accesul read-write din alte clase a Butonului btn1
        /// </summary>
        static public Button Btn1 { get { return btn1; } set { btn1 = value; } }
        /// <summary>
        /// Proprietate startica care permite accesul read-write din alte clase a Butonului medium1
        /// </summary>
        static public Button Medium1 { get { return medium1; } set { medium1 = value; } }
        /// <summary>
        /// Proprietate startica care permite accesul read-write din alte clase a Butonului hard1
        /// </summary>
        static public Button Hard1 { get { return hard1; } set { hard1 = value; } }
        /// <summary>
        /// Proprietate startica care permite accesul read-write din alte clase a Butonului back
        /// </summary>
        static public Button Back { get { return back; } set { back = value; } }
        /// <summary>
        /// Proprietate startica care permite accesul read-write din alte clase a Butonului backsecond
        /// </summary>
        static public Button Backsecond { get { return backsecond; } set { backsecond = value; } }
        /// <summary>
        /// Proprietate startica care permite accesul read-write din alte clase a Etichetei cronometruEticheta
        /// </summary>
        static public Label CronometruEticheta { get { return cronometruEticheta; } set { cronometruEticheta = value; } }
        /// <summary>
        /// Proprietate startica care permite accesul read-write din alte clase a etichetei scorEtichet
        /// </summary>
        static public Label ScorEticheta { get { return scorEticheta; } set { scorEticheta = value; } }
        /// <summary>
        /// Constructorul implicit al formei curente, principale
        /// </summary>
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
            f = this;
        }
        /// <summary>
        /// Proprietate statica care permite accesul read-only din alte clase a formei curente
        /// </summary>
        static public Form1 ff
        {
            get { return f; }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Metoda care defineste proprietatile din cod ale etichetei care arata cronometrul
        /// </summary>
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
        /// <summary>
        /// metoda care defineste proprietatile din cod ale etichetei care arata scorul
        /// </summary>
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
        /// <summary>
        /// Metoda care face butoanele pentru cele 3 nivele invizibile si porneste timer-ul formei
        /// </summary>
        public void vizibilitati()
        {
            btn1.Visible = false;
            medium1.Visible = false;
            hard1.Visible = false;
            Timer1.Enabled = true;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Metoda care adauga controalele pentru alegerea nivelului si pentru butonul back pe forma dupa ce acestea au fost descrise
        /// anterior in alte metode
        /// </summary>
        public void adauga_controale_pe_forma()
        {
            //adaugare controale
            Controls.Add(btn1);
            Controls.Add(medium1);
            Controls.Add(hard1);
            Controls.Add(back);
        }
        
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Metoda care descrie butonul de click-inapoi din un nivel ales la alegerea altui nivel
        /// </summary>
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
        
        /// <summary>
        /// Metoda care initializeza jocul,adica seteaza la valori default listele de Imagini, Alegeri si Potriviri
        /// </summary>
        
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
        
        /// <summary>
        /// metoda care seteaza variabilele booleene si scorul la valorile de start(fals si respectiv 0)
        /// </summary>
        
        public void initializare_date()
        {
            usor = false;
            medium = false;
            greu = false;
            scor = 0;
        }
        
        /// <summary>
        /// Metoda de revenire la meniul principal de unde se poate alege categoria de joc(Minion/Easter/geometry)
        /// </summary>
        /// <param name="sender"> Obiectul sender standard asociat unei proceduri-eveniment</param>
        /// <param name="e">Variabila de tip EventArgs standard asociata unei proceduri-eveniment </param>

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

        /// <summary>
        /// Metoda de amestecare a imaginilor random pe suprafata formei
        /// </summary>
        /// <param name="img">Lista de imagini care vor fi amestecate pe forma</param>
        
        public void Amesteca(ref List<PictureBox> img)
        {
            Random rnd = new Random();
            for (int i = 0; i < img.Count - 1; i++)
            {
                int index = rnd.Next(i, img.Count);
                if (i != index)
                {
                    PictureBox imgf = img[i];
                    img[i] = img[index];
                    img[index] = imgf;
                }
            }
        }
        /// <summary>
        /// metoda seteaza butoanele din meniul principal pe false
        /// </summary>
        private void initializeazaButoane()
        {
            Button5.Visible = false;
            Button1.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;
            Button4.Visible = false;

        }

        /// <summary>
        /// Metoda de afisare a imaginilor pe un numar de randuri specificat prin parametrul functiei. Numarul 
        /// de imagini dispuse pe coloana depinde de nivelul jocului
        /// </summary>
        /// <param name="numarRanduri">Variabila de tip int care va specifica pe cate randuri se vor dispune imaginile</param>
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

        /// <summary>
        /// Metoda care verifica daca 2 imagini care au fost selectate sunt identice, asa incat sa fie 'rezolvate'
        /// </summary>
        /// <returns>true daca imaginile sunt identice, false altfel</returns>
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
        /// <summary>
        /// Metoda de adaugare a unor controale pe forma : cele 3 butoane pentru nivelele de joc si butonul de back din 
        /// cadrul unui joc deja inceput sau selectat
        /// </summary>
        private void adaugaControale()
        {
            Controls.Add(btn1);
            Controls.Add(medium1);
            Controls.Add(hard1);
            Controls.Add(backsecond);
        }
        /// <summary>
        /// Metoda care creeaza un buton cu anumite caracteristici specificate prin parametrii functiei
        /// </summary>
        /// <param name="x">Butonul care va fi creat- de tip referinta</param>
        /// <param name="nivel">variabila de tip string care specifica nivelul jocului corespunzatoru butonului care se creeaza</param>
        /// <param name="XLocation">Coordonata X a locatiei butonului care se doreste a fi creat</param>
        /// <param name="YLocation">Coordonata Y a locatiei butonului care se doreste a fi creat</param>
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
        /// <summary>
        /// Al doilea buton 'inapoi' care duce controlul jocului de la jocul efectiv la meniul unde se poate alege nivelul jocului
        /// </summary>
        /// <param name="sender">Obiectul sender standard asociat unei proceduri-eveniment</param>
        /// <param name="e">Variabila de tip EventArgs standard asociata unei proceduri-eveniment</param>
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
        /// <summary>
        /// Butonul (1) de pe forma principala de joc care alege categoria 'Minioni'
        /// </summary>
        /// <param name="sender">Obiectul sender standard asociat unei proceduri-eveniment</param>
        /// <param name="e">Variabila de tip EventArgs standard asociata unei proceduri-eveniment</param>
        private void Button1_Click(object sender, EventArgs e)
        {
            initializeazaButoane();
            InitializeazaJoc();
             // se sterg datele de joc existente
            //butonul usor
            Nivele m = new Nivele(Minion);
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
        /// <summary>
        /// Butonul (2) de pe forma principala de joc care alege categoria 'Easter'
        /// </summary>
        /// <param name="sender">Obiectul sender standard asociat unei proceduri-eveniment</param>
        /// <param name="e">Variabila de tip EventArgs standard asociata unei proceduri-eveniment</param>
        private void Button2_Click(object sender, EventArgs e)
        {
            initializeazaButoane();
            InitializeazaJoc(); // se sterg datele de joc existente
            //butonul usor
            Nivele p = new Nivele(Easter);
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
        /// <summary>
        /// Butonul (3) de pe forma principala de joc care alege categoria 'Geometry'
        /// </summary>
        /// <param name="sender">Obiectul sender standard asociat unei proceduri-eveniment</param>
        /// <param name="e">Variabila de tip EventArgs standard asociata unei proceduri-eveniment</param>
        private void Button3_Click(object sender, EventArgs e)
        {
            initializeazaButoane();
            InitializeazaJoc(); // se sterg datele de joc existente
            //butonul usor
            Nivele g = new Nivele(Geometry);
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
        /// <summary>
        /// Butonul (4) de pe forma principala ajocului care permite parasirea aplicatiei
        /// </summary>
        /// <param name="sender">Obiectul sender standard asociat unei proceduri-eveniment</param>
        /// <param name="e">Variabila de tip EventArgs standard asociata unei proceduri-eveniment</param>
        private void Button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sigur parasiti aplicatia?", "",MessageBoxButtons.YesNo)==DialogResult.Yes)
                this.Close();
        }
        /// <summary>
        /// Metoda de tratare a Timer-ului, adica ce se intampla la fiecare Interval al Timer-ului. Intervalul a fost setat la o secunda
        /// </summary>
        /// <param name="sender">Obiectul sender standard asociat unei proceduri-eveniment</param>
        /// <param name="e">Variabila de tip EventArgs standard asociata unei proceduri-eveniment</param>
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
        /// <summary>
        /// Butonul (5) de pe forma principala a jocului ce permite afisarea istoricului jocului, adica informatii
        /// despre persoane care au jucat jocul anterior si totodata informatiile de performanta a acestor jocuri jucate
        /// Modul in care informatiile sunt stocate in fisier sunt reprezentate de capul de tabel, adica: 
        /// 'NUME     SCOR     TIMP   GRESELI    DATA    ORA    CATEGORIE'
        /// </summary>
        /// <param name="sender">Obiectul sender standard asociat unei proceduri-eveniment</param>
        /// <param name="e">Variabila de tip EventArgs standard asociata unei proceduri-eveniment</param>
        private void Button5_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("student: Pamparau Cristian, grupa 3131a\n\nIndrumator: s.l. dr. ing. Gîză-Belciug Felicia");
            ClasaFisiere cl = new ClasaFisiere();
            cl.NumeFisier = "istoric.txt";
            string citit="";
            if (cl.deschideFisier())
            {
                citit = "NUME     SCOR     TIMP   GRESELI    DATA    ORA    CATEGORIE\n";
                do
                {
                    citit += cl.citesteLinie();
                } while (cl.citesteLinie() == string.Empty);
                MessageBox.Show(citit);
            }
            else
                MessageBox.Show("FISIERUL nu exista!!");
        }

        public string functie_noua(object sender, EventArgs e, int timp)
        {
            return "";
        }
       }
}
