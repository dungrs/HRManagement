using System;
using System.Collections.Generic;
using DTO;
using System.Data;
using DA;
using System.Data.SqlClient;

namespace DAO {
    public class DAO_Tinh {
        #region Lấy danh sách tỉnh
        public static List<Tinh> getDanhSachTinh() {
            List<Tinh> danhSachTinh = new List<Tinh>();
            string query = "SELECT id, tentinh FROM Tinh";
            DataTable dt = KetNoi.executeQuery(query);

            foreach (DataRow row in dt.Rows) {
                string id = row["id"].ToString();
                string tentinh = row["tentinh"].ToString();

                Tinh tinh = new Tinh(id, tentinh); 
                danhSachTinh.Add(tinh);
            }

            return danhSachTinh;
        }
        #endregion

        #region Kiểm tra mã tỉnh có tồn tại hay không trước khi thêm
        public static bool kiemTraMaTinhKhiThem(string maTinh) {
            string query = "SELECT COUNT(1) FROM Tinh WHERE id = @maTinh";
            List<SqlParameter> parameters = new List<SqlParameter>() {
                new SqlParameter("@maTinh", SqlDbType.NVarChar) { Value = maTinh }
            };

            object result = KetNoi.executeScalar(query, parameters.ToArray());

            return Convert.ToInt32(result) > 0;
        }
        #endregion

        #region Kiểm tra mã tỉnh có tồn tại hay không trước khi sửa
        public static bool kiemTraMaTinhKhiSua(string maCu, string maMoi) {
            string query = "SELECT CASE WHEN EXISTS (SELECT 1 FROM Tinh WHERE id = @maMoi AND id <> @maCu) THEN 1 ELSE 0 END";
            List<SqlParameter> parameters = new List<SqlParameter>() {
                new SqlParameter("@maMoi", SqlDbType.NVarChar) { Value = maMoi },
                new SqlParameter("@maCu", SqlDbType.NVarChar) { Value = maCu },
            };

            object result = KetNoi.executeScalar(query, parameters.ToArray());
            return Convert.ToInt32(result) > 0;
        }
        #endregion

        #region Thêm tỉnh mới
        public static bool insertTinh(string maTinh, string tentinh) { 
            string query = "INSERT INTO Tinh (id, tentinh) VALUES (@maTinh, @tentinh)";
            List<SqlParameter> parameters = new List<SqlParameter>() {
                new SqlParameter("@maTinh", SqlDbType.NVarChar) { Value = maTinh },
                new SqlParameter("@tentinh", SqlDbType.NVarChar) { Value = tentinh } 
            };

            return KetNoi.executeNonQuery(query, parameters.ToArray());
        }
        #endregion

        #region Cập nhật thông tin tỉnh
        public static bool updateTinh(string maCu, string maMoi, string tentinh) {
            string query = "UPDATE Tinh SET id = @maMoi, tentinh = @tentinh WHERE id = @maCu";
            List<SqlParameter> parameters = new List<SqlParameter>() {
                new SqlParameter("@maMoi", SqlDbType.NVarChar) { Value = maMoi },
                new SqlParameter("@tentinh", SqlDbType.NVarChar) { Value = tentinh }, 
                new SqlParameter("@maCu", SqlDbType.NVarChar) { Value = maCu },
            };

            return KetNoi.executeNonQuery(query, parameters.ToArray());
        }
        #endregion  

        #region Xóa tỉnh
        public static bool deleteTinh(string maTinh) {
            string query = "DELETE FROM Tinh WHERE id = @maTinh";
            List<SqlParameter> parameters = new List<SqlParameter> {
                new SqlParameter("@maTinh", SqlDbType.NVarChar) { Value = maTinh }
            };

            return KetNoi.executeNonQuery(query, parameters.ToArray());
        }
        #endregion
    }
}
