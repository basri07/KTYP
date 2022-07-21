namespace KTYP
{
    partial class STATIK_ALGORITMALAR
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
            this.components = new System.ComponentModel.Container();
            this.PSO_SOP = new System.Windows.Forms.TabControl();
            this.PSO_SOPPage = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.EKS_Checkbox = new System.Windows.Forms.CheckBox();
            this.PSOIteresyonTextBox = new System.Windows.Forms.TextBox();
            this.iterasyonlabel = new System.Windows.Forms.Label();
            this.PSOParcacikTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SOPData = new System.Windows.Forms.ComboBox();
            this.PSO_SOPCozumButton = new System.Windows.Forms.Button();
            this.Senaryo1 = new System.Windows.Forms.TabPage();
            this.S1Fill_Button = new System.Windows.Forms.Button();
            this.S1load_GVW = new System.Windows.Forms.DataGridView();
            this.S1Solve_Button = new System.Windows.Forms.Button();
            this.SolveMethod_ComboBox = new System.Windows.Forms.ComboBox();
            this.S1_comboBox = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.PSO_SOP.SuspendLayout();
            this.PSO_SOPPage.SuspendLayout();
            this.Senaryo1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.S1load_GVW)).BeginInit();
            this.SuspendLayout();
            // 
            // PSO_SOP
            // 
            this.PSO_SOP.Controls.Add(this.PSO_SOPPage);
            this.PSO_SOP.Controls.Add(this.Senaryo1);
            this.PSO_SOP.Location = new System.Drawing.Point(12, 21);
            this.PSO_SOP.Name = "PSO_SOP";
            this.PSO_SOP.SelectedIndex = 0;
            this.PSO_SOP.Size = new System.Drawing.Size(1514, 890);
            this.PSO_SOP.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.PSO_SOP.TabIndex = 1;
            // 
            // PSO_SOPPage
            // 
            this.PSO_SOPPage.BackColor = System.Drawing.Color.DarkCyan;
            this.PSO_SOPPage.Controls.Add(this.label3);
            this.PSO_SOPPage.Controls.Add(this.EKS_Checkbox);
            this.PSO_SOPPage.Controls.Add(this.PSOIteresyonTextBox);
            this.PSO_SOPPage.Controls.Add(this.iterasyonlabel);
            this.PSO_SOPPage.Controls.Add(this.PSOParcacikTextBox);
            this.PSO_SOPPage.Controls.Add(this.label2);
            this.PSO_SOPPage.Controls.Add(this.SOPData);
            this.PSO_SOPPage.Controls.Add(this.PSO_SOPCozumButton);
            this.PSO_SOPPage.Location = new System.Drawing.Point(4, 24);
            this.PSO_SOPPage.Name = "PSO_SOPPage";
            this.PSO_SOPPage.Padding = new System.Windows.Forms.Padding(3);
            this.PSO_SOPPage.Size = new System.Drawing.Size(1506, 862);
            this.PSO_SOPPage.TabIndex = 0;
            this.PSO_SOPPage.Text = "PSO SOP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(3, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Başlangıç Çözümü";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // EKS_Checkbox
            // 
            this.EKS_Checkbox.AutoSize = true;
            this.EKS_Checkbox.Location = new System.Drawing.Point(3, 133);
            this.EKS_Checkbox.Name = "EKS_Checkbox";
            this.EKS_Checkbox.Size = new System.Drawing.Size(313, 19);
            this.EKS_Checkbox.TabIndex = 9;
            this.EKS_Checkbox.Text = "Atanabilir Liste içinde En Yakın Komşu Sezgiseli Uygula";
            this.EKS_Checkbox.UseVisualStyleBackColor = true;
            // 
            // PSOIteresyonTextBox
            // 
            this.PSOIteresyonTextBox.Location = new System.Drawing.Point(95, 65);
            this.PSOIteresyonTextBox.Name = "PSOIteresyonTextBox";
            this.PSOIteresyonTextBox.Size = new System.Drawing.Size(81, 23);
            this.PSOIteresyonTextBox.TabIndex = 8;
            // 
            // iterasyonlabel
            // 
            this.iterasyonlabel.AutoSize = true;
            this.iterasyonlabel.Location = new System.Drawing.Point(6, 68);
            this.iterasyonlabel.Name = "iterasyonlabel";
            this.iterasyonlabel.Size = new System.Drawing.Size(87, 15);
            this.iterasyonlabel.TabIndex = 7;
            this.iterasyonlabel.Text = "İterasyon Sayısı";
            // 
            // PSOParcacikTextBox
            // 
            this.PSOParcacikTextBox.Location = new System.Drawing.Point(95, 36);
            this.PSOParcacikTextBox.Name = "PSOParcacikTextBox";
            this.PSOParcacikTextBox.Size = new System.Drawing.Size(81, 23);
            this.PSOParcacikTextBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Parçacık Sayısı";
            // 
            // SOPData
            // 
            this.SOPData.FormattingEnabled = true;
            this.SOPData.Location = new System.Drawing.Point(6, 6);
            this.SOPData.Name = "SOPData";
            this.SOPData.Size = new System.Drawing.Size(207, 23);
            this.SOPData.TabIndex = 4;
            this.SOPData.Text = "Veri Seç";
            // 
            // PSO_SOPCozumButton
            // 
            this.PSO_SOPCozumButton.BackColor = System.Drawing.Color.Pink;
            this.PSO_SOPCozumButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PSO_SOPCozumButton.Location = new System.Drawing.Point(6, 191);
            this.PSO_SOPCozumButton.Name = "PSO_SOPCozumButton";
            this.PSO_SOPCozumButton.Size = new System.Drawing.Size(389, 33);
            this.PSO_SOPCozumButton.TabIndex = 3;
            this.PSO_SOPCozumButton.Text = "SOP VERİSİNİ PSO İLE ÇÖZ";
            this.PSO_SOPCozumButton.UseVisualStyleBackColor = false;
            this.PSO_SOPCozumButton.Click += new System.EventHandler(this.PSO_SOPCozumButton_Click);
            // 
            // Senaryo1
            // 
            this.Senaryo1.BackColor = System.Drawing.Color.DarkCyan;
            this.Senaryo1.Controls.Add(this.S1Fill_Button);
            this.Senaryo1.Controls.Add(this.S1load_GVW);
            this.Senaryo1.Controls.Add(this.S1Solve_Button);
            this.Senaryo1.Controls.Add(this.SolveMethod_ComboBox);
            this.Senaryo1.Controls.Add(this.S1_comboBox);
            this.Senaryo1.Location = new System.Drawing.Point(4, 24);
            this.Senaryo1.Name = "Senaryo1";
            this.Senaryo1.Padding = new System.Windows.Forms.Padding(3);
            this.Senaryo1.Size = new System.Drawing.Size(1506, 862);
            this.Senaryo1.TabIndex = 1;
            this.Senaryo1.Text = "KTYP SENARYO 1";
            // 
            // S1Fill_Button
            // 
            this.S1Fill_Button.Location = new System.Drawing.Point(6, 35);
            this.S1Fill_Button.Name = "S1Fill_Button";
            this.S1Fill_Button.Size = new System.Drawing.Size(430, 30);
            this.S1Fill_Button.TabIndex = 4;
            this.S1Fill_Button.Text = "Senaryo Datalarını Getir";
            this.S1Fill_Button.UseVisualStyleBackColor = true;
            this.S1Fill_Button.Click += new System.EventHandler(this.S1Fill_Button_Click);
            // 
            // S1load_GVW
            // 
            this.S1load_GVW.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.S1load_GVW.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.S1load_GVW.BackgroundColor = System.Drawing.Color.DarkGray;
            this.S1load_GVW.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.S1load_GVW.GridColor = System.Drawing.Color.IndianRed;
            this.S1load_GVW.Location = new System.Drawing.Point(483, 3);
            this.S1load_GVW.Name = "S1load_GVW";
            this.S1load_GVW.RowTemplate.Height = 25;
            this.S1load_GVW.Size = new System.Drawing.Size(1023, 859);
            this.S1load_GVW.TabIndex = 6;
            // 
            // S1Solve_Button
            // 
            this.S1Solve_Button.Location = new System.Drawing.Point(6, 791);
            this.S1Solve_Button.Name = "S1Solve_Button";
            this.S1Solve_Button.Size = new System.Drawing.Size(430, 65);
            this.S1Solve_Button.TabIndex = 5;
            this.S1Solve_Button.Text = "SENARYO 1 ÇÖZ";
            this.S1Solve_Button.UseVisualStyleBackColor = true;
            // 
            // SolveMethod_ComboBox
            // 
            this.SolveMethod_ComboBox.FormattingEnabled = true;
            this.SolveMethod_ComboBox.Items.AddRange(new object[] {
            "PSO",
            "RASTSAL",
            "EYKS",
            "MATEMATİKSEL MODEL"});
            this.SolveMethod_ComboBox.Location = new System.Drawing.Point(226, 6);
            this.SolveMethod_ComboBox.Name = "SolveMethod_ComboBox";
            this.SolveMethod_ComboBox.Size = new System.Drawing.Size(207, 23);
            this.SolveMethod_ComboBox.TabIndex = 3;
            this.SolveMethod_ComboBox.Text = "Çözüm Yöntemi";
            // 
            // S1_comboBox
            // 
            this.S1_comboBox.FormattingEnabled = true;
            this.S1_comboBox.Location = new System.Drawing.Point(3, 6);
            this.S1_comboBox.Name = "S1_comboBox";
            this.S1_comboBox.Size = new System.Drawing.Size(207, 23);
            this.S1_comboBox.TabIndex = 2;
            this.S1_comboBox.Text = "Veri Seç";
            // 
            // STATIK_ALGORITMALAR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1527, 915);
            this.Controls.Add(this.PSO_SOP);
            this.Name = "STATIK_ALGORITMALAR";
            this.Text = "STATIK_ALGORITMALAR";
            this.Load += new System.EventHandler(this.STATIK_ALGORITMALAR_Load);
            this.PSO_SOP.ResumeLayout(false);
            this.PSO_SOPPage.ResumeLayout(false);
            this.PSO_SOPPage.PerformLayout();
            this.Senaryo1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.S1load_GVW)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl PSO_SOP;
        private System.Windows.Forms.TabPage PSO_SOPPage;
        private System.Windows.Forms.ComboBox SOPData;
        private System.Windows.Forms.Button PSO_SOPCozumButton;
        private System.Windows.Forms.TabPage Senaryo1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox PSOIteresyonTextBox;
        private System.Windows.Forms.Label iterasyonlabel;
        private System.Windows.Forms.TextBox PSOParcacikTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox EKS_Checkbox;
        private System.Windows.Forms.ComboBox S1_comboBox;
        private System.Windows.Forms.ComboBox SolveMethod_ComboBox;
        private System.Windows.Forms.Button S1Solve_Button;
        private System.Windows.Forms.DataGridView S1load_GVW;
        private System.Windows.Forms.Button S1Fill_Button;
    }
}