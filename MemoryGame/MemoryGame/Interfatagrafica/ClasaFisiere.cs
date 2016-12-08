using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Interfatagrafica
{
    class ClasaFisiere
    {
        //date membre private
        private string numeFisier;
        private TextReader read;
        private TextWriter write;

        //constructor implicit
        public ClasaFisiere()
        {
            numeFisier = "NEPRCIZAT";
        }

        //proprietatea numeFisier
        public string NumeFisier
        {
            get
            {
                return numeFisier;
            }
            set
            {
                numeFisier = value;
            }
        }
        // metoda de deschidere a fisierului
        public bool deschideFisier()
        {
            bool rezultat = false;
            try
            {
                read = new StreamReader(numeFisier);
                rezultat = true;
            }
            catch (Exception e)
            {
                rezultat = false;
            }
            return rezultat;
        }
        //metoda de deschidere a fisierului
        public bool deschideScriereInFisier()
        {
            bool rezultat = false;
            try
            {
                write = new StreamWriter(numeFisier);
                rezultat = true;
            }
            catch (Exception e)
            {
                rezultat = false;
            }
            return rezultat;
        }
        // metoda de deschidere SI SCRIERE in fisier
        public string scrieInFisier(string sir_de_scris_in_fisier)
        {
            string rezultat = "";
            try
            {
               
                write.WriteLine(sir_de_scris_in_fisier);
                rezultat = "Scriere cu succes in fisierul " + numeFisier;
            }
            catch (Exception e)
            {
                rezultat = "EROARE scriere in fisier : " + e.Message;
            }
            return rezultat;
        }

        //metoda de inchidere a fisierului pentru scriere
        public void inchideScriereFisier()
        {
            try
            {
                write.Close();
            }
            catch { }
        }

        //metoda de inchidere a fisierului pentru citire
        public void inchidereCitireFisier()
        {
            try
            {
                read.Close();
            }
            catch { }
        }

        //metoda de citire a unei linii
        public string citesteLinie()
        {
            string linie = read.ReadLine();
            return linie;
        }
    }
}
