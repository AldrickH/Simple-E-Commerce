namespace Simple_E_Commerce
{
    partial class FrmSejarahPembelian
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSejarahPembelian));
            this.dgvDataOrder = new System.Windows.Forms.DataGridView();
            this.clmNoOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTglOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmKodeBrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNamaBrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHargaBrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmJumlahBrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotalPembelian = new System.Windows.Forms.Label();
            this.lblNominalHarga = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDataOrder
            // 
            this.dgvDataOrder.AllowUserToAddRows = false;
            this.dgvDataOrder.AllowUserToDeleteRows = false;
            this.dgvDataOrder.AllowUserToResizeColumns = false;
            this.dgvDataOrder.AllowUserToResizeRows = false;
            this.dgvDataOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDataOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDataOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmNoOrder,
            this.clmTglOrder,
            this.clmKodeBrg,
            this.clmNamaBrg,
            this.clmHargaBrg,
            this.clmJumlahBrg,
            this.clmTotal});
            this.dgvDataOrder.Location = new System.Drawing.Point(20, 73);
            this.dgvDataOrder.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDataOrder.Name = "dgvDataOrder";
            this.dgvDataOrder.ReadOnly = true;
            this.dgvDataOrder.RowHeadersVisible = false;
            this.dgvDataOrder.RowTemplate.Height = 33;
            this.dgvDataOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataOrder.Size = new System.Drawing.Size(1042, 335);
            this.dgvDataOrder.TabIndex = 1;
            // 
            // clmNoOrder
            // 
            this.clmNoOrder.HeaderText = "No_Order";
            this.clmNoOrder.Name = "clmNoOrder";
            this.clmNoOrder.ReadOnly = true;
            // 
            // clmTglOrder
            // 
            this.clmTglOrder.HeaderText = "Tgl_Order";
            this.clmTglOrder.Name = "clmTglOrder";
            this.clmTglOrder.ReadOnly = true;
            // 
            // clmKodeBrg
            // 
            this.clmKodeBrg.HeaderText = "Kode_Barang";
            this.clmKodeBrg.Name = "clmKodeBrg";
            this.clmKodeBrg.ReadOnly = true;
            // 
            // clmNamaBrg
            // 
            this.clmNamaBrg.HeaderText = "Nama_Barang";
            this.clmNamaBrg.Name = "clmNamaBrg";
            this.clmNamaBrg.ReadOnly = true;
            // 
            // clmHargaBrg
            // 
            this.clmHargaBrg.HeaderText = "Harga";
            this.clmHargaBrg.Name = "clmHargaBrg";
            this.clmHargaBrg.ReadOnly = true;
            // 
            // clmJumlahBrg
            // 
            this.clmJumlahBrg.HeaderText = "Jumlah";
            this.clmJumlahBrg.Name = "clmJumlahBrg";
            this.clmJumlahBrg.ReadOnly = true;
            // 
            // clmTotal
            // 
            this.clmTotal.HeaderText = "Total";
            this.clmTotal.Name = "clmTotal";
            this.clmTotal.ReadOnly = true;
            // 
            // lblTotalPembelian
            // 
            this.lblTotalPembelian.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalPembelian.Location = new System.Drawing.Point(753, 438);
            this.lblTotalPembelian.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalPembelian.Name = "lblTotalPembelian";
            this.lblTotalPembelian.Size = new System.Drawing.Size(119, 24);
            this.lblTotalPembelian.TabIndex = 2;
            this.lblTotalPembelian.Text = "Total Pembelian";
            // 
            // lblNominalHarga
            // 
            this.lblNominalHarga.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNominalHarga.AutoSize = true;
            this.lblNominalHarga.Location = new System.Drawing.Point(899, 438);
            this.lblNominalHarga.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNominalHarga.Name = "lblNominalHarga";
            this.lblNominalHarga.Size = new System.Drawing.Size(120, 17);
            this.lblNominalHarga.TabIndex = 3;
            this.lblNominalHarga.Text = "{ Nominal Harga }";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(20, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(248, 56);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // FrmSejarahPembelian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 485);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblNominalHarga);
            this.Controls.Add(this.lblTotalPembelian);
            this.Controls.Add(this.dgvDataOrder);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmSejarahPembelian";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form Sejarah Pembelian";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmSejarahPembelian_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDataOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNoOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTglOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmKodeBrg;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNamaBrg;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHargaBrg;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmJumlahBrg;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotal;
        private System.Windows.Forms.Label lblTotalPembelian;
        private System.Windows.Forms.Label lblNominalHarga;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}