using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Verlag
{
    public class Buch
    {
        private string autor;
        private string titel;
        private int auflage = 1;

        private char[] nichtErlaubteZeichen = { '#', ';', '§', '%' };

        public Buch(string autor, string titel)
        {
            //foreach (char c in nichtErlaubteZeichen)
            //{
            //    if (autor.Contains(c)) throw new ArgumentException("Ein nicht erlaubtes Zeichen wurde eingetragen: " + c);
            //}
            if (Regex.IsMatch(autor, @"^[%§#;]+$"))
            {
                throw new ArgumentException("Ein nicht erlaubtes Zeichen wurde eingetragen.");
            }

            if (autor == "" || autor == null) throw new ArgumentException("Autor darf nicht leer sein");

            this.autor = autor;
            this.titel = titel;
        }

        public Buch(string autor, string titel, int auflage) :this(autor, titel)
        {  
            if (auflage < 1)
            {
                throw new ArgumentOutOfRangeException("Auflage muss > 1 sein.");
            }

            this.auflage = auflage;
        }

        public string Autor { get => autor; set { this.autor = value; } }
        public string Titel { get => titel; }
        public int Auflage
        {
            get => auflage;
            set
            {
                if (value < 1) throw new ArgumentOutOfRangeException("Auflage muss > 1 sein.");
                this.auflage = value;
            }
        }


    }
}
