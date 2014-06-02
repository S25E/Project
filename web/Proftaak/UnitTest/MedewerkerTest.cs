using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SME;

namespace UnitTest
{
    [TestClass]
    public class MedewerkerTest
    {
        [TestMethod]
        public void AddMedewerker()
        {
            Persoon.AddPersoon(new Medewerker("Medewerker", "Functie", "Rekeningnummer", "Wachtwoord"));
        }
    }
}
