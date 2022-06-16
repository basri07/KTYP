using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace KTYP
{

    public partial class VERİEKLE : Form
    {

        txtVeriEkleme txtVeriEkleme;
        SqlConnection Conn = ConnectionSQL.SqlConnection();





        public VERİEKLE()
        {
            InitializeComponent();
            txtVeriEkleme = new txtVeriEkleme();
        }

        private void SOP_SecButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();

            file.FilterIndex = 2;
            file.RestoreDirectory = true;
            file.CheckFileExists = false;
            file.Title = "Txt Dosyası Seçiniz..";
            file.ShowDialog();
            SOP_AdressTextBox.Text = file.FileName;
            txtVeriEkleme.AdresTxt = file.FileName;
        }

        private void SOP_EkleButton_Click(object sender, EventArgs e)
        {
            txtVeriEkleme.SOPTxtToSQL();
        }

        private void KTYP_EkleButton_Click(object sender, EventArgs e)
        {
            txtVeriEkleme.KTYPtoFullMatrix();
        }

        private void KTYP_Dijkstra_Button_Click(object sender, EventArgs e)
        {

            string sorgu = "SELECT Nodes_I,Nodes_J,Distance FROM KTYP.. KTYP_FULL_MATRIX ORDER BY Nodes_I,Nodes_J";
            Conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sorgu, Conn);
            DataSet ds = new DataSet();
            int result = da.Fill(ds);
            //Bir TXT dosyasına 192 satırın bilgilerini yazıyor. O yüzden ilk 100 düğümün bilgilerini DistanceMatrix0_100.txt dosyasına, diğer kalan 94 düğümü DistanceMatrix100_194.txt dosyasına yazdırıyorum
            string DistanceMatrix = "";
            StreamWriter Yaz = new StreamWriter("C:\\Users\\hbasr\\OneDrive\\Masaüstü\\YLKODLAMA\\KTYP-1\\Data\\DistanceMatrix0_100.txt");
            int k = 0;
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 195; j++)
                {
                    if (j == 0)
                    {
                        DistanceMatrix = "{";
                        DistanceMatrix += " " + Convert.ToString(ds.Tables[0].Rows[k][2]) + ",";
                        k++;
                    }
                    if (j < 194 && j != 0)
                    {
                        DistanceMatrix += "  " + Convert.ToString(ds.Tables[0].Rows[k][2]) + ",";
                        k++;
                    }
                    if (j == 194)
                    {
                        DistanceMatrix += " " + Convert.ToString(ds.Tables[0].Rows[k][2]) + " },";
                        Yaz.WriteLine(DistanceMatrix);
                        k++;
                    }

                }
            }
            Yaz.Close();
            StreamWriter Yaz1 = new StreamWriter("C:\\Users\\hbasr\\OneDrive\\Masaüstü\\YLKODLAMA\\KTYP-1\\Data\\DistanceMatrix100_194.txt");
            for (int i = 0; i < 95; i++)
            {
                for (int j = 0; j < 195; j++)
                {
                    if (j == 0)
                    {
                        DistanceMatrix = "{";
                        DistanceMatrix += " " + Convert.ToString(ds.Tables[0].Rows[k][2]) + ",";
                        k++;
                    }
                    if (j < 194 && j != 0)
                    {
                        DistanceMatrix += "  " + Convert.ToString(ds.Tables[0].Rows[k][2]) + ",";
                        k++;
                    }
                    if (j == 194)
                    {
                        DistanceMatrix += " " + Convert.ToString(ds.Tables[0].Rows[k][2]) + " },";
                        Yaz1.WriteLine(DistanceMatrix);
                        k++;
                    }

                }
            }
            Yaz1.Close();
            MessageBox.Show(result.ToString());
            Conn.Close();
        }

        private void TxtToSQLKTYP_Button_Click(object sender, EventArgs e)
        {
            DijkstraWithoutQueue.DijkstraSolve();
            MessageBox.Show("İŞLEM BİTTİ");
        }

        private void KTYPExcel_Sec_Button_Click(object sender, EventArgs e)
        {

            OpenFileDialog file = new OpenFileDialog();

            file.FilterIndex = 2;
            file.RestoreDirectory = true;
            file.CheckFileExists = false;
            file.Title = "Txt Dosyası Seçiniz..";
            file.ShowDialog();
            BookTxtAddress_TextBox.Text = file.FileName;
            txtVeriEkleme.AdresTxt = file.FileName;
        }


        private void BookTxtToSql_Button_Click(object sender, EventArgs e)
        {
            txtVeriEkleme.BookTxtToSQL(BookTxtAddress_TextBox.Text, TtoSql_QRCode_pictureBox.Image);
        }


        private void BookFill_Button_Click_1(object sender, EventArgs e)
        {
            txtVeriEkleme.BookFillToDataGridView(BookInsertGW);
        }

        private void BookInsert_Button_Click(object sender, EventArgs e)
        {
            txtVeriEkleme.BookInsertToSQL(BookCode_TextBox.Text, BookYear_TextBox.Text, BookName_TextBox.Text, AuthorName_TextBox.Text, BookshelfID_TextBox.Text, BookCode_pictureBox.Image);
            BookCode_TextBox.Clear();
            BookYear_TextBox.Clear();
            BookName_TextBox.Clear();
            AuthorName_TextBox.Clear();
            BookshelfID_TextBox.Clear();
            BookCode_TextBox.Focus();
            txtVeriEkleme.BookFillToDataGridView(BookInsertGW);
        }

        private void BookFilter_Button_Click(object sender, EventArgs e)
        {
            txtVeriEkleme.BookFilterSQLtoDataGridView(BookCode_TextBox.Text, BookYear_TextBox.Text, BookName_TextBox.Text, AuthorName_TextBox.Text, BookshelfID_TextBox.Text, BookInsertGW);
            BookCode_TextBox.Clear();
            BookYear_TextBox.Clear();
            BookName_TextBox.Clear();
            AuthorName_TextBox.Clear();
            BookshelfID_TextBox.Clear();
            BookCode_TextBox.Focus();
        }

        private void BookDelete_Button_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow drow in BookInsertGW.SelectedRows)  //Seçili Satırları Silme
            {
#pragma warning disable CS8600 // Null sabit değeri veya olası null değeri, boş değer atanamaz türe dönüştürülüyor.
                int BookID = Convert.ToInt32(drow.Cells[0].Value);

                txtVeriEkleme.BookDeleteFromSqlWhereSelectedGW(BookID);

            }
            txtVeriEkleme.BookFillToDataGridView(BookInsertGW);
        }
        private void BookInsertGW_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int SelectedArea = BookInsertGW.SelectedCells[0].RowIndex;
            string BookCode = BookInsertGW.Rows[SelectedArea].Cells[1].Value.ToString();
            string BookYear = BookInsertGW.Rows[SelectedArea].Cells[2].Value.ToString();
            string BookName = BookInsertGW.Rows[SelectedArea].Cells[3].Value.ToString();
            string AuthorName = BookInsertGW.Rows[SelectedArea].Cells[4].Value.ToString();
            string BookshelfID = BookInsertGW.Rows[SelectedArea].Cells[5].Value.ToString();
            var Barcode = (Byte[])(BookInsertGW.Rows[SelectedArea].Cells[6].Value);
            var stream = new MemoryStream(Barcode);

            BookCode_TextBox.Text = BookCode;
            BookYear_TextBox.Text = BookYear;
            BookName_TextBox.Text = BookName;
            AuthorName_TextBox.Text = AuthorName;
            BookshelfID_TextBox.Text = BookshelfID;
            BookCode_pictureBox.Image = Image.FromStream(stream);
        }
        private void BookUpdate_Button_Click(object sender, EventArgs e)
        {
            int SelectedArea = BookInsertGW.SelectedCells[0].RowIndex;
            int Book_ID = (int)BookInsertGW.Rows[SelectedArea].Cells[0].Value;
            txtVeriEkleme.BookUpdateSQL
                (Book_ID, BookCode_TextBox.Text,
                BookYear_TextBox.Text,
                BookName_TextBox.Text,
                AuthorName_TextBox.Text,
                BookshelfID_TextBox.Text, BookCode_pictureBox.Image);
            txtVeriEkleme.BookFilterSQLtoDataGridView(BookCode_TextBox.Text, BookYear_TextBox.Text, BookName_TextBox.Text, AuthorName_TextBox.Text, BookshelfID_TextBox.Text, BookInsertGW);
        }
    }
}
