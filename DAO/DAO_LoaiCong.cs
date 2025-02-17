using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System;
using DA;
using DTO;

namespace DAO {
    public class DAO_LoaiCong {
        #region Lấy danh sách loại công
        public static List<LoaiCong> getDanhSachLoaiCong() {
            List<LoaiCong> danhSachLoaiCong = new List<LoaiCong>();
            string query = @"
                SELECT * 
                FROM DMloaicong";
                
            DataTable dt = KetNoi.executeQuery(query);

            foreach (DataRow row in dt.Rows) {
                string maloai = row["maloai"].ToString();
                string tenloai = row["tenloai"].ToString();
                string heso = row["heso"].ToString();

                LoaiCong loaiCong = new LoaiCong(maloai, tenloai, heso);
                danhSachLoaiCong.Add(loaiCong);
            }

            return danhSachLoaiCong;
        }
        #endregion

        #region Kiểm tra mã loại công có tồn tại hay không trước khi thêm
        public static bool kiemTraTrungMaKhiThem(string maloai) {
            string query = @"
                SELECT COUNT(*) 
                FROM DMloaicong 
                WHERE maloai = @maloai";
                
            List<SqlParameter> parameters = new List<SqlParameter>() {
                new SqlParameter("@maloai", SqlDbType.NVarChar) { Value = maloai }
            };

            object result = KetNoi.executeScalar(query, parameters.ToArray());
            return Convert.ToInt32(result) > 0;
        }
        #endregion

        #region Kiểm tra mã loại công có tồn tại hay không trước khi sửa
        public static bool kiemTraTrungMaKhiSua(string maCu, string maMoi) {
            string query = @"
                SELECT CASE 
                    WHEN EXISTS (
                        SELECT 1 
                        FROM DMloaicong 
                        WHERE maloai = @maMoi 
                        AND maloai <> @maCu
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

        #region Kiểm tra tên loại có tồn tại hay không
        public static bool kiemTraTrungTen(string tenloai) {
            string query = @"
                SELECT COUNT(*) 
                FROM DMloaicong 
                WHERE tenloai = @tenloai";
                
            List<SqlParameter> parameters = new List<SqlParameter>() {
                new SqlParameter("@tenloai", SqlDbType.NVarChar) { Value = tenloai }
            };

            object result = KetNoi.executeScalar(query, parameters.ToArray());
            return Convert.ToInt32(result) > 0;
        }
        #endregion

        #region Thêm loại công
        public static bool insertLoaiCong(LoaiCong loaiCong) {
            string query = @"
                INSERT INTO DMloaicong (maloai, tenloai, heso) 
                VALUES (@maloai, @tenloai, @heso)";
                
            List<SqlParameter> parameters = new List<SqlParameter>() {
                new SqlParameter("@maloai", SqlDbType.NVarChar) { Value = loaiCong.Maloai },
                new SqlParameter("@tenloai", SqlDbType.NVarChar) { Value = loaiCong.Tenloai },
                new SqlParameter("@heso", SqlDbType.Float) { Value = loaiCong.Heso }
            };

            return KetNoi.executeNonQuery(query, parameters.ToArray());
        }
        #endregion

        #region Xóa loại công
        public static bool deleteLoaiCong(string maloai) {
            string query = @"
                DELETE FROM DMloaicong 
                WHERE maloai = @maloai";
                
            List<SqlParameter> parameters = new List<SqlParameter>() {
                new SqlParameter("@maloai", SqlDbType.NVarChar) { Value = maloai }
            };

            return KetNoi.executeNonQuery(query, parameters.ToArray());
        }

        public static bool kiemTraXoa(string maloai) {
            string query = @"
                SELECT COUNT(*) 
                FROM BangCong 
                WHERE maloaicong = @maloai";
                
            List<SqlParameter> parameters = new List<SqlParameter>() {
                new SqlParameter("@maloai", SqlDbType.NVarChar) { Value = maloai }
            };

            return KetNoi.executeNonQuery(query, parameters.ToArray());
        }
        #endregion

        #region Cập nhật loại công
        public static bool updateLoaiCong(LoaiCong loaiCong, string maloaiCu) {
            string query = @"
                UPDATE DMloaicong 
                SET maloai = @maloai, 
                    tenloai = @tenloai, 
                    heso = @heso 
                WHERE maloai = @maloaiCu";
                
            SqlParameter[] parameters = {
                new SqlParameter("@maloai", loaiCong.Maloai),
                new SqlParameter("@tenloai", loaiCong.Tenloai),
                new SqlParameter("@heso", loaiCong.Heso),
                new SqlParameter("@maloaiCu", maloaiCu)
            };

            return KetNoi.executeNonQuery(query, parameters);
        }
        #endregion

        #region Lấy tên loại công từ mã
        public static string layTenTuMa(string maloai) {
            string query = @"
                SELECT tenloai 
                FROM DMloaicong 
                WHERE maloai = @maloai";
                
            SqlParameter[] parameters = { new SqlParameter("@maloai", maloai) };
            DataTable dt = KetNoi.executeQuery(query, parameters);

            return dt.Rows.Count > 0 ? dt.Rows[0]["tenloai"].ToString() : "";
        }
        #endregion
    }
}