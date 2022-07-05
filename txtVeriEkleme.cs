using MessagingToolkit.QRCode.Codec;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace KTYP
{
    public class txtVeriEkleme
    {


        SqlConnection Conn = ConnectionSQL.SqlConnection();



        public string AdresTxt { get; set; }
        public string SQLSorgu { get; set; }
        public string AdresXlsx { get; set; }

        public txtVeriEkleme()
        {
            AdresTxt = "";
            SQLSorgu = "";
            AdresXlsx = "";

        }
        public void SOPTxtToSQL()
        {
            SqlCommand komut;
            string sorgu = "INSERT INTO KTYP.. DENEMEUZAKLIKMATRIS(DATA_ID,DATA_ADI,DUGUM_I,DUGUM_J,UZAKLIK,TOPLAM_DUGUM) VALUES (@ID,@ADI,@I,@J,@UZAKLIK,@TOPLAM_DUGUM)";
            // sqlDataAdapter;
            String AdresText = AdresTxt;
            String strFile = File.ReadAllText(AdresText);
            strFile = strFile.Replace("   ", " ");
            File.WriteAllText(AdresTxt, strFile);
            strFile = strFile.Replace("  ", " ");
            File.WriteAllText(AdresTxt, strFile);
            string[] lines = File.ReadAllLines(AdresTxt);
            //String DataID;
            String DataAdi;

            int NodeCount = 0;
            string[] parcalar;
            parcalar = lines[0].Split(' ');
            DataAdi = parcalar[1];
            NodeCount = Convert.ToInt32(lines[7]);
            int i = NodeCount;
            int j = NodeCount;
            string a;
            String DATAADI = DataAdi;
            String DATAID = DataAdi;
            Conn.Open();
            SqlCommand komut2;
            komut2 = new SqlCommand("Select DATA_ADI From KTYP.. DENEMEUZAKLIKMATRIS WHERE DATA_ADI='" + DATAADI + "'", Conn);
            SqlDataReader dr = komut2.ExecuteReader();

            if (dr.Read())
            {
                MessageBox.Show("AYNI VERİ İSMİ DAHA ÖNCE EKLENMİŞTİR");
                dr.Close();
                Conn.Close();
            }
            else
            {

                dr.Close();

                for (int l = 0; l < i; l++)
                {

                    parcalar = lines[l + 8].Split(' ');

                    for (int k = 0; k < j; k++)
                    {

                        a = l.ToString() + " " + k.ToString() + " " + parcalar[k + 1];

                        int I = l;
                        int J = k;
                        decimal UZAKLIK = Convert.ToDecimal(parcalar[k + 1]);
                        komut = new SqlCommand(sorgu, Conn);
                        komut.Parameters.AddWithValue("@ID", DATAID);
                        komut.Parameters.AddWithValue("@ADI", DATAADI);
                        komut.Parameters.AddWithValue("@I", I);
                        komut.Parameters.AddWithValue("@J", J);
                        komut.Parameters.AddWithValue("@UZAKLIK", UZAKLIK);
                        komut.Parameters.AddWithValue("@TOPLAM_DUGUM", NodeCount);
                        komut.ExecuteNonQuery();
                    }
                }

                Conn.Close();
                MessageBox.Show(DataAdi + " isimli SOP verisi veritabanına eklendi");
            }
        }
        public void KTYPtoFullMatrix()
        {

            int KTYPNodeCount = 194;
            string insert = "INSERT INTO KTYP.. KTYP_FULL_MATRIX (Nodes_I,Nodes_j,Distance,Axis,Degree_Angle) VALUES (@Nodes_I,@Nodes_J,@Distance,@Axis,@Degree_Angle)";
            for (int i = 0; i < KTYPNodeCount + 1; i++)
            {

                string komut = "Select *from KTYP.. KTYP_NOT_FULL_MATRIX where Nodes_I=" + i + "";
                SqlDataAdapter da = new SqlDataAdapter(komut, Conn);
                DataSet ds = new DataSet();
                int result = da.Fill(ds);
                ArrayList Nodes_J_List = new ArrayList();
                for (int c = 0; c < result; c++)
                {
                    int Nodes_I = Convert.ToInt32(ds.Tables[0].Rows[c][0]);
                    int Nodes_J = Convert.ToInt32(ds.Tables[0].Rows[c][1]);
                    int Distance = Convert.ToInt32(ds.Tables[0].Rows[c][2]);
#pragma warning disable CS8600 // Null sabit değeri veya olası null değeri, boş değer atanamaz türe dönüştürülüyor.
                    String Axis = ds.Tables[0].Rows[c][3].ToString();
#pragma warning restore CS8600 // Null sabit değeri veya olası null değeri, boş değer atanamaz türe dönüştürülüyor.
                    int Degree_Angle = Convert.ToInt32(ds.Tables[0].Rows[c][4]);
                    Nodes_J_List.Add(Nodes_J);

                    Conn.Open();
                    SqlCommand SqlInsert = new SqlCommand(insert, Conn);
                    SqlInsert.Parameters.AddWithValue("@Nodes_I", Nodes_I);
                    SqlInsert.Parameters.AddWithValue("@Nodes_J", Nodes_J);
                    SqlInsert.Parameters.AddWithValue("@Distance", Distance);
                    SqlInsert.Parameters.AddWithValue("@Axis", Axis);
                    SqlInsert.Parameters.AddWithValue("@Degree_Angle", Degree_Angle);
                    SqlInsert.ExecuteNonQuery();
                    Conn.Close();

                }
                for (int j = 0; j < KTYPNodeCount + 1; j++)
                {
                    if (Nodes_J_List.Contains(j) == false)
                    {
                        Conn.Open();
                        SqlCommand SqlInsert = new SqlCommand(insert, Conn);
                        SqlInsert.Parameters.AddWithValue("@Nodes_I", i);
                        SqlInsert.Parameters.AddWithValue("@Nodes_J", j);
                        SqlInsert.Parameters.AddWithValue("@Distance", 0);
                        SqlInsert.Parameters.AddWithValue("@Axis", "X");
                        SqlInsert.Parameters.AddWithValue("@Degree_Angle", 0);
                        SqlInsert.ExecuteNonQuery();
                        Conn.Close();
                    }
                }
            }

            MessageBox.Show("VERİLER FULL MATRİS OLARAK KAYDEDİLMİŞTİR...");
        }
        public void KTYPTxtToSQL()
        {
            #region Veriler Düzgün olduğu için excelden SQL'e aktardım.(Yerleşim Planı Matris.xlsx)
            //  ="INSERT INTO KTYP.. KTYP_NOT_FULL_MATRIX (@Nodes_I,@Nodes_J,@Distance,@Axis,@Degree_Angle) VALUES ("&A2&","&B2&","&C2&",'"&D2&"',"&E2&")"
            //  Veriler Düzgün olduğu için excelden SQL'e aktardım.(Yerleşim Planı Matris.xlsx)
            #endregion

        }
        public void BookTxtToSQL(string BookTxtAddress, Image Barcode)
        {


            SqlCommand komut;
            string sorgu = "INSERT INTO KTYP.. KTYP_BOOKS_DATA(Book_Code,Book_Release_Year,Book_Name,Author_Name,Bookshelf,Book_Barcode) VALUES (@Book_Code,@Book_Release_Year,@Book_Name,@Author_Name,@Bookshelf,@Book_Barcode)";
            // sqlDataAdapter;
            String AdresText = BookTxtAddress;
            String strFile = File.ReadAllText(AdresText);


            strFile = strFile.Replace("\t", "½");
            File.WriteAllText(AdresText, strFile);
            string[] lines = File.ReadAllLines(AdresText);
            int l = lines.Length;
            string[] parcalar;
            //pARÇALAMA İŞLEMİ DOĞRULUĞU KONTROL ETME
            //parcalar = lines[0].Split('½');
            //MessageBox.Show("Kitap Sayısı :"+l.ToString()+"\n"+parcalar[0].ToString()+ "  " + parcalar[1].ToString()+ "  "+parcalar[2].ToString()+"  " +  parcalar[3].ToString()+ " -----RAF" + parcalar[4].ToString());
            Conn.Open();
            for (int i = 0; i < l; i++)
            {
                parcalar = lines[i].Split('½');
                komut = new SqlCommand(sorgu, Conn);
                komut.Parameters.AddWithValue("@Book_Code", parcalar[0]);
                komut.Parameters.AddWithValue("@Book_Release_Year", parcalar[1]);
                komut.Parameters.AddWithValue("@Book_Name", parcalar[2]);
                komut.Parameters.AddWithValue("@Author_Name", parcalar[3]);
                komut.Parameters.AddWithValue("@Bookshelf", parcalar[4]);
                //TXT'den alınan verilerden kitap koduna göre QR kod oluşturup SQL'e ekliyoruz
                QRCodeEncoder enc = new QRCodeEncoder();
                enc.QRCodeScale = 4;
                Bitmap qrcode = enc.Encode(parcalar[0].ToString());
                Barcode = qrcode as Image;
                MemoryStream stream = new MemoryStream();
                Barcode.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] pic = stream.ToArray();

                komut.Parameters.AddWithValue("@Book_Barcode", pic);
                komut.ExecuteNonQuery();
            }
            Conn.Close();

        }
        public void BookInsertToSQL(string Code, string BookYear, string BookName, string AuthorName, string BookshelfID, Image Barcode)
        {
            SqlCommand komut;
            if (Code == null || BookYear == null || BookName == null || AuthorName == null || BookshelfID == null)
            {
                MessageBox.Show("Hücreler Boş geçilemez...!");
            }
            else
            {
                string sorgu = "INSERT INTO KTYP.. KTYP_BOOKS_DATA(Book_Code,Book_Release_Year,Book_Name,Author_Name,Bookshelf,Book_Barcode) VALUES (@Book_Code,@Book_Release_Year,@Book_Name,@Author_Name,@Bookshelf,@Book_Barcode)";
                Conn.Open();
                komut = new SqlCommand(sorgu, Conn);
                komut.Parameters.AddWithValue("@Book_Code", Code);
                komut.Parameters.AddWithValue("@Book_Release_Year", BookYear);
                komut.Parameters.AddWithValue("@Book_Name", BookName);
                komut.Parameters.AddWithValue("@Author_Name", AuthorName);
                komut.Parameters.AddWithValue("@Bookshelf", BookshelfID);
                QRCodeEncoder enc = new QRCodeEncoder();
                enc.QRCodeScale = 4;
                Bitmap qrcode = enc.Encode(Code);
                Barcode = qrcode as Image;
                MemoryStream stream = new MemoryStream();
                Barcode.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] pic = stream.ToArray();
                komut.Parameters.AddWithValue("@Book_Barcode", pic);
                komut.ExecuteNonQuery();
                Conn.Close();
            }

        }
        //Data Grid View 'e verileri çekme
        public void BookFillToDataGridView(DataGridView BookInsertGW)
        {
            string sorgu = "SELECT *FROM KTYP.. KTYP_BOOKS_DATA";
            Conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sorgu, Conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            BookInsertGW.DataSource = ds.Tables[0];
            Conn.Close();
        }
        //Data Grid View 'e filtrelenen verileri çekme
        public void BookFilterSQLtoDataGridView(string Code, string BookYear, string BookName, string AuthorName, string BookshelfID, DataGridView dataGridView)
        {
            string sorgu = "SELECT *FROM KTYP.. KTYP_BOOKS_DATA WHERE Book_Code LIKE '%" + Code + "%' AND Book_Release_Year LIKE '%" + BookYear + "%' AND Book_Name LIKE '%" + BookName + "%' AND Author_Name LIKE '%" + AuthorName + "%' AND Bookshelf LIKE '%" + BookshelfID + "%'";
            Conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sorgu, Conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView.DataSource = ds.Tables[0];
            Conn.Close();

        }
        //Data Grid View 'de seçilen verileri veritabanından silme silme
        public void BookDeleteFromSqlWhereSelectedGW(int Book_ID)
        {
            SqlCommand komut;
            string sorgu = "DELETE FROM KTYP.. KTYP_BOOKS_DATA WHERE Book_ID =@Book_ID";
            Conn.Open();
            komut = new SqlCommand(sorgu, Conn);
            komut.Parameters.AddWithValue("@Book_ID", Book_ID);
            komut.ExecuteNonQuery();
            Conn.Close();
        }
        public void BookUpdateSQL(int Book_ID, string Code, string BookYear, string BookName, string AuthorName, string BookshelfID, Image Barcode)
        {
            SqlCommand komut;
            string sorgu = "UPDATE KTYP.. KTYP_BOOKS_DATA SET  Book_Code='" + Code + "' , Book_Release_Year ='" + BookYear + "' , Book_Name = '" + BookName + "' , Author_Name = '" + AuthorName + "' , Bookshelf = '" + BookshelfID + "',Book_Barcode=@Book_Barcode WHERE Book_ID =@Book_ID";
            //Kitap Kodu değişmişse Barcode da değişecek. 

            QRCodeEncoder enc = new QRCodeEncoder();
            enc.QRCodeScale = 4;
            Bitmap qrcode = enc.Encode(Code);
            Barcode = qrcode as Image;
            MemoryStream stream = new MemoryStream();
            Barcode.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] pic = stream.ToArray();
            Conn.Open();
            komut = new SqlCommand(sorgu, Conn);
            komut.Parameters.AddWithValue("@Book_ID", Book_ID);
            komut.Parameters.AddWithValue("@Book_Barcode", pic);
            komut.ExecuteNonQuery();
            Conn.Close();

        }
        public void KTYPRastsalProblemOlustur(int BooksCount,int DmBooksCount , int BookshelfCount , int TablesCount)
        {
            SqlCommand komut;

            //RAF SAYISINA GÖRE RASTSAL RAF ÜRET
            string BookShelfRandomSQL = "SELECT TOP "+ BookshelfCount.ToString()+" Description FROM KTYP.. Nodes_Information WHERE Description like 'R%' ORDER BY NEWID()";
            Conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(BookShelfRandomSQL, Conn);
            DataSet ds = new DataSet();
            int result = da.Fill(ds);
            ArrayList RandomBookShelfList = new ArrayList();
            StringBuilder BookShelfListSQL = new StringBuilder("(");
            for (int i = 0; i < result; i++)
            {
                if (i==0)
                {
                    BookShelfListSQL.Append("'" + Convert.ToString(ds.Tables[0].Rows[i][0]) + "'");
                    RandomBookShelfList.Add(Convert.ToString(ds.Tables[0].Rows[i][0]));
                }
                else
                { 
                    BookShelfListSQL.Append(",'"+Convert.ToString(ds.Tables[0].Rows[i][0])+"'");
                    RandomBookShelfList.Add(Convert.ToString(ds.Tables[0].Rows[i][0]));
                }
            }
            BookShelfListSQL.Append(")");
            //ÜRETİLEN RAFLAR'a Kitap Sayısı miktarı kadar kitap üret.
            string BookinTableRandomSQL = "SELECT TOP "+ BooksCount.ToString()+ " Book_ID,Bookshelf FROM KTYP.. KTYP_BOOKS_DATA WHERE Author_Name not like '' AND Bookshelf IN" + BookShelfListSQL+" ORDER BY NEWID()";
            SqlDataAdapter da1 = new SqlDataAdapter(BookinTableRandomSQL, Conn);
            DataSet ds1 = new DataSet();
            int result1 = da1.Fill(ds1);
            ArrayList RandomBookList = new ArrayList();
            ArrayList BookshelfList = new ArrayList();
            for (int i = 0; i < result1; i++)
            {
                RandomBookList.Add(Convert.ToString(ds1.Tables[0].Rows[i][0]));
                BookshelfList.Add(Convert.ToString(ds1.Tables[0].Rows[i][1]));
            }
            //RASTSAL MASA MİKTARI KADAR MASA ÜRET
            string TableRandomSQL = "SELECT TOP "+TablesCount.ToString()+ " Description FROM KTYP.. Nodes_Information WHERE Description not like'R%' AND Description <>'DM'  ORDER BY NEWID()";
            SqlDataAdapter da2 = new SqlDataAdapter(TableRandomSQL, Conn);
            DataSet ds2 = new DataSet();
            int result2 = da2.Fill(ds2);
            ArrayList RandomTableList = new ArrayList();
            for (int i = 0; i < result2; i++)
            {
                RandomTableList.Add(Convert.ToString(ds2.Tables[0].Rows[i][0]));
            }
            //MASALARDA KİTAP DAĞIIMI
            
            ArrayList BooksCountTableRandomList = new ArrayList();
            for (int i = 0; i < DmBooksCount; i++)
            {
                BooksCountTableRandomList.Add("DM");
            }
            int BooksinTableCount = BooksCount - DmBooksCount;
            for (int i = 0; i < BooksinTableCount; i++)
            {
                Random Rnd = new Random();
                int RndTableIndex = Rnd.Next(TablesCount);
                BooksCountTableRandomList.Add(RandomTableList[RndTableIndex]);
            }
            string LastProblemIDSQL = "SELECT MAX(PROBLEM_ID) from KTYP..KTYP_PROBLEM";
            SqlDataAdapter da3 = new SqlDataAdapter(LastProblemIDSQL, Conn);
            DataSet ds3 = new DataSet();
            int result3 = da3.Fill(ds3);
            string LastProblemID;
            string NewProblemID;
            if (Convert.ToString(ds3.Tables[0].Rows[0][0])=="")
            {
                NewProblemID = "KTYP.B"+ BooksCount.ToString() +".N"+ Convert.ToString(TablesCount+BookshelfCount)+ ".T" + TablesCount.ToString()+".R"+ BookshelfCount.ToString()+".1";

            }
            else
            {
                LastProblemID = ds3.Tables[0].Rows[0][0].ToString();
#pragma warning disable CS8600 // Null sabit değeri veya olası null değeri, boş değer atanamaz türe dönüştürülüyor.
                string[] parcalar;
#pragma warning disable CS8602 // Olası bir null başvurunun başvurma işlemi.
                parcalar = LastProblemID.Split('.');
#pragma warning disable CS8602 // Olası bir null başvurunun başvurma işlemi.
                NewProblemID = parcalar[0] + ".B" + BooksCount.ToString() + ".N" + Convert.ToString(TablesCount + BookshelfCount) + ".T" + TablesCount.ToString() + ".R" + BookshelfCount.ToString()+".";
                int ID = Convert.ToInt32(parcalar[5]) + 1;
                NewProblemID += ID.ToString();

            }
#pragma warning disable CS8600 // Null sabit değeri veya olası null değeri, boş değer atanamaz türe dönüştürülüyor.


            string InsertProblemSQL = "INSERT INTO KTYP.. KTYP_PROBLEM (PROBLEM_ID,Book_ID,Pickup_Node_Def,Delivery_Node_Def) VALUES(@PROBLEM_ID,@Book_ID,@Pickup_Node_Def,@Delivery_Node_Def)";
            for (int i = 0; i < BooksCount; i++)
            {
                komut = new SqlCommand(InsertProblemSQL, Conn);
                komut.Parameters.AddWithValue("@PROBLEM_ID", NewProblemID);
                komut.Parameters.AddWithValue("@Book_ID", RandomBookList[i]);
                komut.Parameters.AddWithValue("@Pickup_Node_Def", BooksCountTableRandomList[i]);
                komut.Parameters.AddWithValue("@Delivery_Node_Def", BookshelfList[i]);
                komut.ExecuteNonQuery();
            }
            Conn.Close();
        }
    }
}
