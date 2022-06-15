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
    public partial class UzaklikHesapla:SOP
    {
        public override string SOPCoz(int nodeCount, ArrayList atanabilirDugumIDListesi, bool EYKS)
        {
            throw new NotImplementedException();
        }
        public UzaklikHesapla(SqlConnection baglanti, SOPAtanabilirListeGuncelle sopk, string dataId) : base(baglanti, sopk, dataId)
        {
            this.baglanti = baglanti;
            this.dataId = dataId;
            this.sopk = sopk;
        }
        public int UzaklikHesabi(ArrayList array)
        {
            int Uzaklik = 0;
            int ToplamUzaklik = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < array.Count; i++)
            {
                if (i != 0)
                {
                    sb.Append("SELECT UZAKLIK FROM KTYP.. DENEMEUZAKLIKMATRIS WHERE DATA_ID ='" + dataId + "' AND DUGUM_I=" + array[i - 1] + " AND DUGUM_J=" + array[i] + ";");
                }
            }
            SqlDataAdapter da = new SqlDataAdapter(sb.ToString(), baglanti);
            DataSet ds = new DataSet();
            int result = da.Fill(ds);
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                Uzaklik = Convert.ToInt32(ds.Tables[i].Rows[0][0]);
                ToplamUzaklik += Uzaklik;
            }
            return ToplamUzaklik;
        }
    }
    
}
