using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using interfataCategorii;
using System.Threading;

namespace Interfatagrafica
{
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
