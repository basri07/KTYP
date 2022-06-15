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
            this.PSOIteresyonTextBox = new System.Windows.Forms.TextBox();
            this.iterasyonlabel = new System.Windows.Forms.Label();
            this.PSOParcacikTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SOPData = new System.Windows.Forms.ComboBox();
            this.PSO_SOPCozumButton = new System.Windows.Forms.Button();
            this.GA_SOPPage = new System.Windows.Forms.TabPage();
            this.KTYP_EkleButton = new System.Windows.Forms.Button();
            this.KTYP_SecButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.KTYP_AdressTextBox = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.EKS_Checkbox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PSO_SOP.SuspendLayout();
            this.PSO_SOPPage.SuspendLayout();
            this.GA_SOPPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // PSO_SOP
            // 
            this.PSO_SOP.Controls.Add(this.PSO_SOPPage);
            this.PSO_SOP.Controls.Add(this.GA_SOPPage);
            this.PSO_SOP.Location = new System.Drawing.Point(12, 21);
            this.PSO_SOP.Name = "PSO_SOP";
            this.PSO_SOP.SelectedIndex = 0;
            this.PSO_SOP.Size = new System.Drawing.Size(569, 356);
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
            this.PSO_SOPPage.Size = new System.Drawing.Size(561, 328);
            this.PSO_SOPPage.TabIndex = 0;
            this.PSO_SOPPage.Text = "PSO SOP";
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
            this.PSO_SOPCozumButton.Location = new System.Drawing.Point(157, 277);
            this.PSO_SOPCozumButton.Name = "PSO_SOPCozumButton";
            this.PSO_SOPCozumButton.Size = new System.Drawing.Size(389, 33);
            this.PSO_SOPCozumButton.TabIndex = 3;
            this.PSO_SOPCozumButton.Text = "SOP VERİSİNİ PSO İLE ÇÖZ";
            this.PSO_SOPCozumButton.UseVisualStyleBackColor = false;
            this.PSO_SOPCozumButton.Click += new System.EventHandler(this.PSO_SOPCozumButton_Click);
            // 
            // GA_SOPPage
            // 
            this.GA_SOPPage.BackColor = System.Drawing.Color.DarkCyan;
            this.GA_SOPPage.Controls.Add(this.KTYP_EkleButton);
            this.GA_SOPPage.Controls.Add(this.KTYP_SecButton);
            this.GA_SOPPage.Controls.Add(this.label1);
            this.GA_SOPPage.Controls.Add(this.KTYP_AdressTextBox);
            this.GA_SOPPage.Location = new System.Drawing.Point(4, 24);
            this.GA_SOPPage.Name = "GA_SOPPage";
            this.GA_SOPPage.Padding = new System.Windows.Forms.Padding(3);
            this.GA_SOPPage.Size = new System.Drawing.Size(561, 328);
            this.GA_SOPPage.TabIndex = 1;
            this.GA_SOPPage.Text = "GA SOP";
            // 
            // KTYP_EkleButton
            // 
            this.KTYP_EkleButton.BackColor = System.Drawing.Color.Pink;
            this.KTYP_EkleButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.KTYP_EkleButton.Location = new System.Drawing.Point(53, 48);
            this.KTYP_EkleButton.Name = "KTYP_EkleButton";
            this.KTYP_EkleButton.Size = new System.Drawing.Size(360, 23);
            this.KTYP_EkleButton.TabIndex = 7;
            this.KTYP_EkleButton.Text = "VERİTABANINA EKLE";
            this.KTYP_EkleButton.UseVisualStyleBackColor = false;
            // 
            // KTYP_SecButton
            // 
            this.KTYP_SecButton.BackColor = System.Drawing.Color.Pink;
            this.KTYP_SecButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.KTYP_SecButton.Location = new System.Drawing.Point(415, 20);
            this.KTYP_SecButton.Name = "KTYP_SecButton";
            this.KTYP_SecButton.Size = new System.Drawing.Size(95, 23);
            this.KTYP_SecButton.TabIndex = 6;
            this.KTYP_SecButton.Text = "SEÇ";
            this.KTYP_SecButton.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Adress";
            // 
            // KTYP_AdressTextBox
            // 
            this.KTYP_AdressTextBox.Location = new System.Drawing.Point(53, 19);
            this.KTYP_AdressTextBox.Name = "KTYP_AdressTextBox";
            this.KTYP_AdressTextBox.Size = new System.Drawing.Size(360, 23);
            this.KTYP_AdressTextBox.TabIndex = 4;
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
            // STATIK_ALGORITMALAR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PSO_SOP);
            this.Name = "STATIK_ALGORITMALAR";
            this.Text = "STATIK_ALGORITMALAR";
            this.Load += new System.EventHandler(this.STATIK_ALGORITMALAR_Load);
            this.PSO_SOP.ResumeLayout(false);
            this.PSO_SOPPage.ResumeLayout(false);
            this.PSO_SOPPage.PerformLayout();
            this.GA_SOPPage.ResumeLayout(false);
            this.GA_SOPPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl PSO_SOP;
        private System.Windows.Forms.TabPage PSO_SOPPage;
        private System.Windows.Forms.ComboBox SOPData;
        private System.Windows.Forms.Button PSO_SOPCozumButton;
        private System.Windows.Forms.TabPage GA_SOPPage;
        private System.Windows.Forms.Button KTYP_EkleButton;
        private System.Windows.Forms.Button KTYP_SecButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox KTYP_AdressTextBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox PSOIteresyonTextBox;
        private System.Windows.Forms.Label iterasyonlabel;
        private System.Windows.Forms.TextBox PSOParcacikTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox EKS_Checkbox;
    }
}