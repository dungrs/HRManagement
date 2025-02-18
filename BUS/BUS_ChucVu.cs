using System.Collections.Generic;

using DTO;
using DAO;

namespace BUS {
    public class BUS_ChucVu {
        // Lấy danh sách chức vụ
        public static List<ChucVu> getDanhSachChucVu() {
            return DAO_ChucVu.getDanhSachChucVu();
        }
        
        // Kiểm tra trùng mã trước khi thêm
        public static bool kiemTraTrungMaKhiThem(string machucvu) {
            return DAO_ChucVu.kiemTraTrungMaKhiThem(machucvu);
        }

        // Kiểm tra trùng mã trước khi sửa
        public static bool kiemTraTrungMaKhiSua(string maCu, string maMoi) {
            return DAO_ChucVu.kiemTraTrungMaKhiSua(maCu, maMoi);
        }

        // Kiểm tra trùng mã trước khi xóa
        public static bool kiemTraTrungMaKhiXoa(string machucvu) {
            return DAO_ChucVu.kiemTraTrungMaKhiXoa(machucvu);
        }

        // Thêm chức vụ
        public static bool insertChucVu(ChucVu chucVu) {
            return DAO_ChucVu.insertChucVu(chucVu);
        }

        // Cập nhật chức vụ
        public static bool updateChucVu(ChucVu chucVu, string machucvu) {
            return DAO_ChucVu.updateChucVu(chucVu, machucvu);
        }

        // Xóa chức vụ
        public static bool deleteChucVu(string machucvu) {
            return DAO_ChucVu.deleteChucVu(machucvu);
        }
    }
}