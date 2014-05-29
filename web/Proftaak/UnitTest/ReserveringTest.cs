﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SME;

namespace UnitTest
{
    [TestClass]
    public class ReserveringTest
    {
        private Reservering reservering;

        [TestInitialize]
        [TestMethod]
        public void AddHoofdboeker()
        {
            Hoofdboeker hoofdboeker = new Hoofdboeker("Naam", "Straat", "Postcode", "Woonplaats", "Telefoon", "Email", "Rekeningnummer", "Sofinummer", "Wachtwoord", false);
            Reservering reservering = new Reservering();
            ReserveringBeheer.AddReservering(reservering, hoofdboeker);
            this.reservering = reservering;
            Hoofdboeker persoon = (Hoofdboeker)Persoon.GetPersoonBijRFID(hoofdboeker.Nummer);
            Assert.AreEqual("Naam", persoon.Naam, "Naam komt niet overeen met wat is toegevoegd.");
            Assert.AreEqual("Straat", persoon.Straat, "Straat komt niet overeen met wat is toegevoegd.");
            Assert.AreEqual("Postcode", persoon.Postcode, "Postcode komt niet overeen met wat is toegevoegd.");
            Assert.AreEqual("Woonplaats", persoon.Woonplaats, "Woonplaats komt niet overeen met wat is toegevoegd.");
            Assert.AreEqual("Telefoon", persoon.Telefoon, "Telefoon komt niet overeen met wat is toegevoegd.");
            Assert.AreEqual("Email", persoon.Email, "Email komt niet overeen met wat is toegevoegd.");
            Assert.AreEqual("Rekeningnummer", persoon.Rekeningnummer, "Rekeningnummer komt niet overeen met wat is toegevoegd.");
            Assert.AreEqual("Sofinummer", persoon.Sofinummer, "Sofinummer komt niet overeen met wat is toegevoegd.");
            Assert.AreEqual(true, persoon.ControleerWachtwoord("Wachtwoord"), "Wachtwoord komt niet overeen met wat is toegevoegd.");
            Assert.AreEqual(false, persoon.Aanwezig, "Email komt niet overeen met wat is toegevoegd.");

            persoon = (Hoofdboeker)Persoon.GetHoofdboekerBijReservering(reservering);
            Assert.AreEqual(hoofdboeker.Nummer, persoon.Nummer, "Hoofdboeker bij reservering komt niet overeen.");

            persoon.Delete();
            Assert.AreEqual(null, (Hoofdboeker)Persoon.GetPersoonBijRFID(hoofdboeker.Nummer), "Persoon is aanwezig ondanks dat deze verwijderd is.");
        }

        [TestMethod]
        public void AddBijboeker()
        {
            this.reservering.AddBijboeker(new Bijboeker("Bijboeker", "Wachtwoord"));
        }

    }
}
