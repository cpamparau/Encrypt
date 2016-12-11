using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Interfatagrafica
{
    /// <summary>
    /// Clasa care va permite tratarea operatiilor cu fisiere
    /// </summary>
    class ClasaFisiere
    {
       /// <summary>
       /// Data de tip string care specifica numele fisierului;
       /// </summary>
        private string nume_fisier;
        /// <summary>
        /// Instanta de tip TextReader care permite operatii specifice pentru citirea din fisier
        /// </summary>
        private TextReader read;
        /// <summary>
        /// Instanta de tip TextWriter care permite operatii specifice pentru scrierea in fisier
        /// </summary>
        private TextWriter write;

        /// <summary>
        /// Proprietate publica care ofera acces read-write la numele fisierului cu care se lucreaza
        /// </summary>

        public string NumeFisier
        {
            get { return nume_fisier; }
            set { nume_fisier = value; }
        }
        /// <summary>
        /// Constructorul implicit al clasei curente
        /// </summary>
        public ClasaFisiere()
        {
            
        }
        /// <summary>
        /// Metoda de deschidere a unui fisier pentru CITIRE
        /// </summary>
        /// <returns>true daca fisierul s-a deschis cu succes, false altfel</returns>
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
        /// <summary>
        /// Metoda de deschidere a unui fisier pentru SCRIERE
        /// </summary>
        /// <param name="name">Numele fisierului care se va deschide pentru scriere</param>
        /// <returns>true daca fisierul s-a deschis cu succes, false altfel</returns>
        public bool deschideScriereInFisier(string name)
        {
            bool rezultat = false;
            try
            {
                nume_fisier = name;
                write = new StreamWriter(nume_fisier, true);
                rezultat = true;
            }
            catch (Exception e)
            {
                throw (e);
            }
            return rezultat;
        }
        /// <summary>
        /// Metoda care scrie in fisier string-ul primit ca parametru
        /// </summary>
        /// <param name="sir_de_scris_in_fisier">String-ul care se va scrie in fisier</param>
        /// <returns>Un string sugestiv pentru situatiile de succes/failure a operatiei de scriere in fisier</returns>
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

        /// <summary>
        /// Metoda publica de inchidere a fisierului deschis pentru SCRIERE
        /// </summary>
        public void inchideScriereFisier()
        {
            try
            {
                write.Close();
            }
            catch { }
        }

        /// <summary>
        /// Metoda publica de inchidere a fisierului deschis pentru CITIRE
        /// </summary>
        public void inchidereCitireFisier()
        {
            try
            {
                read.Close();
            }
            catch { }
        }

        /// <summary>
        /// Metoda publica de citire a unei linii din fisierul deschis anterior
        /// </summary>
        /// <returns>Linia citita din fisier</returns>
        public string citesteLinie()
        {
            string linie = read.ReadLine();
            return linie;
        }
    }
}
