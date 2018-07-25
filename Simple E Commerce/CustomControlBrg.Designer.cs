namespace Simple_E_Commerce
{
    partial class CustomCntrlBrg
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pBox = new System.Windows.Forms.PictureBox();
            this.lblNama = new System.Windows.Forms.Label();
            this.lblHarga = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtBoxJumlah = new System.Windows.Forms.TextBox();
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnKurang = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pBox
            // 
            this.pBox.Location = new System.Drawing.Point(54, 22);
            this.pBox.Name = "pBox";
            this.pBox.Size = new System.Drawing.Size(150, 150);
            this.pBox.TabIndex = 0;
            this.pBox.TabStop = false;
            // 
            // lblNama
            // 
            this.lblNama.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNama.Location = new System.Drawing.Point(16, 175);
            this.lblNama.Name = "lblNama";
            this.lblNama.Size = new System.Drawing.Size(222, 41);
            this.lblNama.TabIndex = 1;
            this.lblNama.Text = "{ nama }";
            this.lblNama.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHarga
            // 
            this.lblHarga.Location = new System.Drawing.Point(19, 219);
            this.lblHarga.Name = "lblHarga";
            this.lblHarga.Size = new System.Drawing.Size(219, 33);
            this.lblHarga.TabIndex = 1;
            this.lblHarga.Text = "{ harga }";
            this.lblHarga.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblQty
            // 
            this.lblQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.ForeColor = System.Drawing.Color.Red;
            this.lblQty.Location = new System.Drawing.Point(143, 269);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(61, 17);
            this.lblQty.TabIndex = 2;
            this.lblQty.Text = "{ Qty }";
            // 
            // txtBoxJumlah
            // 
            this.txtBoxJumlah.Location = new System.Drawing.Point(90, 309);
            this.txtBoxJumlah.Multiline = true;
            this.txtBoxJumlah.Name = "txtBoxJumlah";
            this.txtBoxJumlah.Size = new System.Drawing.Size(85, 25);
            this.txtBoxJumlah.TabIndex = 3;
            this.txtBoxJumlah.Text = "0";
            this.txtBoxJumlah.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnTambah
            // 
            this.btnTambah.Location = new System.Drawing.Point(181, 309);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(35, 25);
            this.btnTambah.TabIndex = 4;
            this.btnTambah.Text = "+";
            this.btnTambah.UseVisualStyleBackColor = true;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // btnKurang
            // 
            this.btnKurang.Location = new System.Drawing.Point(49, 309);
            this.btnKurang.Name = "btnKurang";
            this.btnKurang.Size = new System.Drawing.Size(35, 25);
            this.btnKurang.TabIndex = 4;
            this.btnKurang.Text = "-";
            this.btnKurang.UseVisualStyleBackColor = true;
            this.btnKurang.Click += new System.EventHandler(this.btnKurang_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(74, 269);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tersisa :";
            // 
            // CustomCntrlBrg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnKurang);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.txtBoxJumlah);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblHarga);
            this.Controls.Add(this.lblNama);
            this.Controls.Add(this.pBox);
            this.Name = "CustomCntrlBrg";
            this.Size = new System.Drawing.Size(251, 359);
            this.Load += new System.EventHandler(this.CustomCntrlBrg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pBox;
        private System.Windows.Forms.Label lblNama;
        private System.Windows.Forms.Label lblHarga;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.TextBox txtBoxJumlah;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Button btnKurang;
        private System.Windows.Forms.Label label1;
    }
}
