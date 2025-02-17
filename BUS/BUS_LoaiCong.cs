using System;
using System.Collections.Generic;
using DAO;
using DTO;

namespace BUS {
    public class BUS_LoaiCong {

        // Lấy danh sách loại công
        public static List<LoaiCong> getDanhSachLoaiCong() {
            return DAO_LoaiCong.getDanhSachLoaiCong();
        }

        // Kiểm tra xem có trùng tên hay không
        public static bool kiemTraTrungTen(string tenloai) {
            return DAO_LoaiCong.kiemTraTrungTen(tenloai);
        }

        // Kiểm tra xem có trùng mã hay không trước khi thêm
        public static bool kiemTraTrungMaKhiThem(string maloaicong) {
            return DAO_LoaiCong.kiemTraTrungMaKhiThem(maloaicong);
        }

        // Thêm mới loại công
        public static bool insertLoaiCong(LoaiCong loaiCong) {
            return DAO_LoaiCong.insertLoaiCong(loaiCong);
        }

        // Kiểm tra xem có trùng mã hay không trước khi sửa
        public static bool kiemTraTrungMaKhiSua(string maCu, string maMoi) {
            return DAO_LoaiCong.kiemTraTrungMaKhiSua(maCu, maMoi);
        }

        // Cập nhật loại công
        public static bool updateLoaiCong(LoaiCong loaiCong, string maloaicu) {
            return DAO_LoaiCong.updateLoaiCong(loaiCong, maloaicu);
        }

        // Xóa loại công
        public static bool deleteLoaiCong(string maloaicong) {
            return DAO_LoaiCong.deleteLoaiCong(maloaicong);
        }

        public static string layTenTuMa(string maloaicong) {
            return DAO_LoaiCong.layTenTuMa(maloaicong);
        }
    }
}
