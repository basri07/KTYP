using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTYP
{
    public class SOP_EYKS : SOP
    {
        UzaklikHesapla UH;
        public SOP_EYKS(SqlConnection baglanti, SOPAtanabilirListeGuncelle sopk, string dataId) : base(baglanti, sopk, dataId)
        {
            this.baglanti = baglanti;
            this.dataId = dataId;
            this.sopk = sopk;
            this.UH = new UzaklikHesapla(baglanti, sopk, dataId);

        }

        public override string SOPCoz(int nodeCount, ArrayList atanabilirDugumIDListesi,bool EYKS)
        {
            ArrayList atananDugumIDListesi = new ArrayList();
            StringBuilder sonuc = new StringBuilder("");
            int ToplamUzaklik = 0;
            //int Uzaklik = 0;
            Random rastgeleAtama = new Random();
            for (int i = 0; i < nodeCount; i++)
            {

                int RandomIndex = rastgeleAtama.Next(atanabilirDugumIDListesi.Count - 1);
                int atananDugumID = Convert.ToInt32(atanabilirDugumIDListesi[RandomIndex]);
                atananDugumIDListesi.Add(atananDugumID);

                sopk.AtananID = atananDugumID;
                atanabilirDugumIDListesi.Remove(atananDugumID);
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
