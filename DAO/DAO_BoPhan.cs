using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using DA;
using DTO;

namespace DAO {
    public class DAO_BoPhan {
        #region Lấy danh sách bộ phận
            public static List<BoPhan> getDanhSachBoPhan() {
                List<BoPhan> danhSachBoPhan = new List<BoPhan>();
                string query = @"SELECT * FROM BoPhan";

                DataTable dt = KetNoi.executeQuery(query);
                foreach(DataRow row in dt.Rows) {
                    BoPhan boPhan = new BoPhan(
                        row["Mabophan"].ToString(),
                        row["Tenbophan"].ToString()
                    );

                    danhSachBoPhan.Add(boPhan);
                }
                return danhSachBoPhan;
            }
        #endregion

        #region Kiểm tra mã bộ phận trước khi thêm
            public static bool kiemTraTrungMaKhiThem(string mabophan) {
                string query = @"
                        SELECT COUNT(1)
                        FROM BoPhan
                        WHERE Mabophan = @mabp";
                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter("@mabp", SqlDbType.NVarChar) { Value = mabophan }
                };

                object result = KetNoi.executeScalar(query, parameters.ToArray());
                return Convert.ToInt32(result) > 0;
            }
        #endregion

        #region Kiểm tra mã bộ phận trước khi sửa
            public static bool kiemTraTrungMaKhiSua(string maCu, string maMoi) {
                string query = @"
                    SELECT CASE 
                        WHEN EXISTS (
                            SELECT 1 
                            FROM BoPhan 
                            WHERE Mabophan = @maMoi 
                            AND Mabophan <> @maCu
                        ) 
                        THEN 1 ELSE 0 
                    END";

                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter("@maMoi", SqlDbType.NVarChar) { Value = maMoi },
                    new SqlParameter("@maCu", SqlDbType.NVarChar) { Value = maCu }
                };

                object result = KetNoi.executeScalar(query, parameters.ToArray());
                return Convert.ToInt32(result) > 0;
            }
        #endregion

        #region Kiểm tra mã bộ phận trước khi xóa
            public static bool kiemTraTrungMaKhiXoa(string mabophan) {
                string query = @"
                SELECT CASE 
                    WHEN EXISTS (
                        SELECT 1 
                        FROM NhanVien 
                        WHERE Mabophan = @mabp AND thoiviec = 1
                    ) 
                    THEN 1 ELSE 0 
                END";

                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter("@mabp", SqlDbType.NVarChar) { Value = mabophan }
                };

                object result = KetNoi.executeScalar(query, parameters.ToArray());
                return Convert.ToInt32(result) > 0;
            }
        #endregion

        #region Thêm mới bộ phận
            public static bool insertBoPhan(BoPhan boPhan) {
                string query = @"
                    INSERT INTO BoPhan (Mabophan, Tenbophan)
                    VALUES (@mabp, @tenbp)";
                
                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter("@mabp", SqlDbType.NVarChar) { Value = boPhan.Mabophan },
                    new SqlParameter("@tenbp", SqlDbType.NVarChar) { Value = boPhan.Tenbophan },
                };

                return KetNoi.executeNonQuery(query, parameters.ToArray());
            }
        #endregion

        #region Cập nhật bộ phận
            public static bool updateBoPhan(BoPhan boPhan, string maCu) {
                string query = @"
                    UPDATE BoPhan 
                    SET Mabophan = @mabophan, 
                        Tenbophan = @tenbophan
                    WHERE Mabophan = @maCu";

                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter("@mabophan", SqlDbType.NVarChar) { Value = boPhan.Mabophan },
                    new SqlParameter("@tenbophan", SqlDbType.NVarChar) { Value = boPhan.Tenbophan },
                    new SqlParameter("@maCu", SqlDbType.NVarChar) { Value = maCu }
                };

                return KetNoi.executeNonQuery(query, parameters.ToArray());
            }
        #endregion

        #region Xóa bộ phận
            public static bool deleteBoPhan(string mabophan) {
                string query = @"
                    DELETE FROM BoPhan
                    WHERE Mabophan = @mabophan";

                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter("@mabophan", SqlDbType.NVarChar) { Value = mabophan }
                };

                return KetNoi.executeNonQuery(query, parameters.ToArray());
            }
        #endregion
    }   
}