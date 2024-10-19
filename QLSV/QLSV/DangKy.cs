using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLSV
{
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == txtMatKhauLai.Text)
            {
                string connectionString = @"Data Source=MAYBANDANG04;Initial Catalog=quanlysv;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "INSERT INTO TaiKhoan (TenDangNhap, MatKhau, Keypass) VALUES (@TenDN, @MatKhau, @Keypass)";
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@TenDN", txtTenDN.Text);  // Tham số tên đăng nhập
                        cmd.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text);  // Tham số mật khẩu
                        cmd.Parameters.AddWithValue("@Keypass", txtKey.Text);  // Tham số khóa bảo mật
                        cmd.ExecuteNonQuery();  // Thực thi truy vấn

                        MessageBox.Show("Đăng ký thành công!");
                        this.Hide();
                        Login loginForm = new Login();  // Mở lại form đăng nhập
                        loginForm.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!");
            }
        }

        private void DangKy_Load(object sender, EventArgs e)
        {
            // Bạn có thể thêm code để khởi tạo dữ liệu ở đây, nếu cần
            MessageBox.Show("Form Đăng Ký đã tải thành công!");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();  // Ẩn form đăng ký và quay lại form đăng nhập
            Login loginForm = new Login();
            loginForm.Show();
        }
    }
}
