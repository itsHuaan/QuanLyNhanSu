using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.InteropServices;

namespace QuanLyNhanSu
{
    public static class GenericClass
    {
        public static string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=qlynhansu;Integrated Security=True";
        public static string selectPhong = "SELECT * FROM Phong ORDER BY TenPhong ASC";
        public static string selectChucVu = "SELECT * FROM ChucVu ORDER BY HeSoPhuCap ASC";
        public static string selectNhanVien = "SELECT * FROM NhanVien ORDER BY RIGHT(HoTen, CHARINDEX(' ', REVERSE(HoTen)) - 1) ASC";
        public static bool fromBaoCao;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        public static void mouseDown(Form form)
        {
            ReleaseCapture();
            SendMessage(form.Handle, 0x112, 0xf012, 0);
        }

        public static bool isLeapYear(int year)
        {
            if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string laymaluong()
        {
            string maLuong = "";
            using (SqlConnection connection1 = new SqlConnection(GenericClass.connectionString))
            {
                connection1.Open();

                string query = "SELECT MaLuong FROM Luong WHERE MaNhanVien = @MaNhanVien AND Thang = @Thang AND Nam = @Nam";

                using (SqlCommand command = new SqlCommand(query, connection1))
                {
                    command.Parameters.AddWithValue("@MaNhanVien", ThongTinChamCong.MaNhanVien);
                    command.Parameters.AddWithValue("@Thang", ThongTinChamCong.Thang);
                    command.Parameters.AddWithValue("@Nam", ThongTinChamCong.Nam);

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        maLuong = result.ToString();
                    }
                    else
                    {
                        // Xử lý trường hợp không tìm thấy dữ liệu
                    }
                }
                connection1.Close();
            }
            return maLuong;
        }

        public static ArrayList CreateArrayList(int startPoint, int endPoint)
        {
            ArrayList arrayList = new ArrayList();
            for (int i = startPoint; i <= endPoint; i++)
            {
                arrayList.Add(i);
            }
            arrayList.Reverse();
            return arrayList;
        }

        public static string GenerateRandomString(string prefix, int min, int max)
        {
            Random random = new Random();
            int randomNumber = random.Next(min, max);
            string randomString = $"{prefix.ToUpper()}{randomNumber}";
            return randomString;
        }

        public static void panel_background(object sender, PaintEventArgs e, int cornerRadius, int alpha, int red, int green, int blue)
        {
            Panel panel = (Panel)sender;
            Color backgroundColor = Color.FromArgb(alpha, red, green, blue);

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
                path.AddArc(panel.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
                path.AddArc(panel.Width - cornerRadius, panel.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
                path.AddArc(0, panel.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (SolidBrush brush = new SolidBrush(backgroundColor))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }
        }

        public static void changeColor(Control control, Color? backColor, Color? foreColor)
        {
            if (control != null)
            {
                control.BackColor = backColor ?? control.BackColor;
                if (foreColor.HasValue && control is Control)
                {
                    control.ForeColor = foreColor.Value;
                }
            }
        }


        public static void LoadCombobox(SqlConnection connection, string query, ComboBox comboBox, string valueMember, string displayMember)
        {
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                comboBox.DataSource = dataTable;
                comboBox.ValueMember = valueMember;
                comboBox.DisplayMember = displayMember;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối:" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void LoadData(SqlConnection connection, string query, DataGridView dataGridView)
        {
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            dataGridView.DataSource = data;
        }
    }
}
