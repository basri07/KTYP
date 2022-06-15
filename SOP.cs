using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTYP
{
    public abstract class SOP
    {
        protected SqlConnection baglanti;
        protected string dataId;
        protected SOPAtanabilirListeGuncelle sopk;

        public SOP(SqlConnection baglanti, SOPAtanabilirListeGuncelle sopk, string dataId)
        {
            this.baglanti = baglanti;
            this.dataId = dataId;
            this.sopk = sopk;
        }



        public List<OnculMatrisi> OnculMatrisi()
        {
            List<OnculMatrisi> Matris = new List<OnculMatrisi>();
            #region Oncelik Matrisini Ekliyoruz
            string Sqlsorgu3 = "SELECT DUGUM_I FROM KTYP.. VW_SOP_ONCELIK_MIKTARLARI WHERE DATA_ID = '" + dataId + "'";
            SqlDataAdapter da = new SqlDataAdapter(Sqlsorgu3, baglanti);
            DataSet ds = new DataSet();
            int NodeCount = da.Fill(ds) + 1;
            for (int i = 0; i < NodeCount; i++)
            {
                OnculMatrisi NODE = new OnculMatrisi();
                if (i == 0)
                {
                    NODE.Dugum_I = i;
                    //NODE.Dugum_J = null;
                    NODE.Miktar = 0;
                    Matris.Add(NODE);
                }
                else
                {
                    NODE.Dugum_I = i;
                    string SqlSorguL = "SELECT DUGUM_J from KTYP.. VW_SOP_ONCUL_LISTESI WHERE DATA_ID = '" + dataId + "' AND DUGUM_I =" + i + " ORDER BY DUGUM_J";
                    SqlDataAdapter daL = new SqlDataAdapter(SqlSorguL, baglanti);
                    DataSet dsL = new DataSet();
                    int OncelikMiktari = daL.Fill(dsL);
                    ArrayList DugumJList = new ArrayList();
                    StringBuilder Sb = new StringBuilder("");
                    for (int j = 0; j < OncelikMiktari; j++)
                    {
                        int a = Convert.ToInt32(dsL.Tables[0].Rows[j][0]);
                        NODE.Dugum_J.Add(a);
                    }
                    NODE.Miktar = OncelikMiktari;
                    Matris.Add(NODE);
                }
            }
           
            //Matris.FirstOrDefault<OnculMatrisi>(x => x.Dugum_J != null);

            #endregion Oncelik Matrisini Ekliyoruz
            return Matris;
        }

        public int NodeCount()
        {
            baglanti.Open();
            //DÜĞÜM SAYISI   //DÜĞÜM SAYISI   //DÜĞÜM SAYISI   //DÜĞÜM SAYISI   //DÜĞÜM SAYISI   //DÜĞÜM SAYISI   //DÜĞÜM SAYISI
            int nodeCount = 0;
            SqlCommand komut = new SqlCommand("SELECT TOPLAM_DUGUM FROM KTYP.. VW_SOP_DATA_TOPLAM_BILGILERI WHERE DATA_ID ='" + dataId + "'", baglanti);
            SqlDataReader dr1 = komut.ExecuteReader();
            while (dr1.Read())
            {
                nodeCount = Convert.ToInt32(dr1[0]);
            }
            sopk.NodeC = nodeCount;
            dr1.Close();
            baglanti.Close();
            return nodeCount;
        }

        public ArrayList AtabilirDugumIdListele()
        {
            #region PARAMETRELER
            //ATANABİLİR VE ATANAN DÜĞÜMLERİN LİSTE TANIMLAMASI
            ArrayList atanabilirDugumIDListesi = new ArrayList();
            int BaslangıcID, BitisID; 
            //BAŞLANGIC VE BİTİŞ DÜĞÜMLERİNİN BULUNMASI 1 başangıç 1 bitiş için
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT DURUM,DUGUM_I FROM KTYP.. VW_SOP_BASLANGIC_BITIS WHERE DATA_ID ='" + dataId + "'", baglanti);
            SqlDataReader dr2 = komut.ExecuteReader();

            while (dr2.Read())
            {
                if (Convert.ToString(dr2[0]) == "BASLANGIC")
                {
                    BaslangıcID = Convert.ToInt32(dr2[1]);
                    atanabilirDugumIDListesi.Add(BaslangıcID);
                }
                if (Convert.ToString(dr2[0]) == "BITIS")
                {
                    BitisID = Convert.ToInt32(dr2[1]);
                }
            }
            dr2.Close();
            baglanti.Close();
            return atanabilirDugumIDListesi;
            #endregion
        }

        public abstract string SOPCoz(int nodeCount, ArrayList atanabilirDugumIDListesi,bool EYKS);
    }
}
