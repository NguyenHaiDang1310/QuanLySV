using QuanLySV;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLSV
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=MAYBANDANG04;Initial Catalog=quanlysv;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();  // Mở kết nối tới SQL
                    string query = "SELECT COUNT(1) FROM TaiKhoan WHERE TenDangNhap=@TenDN AND MatKhau=@MatKhau";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@TenDN", txtTenDN.Text);  // Tham số tên đăng nhập
                    cmd.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text);  // Tham số mật khẩu

                    int count = Convert.ToInt32(cmd.ExecuteScalar());  // Thực thi truy vấn

                    if (count == 1)
                    {
                        MessageBox.Show("Đăng nhập thành công!");
                        this.Hide();  // Ẩn form đăng nhập
                        Form2 qlsvForm = new Form2();  // Mở form quản lý sinh viên
                        qlsvForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void btnDangKy_Click(object sender, EventArgs e)
        {
            this.Hide();  // Ẩn form đăng nhập
            DangKy dkForm = new DangKy();  // Mở form đăng ký
            dkForm.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();  // Thoát chương trình
        }
        private void Login_Load(object sender, EventArgs e)
        {
            // Bạn có thể thêm code để khởi tạo dữ liệu ở đây, nếu cần
            MessageBox.Show("Form Login đã tải thành công!");
        }

    }
}
