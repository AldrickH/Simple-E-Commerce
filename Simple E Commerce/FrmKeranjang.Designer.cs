namespace Simple_E_Commerce
{
    partial class FrmKeranjang
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
            this.dgvDataOrder = new System.Windows.Forms.DataGridView();
            this.clmNoOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTglOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNamaPembeli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmKodeBrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNamaBrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHargaBrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmJumlahBrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTotalBarang = new System.Windows.Forms.Label();
            this.lblTotalBarangIsi = new System.Windows.Forms.Label();
            this.lblTotalHarga = new System.Windows.Forms.Label();
            this.lblTotalHargaIsi = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataOrder)).BeginInit();
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
            this.dgvDataOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmNoOrder,
            this.clmTglOrder,
            this.clmNamaPembeli,
            this.clmKodeBrg,
            this.clmNamaBrg,
            this.clmHargaBrg,
            this.clmJumlahBrg,
            this.clmTotal});
            this.dgvDataOrder.Location = new System.Drawing.Point(60, 49);
            this.dgvDataOrder.Name = "dgvDataOrder";
            this.dgvDataOrder.RowHeadersVisible = false;
            this.dgvDataOrder.RowTemplate.Height = 33;
            this.dgvDataOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataOrder.Size = new System.Drawing.Size(1475, 480);
            this.dgvDataOrder.TabIndex = 1;
            this.dgvDataOrder.Resize += new System.EventHandler(this.dgvDataOrder_Resize);
            // 
            // clmNoOrder
            // 
            this.clmNoOrder.HeaderText = "No Order";
            this.clmNoOrder.Name = "clmNoOrder";
            this.clmNoOrder.ReadOnly = true;
            // 
            // clmTglOrder
            // 
            this.clmTglOrder.HeaderText = "Tgl Order";
            this.clmTglOrder.Name = "clmTglOrder";
            this.clmTglOrder.ReadOnly = true;
            // 
            // clmNamaPembeli
            // 
            this.clmNamaPembeli.HeaderText = "Nama Pembeli";
            this.clmNamaPembeli.Name = "clmNamaPembeli";
            this.clmNamaPembeli.ReadOnly = true;
            // 
            // clmKodeBrg
            // 
            this.clmKodeBrg.HeaderText = "Kode Barang";
            this.clmKodeBrg.Name = "clmKodeBrg";
            this.clmKodeBrg.ReadOnly = true;
            // 
            // clmNamaBrg
            // 
            this.clmNamaBrg.HeaderText = "Nama Barang";
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
            // btnOrder
            // 
            this.btnOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrder.Location = new System.Drawing.Point(1322, 781);
            this.btnOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(213, 69);
            this.btnOrder.TabIndex = 2;
            this.btnOrder.Text = "Order";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(1064, 781);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(213, 69);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTotalBarang
            // 
            this.lblTotalBarang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalBarang.AutoSize = true;
            this.lblTotalBarang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBarang.Location = new System.Drawing.Point(1100, 577);
            this.lblTotalBarang.Name = "lblTotalBarang";
            this.lblTotalBarang.Size = new System.Drawing.Size(202, 37);
            this.lblTotalBarang.TabIndex = 3;
            this.lblTotalBarang.Text = "Total Barang";
            // 
            // lblTotalBarangIsi
            // 
            this.lblTotalBarangIsi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalBarangIsi.AutoSize = true;
            this.lblTotalBarangIsi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBarangIsi.Location = new System.Drawing.Point(1307, 577);
            this.lblTotalBarangIsi.Name = "lblTotalBarangIsi";
            this.lblTotalBarangIsi.Size = new System.Drawing.Size(228, 37);
            this.lblTotalBarangIsi.TabIndex = 4;
            this.lblTotalBarangIsi.Text = "{ total barang }";
            // 
            // lblTotalHarga
            // 
            this.lblTotalHarga.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalHarga.AutoSize = true;
            this.lblTotalHarga.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHarga.Location = new System.Drawing.Point(1109, 657);
            this.lblTotalHarga.Name = "lblTotalHarga";
            this.lblTotalHarga.Size = new System.Drawing.Size(186, 37);
            this.lblTotalHarga.TabIndex = 5;
            this.lblTotalHarga.Text = "Total Harga";
            // 
            // lblTotalHargaIsi
            // 
            this.lblTotalHargaIsi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalHargaIsi.AutoSize = true;
            this.lblTotalHargaIsi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHargaIsi.Location = new System.Drawing.Point(1307, 657);
            this.lblTotalHargaIsi.Name = "lblTotalHargaIsi";
            this.lblTotalHargaIsi.Size = new System.Drawing.Size(215, 37);
            this.lblTotalHargaIsi.TabIndex = 6;
            this.lblTotalHargaIsi.Text = "{ total Harga }";
            // 
            // FrmKeranjang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1594, 897);
            this.Controls.Add(this.lblTotalHargaIsi);
            this.Controls.Add(this.lblTotalHarga);
            this.Controls.Add(this.lblTotalBarangIsi);
            this.Controls.Add(this.lblTotalBarang);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.dgvDataOrder);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmKeranjang";
            this.Text = "FrmKeranjang";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmKeranjang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDataOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNoOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTglOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNamaPembeli;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmKodeBrg;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNamaBrg;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHargaBrg;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmJumlahBrg;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotal;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTotalBarang;
        private System.Windows.Forms.Label lblTotalBarangIsi;
        private System.Windows.Forms.Label lblTotalHarga;
        private System.Windows.Forms.Label lblTotalHargaIsi;
    }
}