using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SME
{
    public partial class MateriaalCategorie
    {
        public static List<MateriaalCategorie> GetMateriaalCategorieen()
        {
            List<MateriaalCategorie> materiaalcategorieen = new List<MateriaalCategorie>();

            foreach (DataRow row in Database.GetData("SELECT DISTINCT CATEGORIE FROM MATERIAAL").Rows)
            {
                materiaalcategorieen.Add(new MateriaalCategorie(row["Categorie"].ToString()));
                
            }
            return materiaalcategorieen;
        }
    }
}