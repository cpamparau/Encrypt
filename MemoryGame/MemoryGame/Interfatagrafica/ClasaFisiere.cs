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
       // date membre private
        private string nume_fisier;
        private TextReader read;
        private TextWriter write;

        // Proprietati
        public string Nume_fisier
        {
            get
            {
                return nume_fisier;
            }
            set
            {
                nume_fisier = value;
            }
        }

        public string NumeFisier
        {
            get { return nume_fisier; }
            set { nume_fisier = value; }
        }
        // constructor implicit
        public ClasaFisiere()
        {
            
        }
        // metoda de deschidere a fisierului
        public bool deschideFisier()
        {
            bool rezultat = false;
            try
            {
                read = new StreamReader(nume_fisier);
                rezultat = true;
            }
            catch (Exception e)
            {
                return false;
            }
            return rezultat;
        }
        //metoda de deschidere a fisierului
        public bool deschideScriereInFisier(string name)
        {
            bool rezultat = false;
            try
            {
                write = new StreamWriter(name, true);
                rezultat = true;
            }
            catch (Exception e)
            {
                throw (e);
            }
            return rezultat;
        }
        // metoda de deschidere SI SCRIERE in fisier
        public string scrieInFisier(string sir_de_scris_in_fisier)
        {
            string rezultat = "";
            try
            {
                write.Write(sir_de_scris_in_fisier);
                rezultat = "Scriere cu succes in fisierul " + nume_fisier;
            }
            catch (Exception e)
            {
                rezultat = "EROARE scriere in fisier!";
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
