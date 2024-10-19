namespace QLSV
{
    partial class DangKy
    {

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtTenDN = new System.Windows.Forms.TextBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.txtMatKhauLai = new System.Windows.Forms.TextBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.lblTenDN = new System.Windows.Forms.Label();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.lblMatKhauLai = new System.Windows.Forms.Label();
            this.lblKey = new System.Windows.Forms.Label();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTenDN
            // 
            this.txtTenDN.Location = new System.Drawing.Point(177, 41);
            this.txtTenDN.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenDN.Name = "txtTenDN";
            this.txtTenDN.Size = new System.Drawing.Size(199, 22);
            this.txtTenDN.TabIndex = 0;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(177, 87);
            this.txtMatKhau.Margin = new System.Windows.Forms.Padding(4);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(199, 22);
            this.txtMatKhau.TabIndex = 1;
            // 
            // txtMatKhauLai
            // 
            this.txtMatKhauLai.Location = new System.Drawing.Point(177, 133);
            this.txtMatKhauLai.Margin = new System.Windows.Forms.Padding(4);
            this.txtMatKhauLai.Name = "txtMatKhauLai";
            this.txtMatKhauLai.PasswordChar = '*';
            this.txtMatKhauLai.Size = new System.Drawing.Size(199, 22);
            this.txtMatKhauLai.TabIndex = 2;
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(177, 182);
            this.txtKey.Margin = new System.Windows.Forms.Padding(4);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(199, 22);
            this.txtKey.TabIndex = 3;
            // 
            // lblTenDN
            // 
            this.lblTenDN.AutoSize = true;
            this.lblTenDN.Location = new System.Drawing.Point(67, 41);
            this.lblTenDN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTenDN.Name = "lblTenDN";
            this.lblTenDN.Size = new System.Drawing.Size(102, 16);
            this.lblTenDN.TabIndex = 4;
            this.lblTenDN.Text = "Tên Đăng Nhập";
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Location = new System.Drawing.Point(67, 90);
            this.lblMatKhau.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(62, 16);
            this.lblMatKhau.TabIndex = 5;
            this.lblMatKhau.Text = "Mật Khẩu";
            // 
            // lblMatKhauLai
            // 
            this.lblMatKhauLai.AutoSize = true;
            this.lblMatKhauLai.Location = new System.Drawing.Point(67, 139);
            this.lblMatKhauLai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMatKhauLai.Name = "lblMatKhauLai";
            this.lblMatKhauLai.Size = new System.Drawing.Size(83, 16);
            this.lblMatKhauLai.TabIndex = 6;
            this.lblMatKhauLai.Text = "Nhập Lại MK";
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(67, 188);
            this.lblKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(30, 16);
            this.lblKey.TabIndex = 7;
            this.lblKey.Text = "Key";
            // 
            // btnDangKy
            // 
            this.btnDangKy.Location = new System.Drawing.Point(167, 234);
            this.btnDangKy.Margin = new System.Windows.Forms.Padding(4);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(100, 28);
            this.btnDangKy.TabIndex = 8;
            this.btnDangKy.Text = "Đăng Ký";
            this.btnDangKy.UseVisualStyleBackColor = true;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(276, 234);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(100, 28);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // DangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 283);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDangKy);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.lblMatKhauLai);
            this.Controls.Add(this.lblMatKhau);
            this.Controls.Add(this.lblTenDN);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.txtMatKhauLai);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.txtTenDN);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DangKy";
            this.Text = "Đăng Ký";
            this.Load += new System.EventHandler(this.DangKy_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox txtTenDN;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.TextBox txtMatKhauLai;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label lblTenDN;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.Label lblMatKhauLai;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Button btnThoat;
    }
}
