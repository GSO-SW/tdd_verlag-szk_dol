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
            Autor = autor;
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
            ISBN = isbn;
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
                if (Regex.IsMatch(value, @"[%§#;]+"))
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
        public string ISBN
        {
            get => isbn;
            set
            {
                if (value.Length == 13)
                {
                    char[] isbnChars = value.Remove(value.IndexOf('-'), 1).ToCharArray();
                    int[] isbnZiffern = Array.ConvertAll(isbnChars, c => (int)Char.GetNumericValue(c));
                    int pruefZiffer = 0;

                    for (int i = 0; i < isbnZiffern.Length; i++)
                    {
                        if ((i + 1) % 2 == 0)
                        {
                            pruefZiffer += isbnZiffern[i] * 3;
                        }
                        else
                        {
                            pruefZiffer += isbnZiffern[i];
                        }
                    }
                    int ziffer = 10 - (pruefZiffer % 10);
                    if (ziffer == 10) ziffer = 0;
                    this.isbn = value + $"{ziffer}";
                    return;
                }
                this.isbn = value;

            }
        }

        public string ISBN10
        {
            get
            {
                //if (isbn.Length == 14)
                //{
                //    char[] isbnChars = isbn.Replace('-', '\0')[..^1].ToCharArray();
                //    int[] isbnZiffern = Array.ConvertAll(isbnChars, c => (int)Char.GetNumericValue(c));
                //    int pruefZiffer = 0;
                //    for (int i = 0; i < isbnZiffern.Length; i++)
                //    {
                //        pruefZiffer += isbnZiffern[i] * i + 1;
                //    }
                //    char pz = 'X';
                //    if (pruefZiffer % 11 == 10)
                //    {
                //        pz = 'X';
                //    } 
                //    else
                //    {
                //        pz = char.Parse((pruefZiffer % 11).ToString());
                //    }
                //    return isbn.Substring(isbn.IndexOf('-') + 1)[..^1] + pz;
                //}
                //return "";

                var split = isbn[4..^1].Where(x => char.IsDigit(x)).Select(x => int.Parse(x.ToString())).ToArray();

                for (int i = 0; i < 9;)
                {
                    split[i] *= ++i;
                }

                int dings = split.Sum() % 11;

                return dings switch
                {
                    13 => isbn[4..^1] + 'X',
                    _ => isbn[4..^1] + dings
                };
            }
        }
    }
}
