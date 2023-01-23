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
            ISBN = iSBN;
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

            private set 
            {
                if (value.Length == 14)
                {
                    iSBN = value;
                    return;
                }
                if (value.Length == 13)
                {
                    double summe = 0;
                    int i = 1;
                    foreach (char x in value)
                    {
                        if (x != '-')
                        {
                            if (i % 2 == 0)
                            {
                                summe += Char.GetNumericValue(x) * 3;
                            }
                            else
                            {
                                summe += Char.GetNumericValue(x);
                            }
                        i++;
                        }
                    }
                    double pruefziffer = 10 - (summe % 10);
                    if (pruefziffer == 10)
                    {
                        pruefziffer = 0;
                    }

                    iSBN = value + Convert.ToString(pruefziffer);
                    return;
                }
                throw new ArgumentOutOfRangeException("Die ISBN Nummer muss entweder 12 oder 13 Ziffern lang sein");
            }
        }
        public string ISBN10
        {
            get
            {
                string isbn10 = iSBN.Substring(4,iSBN.Length-5);

                double i = 10;
                double summe = 0;
                foreach (char x in isbn10)
                {
                    summe += i * Char.GetNumericValue(x);
                    i--;
                }
                double pruefziffer = summe % 11;
                if (pruefziffer == 10)
                {
                    return isbn10 + 'X';
                }

                return isbn10 + Convert.ToString(pruefziffer);
            }
        }

    }
}
