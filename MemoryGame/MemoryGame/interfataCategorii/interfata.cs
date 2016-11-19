using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interfataCategorii
{
    public interface interfataPentruCategorii
    {
        void deseneazaImagine(int numarTipImagine, int numarCopiiImagini);
        void imagineClick(Object sender, EventArgs e);
        void ascundeImagini(PictureBox imagine);
        void arataimagine(PictureBox imagine);
        void nivelUsor(object sender, EventArgs e);
        void nivelMedium(object sender, EventArgs e);
        void nivelGreu(object sender, EventArgs e);
    }
}
