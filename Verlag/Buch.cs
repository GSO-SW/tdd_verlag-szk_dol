using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Verlag
{
    public class Buch
    {
        private string autor;
        private string titel;
        private int auflage;

        public Buch(string autor, string titel)
        {
            Autor = autor;
            this.titel = titel;
            this.auflage = 1;
        }

        public Buch(string autor, string titel, int auflage): this(autor, titel)
        {
            Auflage = auflage;
        }




        public string Autor 
        { 
            get => autor;
            set
            {
                if (Regex.IsMatch(value, "[#%§;]|null"))
                {
                    throw new ArgumentException("Keine Sonderzeichen.");
                }
                autor = value;
            }
        }

        public string Titel
        {
            get => titel;
        }

        public int Auflage
        {
            get => auflage;

            set 
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Auflag kann nicht niedriger als 1 sein.");
                }
                auflage = value;
            }
        }

    }
}
