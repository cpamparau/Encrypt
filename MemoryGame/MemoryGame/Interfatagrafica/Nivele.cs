using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace Interfatagrafica
{
    class Nivele
    {
        OperatiiImagini x;
        

        public Nivele(ImageList given, ref Form1 i)
        {
            x = new OperatiiImagini(given, ref i);
        }

        public void nivelUsor(object sender, EventArgs e)
        {
            Form1.alegeri = new List<PictureBox>();
            Form1.potriviri = new List<int>();
            x.deseneazaImagine(4, 2);
            Form1.timer1.Start();
            Form1.NrSecunde = 0;
            Form1.Greseli = 0;
            Form1.Medium = false;
            Form1.Greu = false;
            Form1.Usor = true;
            x.instance_f1.Timpi = 1;

            //eticheta scor
            Form1.ScorEticheta.Width = 200;
            Form1.ScorEticheta.Height = 40;
            Form1.ScorEticheta.Location = new Point(730, 50);
            Form1.ScorEticheta.Font = new Font("Arial", 18, FontStyle.Bold);
            Form1.ScorEticheta.BorderStyle = BorderStyle.FixedSingle;
            Form1.ScorEticheta.Visible = true;
            Form1.ScorEticheta.Text = "Score : 0";

            //butonul backsecond
            Form1.Backsecond.Width = 200;
            Form1.Backsecond.Height = 40;
            Form1.Backsecond.Location = new Point(730, 400);
            Form1.Backsecond.Text = "Back";
            Form1.Backsecond.Font = new Font("Arial", 18, FontStyle.Bold);
            Form1.Backsecond.Click += new EventHandler(x.instance_f1.secondBack);
            Form1.Backsecond.Visible = true;

            //eticheta cronometru
            Form1.CronometruEticheta.Width = 200;
            Form1.CronometruEticheta.Height = 40;
            Form1.CronometruEticheta.Location = new Point(730, 100);
            Form1.CronometruEticheta.Font = new Font("Arial", 18, FontStyle.Bold);
            Form1.CronometruEticheta.Text = "00:00:00";
            Form1.CronometruEticheta.BorderStyle = BorderStyle.FixedSingle;
            Form1.CronometruEticheta.Visible = true;

            //adaugare controale
            x.instance_f1.Controls.Add(Form1.ScorEticheta);
            x.instance_f1.Controls.Add(Form1.CronometruEticheta);
            x.instance_f1.Controls.Add(Form1.Backsecond);

            Form1.Btn1.Visible = false;
            Form1.Medium1.Visible = false;
            Form1.Hard1.Visible = false;
            Form1.Back.Visible = false;
            Form1.timer1.Enabled = true;
        }

        public void nivelMedium(object sender, EventArgs e)
        {
            Form1.alegeri = new List<PictureBox>();
            Form1.potriviri = new List<int>();
            x.deseneazaImagine(8, 2);
            Form1.timer1.Start();
            Form1.NrSecunde = 0;
            Form1.Greseli = 0;
            Form1.Medium = true;
            Form1.Greu = false;
            Form1.Usor = false;
            x.instance_f1.Timpi = 1;

            //eticheta scor
            Form1.ScorEticheta.Width = 200;
            Form1.ScorEticheta.Height = 40;
            Form1.ScorEticheta.Location = new Point(730, 50);
            Form1.ScorEticheta.Font = new Font("Arial", 18, FontStyle.Bold);
            Form1.ScorEticheta.BorderStyle = BorderStyle.FixedSingle;
            Form1.ScorEticheta.Visible = true;
            Form1.ScorEticheta.Text = "Score : 0";

            //butonul backsecond
            Form1.Backsecond.Width = 200;
            Form1.Backsecond.Height = 40;
            Form1.Backsecond.Location = new Point(730, 400);
            Form1.Backsecond.Text = "Back";
            Form1.Backsecond.Font = new Font("Arial", 18, FontStyle.Bold);
            Form1.Backsecond.Click += new EventHandler(x.instance_f1.secondBack);
            Form1.Backsecond.Visible = true;

            //eticheta cronometru
            Form1.CronometruEticheta.Width = 200;
            Form1.CronometruEticheta.Height = 40;
            Form1.CronometruEticheta.Location = new Point(730, 100);
            Form1.CronometruEticheta.Font = new Font("Arial", 18, FontStyle.Bold);
            Form1.CronometruEticheta.Text = "00:00:00";
            Form1.CronometruEticheta.BorderStyle = BorderStyle.FixedSingle;
            Form1.CronometruEticheta.Visible = true;

            //adaugare controale
            x.instance_f1.Controls.Add(Form1.ScorEticheta);
            x.instance_f1.Controls.Add(Form1.CronometruEticheta);
            x.instance_f1.Controls.Add(Form1.Backsecond);

            Form1.Btn1.Visible = false;
            Form1.Medium1.Visible = false;
            Form1.Hard1.Visible = false;
            Form1.Back.Visible = false;
            Form1.timer1.Enabled = true;
        }

        public void nivelGreu(object sender, EventArgs e)
        {
            Form1.alegeri = new List<PictureBox>();
            Form1.potriviri = new List<int>();
            x.deseneazaImagine(8, 2);
            Form1.timer1.Start();
            Form1.NrSecunde = 0;
            Form1.Greseli = 0;
            Form1.Medium = true;
            Form1.Greu = false;
            Form1.Usor = false;
            x.instance_f1.Timpi = 1;

            //eticheta scor
            Form1.ScorEticheta.Width = 200;
            Form1.ScorEticheta.Height = 40;
            Form1.ScorEticheta.Location = new Point(730, 50);
            Form1.ScorEticheta.Font = new Font("Arial", 18, FontStyle.Bold);
            Form1.ScorEticheta.BorderStyle = BorderStyle.FixedSingle;
            Form1.ScorEticheta.Visible = true;
            Form1.ScorEticheta.Text = "Score : 0";

            //butonul backsecond
            Form1.Backsecond.Width = 200;
            Form1.Backsecond.Height = 40;
            Form1.Backsecond.Location = new Point(730, 400);
            Form1.Backsecond.Text = "Back";
            Form1.Backsecond.Font = new Font("Arial", 18, FontStyle.Bold);
            Form1.Backsecond.Click += new EventHandler(x.instance_f1.secondBack);
            Form1.Backsecond.Visible = true;

            //eticheta cronometru
            Form1.CronometruEticheta.Width = 200;
            Form1.CronometruEticheta.Height = 40;
            Form1.CronometruEticheta.Location = new Point(730, 100);
            Form1.CronometruEticheta.Font = new Font("Arial", 18, FontStyle.Bold);
            Form1.CronometruEticheta.Text = "00:00:00";
            Form1.CronometruEticheta.BorderStyle = BorderStyle.FixedSingle;
            Form1.CronometruEticheta.Visible = true;

            //adaugare controale
            x.instance_f1.Controls.Add(Form1.ScorEticheta);
            x.instance_f1.Controls.Add(Form1.CronometruEticheta);
            x.instance_f1.Controls.Add(Form1.Backsecond);

            Form1.Btn1.Visible = false;
            Form1.Medium1.Visible = false;
            Form1.Hard1.Visible = false;
            Form1.Back.Visible = false;
            Form1.timer1.Enabled = true;
        }
    }
}
