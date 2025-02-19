using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using DA;
using DTO;

namespace DAO {
    public class DAO_KhauTru {
        #region Lấy danh sách khấu trừ
            public static List<KhauTru> getDanhSachKhauTru() {
                List<KhauTru> danhSachKhauTru = new List<KhauTru>();
                string query = @"SELECT * FROM Khautru";
                DataTable dt = KetNoi.executeQuery(query);

                foreach(DataRow row in dt.Rows) {
                    KhauTru khauTru = new KhauTru(
                        row["makt"].ToString(),
                        row["tenkt"].ToString(),
                        Convert.ToSingle(row["tien"])
                    );

                    danhSachKhauTru.Add(khauTru);
                }

                return danhSachKhauTru;
            }
        #endregion

        #region Cập nhật tiền khấu trừ 
            public static bool updateTienKhauTru(string makhautru, float tien) {
                string query = @"
                    UPDATE Khautru SET tien = @tien
                    WHERE makt = @makhautru";

                List<SqlParameter> parameters = new List<SqlParameter>() {
                    new SqlParameter("@tien", SqlDbType.Real) { Value = tien },
                    new SqlParameter("@makhautru", SqlDbType.NVarChar) { Value = makhautru },
                };

                return KetNoi.executeNonQuery(query, parameters.ToArray());
            }
        #endregion
    }
}
