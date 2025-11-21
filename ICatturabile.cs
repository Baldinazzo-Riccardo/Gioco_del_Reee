using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoRE
{
    internal interface ICatturabile
    {
        public delegate void ReAttaccatoEventHandler(object sender, EventArgs e);
        string Cattura();
    }
}
