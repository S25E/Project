using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SME
{
    public class MateriaalCategorie
    {
        public static List<MateriaalCategorie> GetCategorie()
        {
            List<MateriaalCategorie> materiaalcategorieen = new List<MateriaalCategorie>();
            foreach (DataRow row in Database.GetData("Select DISTINCT Categorie From Materiaal").Rows)
            {
                MateriaalCategorie materiaalCategorie = new MateriaalCategorie(row["CATEGORIE"].ToString());
                materiaalcategorieen.Add(materiaalCategorie);
                
            }
            return materiaalcategorieen;
        }
    }
}