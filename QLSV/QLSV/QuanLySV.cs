using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QuanLySV
{
    public partial class Form2 : Form
    {
        int rowindex = -1;
        string connectionString = @"Data Source=MAYBANDANG04;Initial Catalog=quanlysv;Integrated Security=True";

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadKhoa();
            btnXoa.Enabled = false;
            btnCapNhat.Enabled = false;
            btnThem.Enabled = true;
            LoadData();
        }

        private void LoadKhoa()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT TenKhoa FROM Khoa", connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                cbKhoa.DataSource = dataTable;
                cbKhoa.DisplayMember = "TenKhoa";
                cbKhoa.ValueMember = "TenKhoa";
            }
        }

        private void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                dgvDanhSach.Columns.Clear();
                dgvDanhSach.DataSource = null;

                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT MaSinhVien, HoTen, NgaySinh, GioiTinh, DiemTB, Khoa FROM SinhVien", connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dgvDanhSach.DataSource = dataTable;
            }
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || dgvDanhSach.Rows[e.RowIndex].IsNewRow) // Kiểm tra nếu là hàng mới hoặc hàng trống
            {
                ResetData();
                btnThem.Enabled = true;  // Bật nút Thêm
                btnCapNhat.Enabled = false; // Tắt nút Sửa
                btnXoa.Enabled = false;    // Tắt nút Xóa
            }
            else
            {
                rowindex = e.RowIndex;
                mtxtMaSV.Text = dgvDanhSach.Rows[rowindex].Cells["MaSinhVien"].Value.ToString();
                txtHoTen.Text = dgvDanhSach.Rows[rowindex].Cells["HoTen"].Value.ToString();
                txtDiemTB.Text = dgvDanhSach.Rows[rowindex].Cells["DiemTB"].Value.ToString();
                cbKhoa.Text = dgvDanhSach.Rows[rowindex].Cells["Khoa"].Value.ToString();

                string ngaySinhString = dgvDanhSach.Rows[rowindex].Cells["NgaySinh"].Value.ToString();
                DateTime ngaySinh;
                if (DateTime.TryParse(ngaySinhString, out ngaySinh))
                {
                    dtpNgaySinh.Value = ngaySinh;
                }

                string gioiTinh = dgvDanhSach.Rows[rowindex].Cells["GioiTinh"].Value.ToString();
                if (gioiTinh == "Nam")
                {
                    rbNam.Checked = true;
                }
                else
                {
                    rbNu.Checked = true;
                }

                // Load hình ảnh từ SQL (nếu có)
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT HinhAnh FROM SinhVien WHERE MaSinhVien = @MaSV";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@MaSV", mtxtMaSV.Text);
                    byte[] imageBytes = (byte[])cmd.ExecuteScalar();

                    if (imageBytes != null)
                    {
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            pictureBoxStudent.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        pictureBoxStudent.Image = null; // Nếu không có ảnh
                    }
                }

                btnThem.Enabled = false;   // Tắt nút Thêm
                btnCapNhat.Enabled = true; // Bật nút Sửa
                btnXoa.Enabled = true;     // Bật nút Xóa
            }
        }


        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            double diemtb;
            try
            {
                if (mtxtMaSV.Text.Length != 10)
                {
                    throw new Exception("Mã sinh viên phải có 10 ký tự");
                }

                if (!checkMaSV(mtxtMaSV.Text))
                {
                    throw new Exception("Mã sinh viên đã tồn tại");
                }

                if (string.IsNullOrEmpty(txtHoTen.Text))
                {
                    throw new Exception("Họ tên không được để trống");
                }

                if (!double.TryParse(txtDiemTB.Text, out diemtb))
                {
                    throw new Exception("Điểm trung bình phải là số");
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO SinhVien (MaSinhVien, HoTen, NgaySinh, GioiTinh, DiemTB, Khoa, HinhAnh) " +
                                   "VALUES (@MaSV, @HoTen, @NgaySinh, @GioiTinh, @DiemTB, @Khoa, @HinhAnh)";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@MaSV", mtxtMaSV.Text);
                    cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                    cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                    cmd.Parameters.AddWithValue("@GioiTinh", rbNam.Checked ? "Nam" : "Nữ");
                    cmd.Parameters.AddWithValue("@DiemTB", diemtb);
                    cmd.Parameters.AddWithValue("@Khoa", cbKhoa.Text);

                    if (pictureBoxStudent.Image != null)
                    {
                        byte[] imageBytes = ImageToByteArray(pictureBoxStudent.Image);
                        cmd.Parameters.AddWithValue("@HinhAnh", imageBytes);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@HinhAnh", DBNull.Value);
                    }

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Thêm sinh viên thành công!");
                LoadData();
                ResetData();
                btnXoa.Enabled = false;
                btnCapNhat.Enabled = false;
                btnThem.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private bool checkMaSV(string masv)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM SinhVien WHERE MaSinhVien = @MaSV", connection);
                cmd.Parameters.AddWithValue("@MaSV", masv);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count == 0;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            double diemtb;
            try
            {
                if (rowindex == -1 || rowindex >= dgvDanhSach.Rows.Count)
                {
                    throw new Exception("Chưa chọn sinh viên cần sửa");
                }

                if (mtxtMaSV.Text.Length != 10)
                {
                    throw new Exception("Mã sinh viên phải có 10 ký tự");
                }

                if (!double.TryParse(txtDiemTB.Text, out diemtb))
                {
                    throw new Exception("Điểm trung bình phải là số");
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE SinhVien SET HoTen=@HoTen, NgaySinh=@NgaySinh, GioiTinh=@GioiTinh, DiemTB=@DiemTB, Khoa=@Khoa, HinhAnh=@HinhAnh WHERE MaSinhVien=@MaSV";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@MaSV", mtxtMaSV.Text);
                    cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                    cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                    cmd.Parameters.AddWithValue("@GioiTinh", rbNam.Checked ? "Nam" : "Nữ");
                    cmd.Parameters.AddWithValue("@DiemTB", diemtb);
                    cmd.Parameters.AddWithValue("@Khoa", cbKhoa.Text);

                    if (pictureBoxStudent.Image != null)
                    {
                        byte[] imageBytes = ImageToByteArray(pictureBoxStudent.Image);
                        cmd.Parameters.AddWithValue("@HinhAnh", imageBytes);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@HinhAnh", DBNull.Value);
                    }

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Cập nhật sinh viên thành công!");
                LoadData();
                ResetData();
                btnThem.Enabled = true;
                btnCapNhat.Enabled = false;
                btnXoa.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (rowindex == -1 || rowindex >= dgvDanhSach.Rows.Count - 1)
                {
                    throw new Exception("Chưa chọn sinh viên cần xóa");
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM SinhVien WHERE MaSinhVien = @MaSV";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@MaSV", mtxtMaSV.Text);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Xóa sinh viên thành công!");
                LoadData();
                ResetData();
                btnXoa.Enabled = false;
                btnCapNhat.Enabled = false;
                btnThem.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void ResetData()
        {
            mtxtMaSV.Clear();
            txtHoTen.Clear();
            txtDiemTB.Clear();
            rbNam.Checked = false;
            rbNu.Checked = false;
            pictureBoxStudent.Image = null;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có muốn thoát không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void buttonChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBoxStudent.Image = Image.FromFile(openFileDialog.FileName);
            }
        }


    }
}
