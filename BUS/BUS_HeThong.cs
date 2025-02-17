using System.Data;
using DAO;

namespace BUS
{
    public class BUS_HeThong
    {
        public static DataTable dangNhap(string name, string matKhau) {
            return DAO_HeThong.dangNhap(name, matKhau);
        }

        public static DataTable selectTaiKhoan() {
            return DAO_HeThong.selectTaiKhoan();
        }

        public static bool insertTaiKhoan(string hoTen, string ten, string matKhau, int quyen) {
            return DAO_HeThong.insertTaiKhoan(hoTen, ten, matKhau, quyen);
        }

        public static bool updateTaiKhoan(string hoten, string tenCu, string tenMoi, string matKhau, int quyen) {
            return DAO_HeThong.updateTaiKhoan(hoten, tenCu, tenMoi, matKhau, quyen);
        }

        public static bool deleteTaiKhoan(string ten) {
            return DAO_HeThong.deleteTaiKhoan(ten);
        }
    }
}