using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Verlag;

namespace VerlagTests
{
    [TestClass]
    public class ISBNTests
    {

        [TestMethod]
        public void ISBN_PruefzifferWirdRichtigBerechnet()
        {
            // Arrange
            string autor = "Autor";
            string titel = "Titel";
            int auflage = 1;
            string iSBN = "978-377043614";

            // Act
            Buch d = new Buch(autor, titel, auflage, iSBN);

            // Assert
            Assert.AreEqual("978-3770436149", d.ISBN);
        }

        [TestMethod]
        public void ISBN_ISBN13inISBN10Umrechnen()
        {
            //Arrange 
            string autor = "Autor";
            string titel = "Titel";
            int auflage = 1;
            string iSBN = "978-3770436064";
            Buch d = new Buch(autor, titel, auflage, iSBN);

            // Act
            string iSBN10 = d.ISBN10;

            // Assert
            Assert.AreEqual("3770436067", iSBN10);
        }
    }
}
