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
        private string isbn;

        private char[] nichtErlaubteZeichen = { '#', ';', '§', '%' };

        public Buch(string autor, string titel)
        {
            this.Autor = autor;
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

        public Buch(string autor, string titel, int auflage, string isbn) : this(autor, titel, auflage)
        {
            if (isbn.Length == 13)
            {
                char[] isbnChars = isbn.Remove(isbn.IndexOf('-'), 1).ToCharArray();
                int[] isbnZiffern = Array.ConvertAll(isbnChars, c => (int)Char.GetNumericValue(c));
                int pruefZiffer = 0;
                for (int i = 0; i < isbnZiffern.Length; i++)
                {
                    pruefZiffer += isbnZiffern[i] * i + 1;
                }
                this.isbn = isbn + $"{pruefZiffer % 13}";
                return;
            }
            
            this.isbn = isbn;
        }

        public string Autor
        {
            get => autor; 
            set
            {
                //foreach (char c in nichtErlaubteZeichen)
                //{
                //    if (value.Contains(c)) throw new ArgumentException("Ein nicht erlaubtes Zeichen wurde eingetragen: " + c);
                //}
                if (Regex.IsMatch(value, @"^[%§#;]+"))
                {
                    throw new ArgumentException("Ein nicht erlaubtes Zeichen wurde eingetragen.");
                }

                if (value == "") throw new ArgumentException("Autor darf nicht leer sein");
                if (value == null) throw new ArgumentNullException("Es wurde kein Autor angegeben!");

                this.autor = value;
            }
        }
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
        public string ISBN { get => isbn; }
    }
}
