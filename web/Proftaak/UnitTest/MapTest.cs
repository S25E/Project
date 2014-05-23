using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SME;
using System.IO;

namespace UnitTest
{
    [TestClass]
    public class MapTest
    {
        [TestMethod]
        public void AddMap()
        {
            string mapnaam = Path.GetRandomFileName().Replace(",", "");
            Map map = new Map(mapnaam, 0);
            BestandenCatalogus.AddMap(map);
            Map gevondenmap = Map.GetMapBijNummer(map.Nummer);
            Assert.IsNotNull(gevondenmap, "De toegevoegde map is niet terugevonden in de database.");
            Assert.AreEqual(gevondenmap.Naam, mapnaam, "De naam van de gevonden map komt niet overeen met de naam van de toegevoegd map.");
        }
    }
}
