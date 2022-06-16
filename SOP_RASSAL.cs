using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace KTYP
{
    public class SOP_RASSAL : SOP
    {
        UzaklikHesapla UH;
        public SOP_RASSAL(SqlConnection baglanti, SOPAtanabilirListeGuncelle sopk, string dataId) : base(baglanti, sopk, dataId)
        {
            this.baglanti = baglanti;
            this.dataId = dataId;
            this.sopk = sopk;
            this.UH = new UzaklikHesapla(baglanti, sopk, dataId);
        }
        public override string SOPCoz(int nodeCount, ArrayList atanabilirDugumIDListesi, bool EYKS)
        {
            ArrayList atananDugumIDListesi = new ArrayList();
            StringBuilder sonuc = new StringBuilder("");
            int ToplamUzaklik = 0;
            //int Uzaklik = 0;
            Random rastgeleAtama = new Random();
            for (int i = 0; i < nodeCount; i++)
            {
                int RandomIndex;
                int atananDugumID;
                if (EYKS == false || i == 0)
                {
                    RandomIndex = rastgeleAtama.Next(atanabilirDugumIDListesi.Count - 1);
                    atananDugumID = Convert.ToInt32(atanabilirDugumIDListesi[RandomIndex]);
                    atananDugumIDListesi.Add(atananDugumID);
                    sopk.AtananID = atananDugumID;
                    atanabilirDugumIDListesi.Remove(atananDugumID);
                }
                else
                {
                    StringBuilder sb = new StringBuilder("SELECT DUGUM_J,MIN(UZAKLIK)AS UZAKLIK FROM KTYP.. DENEMEUZAKLIKMATRIS WHERE DATA_ID ='" + dataId + "' AND DUGUM_I=" + atananDugumIDListesi[^1] + " AND DUGUM_J IN (");
                    for (int j = 0; j < atanabilirDugumIDListesi.Count; j++)
                    {
                        sb.Append("" + atanabilirDugumIDListesi[j] + ",");
                        if (j == atanabilirDugumIDListesi.Count - 1)
                        {
                            sb.Append("" + atanabilirDugumIDListesi[j] + ") GROUP BY DUGUM_J ORDER BY UZAKLIK");
                        }
                    }
                    SqlDataAdapter da = new SqlDataAdapter(sb.ToString(), baglanti);
                    DataSet ds = new DataSet();
                    int result = da.Fill(ds);
                    int Dugum_J = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    int Uzaklik_J = Convert.ToInt32(ds.Tables[0].Rows[0][1]);

                    atananDugumID = Dugum_J;
                    atananDugumIDListesi.Add(atananDugumID);
                    sopk.AtananID = atananDugumID;
                    atanabilirDugumIDListesi.Remove(atananDugumID);
                }
                if (atanabilirDugumIDListesi.Count == 0)
                {
                    sopk.OnculKontrol(this.dataId, atananDugumID, atananDugumIDListesi, atanabilirDugumIDListesi);
                }
                sonuc.Append(Convert.ToString(atananDugumIDListesi[i]) + " ");
            }
            ToplamUzaklik = UH.UzaklikHesabi(atananDugumIDListesi);
            //baglanti.Close();
            sonuc.Append(ToplamUzaklik.ToString());
            return sonuc.ToString();
        }

    }

}
