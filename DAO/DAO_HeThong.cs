using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DA;

namespace DAO {
    public class DAO_HeThong {
        #region Đăng Nhập
            public static DataTable dangNhap(string name, string pass) {
                string query = "SELECT * FROM Taikhoan WHERE ten = @name AND matkhau = @pass";
                return KetNoi.executeQuery(query,
                    new SqlParameter("@name", name),
                    new SqlParameter("@pass", pass)
                );
            }
        #endregion

        #region Chọn tài khoản người dùng
        public static DataTable selectTaiKhoan() {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT hoten, ten, ");
            query.Append("       CASE quyen ");
            query.Append("           WHEN 0 THEN 'User' ");
            query.Append("           ELSE 'Admin' ");
            query.Append("       END AS quyen ");
            query.Append("FROM taikhoan");
            return KetNoi.executeQuery(query.ToString());
        }
        #endregion

        #region Thêm mới tài khoản người dùng
            public static bool insertTaiKhoan(string hoTen, string ten, string matKhau, int quyen) {
                string query = "INSERT INTO Taikhoan (hoten, ten, matkhau, quyen) VALUES (@hoten, @ten, @matkhau, @quyen)";
                SqlParameter[] parameters = {
                    new SqlParameter("@hoten", SqlDbType.NVarChar) { Value = hoTen },
                    new SqlParameter("@ten", SqlDbType.NVarChar) { Value = ten },
                    new SqlParameter("@matkhau", SqlDbType.NVarChar) { Value = matKhau },
                    new SqlParameter("@quyen", SqlDbType.Int) { Value = quyen },
                };
                return KetNoi.executeNonQuery(query, parameters);
            }
        #endregion

        #region Cập nhật tài khoản người dùng
            public static bool updateTaiKhoan(string hoTen, string tenCu, string tenMoi, string matKhau, int quyen) {
                List<string> updates = new List<string>();
                List<SqlParameter> parameters = new List<SqlParameter>();

                // Kiểm tra hoTen không rỗng thì thêm vào câu lệnh cập nhật
                if (!string.IsNullOrEmpty(hoTen)) {
                    updates.Add("hoten = @hoten");
                    parameters.Add(new SqlParameter("@hoten", SqlDbType.NVarChar) { Value = hoTen });
                }

                // Kiểm tra matKhau không rỗng thì thêm vòa câu lệnh cập nhật
                if (!string.IsNullOrEmpty(matKhau)) {
                    updates.Add("matkhau = @matkhau");
                    parameters.Add(new SqlParameter("@matkhau", SqlDbType.NVarChar) { Value = matKhau });
                }

                // Luôn cập nhật tên mới và quyên khi cập nhật
                updates.Add("ten = @tenmoi");
                updates.Add("quyen = @quyen");

                parameters.Add(new SqlParameter("@tenmoi", SqlDbType.NVarChar) { Value = tenMoi });
                parameters.Add(new SqlParameter("@quyen", SqlDbType.Int) { Value = quyen });
                parameters.Add(new SqlParameter("@tencu", SqlDbType.NVarChar) { Value = tenCu });

                // Tạo câu lệnh UPDATE dựa trên các giá trị cần cập nhật
                string query = $"UPDATE Taikhoan SET {string.Join(", ", updates)} WHERE ten = @tencu";

                return KetNoi.executeNonQuery(query, parameters.ToArray());
            }
        #endregion

        #region Xóa tài khoản người dùng
            public static bool deleteTaiKhoan(string ten) {
                string query = "DELETE FROM Taikhoan WHERE ten = @ten";
                SqlParameter parameters = new SqlParameter("@ten", SqlDbType.NVarChar) { Value = ten };

                return KetNoi.executeNonQuery(query, parameters);
            }
        #endregion

        #region Kiểm tra kết nối tài khoản
            public static bool KT_Ketnoi() {
                KetNoi kn = new KetNoi();
                return kn.Open();
            }
        #endregion
    }
}
