using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTYP
{
    public class ProblemComboBox
    {
        SqlConnection baglanti = ConnectionSQL.SqlConnection();
        public ComboBox SOPDataToComboBox(ComboBox SOPData)
        {
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT DATA_ID from KTYP.. VW_SOP_DATA_TOPLAM_BILGILERI GROUP BY DATA_ID";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                SOPData.Items.Add(dr["DATA_ID"]);
            }
            dr.Close();
            baglanti.Close();
            return SOPData;
        }
        public ComboBox KTYPDataToComboBox(ComboBox S1_comboBox)
        {
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT PROBLEM_ID FROM [KTYP].[dbo].[VW_KTYP_DATA_TOPLAM_BILGILERI] WHERE SENARYO='SENARYO.1' ORDER BY PROBLEM_ID,SENARYO";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;   
            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                S1_comboBox.Items.Add(dr["PROBLEM_ID"]);
            }
            dr.Close();
            baglanti.Close();
            return S1_comboBox;
        }
        public DataGridView KTYPSenaryo1LoadGVW(DataGridView S1LoadGW,string Problem_ID)
        {
            string sorgu = "SELECT *FROM KTYP.. KTYP_PROBLEM WHERE PROBLEM_ID='"+Problem_ID+"' AND Pickup_Node_Def='DM'";
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            S1LoadGW.DataSource = ds.Tables[0];
            baglanti.Close();
            return S1LoadGW;
        }
    }
}
