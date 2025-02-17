namespace QLNhanSu
{
    partial class frmThemphucap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemphucap));
            this.btDong = new DevExpress.XtraEditors.DropDownButton();
            this.btThem = new DevExpress.XtraEditors.DropDownButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.image_no_hesoluong = new System.Windows.Forms.PictureBox();
            this.image_yes_hesoluong = new System.Windows.Forms.PictureBox();
            this.image_no_tenloai = new System.Windows.Forms.PictureBox();
            this.image_yes_tenloai = new System.Windows.Forms.PictureBox();
            this.image_no_maloai = new System.Windows.Forms.PictureBox();
            this.image_yes_maloai = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenloaipc = new DevExpress.XtraEditors.TextEdit();
            this.txtMaloaipc = new DevExpress.XtraEditors.TextEdit();
            this.txtTien = new DevExpress.XtraEditors.TextEdit();
            this.lb2 = new System.Windows.Forms.Label();
            this.lb1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_no_hesoluong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image_yes_hesoluong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image_no_tenloai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image_yes_tenloai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image_no_maloai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image_yes_maloai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenloaipc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaloaipc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTien.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btDong
            // 
            this.btDong.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.btDong.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDong.Appearance.Options.UseBackColor = true;
            this.btDong.Appearance.Options.UseFont = true;
            this.btDong.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btDong.ImageOptions.Image")));
            this.btDong.Location = new System.Drawing.Point(175, 218);
            this.btDong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btDong.Name = "btDong";
            this.btDong.Size = new System.Drawing.Size(131, 28);
            this.btDong.TabIndex = 10;
            this.btDong.Text = "Đóng";
            this.btDong.Click += new System.EventHandler(this.btDong_Click);
            // 
            // btThem
            // 
            this.btThem.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.btThem.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThem.Appearance.Options.UseBackColor = true;
            this.btThem.Appearance.Options.UseFont = true;
            this.btThem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btThem.ImageOptions.Image")));
            this.btThem.Location = new System.Drawing.Point(26, 218);
            this.btThem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(131, 28);
            this.btThem.TabIndex = 9;
            this.btThem.Text = "Thêm";
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.image_no_hesoluong);
            this.groupBox1.Controls.Add(this.image_yes_hesoluong);
            this.groupBox1.Controls.Add(this.image_no_tenloai);
            this.groupBox1.Controls.Add(this.image_yes_tenloai);
            this.groupBox1.Controls.Add(this.image_no_maloai);
            this.groupBox1.Controls.Add(this.image_yes_maloai);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTenloaipc);
            this.groupBox1.Controls.Add(this.txtMaloaipc);
            this.groupBox1.Controls.Add(this.txtTien);
            this.groupBox1.Controls.Add(this.lb2);
            this.groupBox1.Controls.Add(this.lb1);
            this.groupBox1.Location = new System.Drawing.Point(26, 42);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(280, 167);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // image_no_hesoluong
            // 
            this.image_no_hesoluong.Image = ((System.Drawing.Image)(resources.GetObject("image_no_hesoluong.Image")));
            this.image_no_hesoluong.Location = new System.Drawing.Point(251, 118);
            this.image_no_hesoluong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.image_no_hesoluong.Name = "image_no_hesoluong";
            this.image_no_hesoluong.Size = new System.Drawing.Size(22, 22);
            this.image_no_hesoluong.TabIndex = 130;
            this.image_no_hesoluong.TabStop = false;
            // 
            // image_yes_hesoluong
            // 
            this.image_yes_hesoluong.Image = ((System.Drawing.Image)(resources.GetObject("image_yes_hesoluong.Image")));
            this.image_yes_hesoluong.Location = new System.Drawing.Point(251, 118);
            this.image_yes_hesoluong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.image_yes_hesoluong.Name = "image_yes_hesoluong";
            this.image_yes_hesoluong.Size = new System.Drawing.Size(22, 22);
            this.image_yes_hesoluong.TabIndex = 129;
            this.image_yes_hesoluong.TabStop = false;
            // 
            // image_no_tenloai
            // 
            this.image_no_tenloai.Image = ((System.Drawing.Image)(resources.GetObject("image_no_tenloai.Image")));
            this.image_no_tenloai.Location = new System.Drawing.Point(251, 73);
            this.image_no_tenloai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.image_no_tenloai.Name = "image_no_tenloai";
            this.image_no_tenloai.Size = new System.Drawing.Size(22, 22);
            this.image_no_tenloai.TabIndex = 128;
            this.image_no_tenloai.TabStop = false;
            // 
            // image_yes_tenloai
            // 
            this.image_yes_tenloai.Image = ((System.Drawing.Image)(resources.GetObject("image_yes_tenloai.Image")));
            this.image_yes_tenloai.Location = new System.Drawing.Point(251, 73);
            this.image_yes_tenloai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.image_yes_tenloai.Name = "image_yes_tenloai";
            this.image_yes_tenloai.Size = new System.Drawing.Size(22, 22);
            this.image_yes_tenloai.TabIndex = 127;
            this.image_yes_tenloai.TabStop = false;
            // 
            // image_no_maloai
            // 
            this.image_no_maloai.Image = ((System.Drawing.Image)(resources.GetObject("image_no_maloai.Image")));
            this.image_no_maloai.Location = new System.Drawing.Point(251, 26);
            this.image_no_maloai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.image_no_maloai.Name = "image_no_maloai";
            this.image_no_maloai.Size = new System.Drawing.Size(22, 22);
            this.image_no_maloai.TabIndex = 126;
            this.image_no_maloai.TabStop = false;
            // 
            // image_yes_maloai
            // 
            this.image_yes_maloai.Image = ((System.Drawing.Image)(resources.GetObject("image_yes_maloai.Image")));
            this.image_yes_maloai.Location = new System.Drawing.Point(251, 27);
            this.image_yes_maloai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.image_yes_maloai.Name = "image_yes_maloai";
            this.image_yes_maloai.Size = new System.Drawing.Size(22, 22);
            this.image_yes_maloai.TabIndex = 125;
            this.image_yes_maloai.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã loại phụ cấp:";
            // 
            // txtTenloaipc
            // 
            this.txtTenloaipc.Location = new System.Drawing.Point(129, 71);
            this.txtTenloaipc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenloaipc.Name = "txtTenloaipc";
            this.txtTenloaipc.Size = new System.Drawing.Size(117, 22);
            this.txtTenloaipc.TabIndex = 2;
            this.txtTenloaipc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTenloaipc_KeyUp);
            // 
            // txtMaloaipc
            // 
            this.txtMaloaipc.Location = new System.Drawing.Point(129, 26);
            this.txtMaloaipc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaloaipc.Name = "txtMaloaipc";
            this.txtMaloaipc.Size = new System.Drawing.Size(117, 22);
            this.txtMaloaipc.TabIndex = 1;
            this.txtMaloaipc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMaloaipc_KeyUp);
            // 
            // txtTien
            // 
            this.txtTien.Location = new System.Drawing.Point(129, 117);
            this.txtTien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTien.Name = "txtTien";
            this.txtTien.Size = new System.Drawing.Size(117, 22);
            this.txtTien.TabIndex = 3;
            this.txtTien.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTien_KeyPress);
            this.txtTien.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTien_KeyUp);
            // 
            // lb2
            // 
            this.lb2.AutoSize = true;
            this.lb2.Location = new System.Drawing.Point(43, 121);
            this.lb2.Name = "lb2";
            this.lb2.Size = new System.Drawing.Size(92, 17);
            this.lb2.TabIndex = 2;
            this.lb2.Text = "Tiền phụ cấp:";
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.Location = new System.Drawing.Point(45, 75);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(90, 17);
            this.lb1.TabIndex = 3;
            this.lb1.Text = "Tên phụ cấp:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Constantia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.label4.Location = new System.Drawing.Point(65, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 33);
            this.label4.TabIndex = 8;
            this.label4.Text = "THÊM PHỤ CẤP";
            // 
            // frmThemphucap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 267);
            this.Controls.Add(this.btDong);
            this.Controls.Add(this.btThem);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmThemphucap.IconOptions.Icon")));
            this.IconOptions.Image = global::QLNhanSu.Properties.Resources.Logo_AOF;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmThemphucap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm phụ cấp";
            this.Load += new System.EventHandler(this.frmThemphucap_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_no_hesoluong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image_yes_hesoluong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image_no_tenloai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image_yes_tenloai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image_no_maloai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image_yes_maloai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenloaipc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaloaipc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTien.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DropDownButton btDong;
        private DevExpress.XtraEditors.DropDownButton btThem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox image_no_hesoluong;
        private System.Windows.Forms.PictureBox image_yes_hesoluong;
        private System.Windows.Forms.PictureBox image_no_tenloai;
        private System.Windows.Forms.PictureBox image_yes_tenloai;
        private System.Windows.Forms.PictureBox image_no_maloai;
        private System.Windows.Forms.PictureBox image_yes_maloai;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtTenloaipc;
        private DevExpress.XtraEditors.TextEdit txtMaloaipc;
        private DevExpress.XtraEditors.TextEdit txtTien;
        private System.Windows.Forms.Label lb2;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.Label label4;
    }
}