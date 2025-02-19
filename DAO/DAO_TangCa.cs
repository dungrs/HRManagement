using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using DA;
using DTO;

namespace DAO {
    public class DAO_TangCa {
        // Bảng loại ca
        #region Lấy danh sách loại ca
            public static List<LoaiCa> getDanhSachLoaiCa() {
                List<LoaiCa> danhSachLoaiCa = new List<LoaiCa>();
                string query = @"SELECT * FROM LoaiCa";
                DataTable dt = KetNoi.executeQuery(query);

                foreach(DataRow row in dt.Rows) {
                    LoaiCa loaiCa = new LoaiCa(
                        row["maloai"].ToString(),
                        row["tenca"].ToString(),
                        float.Parse(row["heso"].ToString())
                    );

                    danhSachLoaiCa.Add(loaiCa);
                }
                return danhSachLoaiCa;
            }
        #endregion

        #region Cập nhật tiền tăng ca
            public static bool updateTienLoaiCa(string maloai, float heso) {
                string query = @"UPDATE LoaiCa SET heso = @hs WHERE maloai = @ml";
                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter("@hs", SqlDbType.NVarChar) { Value = heso },
                    new SqlParameter("@ml", SqlDbType.NVarChar) { Value = maloai },
                };

                return KetNoi.executeNonQuery(query, parameters.ToArray());
            }
        #endregion
    }
}
