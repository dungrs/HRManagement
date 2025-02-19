using System.Collections.Generic;

using DAO;
using DTO;

namespace BUS {
    public class BUS_TangCa {
        // Lấy danh sách loại ca
        public static List<LoaiCa> getDanhSachLoaiCa() {
            return DAO_TangCa.getDanhSachLoaiCa();
        }

        // Cập nhật hệ số tiền
        public static bool updateTienLoaiCa(string maloai, float heso) {
            return DAO_TangCa.updateTienLoaiCa(maloai, heso);
        }
    }
}
