using System.Collections.Generic;

using DAO;
using DTO;

namespace BUS {
    public class BUS_KhauTru {
        // Lấy danh sách khấu trừ
        public static List<KhauTru> getDanhSachKhauTru() {
            return DAO_KhauTru.getDanhSachKhauTru();
        }

        // Cập nhật số tiền khấu trừ
        public static bool updateTienKhauTru(string makhautru, float tien) {
            return DAO_KhauTru.updateTienKhauTru(makhautru, tien);
        }
    }
}
