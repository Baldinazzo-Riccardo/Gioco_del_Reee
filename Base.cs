using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoRE
{
    abstract class Base
    {
        public string Nome { get; set; }
        public Base(string nome)
        {
            Nome = nome;
        }
    }
}
