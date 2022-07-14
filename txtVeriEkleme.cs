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
        public void KTYPRastsalProblemOlustur(int BooksCount, int DmBooksCount, int BookshelfCount, int TablesCount)
        {
            SqlCommand komut;
            Conn.Open();
            //RAF SAYISINA GÖRE RASTSAL RAF ÜRET
            ArrayList Nodes = new ArrayList();
            ArrayList Nodes_TM = new ArrayList();
            Nodes_TM.Add("DM");
            Nodes_TM.Add("M101");
            Nodes.Add("DM");
            ArrayList RandomBookShelfList = new ArrayList();
            StringBuilder BookShelfListSQL = new StringBuilder("(");
            for (int i = 0; i < BookshelfCount; i++)
            {
                if (i == 0)
                {
                    string BookShelfRandomSQL = "SELECT TOP (1) Description FROM KTYP.. Nodes_Information WHERE Description like 'R%' ORDER BY NEWID()";
                    SqlDataAdapter da = new SqlDataAdapter(BookShelfRandomSQL, Conn);
                    DataSet ds = new DataSet();
                    int result = da.Fill(ds);
                    RandomBookShelfList.Add(Convert.ToString(ds.Tables[0].Rows[0][0]));
                    BookShelfListSQL.Append("'" + Convert.ToString(ds.Tables[0].Rows[0][0]) + "'");
                    Nodes.Add(Convert.ToString(ds.Tables[0].Rows[0][0]));
                    Nodes_TM.Add(Convert.ToString(ds.Tables[0].Rows[0][0]));
                }
                else
                {
                    if (i == BookshelfCount - 1)
                    {
                        string BookShelfRandomSQL = "SELECT TOP (1) Description FROM KTYP.. Nodes_Information WHERE Description like 'R%' AND Description NOT IN" + BookShelfListSQL.ToString() + ") ORDER BY NEWID()";
                        SqlDataAdapter da = new SqlDataAdapter(BookShelfRandomSQL, Conn);
                        DataSet ds = new DataSet();
                        int result = da.Fill(ds);
                        RandomBookShelfList.Add(Convert.ToString(ds.Tables[0].Rows[0][0]));
                        BookShelfListSQL.Append(",'" + Convert.ToString(ds.Tables[0].Rows[0][0]) + "')");
                        Nodes.Add(Convert.ToString(ds.Tables[0].Rows[0][0]));
                        Nodes_TM.Add(Convert.ToString(ds.Tables[0].Rows[0][0]));
                    }
                    else
                    {
                        string BookShelfRandomSQL = "SELECT TOP (1) Description FROM KTYP.. Nodes_Information WHERE Description like 'R%' AND Description NOT IN" + BookShelfListSQL.ToString() + ") ORDER BY NEWID()";
                        SqlDataAdapter da = new SqlDataAdapter(BookShelfRandomSQL, Conn);
                        DataSet ds = new DataSet();
                        int result = da.Fill(ds);
                        RandomBookShelfList.Add(Convert.ToString(ds.Tables[0].Rows[0][0]));
                        BookShelfListSQL.Append(",'" + Convert.ToString(ds.Tables[0].Rows[0][0]) + "'");
                        Nodes.Add(Convert.ToString(ds.Tables[0].Rows[0][0]));
                        Nodes_TM.Add(Convert.ToString(ds.Tables[0].Rows[0][0]));
                    }

                }

            }

            Nodes_TM.Add("DummyDm");
            // //RASTSAL MASA MİKTARI KADAR MASA ÜRET

            ArrayList RandomTableList = new ArrayList();
            StringBuilder TableListSql = new StringBuilder("(");
            for (int i = 0; i < TablesCount; i++)
            {
                if (i == 0)
                {
                    string TableRandomSQL = "SELECT TOP (1) Description FROM KTYP.. Nodes_Information WHERE Description not like'R%' AND Description <>'DM'  ORDER BY NEWID()";
                    SqlDataAdapter da2 = new SqlDataAdapter(TableRandomSQL, Conn);
                    DataSet ds2 = new DataSet();
                    int result2 = da2.Fill(ds2);
                    RandomTableList.Add(Convert.ToString(ds2.Tables[0].Rows[0][0]));
                    TableListSql.Append("'" + Convert.ToString(ds2.Tables[0].Rows[0][0]) + "'");
                }
                else
                {
                    string TableRandomSQL = "SELECT TOP (1) Description FROM KTYP.. Nodes_Information WHERE Description not like'R%' AND Description <>'DM' AND Description NOT IN" + TableListSql.ToString() + ")   ORDER BY NEWID()";
                    SqlDataAdapter da2 = new SqlDataAdapter(TableRandomSQL, Conn);
                    DataSet ds2 = new DataSet();
                    int result2 = da2.Fill(ds2);
                    RandomTableList.Add(Convert.ToString(ds2.Tables[0].Rows[0][0]));
                    TableListSql.Append(",'" + Convert.ToString(ds2.Tables[0].Rows[0][0]) + "'");
                }

            }
            TableListSql.Append(")");

        //ÜRETİLEN RAFLAR'a Kitap Sayısı miktarı kadar kitap üret.
        KitapUret:
            string BookinTableRandomSQL = "SELECT TOP " + BooksCount.ToString() + " Book_ID,Bookshelf FROM KTYP.. KTYP_BOOKS_DATA WHERE Author_Name not like '' AND Bookshelf IN" + BookShelfListSQL + " ORDER BY NEWID()";
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

            for (int i = 0; i < RandomBookShelfList.Count; i++)
            {
                if (BookshelfList.Contains(RandomBookShelfList[i].ToString()))
                {

                }
                else
                {
                    i = 0;
                    goto KitapUret;
                }
            }


        //MASALARDA KİTAP DAĞILIMI
        MasaKitap:
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
            for (int i = 0; i < TablesCount; i++)
            {
                if (BooksCountTableRandomList.Contains(RandomTableList[i].ToString()))
                {

                }
                else
                {
                    i = 0;
                    goto MasaKitap;
                }
            }
            string LastProblemIDSQL = "SELECT MAX(PROBLEM_ID) from KTYP..KTYP_PROBLEM";
            SqlDataAdapter da3 = new SqlDataAdapter(LastProblemIDSQL, Conn);
            DataSet ds3 = new DataSet();
            int result3 = da3.Fill(ds3);
            string LastProblemID;
            string NewProblemID;
            if (Convert.ToString(ds3.Tables[0].Rows[0][0]) == "")
            {
                NewProblemID = "KTYP.B" + BooksCount.ToString() + ".N" + Convert.ToString(TablesCount + BookshelfCount) + ".T" + TablesCount.ToString() + ".R" + BookshelfCount.ToString() + ".1";

            }
            else
            {
                LastProblemID = ds3.Tables[0].Rows[0][0].ToString();
#pragma warning disable CS8600 // Null sabit değeri veya olası null değeri, boş değer atanamaz türe dönüştürülüyor.
                string[] parcalar;
#pragma warning disable CS8602 // Olası bir null başvurunun başvurma işlemi.
                parcalar = LastProblemID.Split('.');
#pragma warning disable CS8602 // Olası bir null başvurunun başvurma işlemi.
                NewProblemID = parcalar[0] + ".B" + BooksCount.ToString() + ".N" + Convert.ToString(TablesCount + BookshelfCount) + ".T" + TablesCount.ToString() + ".R" + BookshelfCount.ToString() + ".";
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
            //Düğümleri SQL'e Matris olarak Aktar Senaryo 0


            for (int i = 0; i < RandomTableList.Count; i++)
            {
                Nodes.Add(RandomTableList[i]);
            }

            string InsertProblemSenaryo0Matrix = "INSERT INTO KTYP.. KTYP_PROBLEM_SENARYO_MATRIX (PROBLEM_ID,SENARYO, Node_I, Node_I_Def,Node_J,Node_J_Def,Distance,Shortest_Path) VALUES (@PROBLEM_ID,@SENARYO, @Node_I, @Node_I_Def,@Node_J,@Node_J_Def,@Distance,@Shortest_Path)";

            for (int i = 0; i < Nodes.Count; i++)
            {
                for (int j = 0; j < Nodes.Count; j++)
                {
                    komut = new SqlCommand(InsertProblemSenaryo0Matrix, Conn);
                    komut.Parameters.AddWithValue("@PROBLEM_ID", NewProblemID);
                    komut.Parameters.AddWithValue("@SENARYO", "SENARYO.0");
                    //Düğümlerin Açıklamalarına göre Düğüm ID bul
                    string NodesInfSQL = "SELECT *FROM KTYP.. VW_KTYP_REQUIRED_NODES WHERE Nodes_I_Def='" + Nodes[i].ToString() + "' AND Nodes_J_Def='" + Nodes[j].ToString() + "'";
                    SqlDataAdapter da4 = new SqlDataAdapter(NodesInfSQL, Conn);
                    DataSet ds4 = new DataSet();
                    int result4 = da4.Fill(ds4);

                    int Node_I = Convert.ToInt32(ds4.Tables[0].Rows[0][0]);
                    int Node_J = Convert.ToInt32(ds4.Tables[0].Rows[0][1]);
                    int Distance = Convert.ToInt32(ds4.Tables[0].Rows[0][4]);
                    string ShortestPath = ds4.Tables[0].Rows[0][5].ToString();
                    komut.Parameters.AddWithValue("@Node_I", Node_I);
                    komut.Parameters.AddWithValue("@Node_I_Def", Nodes[i].ToString());

                    komut.Parameters.AddWithValue("@Node_J", Node_J);
                    komut.Parameters.AddWithValue("@Node_J_Def", Nodes[j].ToString());

                    komut.Parameters.AddWithValue("@Distance", Distance);
                    komut.Parameters.AddWithValue("@Shortest_Path", ShortestPath);
                    komut.ExecuteNonQuery();
                }
            }

            //Senaryo 1 (GSP) ÇM veya TM dahil değil DM den alınan kitaplar doğrudan raflara
            string ProblemtoSenaryo1 = "SELECT  DISTINCT Delivery_Node_Def FROM KTYP.. KTYP_PROBLEM where Pickup_Node_Def LIKE '%DM%' AND PROBLEM_ID ='" + NewProblemID + "'";
            SqlDataAdapter da8 = new SqlDataAdapter(ProblemtoSenaryo1, Conn);
            DataSet ds8 = new DataSet();
            int result8 = da8.Fill(ds8);
            ArrayList S1senaryoRaf = new ArrayList();
            S1senaryoRaf.Add("DM");
            for (int i = 0; i < result8; i++)
            {
                S1senaryoRaf.Add(ds8.Tables[0].Rows[i][0].ToString());

            }
            for (int i = 0; i < S1senaryoRaf.Count; i++)
            {
                for (int j = 0; j < S1senaryoRaf.Count; j++)
                {
                    komut = new SqlCommand(InsertProblemSenaryo0Matrix, Conn);
                    komut.Parameters.AddWithValue("@PROBLEM_ID", NewProblemID);
                    komut.Parameters.AddWithValue("@SENARYO", "SENARYO.1");

                    string SelectRNodes = "SELECT * FROM KTYP..VW_KTYP_REQUIRED_NODES WHERE Nodes_I_Def = '" + S1senaryoRaf[i].ToString() + "' AND Nodes_J_Def = '" + S1senaryoRaf[j].ToString() + "'";
                    SqlDataAdapter da4 = new SqlDataAdapter(SelectRNodes, Conn);
                    DataSet ds4 = new DataSet();
                    int result4 = da4.Fill(ds4);
                    int Node_I = Convert.ToInt32(ds4.Tables[0].Rows[0][0]);
                    int Node_J = Convert.ToInt32(ds4.Tables[0].Rows[0][1]);
                    int Distance = Convert.ToInt32(ds4.Tables[0].Rows[0][4]);
                    string ShortestPath = ds4.Tables[0].Rows[0][5].ToString();
                    komut.Parameters.AddWithValue("@Node_I", Node_I);
                    komut.Parameters.AddWithValue("@Node_I_Def", S1senaryoRaf[i].ToString());

                    komut.Parameters.AddWithValue("@Node_J", Node_J);
                    komut.Parameters.AddWithValue("@Node_J_Def", S1senaryoRaf[j].ToString());

                    komut.Parameters.AddWithValue("@Distance", Distance);
                    komut.Parameters.AddWithValue("@Shortest_Path", ShortestPath);
                    komut.ExecuteNonQuery();

                }
            }
            //SENARYO 2 SQL'e Aktar( Eş zamanlı TM dahil)

            string InsertProblemSenaryo1Matrix = "INSERT INTO KTYP.. KTYP_PROBLEM_SENARYO_MATRIX (PROBLEM_ID,SENARYO, Node_I, Node_I_Def,Node_J,Node_J_Def,Distance,Shortest_Path) VALUES (@PROBLEM_ID,@SENARYO, @Node_I, @Node_I_Def,@Node_J,@Node_J_Def,@Distance,@Shortest_Path)";
            for (int i = 0; i < Nodes.Count; i++)
            {
                for (int j = 0; j < Nodes.Count; j++)
                {

                    string SelectProblemSQL = "SELECT Pickup_Node_Def,Delivery_Node_Def,Pickup_Node,Delivery_Node,Distance,Shortest_Path FROM KTYP.. VW_KTYP_PROBLEM WHERE PROBLEM_ID='" + NewProblemID + "' AND Pickup_Node_Def ='" + Nodes[i].ToString() + "' AND Delivery_Node_Def ='" + Nodes[j].ToString() + "'";
                    SqlDataAdapter da5 = new SqlDataAdapter(SelectProblemSQL, Conn);
                    DataSet ds5 = new DataSet();
                    int result5 = da5.Fill(ds5);
                    //Burda eğer Problem datasında veri varsa öncelik ilişkisi kuralına göre uzaklık -1 alır eğer yoksa normal uzaklık değeri alınır.
                    if (result5 == 0)
                    {

                        string NodesInfSQL = "SELECT *FROM KTYP.. VW_KTYP_REQUIRED_NODES WHERE Nodes_I_Def='" + Nodes[i].ToString() + "' AND Nodes_J_Def='" + Nodes[j].ToString() + "'";
                        SqlDataAdapter da4 = new SqlDataAdapter(NodesInfSQL, Conn);
                        DataSet ds4 = new DataSet();
                        int result4 = da4.Fill(ds4);
                        int Node_I = Convert.ToInt32(ds4.Tables[0].Rows[0][0]);
                        int Node_J = Convert.ToInt32(ds4.Tables[0].Rows[0][1]);
                        int Distance = Convert.ToInt32(ds4.Tables[0].Rows[0][4]);
                        string ShortestPath = ds4.Tables[0].Rows[0][5].ToString();

                        komut = new SqlCommand(InsertProblemSenaryo1Matrix, Conn);
                        komut.Parameters.AddWithValue("@PROBLEM_ID", NewProblemID);
                        komut.Parameters.AddWithValue("@SENARYO", "SENARYO.2");

                        komut.Parameters.AddWithValue("@Node_I", Node_I);
                        komut.Parameters.AddWithValue("@Node_I_Def", Nodes[i].ToString());

                        komut.Parameters.AddWithValue("@Node_J", Node_J);
                        komut.Parameters.AddWithValue("@Node_J_Def", Nodes[j].ToString());

                        komut.Parameters.AddWithValue("@Distance", Distance);
                        komut.Parameters.AddWithValue("@Shortest_Path", ShortestPath);
                        komut.ExecuteNonQuery();

                    }
                    else
                    {
                        int Node_I = Convert.ToInt32(ds5.Tables[0].Rows[0][2]);
                        int Node_J = Convert.ToInt32(ds5.Tables[0].Rows[0][3]);
                        int Distance = Convert.ToInt32(ds5.Tables[0].Rows[0][4]);
                        string ShortestPath = ds5.Tables[0].Rows[0][5].ToString();

                        komut = new SqlCommand(InsertProblemSenaryo1Matrix, Conn);
                        komut.Parameters.AddWithValue("@PROBLEM_ID", NewProblemID);
                        komut.Parameters.AddWithValue("@SENARYO", "SENARYO.2");

                        komut.Parameters.AddWithValue("@Node_I", Node_I);
                        komut.Parameters.AddWithValue("@Node_I_Def", Nodes[i].ToString());

                        komut.Parameters.AddWithValue("@Node_J", Node_J);
                        komut.Parameters.AddWithValue("@Node_J_Def", Nodes[j].ToString());

                        komut.Parameters.AddWithValue("@Distance", Distance);
                        komut.Parameters.AddWithValue("@Shortest_Path", ShortestPath);
                        komut.ExecuteNonQuery();

                    }
                }

            }
            for (int j = 0; j < Nodes.Count; j++)
            {
                //SOn Düğüm Dummy DM bütün problem düğümlerine uzaklığı -1 yani en son o düğüme gidilecek
                string NodesInfSQL = "SELECT *FROM KTYP.. VW_KTYP_REQUIRED_NODES WHERE   Nodes_J_Def='" + Nodes[j].ToString() + "'";
                SqlDataAdapter da4 = new SqlDataAdapter(NodesInfSQL, Conn);
                DataSet ds4 = new DataSet();
                int result4 = da4.Fill(ds4);
                int Node_I = 1000;
                int Node_J = Convert.ToInt32(ds4.Tables[0].Rows[0][1]);
                int Distance = -1;
                string ShortestPath = "-1";

                komut = new SqlCommand(InsertProblemSenaryo1Matrix, Conn);
                komut.Parameters.AddWithValue("@PROBLEM_ID", NewProblemID);
                komut.Parameters.AddWithValue("@SENARYO", "SENARYO.2");

                komut.Parameters.AddWithValue("@Node_I", Node_I);
                komut.Parameters.AddWithValue("@Node_I_Def", "DummyDM");

                komut.Parameters.AddWithValue("@Node_J", Node_J);
                komut.Parameters.AddWithValue("@Node_J_Def", Nodes[j].ToString());

                komut.Parameters.AddWithValue("@Distance", Distance);
                komut.Parameters.AddWithValue("@Shortest_Path", ShortestPath);
                komut.ExecuteNonQuery();
                if (Nodes[j].ToString() == "DM")
                {
                    result4 = da4.Fill(ds4);
                    Node_I = 0;
                    Node_J = 1000;
                    Distance = 10000;
                    ShortestPath = "-1";

                    komut = new SqlCommand(InsertProblemSenaryo1Matrix, Conn);
                    komut.Parameters.AddWithValue("@PROBLEM_ID", NewProblemID);
                    komut.Parameters.AddWithValue("@SENARYO", "SENARYO.2");

                    komut.Parameters.AddWithValue("@Node_I", Node_I);
                    komut.Parameters.AddWithValue("@Node_I_Def", "DM");

                    komut.Parameters.AddWithValue("@Node_J", Node_J);
                    komut.Parameters.AddWithValue("@Node_J_Def", "DummyDM");

                    komut.Parameters.AddWithValue("@Distance", Distance);
                    komut.Parameters.AddWithValue("@Shortest_Path", ShortestPath);
                    komut.ExecuteNonQuery();
                }
                else
                {
                    string NodesInfSQLDM = "SELECT *FROM KTYP.. VW_KTYP_REQUIRED_NODES WHERE  Nodes_I_Def='" + Nodes[j].ToString() + "' AND Nodes_J_Def='DM'";
                    SqlDataAdapter da5 = new SqlDataAdapter(NodesInfSQLDM, Conn);
                    DataSet ds5 = new DataSet();
                    int result5 = da5.Fill(ds5);
                    result5 = da5.Fill(ds5);
                    Node_I = Convert.ToInt32(ds5.Tables[0].Rows[0][0]);
                    Node_J = 1000;
                    Distance = Convert.ToInt32(ds5.Tables[0].Rows[0][4]);
                    ShortestPath = (ds5.Tables[0].Rows[0][5]).ToString();

                    komut = new SqlCommand(InsertProblemSenaryo1Matrix, Conn);
                    komut.Parameters.AddWithValue("@PROBLEM_ID", NewProblemID);
                    komut.Parameters.AddWithValue("@SENARYO", "SENARYO.2");

                    komut.Parameters.AddWithValue("@Node_I", Node_I);
                    komut.Parameters.AddWithValue("@Node_I_Def", Nodes[j].ToString());

                    komut.Parameters.AddWithValue("@Node_J", Node_J);
                    komut.Parameters.AddWithValue("@Node_J_Def", "DummyDM");

                    komut.Parameters.AddWithValue("@Distance", Distance);
                    komut.Parameters.AddWithValue("@Shortest_Path", ShortestPath);
                    komut.ExecuteNonQuery();
                }

            }
            //Dummy DM'nin Dummy Dm ye olan uzaklığı 0
            komut = new SqlCommand(InsertProblemSenaryo1Matrix, Conn);
            komut.Parameters.AddWithValue("@PROBLEM_ID", NewProblemID);
            komut.Parameters.AddWithValue("@SENARYO", "SENARYO.2");

            komut.Parameters.AddWithValue("@Node_I", 1000);
            komut.Parameters.AddWithValue("@Node_I_Def", "DummyDM");

            komut.Parameters.AddWithValue("@Node_J", 1000);
            komut.Parameters.AddWithValue("@Node_J_Def", "DummyDM");

            komut.Parameters.AddWithValue("@Distance", 0);
            komut.Parameters.AddWithValue("@Shortest_Path", -1);
            komut.ExecuteNonQuery();
            //Masalardan Raflara öncelik ilişkisi düzenlemesi eğer KTYP_PROBLEM datasında ilgili masada ilgili rafın kitabı varsa uzaklığı -1 olarak güncelle . Tüm düğümlerin DM masasına olan uzaklıkları -1 yap

            for (int i = 0; i < Nodes.Count; i++)
            {
                for (int j = 0; j < Nodes.Count; j++)
                {
                    string SelectProblemSQL = "SELECT Pickup_Node_Def,Delivery_Node_Def,Pickup_Node,Delivery_Node,Distance,Shortest_Path FROM KTYP.. VW_KTYP_PROBLEM WHERE PROBLEM_ID='" + NewProblemID + "' AND Pickup_Node_Def ='" + Nodes[i].ToString() + "' AND Delivery_Node_Def ='" + Nodes[j].ToString() + "'";
                    SqlDataAdapter da5 = new SqlDataAdapter(SelectProblemSQL, Conn);
                    DataSet ds5 = new DataSet();
                    int result5 = da5.Fill(ds5);


                    if (result5 > 0)
                    {
                        string UptadeMatrisSenaryo1 = "UPDATE KTYP.. KTYP_PROBLEM_SENARYO_MATRIX SET Distance=-1,Shortest_Path=-1 WHERE PROBLEM_ID='" + NewProblemID + "' AND SENARYO='SENARYO.2' AND Node_I_Def='" + Nodes[j].ToString() + "' AND Node_J_Def='" + Nodes[i].ToString() + "'";
                        komut = new SqlCommand(UptadeMatrisSenaryo1, Conn);
                        komut.ExecuteNonQuery();
                    }
                    if (Nodes[j].ToString() != "DM" && Nodes[i].ToString() == "DM")
                    {
                        string UptadeMatrisSenaryo1 = "UPDATE KTYP.. KTYP_PROBLEM_SENARYO_MATRIX SET Distance=-1,Shortest_Path=-1 WHERE PROBLEM_ID='" + NewProblemID + "' AND SENARYO='SENARYO.2' AND Node_I_Def='" + Nodes[j].ToString() + "' AND Node_J_Def='DM'";
                        komut = new SqlCommand(UptadeMatrisSenaryo1, Conn);
                        komut.ExecuteNonQuery();
                    }
                }
            }

            //SENARYO 3 önce masalar sonra raflar ÖTSD

            string SelectMatrısS1 = "SELECT *FROM KTYP.. KTYP_PROBLEM_SENARYO_MATRIX  where SENARYO='SENARYO.2' AND PROBLEM_ID ='" + NewProblemID + "'  order by PROBLEM_ID,Node_I,Node_J ";
            SqlDataAdapter da6 = new SqlDataAdapter(SelectMatrısS1, Conn);
            DataSet ds6 = new DataSet();
            int result6 = da6.Fill(ds6);

            //Senaryo 2 den verileri getir ve senaryo 3 olarak ekle
            for (int i = 0; i < result6; i++)
            {

                int Node_I = Convert.ToInt32(ds6.Tables[0].Rows[i][2]);
                string Node_I_Def = ds6.Tables[0].Rows[i][3].ToString();
                int Node_J = Convert.ToInt32(ds6.Tables[0].Rows[i][4]);
                string Node_J_Def = ds6.Tables[0].Rows[i][5].ToString();
                int Distance = Convert.ToInt32(ds6.Tables[0].Rows[i][6]);
                string ShortestPath = ds6.Tables[0].Rows[i][7].ToString();

                komut = new SqlCommand(InsertProblemSenaryo1Matrix, Conn);
                komut.Parameters.AddWithValue("@PROBLEM_ID", NewProblemID);
                komut.Parameters.AddWithValue("@SENARYO", "SENARYO.3");

                komut.Parameters.AddWithValue("@Node_I", Node_I);
                komut.Parameters.AddWithValue("@Node_I_Def", Node_I_Def);

                komut.Parameters.AddWithValue("@Node_J", Node_J);
                komut.Parameters.AddWithValue("@Node_J_Def", Node_J_Def);

                komut.Parameters.AddWithValue("@Distance", Distance);
                komut.Parameters.AddWithValue("@Shortest_Path", ShortestPath);
                komut.ExecuteNonQuery();
            }
            //Senaryo 3 verilerinde tüm rafların tüm masalara olan uzaklığını -1 olarak güncelle.(Önce masalar sonra raflar ) ÖTSD
            string UpdatePreS2 = "UPDATE KTYP.. KTYP_PROBLEM_SENARYO_MATRIX SET Distance=-1, Shortest_Path='-1' WHERE SENARYO='SENARYO.3' AND (Node_I_Def LIKE 'R%' AND Node_J_Def LIKE 'M%' ) AND PROBLEM_ID='" + NewProblemID + "'";
            komut = new SqlCommand(UpdatePreS2, Conn);
            komut.ExecuteNonQuery();
            //Senaryo4 Senaryo2 ile aynı matrisi kullanabilir



            //Senaryo 5 TM dahil eş zamanlı
            for (int i = 0; i < Nodes_TM.Count - 1; i++)
            {
                for (int j = 0; j < Nodes_TM.Count - 1; j++)
                {
                    string SelectTmSQL = "SELECT *FROM KTYP.. VW_KTYP_REQUIRED_NODES WHERE  Nodes_I_Def='" + Nodes_TM[i].ToString() + "' AND Nodes_J_Def='" + Nodes_TM[j].ToString() + "'";
                    SqlDataAdapter da5 = new SqlDataAdapter(SelectTmSQL, Conn);
                    DataSet ds5 = new DataSet();
                    int result5 = da5.Fill(ds5);
                    result5 = da5.Fill(ds5);

                    if (i != 0 && j == 0)
                    {
                        int Node_I = Convert.ToInt32(ds5.Tables[0].Rows[0][0]);
                        int Node_J = Convert.ToInt32(ds5.Tables[0].Rows[0][1]);
                        int Distance = -1;
                        string ShortestPath = "-1";

                        komut = new SqlCommand(InsertProblemSenaryo1Matrix, Conn);
                        komut.Parameters.AddWithValue("@PROBLEM_ID", NewProblemID);
                        komut.Parameters.AddWithValue("@SENARYO", "SENARYO.5");

                        komut.Parameters.AddWithValue("@Node_I", Node_I);
                        komut.Parameters.AddWithValue("@Node_I_Def", Nodes_TM[i].ToString());

                        komut.Parameters.AddWithValue("@Node_J", Node_J);
                        komut.Parameters.AddWithValue("@Node_J_Def", Nodes_TM[j].ToString());

                        komut.Parameters.AddWithValue("@Distance", Distance);
                        komut.Parameters.AddWithValue("@Shortest_Path", ShortestPath);
                        komut.ExecuteNonQuery();
                    }
                    else
                    {
                        int Node_I = Convert.ToInt32(ds5.Tables[0].Rows[0][0]);
                        int Node_J = Convert.ToInt32(ds5.Tables[0].Rows[0][1]);
                        int Distance = Convert.ToInt32(ds5.Tables[0].Rows[0][4]);
                        string ShortestPath = (ds5.Tables[0].Rows[0][5]).ToString();

                        komut = new SqlCommand(InsertProblemSenaryo1Matrix, Conn);
                        komut.Parameters.AddWithValue("@PROBLEM_ID", NewProblemID);
                        komut.Parameters.AddWithValue("@SENARYO", "SENARYO.5");

                        komut.Parameters.AddWithValue("@Node_I", Node_I);
                        komut.Parameters.AddWithValue("@Node_I_Def", Nodes_TM[i].ToString());

                        komut.Parameters.AddWithValue("@Node_J", Node_J);
                        komut.Parameters.AddWithValue("@Node_J_Def", Nodes_TM[j].ToString());

                        komut.Parameters.AddWithValue("@Distance", Distance);
                        komut.Parameters.AddWithValue("@Shortest_Path", ShortestPath);
                        komut.ExecuteNonQuery();

                    }
                }
            }
            //Senaryo5 de DummyDm ekle
            for (int j = 0; j < Nodes_TM.Count - 1; j++)
            {
                //SOn Düğüm Dummy DM bütün problem düğümlerine uzaklığı -1 yani en son o düğüme gidilecek
                string NodesInfSQL = "SELECT *FROM KTYP.. VW_KTYP_REQUIRED_NODES WHERE   Nodes_J_Def='" + Nodes_TM[j].ToString() + "'";
                SqlDataAdapter da4 = new SqlDataAdapter(NodesInfSQL, Conn);
                DataSet ds4 = new DataSet();
                int result4 = da4.Fill(ds4);
                int Node_I = 1000;
                int Node_J = Convert.ToInt32(ds4.Tables[0].Rows[0][1]);
                int Distance = -1;
                string ShortestPath = "-1";

                komut = new SqlCommand(InsertProblemSenaryo1Matrix, Conn);
                komut.Parameters.AddWithValue("@PROBLEM_ID", NewProblemID);
                komut.Parameters.AddWithValue("@SENARYO", "SENARYO.5");

                komut.Parameters.AddWithValue("@Node_I", Node_I);
                komut.Parameters.AddWithValue("@Node_I_Def", "DummyDM");

                komut.Parameters.AddWithValue("@Node_J", Node_J);
                komut.Parameters.AddWithValue("@Node_J_Def", Nodes_TM[j].ToString());

                komut.Parameters.AddWithValue("@Distance", Distance);
                komut.Parameters.AddWithValue("@Shortest_Path", ShortestPath);
                komut.ExecuteNonQuery();
                if (Nodes[j].ToString() == "DM")
                {
                    result4 = da4.Fill(ds4);
                    Node_I = 0;
                    Node_J = 1000;
                    Distance = 10000;
                    ShortestPath = "-1";

                    komut = new SqlCommand(InsertProblemSenaryo1Matrix, Conn);
                    komut.Parameters.AddWithValue("@PROBLEM_ID", NewProblemID);
                    komut.Parameters.AddWithValue("@SENARYO", "SENARYO.5");

                    komut.Parameters.AddWithValue("@Node_I", Node_I);
                    komut.Parameters.AddWithValue("@Node_I_Def", "DM");

                    komut.Parameters.AddWithValue("@Node_J", Node_J);
                    komut.Parameters.AddWithValue("@Node_J_Def", "DummyDM");

                    komut.Parameters.AddWithValue("@Distance", Distance);
                    komut.Parameters.AddWithValue("@Shortest_Path", ShortestPath);
                    komut.ExecuteNonQuery();
                }
                else
                {
                    string NodesInfSQLDM = "SELECT *FROM KTYP.. VW_KTYP_REQUIRED_NODES WHERE  Nodes_I_Def='" + Nodes_TM[j].ToString() + "' AND Nodes_J_Def='DM'";
                    SqlDataAdapter da5 = new SqlDataAdapter(NodesInfSQLDM, Conn);
                    DataSet ds5 = new DataSet();
                    int result5 = da5.Fill(ds5);
                    result5 = da5.Fill(ds5);
                    Node_I = Convert.ToInt32(ds5.Tables[0].Rows[0][0]);
                    Node_J = 1000;
                    Distance = Convert.ToInt32(ds5.Tables[0].Rows[0][4]);
                    ShortestPath = (ds5.Tables[0].Rows[0][5]).ToString();

                    komut = new SqlCommand(InsertProblemSenaryo1Matrix, Conn);
                    komut.Parameters.AddWithValue("@PROBLEM_ID", NewProblemID);
                    komut.Parameters.AddWithValue("@SENARYO", "SENARYO.5");

                    komut.Parameters.AddWithValue("@Node_I", Node_I);
                    komut.Parameters.AddWithValue("@Node_I_Def", Nodes_TM[j].ToString());

                    komut.Parameters.AddWithValue("@Node_J", Node_J);
                    komut.Parameters.AddWithValue("@Node_J_Def", "DummyDM");

                    komut.Parameters.AddWithValue("@Distance", Distance);
                    komut.Parameters.AddWithValue("@Shortest_Path", ShortestPath);
                    komut.ExecuteNonQuery();
                }

            }
            //Dummy DM'nin Dummy Dm ye olan uzaklığı 0
            komut = new SqlCommand(InsertProblemSenaryo1Matrix, Conn);
            komut.Parameters.AddWithValue("@PROBLEM_ID", NewProblemID);
            komut.Parameters.AddWithValue("@SENARYO", "SENARYO.5");

            komut.Parameters.AddWithValue("@Node_I", 1000);
            komut.Parameters.AddWithValue("@Node_I_Def", "DummyDM");

            komut.Parameters.AddWithValue("@Node_J", 1000);
            komut.Parameters.AddWithValue("@Node_J_Def", "DummyDM");

            komut.Parameters.AddWithValue("@Distance", 0);
            komut.Parameters.AddWithValue("@Shortest_Path", -1);
            komut.ExecuteNonQuery();
            //Senaryo 5 M101 de olan kitapların raflarına uzaklığı -1 olarak güncellendi.
            string SelectTMprecendeceSQL = "SELECT PSM.PROBLEM_ID, PSM.SENARYO, PSM.Node_I, PSM.Node_I_Def, PSM.Node_J,PSM.Node_J_Def,PSM.Distance,PSM.Shortest_Path FROM KTYP.. KTYP_PROBLEM_SENARYO_MATRIX as PSM LEFT OUTER JOIN KTYP..[KTYP_PROBLEM] as KP ON (PSM.PROBLEM_ID=KP.PROBLEM_ID AND PSM.Node_I_Def=KP.Delivery_Node_Def) WHERE KP.Delivery_Node_Def=PSM.Node_I_Def AND PSM.Node_J_Def='M101' AND KP.Pickup_Node_Def LIKE 'M%' AND PSM.SENARYO='SENARYO.5'";
            SqlDataAdapter da10 = new SqlDataAdapter(SelectTMprecendeceSQL, Conn);
            DataSet ds10 = new DataSet();
            int result10= da10.Fill(ds10);
            for (int i = 0; i < result10; i++)
            {
                int NODE_I = Convert.ToInt32(ds10.Tables[0].Rows[i][2]);
                int NODE_J = Convert.ToInt32(ds10.Tables[0].Rows[i][4]);
                string UpdateTMprecendeceSQL = "UPDATE KTYP..KTYP_PROBLEM_SENARYO_MATRIX SET Distance=-1,Shortest_Path='-1' WHERE PROBLEM_ID='" + NewProblemID.ToString() + "' AND SENARYO ='SENARYO.5' AND Node_I=" + NODE_I.ToString() + " AND Node_J=" + NODE_J.ToString();
                komut = new SqlCommand(UpdateTMprecendeceSQL, Conn);
                komut.ExecuteNonQuery();
            }
            Conn.Close();
        }
    }
}
