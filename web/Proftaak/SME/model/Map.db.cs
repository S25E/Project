using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SME
{
    public partial class Map
    {
        /// <summary>
        /// Het ophalen van alle mappen.
        /// </summary>
        /// <returns>Een Dictionary met MAP_NUMMER => de Map</returns>
        public static Dictionary<int, Map> GetMappen()
        {
            Dictionary<int, Map> mappen = new Dictionary<int, Map>();

            foreach (DataRow row in Database.GetData("SELECT * FROM MAP ORDER by MAP_NUMMER ASC").Rows)
                mappen.Add(Convert.ToInt32(row["MAP_ID"]), rowToBestand(row));

            return mappen;
        }

        /// <summary>
        /// Haalt alle submappen op bij een bepaalde map
        /// </summary>
        /// <param name="map"></param>
        /// <returns>Een lijst met mappen</returns>
        public static List<Map> GetSubmappenBijMap(Map map)
        {
            List<Map> mappen = new List<Map>();

            foreach (DataRow row in Database.GetData("SELECT * FROM MAP WHERE PARENT_ID = " + map.Nummer).Rows)
                mappen.Add(rowToBestand(row));

            return mappen;
        }

        /// <summary>
        /// Een map ophalen aan de hand van het nummer van de map
        /// </summary>
        /// <param name="nummer"></param>
        /// <returns>De Map</returns>
        public static Map GetMapBijNummer(int nummer)
        {
            foreach (DataRow row in Database.GetData("SELECT * FROM MAP WHERE MAP_ID = " + nummer).Rows)
                return rowToBestand(row);

            return null;
        }

        /// <summary>
        /// Het toevoegen van een map
        /// </summary>
        /// <param name="map"></param>
        /// <returns>Het nummer van de toegevoegde map</returns>
        public static int AddMap(Map map)
        {
            int insertedId = Convert.ToInt32(Database.GetData("SELECT SEQ_MAP.nextval FROM dual").Rows[0]["NEXTVAL"]);

            Database.Execute("INSERT INTO MAP (MAP_ID, MAP_NAAM, PARENT_ID) VALUES (@nummer, @naam, @parent)", new Dictionary<string, object>()
            {
                {"@nummer", insertedId},
                {"@naam", map.Naam},
                {"@parent", (map.ParentMapNummer == 0 ? "NULL" : map.ParentMapNummer.ToString())}
            });

            return insertedId;
        }

        /// <summary>
        /// Het converteren van de DataRow naar een Map
        /// </summary>
        /// <param name="row"></param>
        /// <returns>De Map</returns>
        private static Map rowToBestand(DataRow row)
        {
            return new Map(
                Convert.ToInt32(row["MAP_ID"]),
                row["MAP_NAAM"].ToString(),
                (row["PARENT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(row["PARENT_ID"]))
            );
        }
    }
}
