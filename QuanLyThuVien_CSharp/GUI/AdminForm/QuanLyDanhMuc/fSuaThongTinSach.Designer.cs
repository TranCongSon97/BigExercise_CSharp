
namespace QuanLyThuVien_CSharp.GUI.AdminForm.QuanLyDanhMuc
{
    partial class fSuaThongTinSach
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
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dtpNamXuatBan = new System.Windows.Forms.DateTimePicker();
            this.lbl1 = new System.Windows.Forms.Label();
            this.nudLanXuatBan = new System.Windows.Forms.NumericUpDown();
            this.txtNhaXuatBan = new System.Windows.Forms.TextBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.txtTacGia = new System.Windows.Forms.TextBox();
            this.txtGiaMuon = new System.Windows.Forms.TextBox();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.cbbTenDanhMuc = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.btnQuayLai = new System.Windows.Forms.Button();
            this.btnXoaNDNhap = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThayAnh = new System.Windows.Forms.Button();
            this.ptbAnhSach = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudLanXuatBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAnhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(484, 347);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "VNĐ";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dtpNamXuatBan
            // 
            this.dtpNamXuatBan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpNamXuatBan.CustomFormat = "yyyy-MM-dd";
            this.dtpNamXuatBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNamXuatBan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNamXuatBan.Location = new System.Drawing.Point(715, 271);
            this.dtpNamXuatBan.Name = "dtpNamXuatBan";
            this.dtpNamXuatBan.Size = new System.Drawing.Size(200, 27);
            this.dtpNamXuatBan.TabIndex = 31;
            this.dtpNamXuatBan.Value = new System.DateTime(2000, 12, 17, 10, 42, 0, 0);
            this.dtpNamXuatBan.ValueChanged += new System.EventHandler(this.dtpNamXuatBan_ValueChanged);
            // 
            // lbl1
            // 
            this.lbl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(712, 249);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(112, 20);
            this.lbl1.TabIndex = 17;
            this.lbl1.Text = "Năm xuất bản";
            // 
            // nudLanXuatBan
            // 
            this.nudLanXuatBan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nudLanXuatBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudLanXuatBan.Location = new System.Drawing.Point(715, 340);
            this.nudLanXuatBan.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLanXuatBan.Name = "nudLanXuatBan";
            this.nudLanXuatBan.Size = new System.Drawing.Size(136, 27);
            this.nudLanXuatBan.TabIndex = 32;
            this.nudLanXuatBan.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLanXuatBan.ValueChanged += new System.EventHandler(this.nudLanXuatBan_ValueChanged);
            // 
            // txtNhaXuatBan
            // 
            this.txtNhaXuatBan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNhaXuatBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNhaXuatBan.Location = new System.Drawing.Point(715, 201);
            this.txtNhaXuatBan.Name = "txtNhaXuatBan";
            this.txtNhaXuatBan.Size = new System.Drawing.Size(306, 27);
            this.txtNhaXuatBan.TabIndex = 30;
            this.txtNhaXuatBan.TextChanged += new System.EventHandler(this.txtNhaXuatBan_TextChanged);
            // 
            // lbl2
            // 
            this.lbl2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(712, 319);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(105, 20);
            this.lbl2.TabIndex = 20;
            this.lbl2.Text = "Lần xuất bản";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(712, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 20);
            this.label7.TabIndex = 21;
            this.label7.Text = "Nhà xuất bản";
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nudSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSoLuong.Location = new System.Drawing.Point(306, 271);
            this.nudSoLuong.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(172, 27);
            this.nudSoLuong.TabIndex = 28;
            this.nudSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoLuong.ValueChanged += new System.EventHandler(this.nudSoLuong_ValueChanged);
            // 
            // txtTacGia
            // 
            this.txtTacGia.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTacGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTacGia.Location = new System.Drawing.Point(306, 201);
            this.txtTacGia.Name = "txtTacGia";
            this.txtTacGia.Size = new System.Drawing.Size(306, 27);
            this.txtTacGia.TabIndex = 27;
            this.txtTacGia.TextChanged += new System.EventHandler(this.txtTacGia_TextChanged);
            this.txtTacGia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTacGia_KeyPress);
            // 
            // txtGiaMuon
            // 
            this.txtGiaMuon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtGiaMuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaMuon.Location = new System.Drawing.Point(306, 341);
            this.txtGiaMuon.Name = "txtGiaMuon";
            this.txtGiaMuon.Size = new System.Drawing.Size(172, 27);
            this.txtGiaMuon.TabIndex = 29;
            this.txtGiaMuon.TextChanged += new System.EventHandler(this.txtGiaMuon_TextChanged);
            this.txtGiaMuon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGiaMuon_KeyPress);
            // 
            // txtTenSach
            // 
            this.txtTenSach.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTenSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenSach.Location = new System.Drawing.Point(306, 131);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(306, 27);
            this.txtTenSach.TabIndex = 26;
            this.txtTenSach.TextChanged += new System.EventHandler(this.txtTenSach_TextChanged);
            // 
            // cbbTenDanhMuc
            // 
            this.cbbTenDanhMuc.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbbTenDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTenDanhMuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTenDanhMuc.FormattingEnabled = true;
            this.cbbTenDanhMuc.Location = new System.Drawing.Point(306, 60);
            this.cbbTenDanhMuc.Name = "cbbTenDanhMuc";
            this.cbbTenDanhMuc.Size = new System.Drawing.Size(199, 28);
            this.cbbTenDanhMuc.TabIndex = 25;
            this.cbbTenDanhMuc.SelectedIndexChanged += new System.EventHandler(this.cbbTenDanhMuc_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(303, 321);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 20);
            this.label5.TabIndex = 23;
            this.label5.Text = "Giá mượn";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(303, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "Số lượng";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(303, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Tác giả";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(303, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Tên sách";
            // 
            // lbl
            // 
            this.lbl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(303, 37);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(115, 20);
            this.lbl.TabIndex = 16;
            this.lbl.Text = "Tên danh mục";
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnQuayLai.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnQuayLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuayLai.ForeColor = System.Drawing.Color.Red;
            this.btnQuayLai.Image = global::QuanLyThuVien_CSharp.Properties.Resources._return;
            this.btnQuayLai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuayLai.Location = new System.Drawing.Point(851, 468);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(182, 54);
            this.btnQuayLai.TabIndex = 35;
            this.btnQuayLai.Text = "Quay lại";
            this.btnQuayLai.UseVisualStyleBackColor = false;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // btnXoaNDNhap
            // 
            this.btnXoaNDNhap.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnXoaNDNhap.BackColor = System.Drawing.Color.MistyRose;
            this.btnXoaNDNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaNDNhap.ForeColor = System.Drawing.Color.Blue;
            this.btnXoaNDNhap.Image = global::QuanLyThuVien_CSharp.Properties.Resources.clear;
            this.btnXoaNDNhap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaNDNhap.Location = new System.Drawing.Point(565, 468);
            this.btnXoaNDNhap.Name = "btnXoaNDNhap";
            this.btnXoaNDNhap.Size = new System.Drawing.Size(256, 54);
            this.btnXoaNDNhap.TabIndex = 34;
            this.btnXoaNDNhap.Text = "Xóa nội dung nhập";
            this.btnXoaNDNhap.UseVisualStyleBackColor = false;
            this.btnXoaNDNhap.Click += new System.EventHandler(this.btnXoaNDNhap_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLuu.BackColor = System.Drawing.Color.MistyRose;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.Blue;
            this.btnLuu.Image = global::QuanLyThuVien_CSharp.Properties.Resources.save;
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(372, 468);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(160, 54);
            this.btnLuu.TabIndex = 33;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThayAnh
            // 
            this.btnThayAnh.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnThayAnh.BackColor = System.Drawing.Color.MistyRose;
            this.btnThayAnh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThayAnh.ForeColor = System.Drawing.Color.Blue;
            this.btnThayAnh.Image = global::QuanLyThuVien_CSharp.Properties.Resources.replace;
            this.btnThayAnh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThayAnh.Location = new System.Drawing.Point(32, 314);
            this.btnThayAnh.Name = "btnThayAnh";
            this.btnThayAnh.Size = new System.Drawing.Size(238, 54);
            this.btnThayAnh.TabIndex = 24;
            this.btnThayAnh.Text = "Thay ảnh sách";
            this.btnThayAnh.UseVisualStyleBackColor = false;
            this.btnThayAnh.Click += new System.EventHandler(this.btnThayAnh_Click);
            // 
            // ptbAnhSach
            // 
            this.ptbAnhSach.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ptbAnhSach.Image = global::QuanLyThuVien_CSharp.Properties.Resources.book;
            this.ptbAnhSach.Location = new System.Drawing.Point(48, 66);
            this.ptbAnhSach.Name = "ptbAnhSach";
            this.ptbAnhSach.Size = new System.Drawing.Size(206, 233);
            this.ptbAnhSach.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbAnhSach.TabIndex = 36;
            this.ptbAnhSach.TabStop = false;
            // 
            // fSuaThongTinSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 558);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpNamXuatBan);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.nudLanXuatBan);
            this.Controls.Add(this.txtNhaXuatBan);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nudSoLuong);
            this.Controls.Add(this.txtTacGia);
            this.Controls.Add(this.txtGiaMuon);
            this.Controls.Add(this.txtTenSach);
            this.Controls.Add(this.cbbTenDanhMuc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.btnQuayLai);
            this.Controls.Add(this.btnXoaNDNhap);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnThayAnh);
            this.Controls.Add(this.ptbAnhSach);
            this.Name = "fSuaThongTinSach";
            this.Text = "fSuaThongTinSach";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fSuaThongTinSach_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudLanXuatBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAnhSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DateTimePicker dtpNamXuatBan;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.NumericUpDown nudLanXuatBan;
        private System.Windows.Forms.TextBox txtNhaXuatBan;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.TextBox txtTacGia;
        private System.Windows.Forms.TextBox txtGiaMuon;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.ComboBox cbbTenDanhMuc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Button btnQuayLai;
        private System.Windows.Forms.Button btnXoaNDNhap;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThayAnh;
        private System.Windows.Forms.PictureBox ptbAnhSach;
    }
}