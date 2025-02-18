using System.Collections.Generic;

using DAO;
using DTO;

namespace BUS {
    public class BUS_BoPhan {
        // Lấy danh sách bộ phận
        public static List<BoPhan> getDanhSachBoPhan() {
            return DAO_BoPhan.getDanhSachBoPhan();
        }

        // Kiểm tra trùng mã trước khi thêm
        public static bool kiemTraTrungMaKhiThem(string mabophan) {
            return DAO_BoPhan.kiemTraTrungMaKhiThem(mabophan);
        }

        // Kiểm tra trùng mã trước khi sửa
        public static bool kiemTraTrungMaKhiSua(string maCu, string maMoi) {
            return DAO_BoPhan.kiemTraTrungMaKhiSua(maCu, maMoi);
        }

        // Kiểm tra trùng mã trước khi xóa
        public static bool kiemTraTrungMaKhiXoa(string mabophan) {
            return DAO_BoPhan.kiemTraTrungMaKhiXoa(mabophan);
        }

        // Thêm bộ phận
        public static bool insertBoPhan(BoPhan boPhan) {
            return DAO_BoPhan.insertBoPhan(boPhan);
        }

        // Cập nhật bộ phận
        public static bool updateBoPhan(BoPhan boPhan, string maCu) {
            return DAO_BoPhan.updateBoPhan(boPhan, maCu);
        }

        // Xóa bộ phận
        public static bool deleteBoPhan(string mabophan) {
            return DAO_BoPhan.deleteBoPhan(mabophan);
        }

    }
}
