using System;
using System.Collections;
using System.Data.SqlClient;
using System.Text;

namespace KTYP
{
    public class SOPAtanabilirListeGuncelle
    {
        SqlConnection baglanti = ConnectionSQL.SqlConnection();
        SqlCommand komut = new SqlCommand();
        public int NodeC { get; set; }
        public int AtananID { get; set; }
        public SOPAtanabilirListeGuncelle()
        {
        }
        public void OnculKontrol(string Data_ID, int item, ArrayList AtananArray, ArrayList AtanabilirArray)
        {
            int AtanmısSayisi = AtananArray.Count;
            int AtanabilirSayisi = AtanabilirArray.Count;
            // I DEN SONRA  J DUGUMUNE  GİDİLEBİLECEK DÜĞÜMLERİ LİSTELEMEK İÇİN SQL
            //ATNANLAR LİSTESİNDE ÖNCÜLLERİN TAMAMI VARSA GİDİLECEK J DÜĞÜMLERİNİ ÇEKME
            StringBuilder AtananlarSql1 = new StringBuilder("(");
            //EĞER I DÜĞÜMÜNE GİDİLMİŞSE VEYA ı DÜĞÜMÜ MEVCUT ATANABİLİR DÜĞÜM LİSTESİNDE İSE İLGİLİ I DÜĞÜMLERİNİ SQL KOMUTU İLE ÇEKMEYECEK
            StringBuilder Atananlar_Atanabilirler_Sql2 = new StringBuilder("(");
            //ATANABİLİR DÜĞÜMLERİ BULMAK İÇİN YAZILAN SQL KOMUTU OLUŞTURMA DÖNGÜSÜ
            //ÖRNEĞİN (0,5,12) DÜĞÜMLERE GİDİLMİŞ OLSUN İLK ÖNCELİĞİ SADECE 0 OLAN DÜĞÜMLER ATANABİLİRLER LİSTESİNE EKLENİR
            // SONRA 5 ATANDIĞINDA ÖNCELİK MİKTARI = 2 VE ÖNCELİĞİ (0 VE 5) OLANLAR LİSTELENECEK
            // EĞER BULUNAN DÜĞÜMLERDEN HERHANGİ BİRİ ATANANLAR LİSTESİNDE VEYA ATANABİLİRLER LİSTESİNDE ZATEN VARSA LİSTELENMEYECEK
            if (AtanmısSayisi + AtanabilirSayisi != NodeC)
            {
                for (int i = 0; i < AtanmısSayisi; i++)
                {
                    if (i == 0)
                    {

                        AtananlarSql1.Append("" + AtananArray[i] + "");
                        Atananlar_Atanabilirler_Sql2.Append("" + AtananArray[i] + "");
                    }
                    else
                    {
                        AtananlarSql1.Append(", " + AtananArray[i] + "");
                        Atananlar_Atanabilirler_Sql2.Append(", " + AtananArray[i] + "");
                    }

                }
                if (AtanabilirSayisi != 0)
                {
                    for (int i = 0; i < AtanabilirSayisi; i++)
                    {
                        Atananlar_Atanabilirler_Sql2.Append(", " + AtanabilirArray[i] + "");
                    }
                }
                else { }
                AtananlarSql1.Append(")");
                Atananlar_Atanabilirler_Sql2.Append(")");
                baglanti.Open();
                //SQL DE STORED PROSEDÜR OLUŞTURULDU
                //PROSEDÜR ATANANLAR VE ATANABİLİRLİRLER LİSTESİNDE OLMAYAN AYNI ZAMANDA BÜTÜN ÖNCÜLLERİ ATANANLAR LİSTESİNDE BULUNANLARI LİSTELİYOR
                komut = new SqlCommand("EXEC KTYP.. SP_ONCELIKPROSEDURU_1 '''" + Data_ID + "''','" + Atananlar_Atanabilirler_Sql2 + "','" + AtananlarSql1 + "','" + AtanmısSayisi + "'", baglanti);
                SqlDataReader dr = komut.ExecuteReader();
                // string a = " ";
                //ATAMA KOŞULLARINI SAĞLAYAN SQL KOMUTUNDAN GELEN VERİLER ATANABİLİRLER LİSTESİNE EKLENİR.
                while (dr.Read())
                {
                    AtanabilirArray.Add(Convert.ToInt32(dr[0]));
                    //a += +Convert.ToInt32(dr[0]) + " ";
                }
                dr.Close();
                baglanti.Close();
            }
        }
    }
}
