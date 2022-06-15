namespace KTYP
{
    partial class VERİEKLE
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VERİEKLE));
            this.SOP_MATRIX = new System.Windows.Forms.TabControl();
            this.SOPPage = new System.Windows.Forms.TabPage();
            this.SOP_EkleButton = new System.Windows.Forms.Button();
            this.SOP_SecButton = new System.Windows.Forms.Button();
            this.AdresLabel = new System.Windows.Forms.Label();
            this.SOP_AdressTextBox = new System.Windows.Forms.TextBox();
            this.KTYPPage = new System.Windows.Forms.TabPage();
            this.TxtToSQLKTYP_Button = new System.Windows.Forms.Button();
            this.KTYP_Dijkstra_Button = new System.Windows.Forms.Button();
            this.KTYP_EkleButton = new System.Windows.Forms.Button();
            this.KitapEkle = new System.Windows.Forms.TabPage();
            this.BookFilter_Button = new System.Windows.Forms.Button();
            this.BookUpdate_Button = new System.Windows.Forms.Button();
            this.BookDelete_Button = new System.Windows.Forms.Button();
            this.BookInsert_Button = new System.Windows.Forms.Button();
            this.BookFill_Button = new System.Windows.Forms.Button();
            this.BookInsertGW = new System.Windows.Forms.DataGridView();
            this.BookshelfID_TextBox = new System.Windows.Forms.TextBox();
            this.BookName_TextBox = new System.Windows.Forms.TextBox();
            this.BookYear_TextBox = new System.Windows.Forms.TextBox();
            this.AuthorName_TextBox = new System.Windows.Forms.TextBox();
            this.BookCode_TextBox = new System.Windows.Forms.TextBox();
            this.BookCode_pictureBox = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BarcodeGenerator = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.TtoSql_QRCode_pictureBox = new System.Windows.Forms.PictureBox();
            this.BookTxtToSql_Button = new System.Windows.Forms.Button();
            this.KTYPExcel_Sec_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BookTxtAddress_TextBox = new System.Windows.Forms.TextBox();
            this.SOP_MATRIX.SuspendLayout();
            this.SOPPage.SuspendLayout();
            this.KTYPPage.SuspendLayout();
            this.KitapEkle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BookInsertGW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BookCode_pictureBox)).BeginInit();
            this.BarcodeGenerator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TtoSql_QRCode_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SOP_MATRIX
            // 
            this.SOP_MATRIX.Controls.Add(this.SOPPage);
            this.SOP_MATRIX.Controls.Add(this.KTYPPage);
            this.SOP_MATRIX.Controls.Add(this.KitapEkle);
            this.SOP_MATRIX.Controls.Add(this.BarcodeGenerator);
            this.SOP_MATRIX.Location = new System.Drawing.Point(-3, 0);
            this.SOP_MATRIX.Name = "SOP_MATRIX";
            this.SOP_MATRIX.SelectedIndex = 0;
            this.SOP_MATRIX.Size = new System.Drawing.Size(2006, 740);
            this.SOP_MATRIX.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.SOP_MATRIX.TabIndex = 0;
            this.SOP_MATRIX.TabStop = false;
            // 
            // SOPPage
            // 
            this.SOPPage.BackColor = System.Drawing.Color.DarkCyan;
            this.SOPPage.Controls.Add(this.SOP_EkleButton);
            this.SOPPage.Controls.Add(this.SOP_SecButton);
            this.SOPPage.Controls.Add(this.AdresLabel);
            this.SOPPage.Controls.Add(this.SOP_AdressTextBox);
            this.SOPPage.Location = new System.Drawing.Point(4, 24);
            this.SOPPage.Name = "SOPPage";
            this.SOPPage.Padding = new System.Windows.Forms.Padding(3);
            this.SOPPage.Size = new System.Drawing.Size(1998, 712);
            this.SOPPage.TabIndex = 0;
            this.SOPPage.Text = "SOP MATRISI";
            // 
            // SOP_EkleButton
            // 
            this.SOP_EkleButton.BackColor = System.Drawing.Color.Pink;
            this.SOP_EkleButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SOP_EkleButton.Location = new System.Drawing.Point(52, 35);
            this.SOP_EkleButton.Name = "SOP_EkleButton";
            this.SOP_EkleButton.Size = new System.Drawing.Size(360, 23);
            this.SOP_EkleButton.TabIndex = 3;
            this.SOP_EkleButton.Text = "VERİTABANINA EKLE";
            this.SOP_EkleButton.UseVisualStyleBackColor = false;
            this.SOP_EkleButton.Click += new System.EventHandler(this.SOP_EkleButton_Click);
            // 
            // SOP_SecButton
            // 
            this.SOP_SecButton.BackColor = System.Drawing.Color.Pink;
            this.SOP_SecButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SOP_SecButton.Location = new System.Drawing.Point(414, 7);
            this.SOP_SecButton.Name = "SOP_SecButton";
            this.SOP_SecButton.Size = new System.Drawing.Size(95, 23);
            this.SOP_SecButton.TabIndex = 2;
            this.SOP_SecButton.Text = "SEÇ";
            this.SOP_SecButton.UseVisualStyleBackColor = false;
            this.SOP_SecButton.Click += new System.EventHandler(this.SOP_SecButton_Click);
            // 
            // AdresLabel
            // 
            this.AdresLabel.AutoSize = true;
            this.AdresLabel.Location = new System.Drawing.Point(4, 9);
            this.AdresLabel.Name = "AdresLabel";
            this.AdresLabel.Size = new System.Drawing.Size(42, 15);
            this.AdresLabel.TabIndex = 1;
            this.AdresLabel.Text = "Adress";
            // 
            // SOP_AdressTextBox
            // 
            this.SOP_AdressTextBox.Location = new System.Drawing.Point(52, 6);
            this.SOP_AdressTextBox.Name = "SOP_AdressTextBox";
            this.SOP_AdressTextBox.Size = new System.Drawing.Size(360, 23);
            this.SOP_AdressTextBox.TabIndex = 0;
            // 
            // KTYPPage
            // 
            this.KTYPPage.BackColor = System.Drawing.Color.DarkCyan;
            this.KTYPPage.Controls.Add(this.TxtToSQLKTYP_Button);
            this.KTYPPage.Controls.Add(this.KTYP_Dijkstra_Button);
            this.KTYPPage.Controls.Add(this.KTYP_EkleButton);
            this.KTYPPage.Location = new System.Drawing.Point(4, 24);
            this.KTYPPage.Name = "KTYPPage";
            this.KTYPPage.Padding = new System.Windows.Forms.Padding(3);
            this.KTYPPage.Size = new System.Drawing.Size(1998, 712);
            this.KTYPPage.TabIndex = 1;
            this.KTYPPage.Text = "KTYP MATRİSİ";
            // 
            // TxtToSQLKTYP_Button
            // 
            this.TxtToSQLKTYP_Button.BackColor = System.Drawing.Color.Pink;
            this.TxtToSQLKTYP_Button.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TxtToSQLKTYP_Button.Location = new System.Drawing.Point(83, 276);
            this.TxtToSQLKTYP_Button.Name = "TxtToSQLKTYP_Button";
            this.TxtToSQLKTYP_Button.Size = new System.Drawing.Size(388, 90);
            this.TxtToSQLKTYP_Button.TabIndex = 9;
            this.TxtToSQLKTYP_Button.Text = "KTYP_FULL_MATRIS TXT TO SQL";
            this.TxtToSQLKTYP_Button.UseVisualStyleBackColor = false;
            this.TxtToSQLKTYP_Button.Click += new System.EventHandler(this.TxtToSQLKTYP_Button_Click);
            // 
            // KTYP_Dijkstra_Button
            // 
            this.KTYP_Dijkstra_Button.BackColor = System.Drawing.Color.Pink;
            this.KTYP_Dijkstra_Button.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.KTYP_Dijkstra_Button.Location = new System.Drawing.Point(83, 158);
            this.KTYP_Dijkstra_Button.Name = "KTYP_Dijkstra_Button";
            this.KTYP_Dijkstra_Button.Size = new System.Drawing.Size(388, 90);
            this.KTYP_Dijkstra_Button.TabIndex = 8;
            this.KTYP_Dijkstra_Button.Text = "KTYP_FULL_MATRIS ADD TO TXT";
            this.KTYP_Dijkstra_Button.UseVisualStyleBackColor = false;
            this.KTYP_Dijkstra_Button.Click += new System.EventHandler(this.KTYP_Dijkstra_Button_Click);
            // 
            // KTYP_EkleButton
            // 
            this.KTYP_EkleButton.BackColor = System.Drawing.Color.Pink;
            this.KTYP_EkleButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.KTYP_EkleButton.Location = new System.Drawing.Point(83, 33);
            this.KTYP_EkleButton.Name = "KTYP_EkleButton";
            this.KTYP_EkleButton.Size = new System.Drawing.Size(388, 90);
            this.KTYP_EkleButton.TabIndex = 7;
            this.KTYP_EkleButton.Text = "CONVERT\r\nKTYP_NOT_FULL_MATRIS TO KTYP_FULL_MATRIS";
            this.KTYP_EkleButton.UseVisualStyleBackColor = false;
            this.KTYP_EkleButton.Click += new System.EventHandler(this.KTYP_EkleButton_Click);
            // 
            // KitapEkle
            // 
            this.KitapEkle.Controls.Add(this.BookFilter_Button);
            this.KitapEkle.Controls.Add(this.BookUpdate_Button);
            this.KitapEkle.Controls.Add(this.BookDelete_Button);
            this.KitapEkle.Controls.Add(this.BookInsert_Button);
            this.KitapEkle.Controls.Add(this.BookFill_Button);
            this.KitapEkle.Controls.Add(this.BookInsertGW);
            this.KitapEkle.Controls.Add(this.BookshelfID_TextBox);
            this.KitapEkle.Controls.Add(this.BookName_TextBox);
            this.KitapEkle.Controls.Add(this.BookYear_TextBox);
            this.KitapEkle.Controls.Add(this.AuthorName_TextBox);
            this.KitapEkle.Controls.Add(this.BookCode_TextBox);
            this.KitapEkle.Controls.Add(this.BookCode_pictureBox);
            this.KitapEkle.Controls.Add(this.label8);
            this.KitapEkle.Controls.Add(this.label7);
            this.KitapEkle.Controls.Add(this.label6);
            this.KitapEkle.Controls.Add(this.label5);
            this.KitapEkle.Controls.Add(this.label4);
            this.KitapEkle.Controls.Add(this.label3);
            this.KitapEkle.Location = new System.Drawing.Point(4, 24);
            this.KitapEkle.Name = "KitapEkle";
            this.KitapEkle.Size = new System.Drawing.Size(1998, 712);
            this.KitapEkle.TabIndex = 2;
            this.KitapEkle.Text = "KİTAP EKLE";
            this.KitapEkle.UseVisualStyleBackColor = true;
            // 
            // BookFilter_Button
            // 
            this.BookFilter_Button.Font = new System.Drawing.Font("Sitka Display", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BookFilter_Button.Location = new System.Drawing.Point(9, 355);
            this.BookFilter_Button.Name = "BookFilter_Button";
            this.BookFilter_Button.Size = new System.Drawing.Size(286, 37);
            this.BookFilter_Button.TabIndex = 20;
            this.BookFilter_Button.Text = "FİLTRELE";
            this.BookFilter_Button.UseVisualStyleBackColor = true;
            this.BookFilter_Button.Click += new System.EventHandler(this.BookFilter_Button_Click);
            // 
            // BookUpdate_Button
            // 
            this.BookUpdate_Button.Font = new System.Drawing.Font("Sitka Display", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BookUpdate_Button.Location = new System.Drawing.Point(9, 445);
            this.BookUpdate_Button.Name = "BookUpdate_Button";
            this.BookUpdate_Button.Size = new System.Drawing.Size(286, 44);
            this.BookUpdate_Button.TabIndex = 18;
            this.BookUpdate_Button.Text = "GÜNCELLE";
            this.BookUpdate_Button.UseVisualStyleBackColor = true;
            this.BookUpdate_Button.Click += new System.EventHandler(this.BookUpdate_Button_Click);
            // 
            // BookDelete_Button
            // 
            this.BookDelete_Button.Font = new System.Drawing.Font("Sitka Display", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BookDelete_Button.Location = new System.Drawing.Point(9, 398);
            this.BookDelete_Button.Name = "BookDelete_Button";
            this.BookDelete_Button.Size = new System.Drawing.Size(286, 41);
            this.BookDelete_Button.TabIndex = 17;
            this.BookDelete_Button.Text = "SİL";
            this.BookDelete_Button.UseVisualStyleBackColor = true;
            this.BookDelete_Button.Click += new System.EventHandler(this.BookDelete_Button_Click);
            // 
            // BookInsert_Button
            // 
            this.BookInsert_Button.Font = new System.Drawing.Font("Sitka Display", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BookInsert_Button.Location = new System.Drawing.Point(9, 310);
            this.BookInsert_Button.Name = "BookInsert_Button";
            this.BookInsert_Button.Size = new System.Drawing.Size(286, 39);
            this.BookInsert_Button.TabIndex = 16;
            this.BookInsert_Button.Text = "EKLE";
            this.BookInsert_Button.UseVisualStyleBackColor = true;
            this.BookInsert_Button.Click += new System.EventHandler(this.BookInsert_Button_Click);
            // 
            // BookFill_Button
            // 
            this.BookFill_Button.Location = new System.Drawing.Point(9, 281);
            this.BookFill_Button.Name = "BookFill_Button";
            this.BookFill_Button.Size = new System.Drawing.Size(286, 23);
            this.BookFill_Button.TabIndex = 15;
            this.BookFill_Button.Text = "Verileri Getir";
            this.BookFill_Button.UseVisualStyleBackColor = true;
            this.BookFill_Button.Click += new System.EventHandler(this.BookFill_Button_Click_1);
            // 
            // BookInsertGW
            // 
            this.BookInsertGW.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.BookInsertGW.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.BookInsertGW.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.BookInsertGW.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.BookInsertGW.DefaultCellStyle = dataGridViewCellStyle1;
            this.BookInsertGW.GridColor = System.Drawing.Color.Coral;
            this.BookInsertGW.Location = new System.Drawing.Point(307, 0);
            this.BookInsertGW.Name = "BookInsertGW";
            this.BookInsertGW.RowTemplate.Height = 25;
            this.BookInsertGW.Size = new System.Drawing.Size(1689, 691);
            this.BookInsertGW.TabIndex = 19;
            this.BookInsertGW.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BookInsertGW_CellClick);
            // 
            // BookshelfID_TextBox
            // 
            this.BookshelfID_TextBox.Location = new System.Drawing.Point(119, 129);
            this.BookshelfID_TextBox.Name = "BookshelfID_TextBox";
            this.BookshelfID_TextBox.Size = new System.Drawing.Size(150, 23);
            this.BookshelfID_TextBox.TabIndex = 14;
            // 
            // BookName_TextBox
            // 
            this.BookName_TextBox.Location = new System.Drawing.Point(119, 69);
            this.BookName_TextBox.Name = "BookName_TextBox";
            this.BookName_TextBox.Size = new System.Drawing.Size(150, 23);
            this.BookName_TextBox.TabIndex = 12;
            // 
            // BookYear_TextBox
            // 
            this.BookYear_TextBox.Location = new System.Drawing.Point(119, 40);
            this.BookYear_TextBox.Name = "BookYear_TextBox";
            this.BookYear_TextBox.Size = new System.Drawing.Size(150, 23);
            this.BookYear_TextBox.TabIndex = 11;
            // 
            // AuthorName_TextBox
            // 
            this.AuthorName_TextBox.Location = new System.Drawing.Point(119, 99);
            this.AuthorName_TextBox.Name = "AuthorName_TextBox";
            this.AuthorName_TextBox.Size = new System.Drawing.Size(150, 23);
            this.AuthorName_TextBox.TabIndex = 13;
            // 
            // BookCode_TextBox
            // 
            this.BookCode_TextBox.Location = new System.Drawing.Point(119, 10);
            this.BookCode_TextBox.Name = "BookCode_TextBox";
            this.BookCode_TextBox.Size = new System.Drawing.Size(150, 23);
            this.BookCode_TextBox.TabIndex = 10;
            // 
            // BookCode_pictureBox
            // 
            this.BookCode_pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.BookCode_pictureBox.Location = new System.Drawing.Point(119, 161);
            this.BookCode_pictureBox.Name = "BookCode_pictureBox";
            this.BookCode_pictureBox.Size = new System.Drawing.Size(116, 100);
            this.BookCode_pictureBox.TabIndex = 9;
            this.BookCode_pictureBox.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(0, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 18);
            this.label8.TabIndex = 4;
            this.label8.Text = "Barcode";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(0, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 18);
            this.label7.TabIndex = 3;
            this.label7.Text = "Yazar Soyadı,Adı";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(0, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 18);
            this.label6.TabIndex = 2;
            this.label6.Text = "Kitap Adı";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(0, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "Raf ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(0, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "Yayın Yılı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(0, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Kitap Kodu";
            // 
            // BarcodeGenerator
            // 
            this.BarcodeGenerator.BackColor = System.Drawing.Color.DarkCyan;
            this.BarcodeGenerator.Controls.Add(this.label2);
            this.BarcodeGenerator.Controls.Add(this.TtoSql_QRCode_pictureBox);
            this.BarcodeGenerator.Controls.Add(this.BookTxtToSql_Button);
            this.BarcodeGenerator.Controls.Add(this.KTYPExcel_Sec_Button);
            this.BarcodeGenerator.Controls.Add(this.label1);
            this.BarcodeGenerator.Controls.Add(this.BookTxtAddress_TextBox);
            this.BarcodeGenerator.Location = new System.Drawing.Point(4, 24);
            this.BarcodeGenerator.Name = "BarcodeGenerator";
            this.BarcodeGenerator.Size = new System.Drawing.Size(1998, 712);
            this.BarcodeGenerator.TabIndex = 3;
            this.BarcodeGenerator.Text = "TXT  Generate Barcode and To SQL ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sitka Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(11, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(788, 253);
            this.label2.TabIndex = 9;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // TtoSql_QRCode_pictureBox
            // 
            this.TtoSql_QRCode_pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TtoSql_QRCode_pictureBox.Location = new System.Drawing.Point(430, 32);
            this.TtoSql_QRCode_pictureBox.Name = "TtoSql_QRCode_pictureBox";
            this.TtoSql_QRCode_pictureBox.Size = new System.Drawing.Size(126, 126);
            this.TtoSql_QRCode_pictureBox.TabIndex = 8;
            this.TtoSql_QRCode_pictureBox.TabStop = false;
            // 
            // BookTxtToSql_Button
            // 
            this.BookTxtToSql_Button.BackColor = System.Drawing.Color.Pink;
            this.BookTxtToSql_Button.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BookTxtToSql_Button.Location = new System.Drawing.Point(64, 32);
            this.BookTxtToSql_Button.Name = "BookTxtToSql_Button";
            this.BookTxtToSql_Button.Size = new System.Drawing.Size(360, 23);
            this.BookTxtToSql_Button.TabIndex = 7;
            this.BookTxtToSql_Button.Text = "VERİTABANINA EKLE";
            this.BookTxtToSql_Button.UseVisualStyleBackColor = false;
            this.BookTxtToSql_Button.Click += new System.EventHandler(this.BookTxtToSql_Button_Click);
            // 
            // KTYPExcel_Sec_Button
            // 
            this.KTYPExcel_Sec_Button.BackColor = System.Drawing.Color.Pink;
            this.KTYPExcel_Sec_Button.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.KTYPExcel_Sec_Button.Location = new System.Drawing.Point(426, 4);
            this.KTYPExcel_Sec_Button.Name = "KTYPExcel_Sec_Button";
            this.KTYPExcel_Sec_Button.Size = new System.Drawing.Size(95, 23);
            this.KTYPExcel_Sec_Button.TabIndex = 6;
            this.KTYPExcel_Sec_Button.Text = "SEÇ";
            this.KTYPExcel_Sec_Button.UseVisualStyleBackColor = false;
            this.KTYPExcel_Sec_Button.Click += new System.EventHandler(this.KTYPExcel_Sec_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Adress";
            // 
            // BookTxtAddress_TextBox
            // 
            this.BookTxtAddress_TextBox.Location = new System.Drawing.Point(64, 3);
            this.BookTxtAddress_TextBox.Name = "BookTxtAddress_TextBox";
            this.BookTxtAddress_TextBox.Size = new System.Drawing.Size(360, 23);
            this.BookTxtAddress_TextBox.TabIndex = 4;
            // 
            // VERİEKLE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(2009, 740);
            this.Controls.Add(this.SOP_MATRIX);
            this.Name = "VERİEKLE";
            this.Text = "VERİEKLE";
            this.SOP_MATRIX.ResumeLayout(false);
            this.SOPPage.ResumeLayout(false);
            this.SOPPage.PerformLayout();
            this.KTYPPage.ResumeLayout(false);
            this.KitapEkle.ResumeLayout(false);
            this.KitapEkle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BookInsertGW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BookCode_pictureBox)).EndInit();
            this.BarcodeGenerator.ResumeLayout(false);
            this.BarcodeGenerator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TtoSql_QRCode_pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl SOP_MATRIX;
        private System.Windows.Forms.TabPage SOPPage;
        private System.Windows.Forms.Button SOP_EkleButton;
        private System.Windows.Forms.Button SOP_SecButton;
        private System.Windows.Forms.Label AdresLabel;
        private System.Windows.Forms.TextBox SOP_AdressTextBox;
        private System.Windows.Forms.TabPage KTYPPage;
        private System.Windows.Forms.Button KTYP_EkleButton;
        private System.Windows.Forms.Button KTYP_Dijkstra_Button;
        private System.Windows.Forms.Button TxtToSQLKTYP_Button;
        private System.Windows.Forms.TabPage KitapEkle;
        private System.Windows.Forms.TabPage BarcodeGenerator;
        private System.Windows.Forms.Button BookTxtToSql_Button;
        private System.Windows.Forms.Button KTYPExcel_Sec_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BookTxtAddress_TextBox;
        private System.Windows.Forms.PictureBox TtoSql_QRCode_pictureBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView BookInsertGW;
        private System.Windows.Forms.TextBox BookshelfID_TextBox;
        private System.Windows.Forms.TextBox BookName_TextBox;
        private System.Windows.Forms.TextBox BookYear_TextBox;
        private System.Windows.Forms.TextBox AuthorName_TextBox;
        private System.Windows.Forms.TextBox BookCode_TextBox;
        private System.Windows.Forms.PictureBox BookCode_pictureBox;
        private System.Windows.Forms.Button BookUpdate_Button;
        private System.Windows.Forms.Button BookDelete_Button;
        private System.Windows.Forms.Button BookInsert_Button;
        private System.Windows.Forms.Button BookFill_Button;
        private System.Windows.Forms.Button BookFilter_Button;
    }
}