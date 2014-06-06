using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace SME
{
    public partial class Materiaal
    {
        public static int AddMateriaal(Materiaal materiaal)
        {
            int insertedId = Database.GetSequence("SEQ_MATERIAAL");
            Database.Execute("INSERT INTO Materiaal (barcode, naam, aantal, verhuurprijs, omschrijving, categorie) VALUES (@barcode, @naam, @aantal, @verhuurprijs, @omschrijving, @categorie)", new Dictionary<string, object>()
            {
                {"@barcode", insertedId},
                {"@naam", materiaal.Naam},
                {"@aantal", materiaal.Aantal},
                {"@verhuurprijs", materiaal.Verhuurprijs},
                {"@omschrijving", materiaal.Omschrijving},
                {"@categorie", materiaal.Categorie}
            });
            return insertedId;
        }

        public static void UpdateAantal(Materiaal materiaal)
        {
            Database.Execute("UPDATE MATERIAAL SET AANTAL = " + materiaal.aantal + " WHERE  BARCODE = @BARCODE", new Dictionary<string, object>(){
                {"@barcode", materiaal.Barcode}
            });
        }
        public static void DeleteMateriaal(Materiaal materiaal)
        {

            Database.Execute("DELETE FROM Materiaal WHERE BARCODE = @BARCODE", new Dictionary<string, object>(){
                {"@barcode", materiaal.Barcode}
            });
        }

        private static DataTable getMaterialenByWhere(string where, Dictionary<string, object> parameters = default(Dictionary<string, object>))
        {

            return Database.GetData("SELECT * FROM Materiaal" + (where != "" ? " WHERE " + where : ""), parameters);

        }

        public static Materiaal rowToMateriaal(DataRow row)
        {
            return new Materiaal(row["BARCODE"].ToString(), row["NAAM"].ToString(), Convert.ToInt32(row["AANTAL"]), Convert.ToInt32(row["VERHUURPRIJS"]), row["OMSCHRIJVING"].ToString(), row["CATEGORIE"].ToString());
        }

        public static Materiaal GetMateriaalBijBarcode(int barcode)
        {
            foreach (DataRow row in getMaterialenByWhere("barcode = " + barcode).Rows)
            {
                return rowToMateriaal(row);
            }

            return (Materiaal)null;
        }

        public static List<Materiaal> GetMaterialenBijCategorie(MateriaalCategorie materiaalcategorie)
        {
            List<Materiaal> materialen = new List<Materiaal>();

            foreach (DataRow row in getMaterialenByWhere("categorie = @categorie", new Dictionary<string, object>(){
               {"@categorie", materiaalcategorie.Naam} 
            }).Rows)
            {
                materialen.Add(rowToMateriaal(row));
            }

            return materialen;
        }

        /*public static List<string> GetMaterialenBijCategorie(string materiaalcategorie)
        {
            List<string> materialen = new List<string>();
            foreach (DataRow row in Database.GetData("SELECT NAAM, CATEGORIE, AANTAL - NVL((SELECT SUM(aantal) FROM UITLENING WHERE MATERIAAL.BARCODE = UITLENING.BARCODE AND DATUM_INGELEVERD IS NULL), 0) as AAP FROM MATERIAAL").Rows)
            {
               if (materiaalcategorie == row["CATEGORIE"].ToString())
               {
                   materialen.Add(row["NAAM"].ToString() + ", " + row["AAP"].ToString()); 
               }
            }

            return materialen;
        }*/

        public static void AddMateriaalReservering(Reservering reservering, int barcode)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Parameters.Add("p_reserveringsnummer", OracleDbType.Varchar2).Value = reservering.Nummer;
            cmd.Parameters.Add("p_barcode", OracleDbType.Varchar2).Value = barcode;
            cmd.Parameters.Add("p_datumUitgeleend", OracleDbType.Date).Value = DateTime.Today;
            cmd.Parameters.Add("p_datumIngeleverd", OracleDbType.Date).Value = null;
            cmd.Parameters.Add("p_aantal", OracleDbType.Int32).Value = "1";
            Database.ExecuteProcedure(cmd, "ADD_MATERIAAL");
        }
    }
}