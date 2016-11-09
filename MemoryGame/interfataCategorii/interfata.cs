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
        void imagineClick(Object sender);
        void ascundeImagini(PictureBox imagine);
        void arataimagine(PictureBox imagine);
        void nivelUsor();
        void nivelMedium();
        void nivelGreu();
    }
}
