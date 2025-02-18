using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DA {
    public class KetNoi  {
        private static readonly string ConnectionString = @"Server=(local);Database=QLNS;Trusted_Connection=True;";
        private SqlConnection connect;

        public KetNoi() {
            connect = new SqlConnection(ConnectionString);
            try {
                connect.Open();
            } catch (Exception ex) {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static SqlConnection GetConnection() {
            return new SqlConnection(ConnectionString);
        }

        public bool Open() {
            try {
                if (connect == null || connect.State == ConnectionState.Closed) {
                    connect = new SqlConnection(ConnectionString);
                    connect.Open();
                }
                return true;
            } catch (Exception ex) {
                MessageBox.Show($"Lỗi mở kết nối: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void Disconnect() {
            if (connect != null && connect.State == ConnectionState.Open) {
                connect.Close();
                MessageBox.Show("Đã đóng kết nối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Phương thức thực thi câu truy vấn SQL trả về kết quả dưới dạng DataTable
        public static DataTable executeQuery(string query, params SqlParameter[] parameters) {
            // Kết nối với cơ sở dữ liệu
            using (SqlConnection cn = GetConnection()) {
                // Tạo một đối tượng để thực thi câu truy vấn SQL
                using (SqlCommand cmd = new SqlCommand(query, cn)) {
                    // Thêm danh sách các tham số vào câu lệnh SQL
                    cmd.Parameters.AddRange(parameters);

                    // Sử dụng SqlDataAdapter để lấy dữ liệu từ database và đổ vào DataTable
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd)) {
                        DataTable dt = new DataTable();
                        cn.Open();
                        da.Fill(dt); // Đổ dữ liệu từ SQL vào DataTable
                        return dt; // Tra về DataTable chứa dữ liệu
                    }
                }
            }
        }

        // Phương thức thực thi câu lệnh SQL không trả về dữ liệu (INSERT, UPDATE, DELETE)
        public static bool executeNonQuery(string query, params SqlParameter[] parameters) {
            try {
                // Kết nối với cơ sở dữ liệu
                using (SqlConnection cn = GetConnection()) {
                    cn.Open(); // Mở kết nối với cơ sở dữ liệu
                    // Tạo một đối tượng để thực thi câu truy vấn SQL
                    using (SqlCommand cmd = new SqlCommand(query, cn)) {
                        cmd.Parameters.AddRange(parameters); // Thêm danh sách các tham số vào câu lệnh SQL
                        cmd.ExecuteNonQuery(); // Thực thi câu truy vấn không trả về dữ liệu
                        return true;
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
                return false;
            }
        }

        // Thực thi truy vấn và trả về một giá trị duy nhất (executeScalar)
        public static object executeScalar(string query, params SqlParameter[] parameters) {
            try {
                // Kết nối với cơ sở dữ liệu
                using (SqlConnection cn = GetConnection()) {
                    cn.Open(); // Mở kết nối với cơ sở dữ liệu
                    // Tạo một đối tượng để thực thi câu truy vấn SQL
                    using (SqlCommand cmd = new SqlCommand(query, cn)) {
                        cmd.Parameters.AddRange(parameters);
                        return cmd.ExecuteScalar();
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
                return null; 
            }
        }   

        public static bool DangNhap(string server, string name, string pass) {
            try {
                using (SqlConnection cn = new SqlConnection($"Server={server};UID={name};PWD={pass};Database=QLNS")) {
                    cn.Open();
                    return true;
                }
            } catch {
                return false;
            }
        }
    }
}
