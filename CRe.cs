using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GiocoRE.CPedone;

namespace GiocoRE
{
    class CRe : Base
    {
        public event ReAttaccatoEventHandler? ReAttaccato;
        public List<string> RisposteAttacco { get; private set; } = new List<string>();
        public bool IsAttaccato { get; set; } = false;

        public CRe(string nome) : base(nome)
        {
            Nome = nome;
        }


        public string Attacca()
        {
            //if (!IsAttaccato)
            //{
                IsAttaccato = true;
                ReAttaccato?.Invoke(this, EventArgs.Empty);
            //}
            return $"Il Re {Nome} è sotto attacco.";
        }

        ~CRe()
        {
                
        }
    }
}
