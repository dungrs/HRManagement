using System.Collections.Generic;
using DTO;
using DAO;
using System.Data;

namespace BUS {
    public class BUS_PhuCap {
        // DANH MỤC PHỤ CẤP

        // Lấy danh sách phụ cấp
        public static List<PhuCap> getDanhSachPhuCap() {
            return DAO_PhuCap.getDanhSachPhuCap();
        }

        // Kiểm tra xem có trùng tên hay không
        public static bool kiemTraTrungTen(string tenphucap) {
            return DAO_PhuCap.kiemTraTrungTen(tenphucap);
        }

        // Kiểm tra xem có trùng mã hay không trước khi thêm
        public static bool kiemTraTrungMaKhiThem(string maloaipc) {
            return DAO_PhuCap.kiemTraTrungMaKhiThem(maloaipc);
        }

        // Thêm mới phụ cấp
        public static bool insertPhuCap(PhuCap phuCap) {
            return DAO_PhuCap.insertPhuCap(phuCap);
        }

        // Kiểm tra xem có trùng mã hay không trước khi sửa
        public static bool kiemTraTrungMaKhiSua(string maCu, string maMoi) {
            return DAO_PhuCap.kiemTraTrungMaKhiSua(maCu, maMoi);
        }

        // Cập nhật phụ cấp
        public static bool updatePhuCap(PhuCap phuCap, string maloaicu) {
            return DAO_PhuCap.updatePhuCap(phuCap, maloaicu);
        }

        // Xóa phụ cấp
        public static bool deletePhuCap(string maloaipc) {
            return DAO_PhuCap.deletePhuCap(maloaipc);
        }
        
        public static DataTable layTenTuMa(string maloaipc) {
            return DAO_PhuCap.layTenTuMa(maloaipc);
        }

        // CHI TIẾT PHỤ CẤP
    }
}
