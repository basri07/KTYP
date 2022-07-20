using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace KTYP
{
    public partial class STATIK_ALGORITMALAR : Form
    {

        //public List<OnculMiktari> OnculMiktari = new List<OnculMiktari>();
        public int NodeCount { get; set; }
        public int AtananDugumID { get; set; }
        public string DATA_ID { get; set; }


        SqlConnection baglanti = ConnectionSQL.SqlConnection();
        SqlCommand komut = new SqlCommand();
        // public List<UzaklikMatrisi> UzaklikMatrisi = new List<UzaklikMatrisi>();
        SOPAtanabilirListeGuncelle sopk;
        ProblemComboBox ProblemComboBox;
        public STATIK_ALGORITMALAR()
        {
            DATA_ID = "";
            InitializeComponent();
            sopk = new SOPAtanabilirListeGuncelle();
            ProblemComboBox= new ProblemComboBox(); 

        }
        private void STATIK_ALGORITMALAR_Load(object sender, EventArgs e)
        {
            #region DATA ADLARI COMBO_BOX'A GETİRİLİR

            ProblemComboBox.SOPDataToComboBox(SOPData);
            ProblemComboBox.KTYPDataToComboBox(S1_comboBox);
            #endregion
        }
        private void PSO_SOPCozumButton_Click(object sender, EventArgs e)
        {
            #region TANIMLAMALAR
            string dataID = SOPData.Text;
            int ParcacikSayisi = Convert.ToInt32(PSOParcacikTextBox.Text);
            int IterasyonSayisi = Convert.ToInt32(PSOIteresyonTextBox.Text);
            Boolean EYKS;
            if (EKS_Checkbox.Checked == true)
            {
                EYKS = true;
            }
            else
            {
                EYKS = false;
            }
            StringBuilder sqlSelect = new StringBuilder();
            sqlSelect.Append("SELECT MAX(COZUM_ID) AS COZUM_ID FROM KTYP.. SONUCLAR;");
            sqlSelect.Append("SELECT  DATA_ADI from KTYP..VW_SOP_DATA_TOPLAM_BILGILERI WHERE DATA_ID='" + dataID + "'");
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect.ToString(), baglanti);
            DataSet ds = new DataSet();
            int result = da.Fill(ds);
            int LastResult = Convert.ToInt32(ds.Tables[0].Rows[0][0]) + 1;
            string DataAdı = Convert.ToString(ds.Tables[1].Rows[0][0]);
            baglanti.Open();
            string sqlInsert = "INSERT INTO KTYP.. SONUCLAR (DATA_ADI,DATA_ID,COZUM_ID,PROBLEM,ALGORITMA,B_ALGORITMA,PARCACIK_SAYISI,ITERASYON_SAYISI,UZAKLIK,B_SURE,TOPLAM_SURE,ENIYI_PARCACIK,ENIYI_ITERASYON,GOSTERIM) VALUES (@DATA_ADI,@DATA_ID,@COZUM_ID,@PROBLEM,@ALGORITMA,@B_ALGORITMA,@PARCACIK_SAYISI,@ITERASYON_SAYISI,@UZAKLIK,@B_SURE,@TOPLAM_SURE,@ENIYI_PARCACIK,@ENIYI_ITERASYON,@GOSTERIM)";
            SqlCommand command = new SqlCommand(sqlInsert, baglanti);
            command.Parameters.Add("@DATA_ADI", SqlDbType.NVarChar).Value = DataAdı;
            command.Parameters.Add("@DATA_ID", SqlDbType.NVarChar).Value = dataID;
            command.Parameters.Add("@COZUM_ID", SqlDbType.Int).Value = LastResult;
            command.Parameters.Add("@PROBLEM", SqlDbType.NVarChar).Value = "SOP";
            if (EYKS == true & ParcacikSayisi == 1 & IterasyonSayisi == 1)
            {
                command.Parameters.Add("@ALGORITMA", SqlDbType.NVarChar).Value = "EYKS";
            }
            else
            {
                command.Parameters.Add("@ALGORITMA", SqlDbType.NVarChar).Value = "PSO";
            }
            if (EYKS == true)
            {
                command.Parameters.Add("@B_ALGORITMA", SqlDbType.NVarChar).Value = "EYKS";
            }
            else
            {
                command.Parameters.Add("@B_ALGORITMA", SqlDbType.NVarChar).Value = "RASTSAL";
            }
            command.Parameters.Add("@PARCACIK_SAYISI", SqlDbType.Int).Value = Convert.ToInt32(PSOParcacikTextBox.Text);
            command.Parameters.Add("@ITERASYON_SAYISI", SqlDbType.NVarChar).Value = Convert.ToInt32(PSOIteresyonTextBox.Text);
            command.Parameters.Add("@UZAKLIK", SqlDbType.Int).Value = 0;
            command.Parameters.Add("@B_SURE", SqlDbType.NVarChar).Value = "";
            command.Parameters.Add("@TOPLAM_SURE", SqlDbType.NVarChar).Value = "";
            command.Parameters.Add("@ENIYI_PARCACIK", SqlDbType.Int).Value = 0;
            command.Parameters.Add("@ENIYI_ITERASYON", SqlDbType.Int).Value = 0;
            command.Parameters.Add("@GOSTERIM", SqlDbType.NVarChar).Value = "";
            command.ExecuteNonQuery();
            baglanti.Close();
            #endregion
            Stopwatch SureHesapla = new Stopwatch();
            SureHesapla.Start();
            PSO_SOP psosop = new PSO_SOP(baglanti, sopk, dataID);
            psosop.psoSOP(dataID, ParcacikSayisi, IterasyonSayisi, EYKS, LastResult);
            SureHesapla.Stop();
            TimeSpan HesaplananZaman = SureHesapla.Elapsed;
            string Sure = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            HesaplananZaman.Hours, HesaplananZaman.Minutes, HesaplananZaman.Seconds, HesaplananZaman.Milliseconds / 10);
            string SqlUpdate = "UPDATE KTYP..SONUCLAR SET TOPLAM_SURE='" + Sure + "' WHERE COZUM_ID =" + LastResult + "";
            baglanti.Open();
            SqlCommand SqlUpdatecmd = new SqlCommand(SqlUpdate, baglanti);
            SqlUpdatecmd.ExecuteNonQuery();
            baglanti.Close();
            //MessageBox.Show(Sure);

        }


    }
}
