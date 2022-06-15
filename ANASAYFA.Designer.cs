namespace KTYP
{
    partial class ANASAYFA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ANASAYFA));
            this.KTYP = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Algoritmalar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // KTYP
            // 
            this.KTYP.BackColor = System.Drawing.SystemColors.HotTrack;
            this.KTYP.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.KTYP.Image = ((System.Drawing.Image)(resources.GetObject("KTYP.Image")));
            this.KTYP.Location = new System.Drawing.Point(28, 34);
            this.KTYP.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.KTYP.Name = "KTYP";
            this.KTYP.Size = new System.Drawing.Size(389, 281);
            this.KTYP.TabIndex = 0;
            this.KTYP.Text = "KTYP";
            this.KTYP.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.KTYP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.KTYP.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(143, 466);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(8, 8);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Algoritmalar
            // 
            this.Algoritmalar.BackColor = System.Drawing.Color.DarkCyan;
            this.Algoritmalar.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Algoritmalar.Image = ((System.Drawing.Image)(resources.GetObject("Algoritmalar.Image")));
            this.Algoritmalar.Location = new System.Drawing.Point(28, 319);
            this.Algoritmalar.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.Algoritmalar.Name = "Algoritmalar";
            this.Algoritmalar.Size = new System.Drawing.Size(389, 281);
            this.Algoritmalar.TabIndex = 2;
            this.Algoritmalar.Text = "ALGORİTMA GELİŞTİRME";
            this.Algoritmalar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Algoritmalar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Algoritmalar.UseVisualStyleBackColor = false;
            this.Algoritmalar.Click += new System.EventHandler(this.Algoritmalar_Click);
            // 
            // ANASAYFA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 46F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(448, 615);
            this.Controls.Add(this.Algoritmalar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.KTYP);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter);
            this.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.Name = "ANASAYFA";
            this.Text = "ANASAYFA";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button KTYP;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Algoritmalar;
    }
}