using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoRE
{
    class CSoldato : Base, ICatturabile
    {
        public delegate void ReAttaccatoEventHandler(object sender, EventArgs e);

        public bool IsCatturato { get; set; } = false;

        public CSoldato(string nome) : base(nome)
        {
            Nome = nome;
        }

        string ICatturabile.Cattura()
        {
            if (!IsCatturato)
            {
                IsCatturato = true;
                return $"Guardia {Nome} è stata catturata.";
            }
            return $"Guardia {Nome} gia' catturata.";
        }

        public void OnReAttaccato(object? sender, EventArgs e)
        {
            if (!IsCatturato)
                (sender as CRe)?.RisposteAttacco.Add($"La Guardia {Nome} sta difendendo.");
        }

    }
}
