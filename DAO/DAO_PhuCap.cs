using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System;
using DA;
using DTO;

namespace DAO {
    public class DAO_PhuCap {
        // DANH MỤC PHỤ CẤP
        #region Lấy danh sách phụ cấp
            public static List<PhuCap> getDanhSachPhuCap() {
                List<PhuCap> danhSachPhuCap = new List<PhuCap>();
                string query = @"SELECT * FROM DMPhucap";
                DataTable dt = KetNoi.executeQuery(query);

                foreach(DataRow row in dt.Rows) {
                    PhuCap phucap = new PhuCap(
                        row["maloaipc"].ToString(),
                        row["tenloai"].ToString(),
                        row["tien"].ToString()
                    );

                    danhSachPhuCap.Add(phucap);
                }

                return danhSachPhuCap;
            }
        #endregion

        #region Lấy phụ cấp theo mã loại
            public static DataTable getPhuCapTheoMa(string maloaipc) {
                string query = @"SELECT * FROM DMPhucap WHERE maloaipc = @mlpc";
                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter("@mlpc", SqlDbType.NVarChar) { Value = maloaipc }
                };

                return KetNoi.executeQuery(query, parameters.ToArray());
            }
        #endregion

        #region Kiểm tra mã phụ cấp trước khi thêm
            public static bool kiemTraTrungMaKhiThem(string maloaipc) {
                string query = @"SELECT * FROM DMPhucap WHERE maloaipc = @mlpc";
                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter("@mlpc", SqlDbType.NVarChar) { Value = maloaipc }
                };

                object result = KetNoi.executeScalar(query, parameters.ToArray());
                return Convert.ToInt32(result) > 0;
            }
        #endregion

        #region Kiểm tra mã phụ cấp trước khi sửa
            public static bool kiemTraTrungMaKhiSua(string maCu, string maMoi) {
                string query = @"
                    SELECT CASE 
                        WHEN EXISTS (
                            SELECT 1 
                            FROM DMPhucap 
                            WHERE maloaipc = @maMoi 
                            AND maloaipc <> @maCu
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

        #region Kiểm tra mã phụ cấp trước khi xóa
            public static bool kiemTraTrungMaKhiXoa(string maloaipc) {
                string query = "SELECT DISTINCT maloaipc FROM ChiTietPhuCap WHERE maloaipc = @mlpc";
                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter("@mlpc", SqlDbType.NVarChar) { Value = maloaipc }
                };

                object result = KetNoi.executeScalar(query, parameters.ToArray());
                return Convert.ToInt32(result) > 0;
            }
        #endregion

        #region Kiểm tra tên loại phụ cấp có tồn tại hay không
            public static bool kiemTraTrungTen(string tenphucap) {
                string query = @"
                    SELECT COUNT(*) 
                    FROM DMPhucap 
                    WHERE tenloai = @tenloai";
                    
                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter("@tenloai", SqlDbType.NVarChar) { Value = tenphucap }
                };

                object result = KetNoi.executeScalar(query, parameters.ToArray());
                return Convert.ToInt32(result) > 0;
            }
        #endregion

        #region Lấy phụ cấp theo mã
            public static DataTable layTenTuMa(string maloaipc) {
                string query = @"
                    SELECT * 
                    FROM DMPhucap 
                    WHERE maloaipc = @mlpc";
                    
                SqlParameter[] parameters = { new SqlParameter("@mlpc", maloaipc) };
                return KetNoi.executeQuery(query, parameters);

            }
        #endregion

        #region Thêm phụ cấp
            public static bool insertPhuCap(PhuCap phuCap) {
                string query = @"
                    INSERT INTO DMPhucap (maloaipc, tenloai, tien)
                    VALUES (@mlpc, @tenloai, @tien)
                ";

                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter("@mlpc", SqlDbType.NVarChar) { Value = phuCap.Maloaipc },
                    new SqlParameter("@tenloai", SqlDbType.NVarChar) { Value = phuCap.Tenloai },
                    new SqlParameter("@tien", SqlDbType.Real) { Value = phuCap.Tien }
                };

                return KetNoi.executeNonQuery(query, parameters.ToArray());
            }
        #endregion

        #region Sửa phụ cấp
            public static bool updatePhuCap(PhuCap phuCap, string maCu) {
                string query = @"
                    UPDATE DMPhucap 
                    SET maloaipc = @mlpc, 
                        tenloai = @tenloai, 
                        tien = @tien 
                    WHERE maloaipc = @maloaiCu";
                    
                SqlParameter[] parameters = {
                    new SqlParameter("@mlpc", phuCap.Maloaipc),
                    new SqlParameter("@tenloai", phuCap.Tenloai),
                    new SqlParameter("@tien", phuCap.Tien),
                    new SqlParameter("@maloaiCu", maCu)
                };

                return KetNoi.executeNonQuery(query, parameters);
            }
        #endregion

        #region Xóa phụ cấp
            public static bool deletePhuCap(string maloaipc) {
                if (!kiemTraTrungMaKhiXoa(maloaipc)) {
                    string query = @"
                    DELETE FROM DMPhucap 
                    WHERE maloaipc = @mlpc";

                    List<SqlParameter> parameters = new List<SqlParameter>() {
                        new SqlParameter("@mlpc", SqlDbType.NVarChar) { Value = maloaipc }
                    };
                    return KetNoi.executeNonQuery(query, parameters.ToArray());
                }
                return false;
            }
        #endregion

        // CHI TIẾT PHỤ CẤP (PIVOT)

    }
}
