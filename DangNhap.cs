using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public partial class DangNhap : Form
    {
        SqlConnection connection = new SqlConnection(GenericClass.connectionString);
        public DangNhap()
        {
            InitializeComponent();
            panel1.Paint += panel1_Paint;
            this.ActiveControl = textBox_tennguoidung;
            radioButton_nhanvien.Checked = true;
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            textBox_tennguoidung.Text = "nv19091";
            textBox_matkhau.Text = "QHuan1909!";
            radioButton_quanly.Checked = true;
        }

        private void button_dangnhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = textBox_tennguoidung.Text;
            string matKhau = textBox_matkhau.Text;
            bool laNhanVien = radioButton_nhanvien.Checked;

            string query = "SELECT MaNhanVien, HoTen, LoaiNguoiDung FROM NhanVien WHERE MaNhanVien = @MaNhanVien AND MatKhau = @MatKhau";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MaNhanVien", tenDangNhap);
            command.Parameters.AddWithValue("@MatKhau", matKhau);

            connection.Open();
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string maNhanVien = reader["MaNhanVien"].ToString().ToUpper();
                    string hoTen = reader["HoTen"].ToString();
                    string loaiNguoiDung = reader["LoaiNguoiDung"].ToString();

                    if (laNhanVien && loaiNguoiDung == "user")
                    {
                        // Lưu thông tin đăng nhập để chuyển sang form sau
                        PhienDangNhap.MaNhanVien = maNhanVien;
                        PhienDangNhap.HoTen = hoTen;
                        PhienDangNhap.LaNhanVien = true;
                        HoSoNhanVien nhanVien = new HoSoNhanVien();
                        this.Hide();
                        nhanVien.ShowDialog();
                        this.Show();
                    }
                    else if (!laNhanVien && loaiNguoiDung == "admin")
                    {
                        PhienDangNhap.MaNhanVien = maNhanVien;
                        PhienDangNhap.HoTen = hoTen;
                        PhienDangNhap.LaNhanVien = false;
                        QuanLy quanLy = new QuanLy();
                        this.Hide();
                        quanLy.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("Vai trò không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Thông tin đăng nhập không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối:" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button_thoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
                PhienDangNhap.XoaPhienDangNhap();
            }
        }

        private void button_hien_Click(object sender, EventArgs e)
        {
            if (textBox_matkhau.PasswordChar == '*')
            {
                button_an.BringToFront();
                textBox_matkhau.PasswordChar = '\0';
            }
        }

        private void button_an_Click(object sender, EventArgs e)
        {
            if (textBox_matkhau.PasswordChar == '\0')
            {
                button_hien.BringToFront();
                textBox_matkhau.PasswordChar = '*';
            }
        }

        private void DangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            PhienDangNhap.XoaPhienDangNhap();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // panel_background(sender, e, cornerRadius, alpha, red, green, blue)
            GenericClass.panel_background(sender, e, 50, 80, 0, 0, 0);
        }

        private void no_space(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label_minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            GenericClass.mouseDown(this);
        }

        private void label_exit_MouseHover(object sender, EventArgs e)
        {
           GenericClass.changeColor(label_exit, Color.Red, SystemColors.Control);
        }

        private void label_exit_MouseLeave(object sender, EventArgs e)
        {
            GenericClass.changeColor(label_exit, Color.Transparent, SystemColors.ControlText);
        }

        private void label_minimize_MouseHover(object sender, EventArgs e)
        {
            GenericClass.changeColor(label_minimize, Color.Gray, SystemColors.ControlText);
        }

        private void label_minimize_MouseLeave(object sender, EventArgs e)
        {
            GenericClass.changeColor(label_minimize, Color.Transparent, SystemColors.ControlText);
        }
    }
}
