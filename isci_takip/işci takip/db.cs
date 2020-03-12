using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace işci_takip
{
    class db
    {
        public static OleDbConnection baglanti = new OleDbConnection("provider=microsoft.ace.oledb.12.0; data source=işcitakip.accdb");
        public static void baglan()
        {
            if (baglanti.State != ConnectionState.Open)
                baglanti.Open();
        }
        public static void kes()
        {
            if (baglanti.State != ConnectionState.Closed)
                baglanti.Close();
        }
    }
}
