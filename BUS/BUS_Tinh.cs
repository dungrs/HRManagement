using DAO;
using DTO;

using System.Collections.Generic;

namespace BUS {
    public class BUS_Tinh {
        public static List<Tinh> selectTinh() {
            return DAO_Tinh.getDanhSachTinh();
        }

        public static bool kiemTraMaTinhKhiThem(string mabp) {
            return DAO_Tinh.kiemTraMaTinhKhiThem(mabp);
        }

        public static bool kiemTraMaTinhKhiSua(string maCu, string maMoi) {
            return DAO_Tinh.kiemTraMaTinhKhiSua(maCu, maMoi);
        }

        public static bool insertTinh(string maTinh, string tenTinh) {
            return DAO_Tinh.insertTinh(maTinh, tenTinh);
        }

        public static bool updateTinh(string maCu, string maMoi, string tenMoi) {
            return DAO_Tinh.updateTinh(maCu, maMoi, tenMoi);
        }
        
        public static bool deleteTinh(string maTinh) {
            return DAO_Tinh.deleteTinh(maTinh);
        }
    }
}
