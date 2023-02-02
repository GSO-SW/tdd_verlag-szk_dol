using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verlag;

namespace VerlagTests
{
    [TestClass]
    public class ISBNTests
    {
        [TestMethod]
        public void ISBN_BuchKannMitEinerISBNErstelltWerden()
        {
            string titel = "TestBuch";
            string autor = "Autor";
            int auflage = 2;
            string isbn = "978-3770436163";

            Buch b = new Buch(autor, titel, auflage, isbn);

            Assert.AreEqual(b.ISBN, isbn);
        }

        [TestMethod]
        public void ISBN_PruefzifferWirdErgaenzt()
        {
            //Arange
            string titel = "TestBuch";
            string autor = "Autor";
            int auflage = 2;
            string isbn = "978-377043614";

            //Act
            Buch b = new Buch(autor, titel, auflage, isbn);

            //Assert
            Assert.AreEqual("978-3770436149", b.ISBN);
        }

        [TestMethod]
        public void ISBN_ISBN10KannAusgegebenWerden()
        {
            //Arange
            string titel = "TestBuch";
            string autor = "Autor";
            int auflage = 2;
            string isbn = "978-3770436064";

            //Act
            Buch b = new Buch(autor, titel, auflage, isbn);

            //Assert
            Assert.AreEqual("3770436067", b.ISBN10);
        }
    }
}
