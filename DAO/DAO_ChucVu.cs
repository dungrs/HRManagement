using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using DA;
using DTO;

namespace DAO{
    public class DAO_ChucVu {
        #region Lấy danh sách chức vụ
            public static List<ChucVu> getDanhSachChucVu() {
                List<ChucVu> danhSachChucVu = new List<ChucVu>();
                string query = @"SELECT * FROM ChucVu";

                DataTable dt = KetNoi.executeQuery(query);
                foreach(DataRow row in dt.Rows) {
                    ChucVu chucVu = new ChucVu(
                        row["machucvu"].ToString(),
                        row["tenchucvu"].ToString(),
                        float.Parse(row["hsl"].ToString())
                    );
                    
                    danhSachChucVu.Add(chucVu);
                }

                return danhSachChucVu;
            }
        #endregion

        #region Kiểm tra mã chức vụ trước khi thêm
            public static bool kiemTraTrungMaKhiThem(string machucvu) {
                string query = @"
                        SELECT COUNT(1)
                        FROM ChucVu
                        WHERE machucvu = @macv";
                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter("@macv", SqlDbType.NVarChar) { Value = machucvu }
                };

                object result = KetNoi.executeScalar(query, parameters.ToArray());
                return Convert.ToInt32(result) > 0;
            }
        #endregion

        #region Kiểm tra mã chức vụ trước khi xóa
            public static bool kiemTraTrungMaKhiXoa(string machucvu) {
                string query = @"
                SELECT CASE 
                    WHEN EXISTS (
                        SELECT 1 
                        FROM NhanVien 
                        WHERE machucvu = @macv AND thoiviec = 1
                    ) 
                    THEN 1 ELSE 0 
                END";

                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter("@macv", SqlDbType.NVarChar) { Value = machucvu }
                };

                object result = KetNoi.executeScalar(query, parameters.ToArray());
                return Convert.ToInt32(result) > 0;
            }
        #endregion

        #region Kiêm tra mã chức vụ trước khi sửa
            public static bool kiemTraTrungMaKhiSua(string maCu, string maMoi) {
                string query = @"
                    SELECT CASE 
                        WHEN EXISTS (
                            SELECT 1 
                            FROM ChucVu 
                            WHERE machucvu = @maMoi 
                            AND machucvu <> @maCu
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

        #region Thêm chức vụ
            public static bool insertChucVu(ChucVu chucVu) {
                string query = @"
                    INSERT INTO ChucVu (machucvu, tenchucvu, hsl)
                    VALUES (@macv, @tencv, @hsl)";
                
                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter("@macv", SqlDbType.NVarChar) { Value = chucVu.Machucvu },
                    new SqlParameter("@tencv", SqlDbType.NVarChar) { Value = chucVu.Tenchucvu },
                    new SqlParameter("@hsl", SqlDbType.Float) { Value = chucVu.Hsl }
                };

                return KetNoi.executeNonQuery(query, parameters.ToArray());
            }
        #endregion

        #region Cập nhật chức vụ
            public static bool updateChucVu(ChucVu chucVu, string maCu) {
                string query = @"
                    UPDATE ChucVu 
                    SET machucvu = @machucvu, 
                        tenchucvu = @tenchvu, 
                        hsl = @hsl
                    WHERE machucvu = @maCu";

                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter("@machucvu", SqlDbType.NVarChar) { Value = chucVu.Machucvu },
                    new SqlParameter("@tenchvu", SqlDbType.NVarChar) { Value = chucVu.Tenchucvu },
                    new SqlParameter("@hsl", SqlDbType.Float) { Value = chucVu.Hsl },
                    new SqlParameter("@maCu", SqlDbType.NVarChar) { Value = maCu }
                };

                return KetNoi.executeNonQuery(query, parameters.ToArray());
            }
        #endregion

        #region Xóa chức vụ
            public static bool deleteChucVu(string macv) {
                string query = @"
                    DELETE FROM ChucVu
                    WHERE machucvu = @machucvu";

                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter("@machucvu", SqlDbType.NVarChar) { Value = macv }
                };

                return KetNoi.executeNonQuery(query, parameters.ToArray());
            }
        #endregion
    }
}
