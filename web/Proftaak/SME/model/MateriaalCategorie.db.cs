﻿using System;
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

            foreach (DataRow row in Database.GetData("SELECT CATEGORIE FROM MATERIAAL WHERE BARCODE NOT IN (SELECT BARCODE FROM UITLENING WHERE DATUM_UITGELEEND IS NOT NULL) ORDER BY NAAM, BARCODE").Rows)
            {
                materiaalcategorieen.Add(new MateriaalCategorie(row["CATEGORIE"].ToString()));
                
            }
          return materiaalcategorieen;
        }
    }
}