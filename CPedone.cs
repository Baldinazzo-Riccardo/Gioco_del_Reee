using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoRE
{
    class CPedone : Base, ICatturabile
    {
        public delegate void ReAttaccatoEventHandler(object sender, EventArgs e);
        public bool IsCatturato { get; set; } = false;

        public CPedone(string nome) : base(nome)
        {
            Nome = nome;
        }

        public void OnReAttaccato(object? sender, EventArgs e)
        {
            if (!IsCatturato)
                (sender as CRe)?.RisposteAttacco.Add($"Il Pedone {Nome} si sta preparando.");
        }

        string ICatturabile.Cattura()
        {
            if (!IsCatturato)
            {
                IsCatturato = true;
                return $"Pedone {Nome} è stata catturata.";
            }
            return $"Pedone {Nome} gia' catturata.";
        }


    }
}
