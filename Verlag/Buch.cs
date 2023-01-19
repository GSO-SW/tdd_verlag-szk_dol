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
        private string iSBN;

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

        public Buch (string autor, string titel, int auflage, string iSBN): this(autor, titel, auflage)
        {
            this.iSBN = iSBN;
        }




        public string Autor 
        { 
            get => autor;
            set
            {
                if (Regex.IsMatch(value, @"[#%§;]+") || value == "")
                {
                    throw new ArgumentException("Der Autor darf keine Sonderzeichen enthalten.");
                }
                if (value == null)
                {
                    throw new ArgumentNullException("Der Autor darf nicht NULL sein.");
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

        public string ISBN
        {
            get => iSBN;
        }

    }
}
