namespace Simple_E_Commerce
{
    partial class FrmUserInterface
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
            this.pbUser = new System.Windows.Forms.PictureBox();
            this.lblNama = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnSejarahPembelian = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.flowLayoutPnl = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pbUser)).BeginInit();
            this.SuspendLayout();
            // 
            // pbUser
            // 
            this.pbUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbUser.Location = new System.Drawing.Point(1443, 30);
            this.pbUser.Name = "pbUser";
            this.pbUser.Size = new System.Drawing.Size(148, 152);
            this.pbUser.TabIndex = 0;
            this.pbUser.TabStop = false;
            // 
            // lblNama
            // 
            this.lblNama.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNama.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNama.Location = new System.Drawing.Point(1612, 30);
            this.lblNama.Name = "lblNama";
            this.lblNama.Size = new System.Drawing.Size(284, 50);
            this.lblNama.TabIndex = 1;
            this.lblNama.Text = "{ Nama }";
            this.lblNama.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogOut.Location = new System.Drawing.Point(1737, 112);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(153, 52);
            this.btnLogOut.TabIndex = 0;
            this.btnLogOut.TabStop = false;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnSejarahPembelian
            // 
            this.btnSejarahPembelian.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSejarahPembelian.Location = new System.Drawing.Point(1143, 88);
            this.btnSejarahPembelian.Name = "btnSejarahPembelian";
            this.btnSejarahPembelian.Size = new System.Drawing.Size(262, 52);
            this.btnSejarahPembelian.TabIndex = 3;
            this.btnSejarahPembelian.Text = "Sejarah Pembelian";
            this.btnSejarahPembelian.UseVisualStyleBackColor = true;
            this.btnSejarahPembelian.Click += new System.EventHandler(this.btnSejarahPembelian_Click);
            // 
            // btnCheckout
            // 
            this.btnCheckout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckout.Location = new System.Drawing.Point(1644, 214);
            this.btnCheckout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(152, 48);
            this.btnCheckout.TabIndex = 33;
            this.btnCheckout.Text = "Checkout";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // flowLayoutPnl
            // 
            this.flowLayoutPnl.Location = new System.Drawing.Point(54, 286);
            this.flowLayoutPnl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flowLayoutPnl.Name = "flowLayoutPnl";
            this.flowLayoutPnl.Size = new System.Drawing.Size(1590, 666);
            this.flowLayoutPnl.TabIndex = 34;
            // 
            // FrmUserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1912, 1022);
            this.Controls.Add(this.flowLayoutPnl);
            this.Controls.Add(this.btnCheckout);
            this.Controls.Add(this.btnSejarahPembelian);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.lblNama);
            this.Controls.Add(this.pbUser);
            this.Name = "FrmUserInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form User Interface";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmUserInterface_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbUser;
        private System.Windows.Forms.Label lblNama;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnSejarahPembelian;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPnl;
    }
}