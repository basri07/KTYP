namespace KTYP
{
    partial class DEVELOPER
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
            this.StatikButton = new System.Windows.Forms.Button();
            this.DinamikButton = new System.Windows.Forms.Button();
            this.VeriEkleButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StatikButton
            // 
            this.StatikButton.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StatikButton.Location = new System.Drawing.Point(12, 12);
            this.StatikButton.Name = "StatikButton";
            this.StatikButton.Size = new System.Drawing.Size(205, 122);
            this.StatikButton.TabIndex = 0;
            this.StatikButton.Text = "STATİK";
            this.StatikButton.UseVisualStyleBackColor = true;
            this.StatikButton.Click += new System.EventHandler(this.StatikButton_Click);
            // 
            // DinamikButton
            // 
            this.DinamikButton.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DinamikButton.Location = new System.Drawing.Point(232, 12);
            this.DinamikButton.Name = "DinamikButton";
            this.DinamikButton.Size = new System.Drawing.Size(205, 122);
            this.DinamikButton.TabIndex = 1;
            this.DinamikButton.Text = "DİNAMİK";
            this.DinamikButton.UseVisualStyleBackColor = true;
            // 
            // VeriEkleButton
            // 
            this.VeriEkleButton.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.VeriEkleButton.Location = new System.Drawing.Point(12, 158);
            this.VeriEkleButton.Name = "VeriEkleButton";
            this.VeriEkleButton.Size = new System.Drawing.Size(205, 122);
            this.VeriEkleButton.TabIndex = 3;
            this.VeriEkleButton.Text = "VERİ EKLE";
            this.VeriEkleButton.UseVisualStyleBackColor = true;
            this.VeriEkleButton.Click += new System.EventHandler(this.VeriEkleButton_Click);
            // 
            // DEVELOPER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.Controls.Add(this.VeriEkleButton);
            this.Controls.Add(this.DinamikButton);
            this.Controls.Add(this.StatikButton);
            this.Name = "DEVELOPER";
            this.Text = "DEVELOPER";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StatikButton;
        private System.Windows.Forms.Button DinamikButton;
        private System.Windows.Forms.Button VeriEkleButton;
    }
}