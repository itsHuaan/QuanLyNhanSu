﻿namespace QuanLyNhanSu
{
    partial class DangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangNhap));
            this.button_dangnhap = new System.Windows.Forms.Button();
            this.button_thoat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_tennguoidung = new System.Windows.Forms.TextBox();
            this.textBox_matkhau = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton_quanly = new System.Windows.Forms.RadioButton();
            this.radioButton_nhanvien = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.button_hien = new System.Windows.Forms.Button();
            this.button_an = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_minimize = new System.Windows.Forms.Label();
            this.label_exit = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_dangnhap
            // 
            this.button_dangnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button_dangnhap.Location = new System.Drawing.Point(54, 250);
            this.button_dangnhap.Margin = new System.Windows.Forms.Padding(4);
            this.button_dangnhap.Name = "button_dangnhap";
            this.button_dangnhap.Size = new System.Drawing.Size(88, 28);
            this.button_dangnhap.TabIndex = 0;
            this.button_dangnhap.Text = "Đăng nhập";
            this.button_dangnhap.UseVisualStyleBackColor = true;
            this.button_dangnhap.Click += new System.EventHandler(this.button_dangnhap_Click);
            // 
            // button_thoat
            // 
            this.button_thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button_thoat.Location = new System.Drawing.Point(175, 250);
            this.button_thoat.Margin = new System.Windows.Forms.Padding(4);
            this.button_thoat.Name = "button_thoat";
            this.button_thoat.Size = new System.Drawing.Size(88, 28);
            this.button_thoat.TabIndex = 1;
            this.button_thoat.Text = "Thoát";
            this.button_thoat.UseVisualStyleBackColor = true;
            this.button_thoat.Click += new System.EventHandler(this.button_thoat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(69, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "ĐĂNG NHẬP";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(54, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên người dùng:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(54, 140);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mật khẩu:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_tennguoidung
            // 
            this.textBox_tennguoidung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.textBox_tennguoidung.Location = new System.Drawing.Point(54, 96);
            this.textBox_tennguoidung.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_tennguoidung.Name = "textBox_tennguoidung";
            this.textBox_tennguoidung.Size = new System.Drawing.Size(209, 21);
            this.textBox_tennguoidung.TabIndex = 5;
            // 
            // textBox_matkhau
            // 
            this.textBox_matkhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.textBox_matkhau.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBox_matkhau.Location = new System.Drawing.Point(54, 157);
            this.textBox_matkhau.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_matkhau.Name = "textBox_matkhau";
            this.textBox_matkhau.PasswordChar = '*';
            this.textBox_matkhau.Size = new System.Drawing.Size(209, 21);
            this.textBox_matkhau.TabIndex = 6;
            this.textBox_matkhau.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.no_space);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.radioButton_quanly);
            this.panel1.Controls.Add(this.radioButton_nhanvien);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox_tennguoidung);
            this.panel1.Controls.Add(this.button_thoat);
            this.panel1.Controls.Add(this.button_dangnhap);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button_hien);
            this.panel1.Controls.Add(this.button_an);
            this.panel1.Controls.Add(this.textBox_matkhau);
            this.panel1.Location = new System.Drawing.Point(324, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(322, 300);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // radioButton_quanly
            // 
            this.radioButton_quanly.AutoSize = true;
            this.radioButton_quanly.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.radioButton_quanly.ForeColor = System.Drawing.Color.White;
            this.radioButton_quanly.Location = new System.Drawing.Point(202, 218);
            this.radioButton_quanly.Name = "radioButton_quanly";
            this.radioButton_quanly.Size = new System.Drawing.Size(66, 19);
            this.radioButton_quanly.TabIndex = 9;
            this.radioButton_quanly.TabStop = true;
            this.radioButton_quanly.Text = "Quản lý";
            this.radioButton_quanly.UseVisualStyleBackColor = true;
            // 
            // radioButton_nhanvien
            // 
            this.radioButton_nhanvien.AutoSize = true;
            this.radioButton_nhanvien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.radioButton_nhanvien.ForeColor = System.Drawing.Color.White;
            this.radioButton_nhanvien.Location = new System.Drawing.Point(54, 218);
            this.radioButton_nhanvien.Name = "radioButton_nhanvien";
            this.radioButton_nhanvien.Size = new System.Drawing.Size(80, 19);
            this.radioButton_nhanvien.TabIndex = 8;
            this.radioButton_nhanvien.TabStop = true;
            this.radioButton_nhanvien.Text = "Nhân viên";
            this.radioButton_nhanvien.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(54, 202);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Vai trò:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_hien
            // 
            this.button_hien.BackgroundImage = global::QuanLyNhanSu.Properties.Resources.show_white;
            this.button_hien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_hien.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.button_hien.FlatAppearance.BorderSize = 0;
            this.button_hien.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_hien.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_hien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_hien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button_hien.Location = new System.Drawing.Point(271, 158);
            this.button_hien.Margin = new System.Windows.Forms.Padding(4);
            this.button_hien.Name = "button_hien";
            this.button_hien.Size = new System.Drawing.Size(21, 21);
            this.button_hien.TabIndex = 10;
            this.button_hien.UseVisualStyleBackColor = true;
            this.button_hien.Click += new System.EventHandler(this.button_hien_Click);
            // 
            // button_an
            // 
            this.button_an.BackgroundImage = global::QuanLyNhanSu.Properties.Resources.hide_white;
            this.button_an.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_an.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.button_an.FlatAppearance.BorderSize = 0;
            this.button_an.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_an.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_an.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_an.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button_an.Location = new System.Drawing.Point(271, 158);
            this.button_an.Margin = new System.Windows.Forms.Padding(4);
            this.button_an.Name = "button_an";
            this.button_an.Size = new System.Drawing.Size(21, 21);
            this.button_an.TabIndex = 11;
            this.button_an.UseVisualStyleBackColor = true;
            this.button_an.Click += new System.EventHandler(this.button_an_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLyNhanSu.Properties.Resources.Company_amico;
            this.pictureBox1.Location = new System.Drawing.Point(17, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label_minimize);
            this.panel2.Controls.Add(this.label_exit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(657, 25);
            this.panel2.TabIndex = 9;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // label_minimize
            // 
            this.label_minimize.AutoSize = true;
            this.label_minimize.BackColor = System.Drawing.Color.Transparent;
            this.label_minimize.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_minimize.Location = new System.Drawing.Point(603, 2);
            this.label_minimize.Name = "label_minimize";
            this.label_minimize.Size = new System.Drawing.Size(24, 20);
            this.label_minimize.TabIndex = 1;
            this.label_minimize.Text = "—";
            this.label_minimize.Click += new System.EventHandler(this.label_minimize_Click);
            this.label_minimize.MouseLeave += new System.EventHandler(this.label_minimize_MouseLeave);
            this.label_minimize.MouseHover += new System.EventHandler(this.label_minimize_MouseHover);
            // 
            // label_exit
            // 
            this.label_exit.AutoSize = true;
            this.label_exit.BackColor = System.Drawing.Color.Transparent;
            this.label_exit.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_exit.Location = new System.Drawing.Point(630, 2);
            this.label_exit.Name = "label_exit";
            this.label_exit.Size = new System.Drawing.Size(24, 20);
            this.label_exit.TabIndex = 0;
            this.label_exit.Text = "⨉";
            this.label_exit.Click += new System.EventHandler(this.label_exit_Click);
            this.label_exit.MouseLeave += new System.EventHandler(this.label_exit_MouseLeave);
            this.label_exit.MouseHover += new System.EventHandler(this.label_exit_MouseHover);
            // 
            // DangNhap
            // 
            this.AcceptButton = this.button_dangnhap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 343);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DangNhap_FormClosed);
            this.Load += new System.EventHandler(this.DangNhap_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_dangnhap;
        private System.Windows.Forms.Button button_thoat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_tennguoidung;
        private System.Windows.Forms.TextBox textBox_matkhau;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton_quanly;
        private System.Windows.Forms.RadioButton radioButton_nhanvien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_hien;
        private System.Windows.Forms.Button button_an;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label_minimize;
        private System.Windows.Forms.Label label_exit;
    }
}

